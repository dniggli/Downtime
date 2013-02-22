using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Collections;
using System.Diagnostics;

using System.Text.RegularExpressions;
using System.IO;
using HL7;
using FunctionalCSharp;
using Microsoft.VisualBasic.CompilerServices;
using System.Data.SqlClient;
using CodeBase2;
namespace downtimeC
{
    public partial class OrderEntryForm2 : OrderBaseForm
    {
        //downtimeC.LabelPrintMode.Collection;
        protected OrderEntryForm2()
        {
            InitializeComponent();
        }

        readonly GroupTestToIndividualTest groupTestToIndividualTest;
        public OrderEntryForm2(SetupTableData setupTableData, GetSqlServer getSqlServer, Hospital hospital)
            : base(setupTableData, getSqlServer, hospital)
        {
            Load += orderentry_Load;
            InitializeComponent();
            groupTestToIndividualTest = new GroupTestToIndividualTest(getSqlServer);
        }

        private void orderentry_Load(System.Object sender, System.EventArgs e)
        {
            this.DisableAll<TextBox>();
            this.DisableAll<ComboBox>();

            TextBoxbillingnumber.Enabled = true;
        }

        //http://www.vbmysql.com/articles/vbnet-mysql-tutorial/the-vbnet-mysql-tutorial-part-4

        public static bool NotAn_X_Mrn(string mrn)
        {

            return !Operators.LikeString(mrn, "X*", CompareMethod.Text);

        }

        /// <summary>
        /// printLabels, insert the order to the database and then sendHL7
        /// </summary>
        /// <param name="orderData"></param>
        protected void printInsertAndSendHL7(ImmutableOrderData orderData)
        {
            printLabels(orderData, this.ComboboxPrinter.Text, setupTableData, orderedTests, TestPrintMode());

            var testsToSend = orderData.getDiTests().tests;


            var dict = testsToSend.GroupBy(x =>
                //group test DataRows by the SpecimenType
                new SpecimenType { extension = x.Key["Extension"].ToString(), diSpecimenType = x.Key["DiTranslation"].ToString() })
                .ToDictionary(gdc => gdc.Key,
                //convert to a Dictionary<SpecimenType,List<String>> where List<string> is the list of testIDs
                //, but those testIDs are all IndividualTests and not group Tests
                gdc => groupTestToIndividualTest.getUniqueUnsentIndividualTests(
                    //pass list of (string TestId,bool Sent) to getUniqueUnsentIndividualTests
                    gdc.Select(q => new Tuple2<string,bool>(q.Key["Id"].ToString(), q.Value ))
                    )
                );

            //send the HL7
            sendHL7(orderData.mrn, orderData.firstName,
              orderData.lastName, orderData.orderNumber, orderData.ward,
              dict);
            

            orderData.setTestsAsSentInDb(testsToSend.Select(dr=>dr.Key["Id"].ToString())).InsertOrder(getSqlServer); //update data about the order in the DB
          

        }
        protected override void OnPrintClick()
        {
            this.ComboBoxRecentOrder.SelectedIndexChanged -= ComboBoxRecentOrder_SelectedIndexChanged;
            this.ordernumber.Enabled = false;
            TextboxCollectDate.Text = DateTime.Now.Date.ToString();

            //get orderNumber from TextBox or create a new one
            var orderNum = this.ordernumber.TextOption.getOrElse(() => RestartWheel.getNewOrderNumber(getSqlServer));
            printInsertAndSendHL7(cloneFormOrderData(orderNum));           

            this.DisableAll<TextBox>();
            this.DisableAll<ComboBox>();

            ComboboxPrinter.Enabled = true;
            ComboBoxRecentOrder.Enabled = true;
            TextBoxbillingnumber.Enabled = true;

            ButtonEditorder.Enabled = true;
            Buttoneditprevious.Enabled = true;

            //remove old copies of this order from the RecentOrderList
            ComboBoxRecentOrder.Items.Cast<string>()
                .Where(s => s.Contains(orderNum)).ToList().forEach(ComboBoxRecentOrder.Items.Remove);

            //add this order
            ComboBoxRecentOrder.Items.Add(orderNum + "   " + lastname.Text + "," + firstname.Text);
            ComboBoxRecentOrder.SelectedIndex = ComboBoxRecentOrder.Items.Count - 1;

            this.ClearAllInputControls(this.ComboboxPrinter, this.TextBoxTechId, ComboBoxRecentOrder);
            testTable.Clear();
            this.TextBoxbillingnumber.Focus();
            this.ComboBoxRecentOrder.SelectedIndexChanged += ComboBoxRecentOrder_SelectedIndexChanged;
        }
        public static void sendHL7(string mrn, string firstName, string lastName, string ordernumber, string ward, Dictionary<SpecimenType, IEnumerable<string>> testCodeUniqueIndividual)
        {
            //set the IP and port to send to
            var sendhl = new SendHl7("172.18.140.209", 10013);

            //create the HL7 message
            var co = new OrderMessage(mrn, firstName, lastName, ordernumber, "", ward, Sex.U, testCodeUniqueIndividual);

            var hl7Messages = co.toHl7();

            if (DialogResult.Yes == MessageBox.Show("Send Order Message to DI?", "Send Order Message to DI?", MessageBoxButtons.YesNo))
            {

              //  send the hl7 messages
                var status = sendhl.SendHL7Multiple(hl7Messages);

                if (status == HL7Status.NOCONNECTION)
                {
                    MessageBox.Show("HL7 connection failed");
                }
                else if ( status == HL7Status.NACK)
                {
                    //  MessageBox.Show("HL7 connection Successful, but NACK returned")
                }
                 else if ( status == HL7Status.EXCEPTION)
                {
                    MessageBox.Show("HL7 connection tried, but exception thrown");
                }
            }

        }

        public void FINDDEMOGRAPHIC()
        {
            if (!TextBoxbillingnumber.Validate()) return;

            var t = getSqlServer.FilledTable("select TOP 1 * FROM [ordered] where billingnumber like '" + this.TextBoxbillingnumber.Text + "' ORDER BY ID DESC");


            try
            {
                DataRow r = t.Rows[0];

                MsgBoxResult response = Interaction.MsgBox("ADD VISIT TO " + Constants.vbNewLine + " " + Constants.vbNewLine + " " + r["lastname"].ToString() + ", " + r["firstname"].ToString() + "  " + Constants.vbNewLine + " MRN: " + r["mrn"].ToString() + "", MsgBoxStyle.YesNo, "MsgBox");

                if (response == MsgBoxResult.Yes)
                {
                    firstname.Text = r["firstname"].ToString();
                    lastname.Text = r["lastname"].ToString();
                    mrn.Text = r["mrn"].ToString();
                    comboBoxWard.Text = r["ward"].ToString();
                    DOB.Text = r["dob"].ToString();

                    this.EnableAll<TextBox>(ordernumber);
                    this.EnableAll<ComboBox>();

                    ComboBoxPriority.Focus();

                    return;
                } else {
                    var response1 = Interaction.MsgBox("WOULD YOU LIKE TO ADD A NEW PATIENT?", MsgBoxStyle.YesNo, "MsgBox");
                    if (response1 == MsgBoxResult.Yes)
                    {
                        this.EnableAll<TextBox>(ordernumber);
                        this.EnableAll<ComboBox>();

                        lastname.Focus();
                    }
                    else
                    {
                        TextBoxbillingnumber.Focus();
                    }
                }
            }
            catch
            {
                this.EnableAll<TextBox>(ordernumber);
                this.EnableAll<ComboBox>();
                lastname.Focus();
            }
        }




        private void ordernumber_TextChanged(System.Object sender, System.EventArgs e)
        {
            if (ordernumber.Text.Length == 8)
            {
                ordernumber.Enabled = false;
                TextBoxTechId.Text = GlobalMutableState.userName;

                Option<DataRow> order = orderLookup(this.ordernumber.Text, getSqlServer);

                if (order.isDefined)
                {
                    MsgBoxResult response = Interaction.MsgBox("Order already exists. Do you wish to edit?", MsgBoxStyle.YesNo, "MsgBox");
                    if (response == MsgBoxResult.Yes)
                    {
                        readDowntimeTable(order.get);

                    }
                    else
                    {
                        ordernumber.Clear();
                        return;
                    }
                }
                else
                {
                    // Display message.
                    Interaction.MsgBox("Order Does Not exist.", MsgBoxStyle.OkOnly, "MsgBox");

                    ordernumber.Clear();
                    ButtonEditorder.Enabled = true;
                    Buttoneditprevious.Enabled = true;
                }
                this.EnableAll<TextBox>(ordernumber);
                this.EnableAll<ComboBox>();
            }

        }

        private void editorder_Click(System.Object sender, System.EventArgs e)
        {
            Buttoneditprevious.Enabled = false;
            ordernumber.Enabled = true;
            DebugButtonRead.Enabled = true;
            ButtonEditorder.Enabled = false;
            ordernumber.Focus();

        }

        private void editOldOrder()
        {
            if (ComboBoxRecentOrder.Text.Length > 8)
            {
                ordernumber.Text = ComboBoxRecentOrder.Text.Substring(0, 8);
                ButtonEditorder.Enabled = false;
                ordernumber.Enabled = false;
            }
        }

        private void ComboBoxRecentOrder_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            editOldOrder();
        }

        protected override bool ProcessTabKey(bool forward)
        {
             return (TextBoxbillingnumber.Focused) ? false : base.ProcessTabKey(forward);
        }

        private void TextBoxbillingnumber_KeyPress(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                FINDDEMOGRAPHIC();
            }
        }

       




        private void orderNumberTextBox_Leave(object sender, EventArgs e)
        {
            this.ordernumber.Enabled = false;
            this.ButtonEditorder.Enabled = true;
        }

        private void Buttoneditprevious_Click(object sender, EventArgs e)
        {
            editOldOrder();
        }

        private void ButtonReset_Click(object sender, EventArgs e)
        {
            this.ClearAllInputControls();
            this.DisableAll<TextBox>();
            this.DisableAll<ComboBox>(this.ComboboxPrinter,this.ComboBoxRecentOrder);
            this.ButtonEditorder.Enabled = true;
            this.TextBoxbillingnumber.Enabled = true;
            testTable.Clear();
        }
    }
}

