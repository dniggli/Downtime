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






        public static object date2ordernumber(DateTime dates)
        {
            string ordend = dates.ToString();

            System.Text.RegularExpressions.Match dateend = Regex.Match(ordend, "([0-9]+)/([0-9]+)/([0-9]+)");
            string endmonth = dateend.Groups[1].Value;
            string endday = dateend.Groups[2].Value;
            string endyear = dateend.Groups[3].Value;
            while (endday.Length < 2)
            {
                endday = "0" + endday;
            }



            int endmnth = int.Parse(endyear) + -2004;
            endmnth = endmnth * 12;


            string monthend = Convert.ToString(Convert.ToInt32(endmonth) + Convert.ToInt32(endmnth));

            if (int.Parse(monthend) > 99)
            {
                int newmonthstart = int.Parse(Strings.Left(monthend, 2));
                string newmonthend = Strings.Right(monthend, 1);
                newmonthstart = newmonthstart + 55;
                monthend = Strings.Chr(newmonthstart) + newmonthend;
            }

            return monthend + endday;

        }

        /// <summary>
        /// printLabels, insert the order to the database and then sendHL7
        /// </summary>
        /// <param name="orderData"></param>
        protected void printInsertAndSendHL7(ImmutableOrderData orderData)
        {
            printLabels(orderData, this.ComboboxPrinter.Text,setupTableData,orderedTests,TestPrintMode());
            orderData.updateOrder(getSqlServer); //update data about the order in the DB



            //send the HL7
            foreach (DataRow row in orderedTests.Where(dr => dr.getOptionString("DiTranslation").isDefined))
            {
                var specType = new SpecimenType { extension = row["Extension"].ToString(), diSpecimenType = row["DiTranslation"].ToString() };

                var indiCodes = groupTestToIndividualTest.getIndividualTests(row["Id"].ToString());
                sendHL7(groupTestToIndividualTest, orderData.mrn, orderData.firstName,
                    orderData.lastName, orderData.orderNumber, orderData.ward,
                    indiCodes, specType);
            }
        }
        protected override void OnPrintClick()
        {
            this.ComboBoxoldorder.SelectedIndexChanged -= ComboBoxoldorder_SelectedIndexChanged;
            this.ordernumber.Enabled = false;
            TextboxCollectDate.Text = DateTime.Now.ToString();

            //get orderNumber from TextBox or create a new one
            var orderNum = this.ordernumber.TextOption.getOrElse(() => getNewOrderNumber(getSqlServer));
            printInsertAndSendHL7(cloneOrderData(orderNum));           

            this.DisableAll<TextBox>();
            this.DisableAll<ComboBox>();

            ComboboxPrinter.Enabled = true;
            ComboBoxoldorder.Enabled = true;
            TextBoxbillingnumber.Enabled = true;

            ButtonEditorder.Enabled = true;
            Buttoneditprevious.Enabled = true;

            ComboBoxoldorder.Items.Add(orderNum + "   " + lastname.Text + "," + firstname.Text);
            ComboBoxoldorder.SelectedIndex = ComboBoxoldorder.Items.Count - 1;

            this.ClearAllInputControls(this.ComboboxPrinter, this.TextBoxTechId, ComboBoxoldorder);
            testTable.Clear();
            this.TextBoxbillingnumber.Focus();
            this.ComboBoxoldorder.SelectedIndexChanged += ComboBoxoldorder_SelectedIndexChanged;
        }
        public static void sendHL7(GroupTestToIndividualTest groupTestToIndividualTest, string mrn, string firstName, string lastName, string ordernumber, string ward, IEnumerable<string> codes, SpecimenType specimenType)
        {
            //set the IP and port to send to
            var sendhl = new SendHl7("172.18.140.209", 10013);

            //create the HL7 message
            var co = new OrderMessage(mrn, firstName, lastName, ordernumber, "", ward, Sex.U, codes, specimenType);
            var hl = co.toHl7(groupTestToIndividualTest);

            if (DialogResult.Yes == MessageBox.Show("Send Order Message to DI?", "Send Order Message to DI?", MessageBoxButtons.YesNo))
            {

                //send the hl7 message
                var status = sendhl.SendHL7(hl);
                if ((status == HL7Status.NOCONNECTION))
                {
                    MessageBox.Show("HL7 connection failed");
                }
                else if ((status == HL7Status.NACK))
                {
                    //  MessageBox.Show("HL7 connection Successful, but NACK returned")
                }
                else if ((status == HL7Status.EXCEPTION))
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
            if (ComboBoxoldorder.Text.Length > 8)
            {
                ordernumber.Text = Strings.Left(ComboBoxoldorder.Text, 8);
                ButtonEditorder.Enabled = false;
                ordernumber.Enabled = false;
            }
        }

        private void ComboBoxoldorder_SelectedIndexChanged(System.Object sender, System.EventArgs e)
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

        /// <summary>
        /// If the Date changes, wipe out the table of orderNumbers and restart ordering
        /// </summary>
        /// <remarks></remarks>

        public static void TruncateOrderNumbersOnDateChange(GetSqlServer getSqlServer)
        {
            if (DateTime.Now.Day != GlobalMutableState.StartupDate.Day)
            {
                var dtable = getSqlServer.FilledTable("select * FROM ordernumber");

                if (dtable.Rows.Count != 1)
                {
                    getSqlServer.ExecuteNonQuery("truncate TABLE ordernumber");
                    getSqlServer.ExecuteNonQuery("insert into ordernumber (OrderLast,Ordernumber) VALUES (1, 7500);");
                }
                GlobalMutableState.StartupDate = System.DateTime.Now;
            }

        }

        /// <summary>
        /// use the DB to generate a new orderNumber
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public static string getNewOrderNumber(GetSqlServer getSqlServer)
        {
            TruncateOrderNumbersOnDateChange(getSqlServer);

            DataRow q = getSqlServer.FilledRowOption("insert into ordernumber (OrderLast,Ordernumber) select TOP 1 OrderLast+1, ordernumber+1 FROM ordernumber ORDER BY OrderLast DESC; select TOP 1 OrderLast, Ordernumber FROM ordernumber ORDER BY OrderLast DESC;").get;

            string neworernumber = q["Ordernumber"].ToString();

            if (neworernumber.Length > 4)
            {
                string letters = Strings.Left(neworernumber, 2);
                string ordernums = Strings.Right(neworernumber, 3);
                neworernumber = Strings.Chr(int.Parse(letters)) + ordernums;
            }

            return date2ordernumber(System.DateTime.Now) + neworernumber.PadLeft(4,'0');
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
            this.DisableAll<ComboBox>(this.ComboboxPrinter,this.ComboBoxoldorder);
            this.ButtonEditorder.Enabled = true;
            this.TextBoxbillingnumber.Enabled = true;
        }
    }
}

