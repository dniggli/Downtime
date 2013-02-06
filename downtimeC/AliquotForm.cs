using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using FunctionalCSharp;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using HL7;
using downtimeC;
using downtimeC.LabelPrinting;
namespace downtimeC
{
    public partial class AliquotForm : OrderBaseForm
    {
        protected AliquotForm()
        {
            InitializeComponent();
        }

        readonly GetMySQL getMySql;
        readonly SetupTableData setupTableData;
        public AliquotForm(GetMySQL getMySql, SetupTableData setupTableData) : base(setupTableData,getMySql)
        {
            InitializeComponent();
            this.setupTableData = setupTableData;
            this.getMySql = getMySql;
        }

        private void aliquotform_Load(System.Object sender, System.EventArgs e)
        {
            this.DisableAll<TextBox>();
            this.DisableAll<ComboBox>(this.ComboboxPrinter);
        }
    
        public void printDowntimeLables(Priority priority)
        {                
            //get all tubeTypeTextboxes in this form
            var tubeTypeTextboxes = this.Controls.Cast<Control>().Where(x => x is TubeTypeTextBox).Cast<TubeTypeTextBox>();
            var labelData = new LabelData(this.ordernumber.Text, this.comboBoxWard.Text, this.mrn.Text, this.lastname.Text, this.firstname.Text, this.comboBoxWard.Text,
    this.DateTimePicker1.Text);
       

            tubeTypeTextboxes.forEach(tb => tb.LabelAppend(labelData,priority));


            labelData.doPrint(ComboboxPrinter.Text, setupTableData);

        }



        //public void writeDowntimeTable()
        //{

        //    string ranletter = RandomLetter.get;


        //    string receivetime1 = receivetime.Text + ":00";

        //    string query = "insert into dtdb1.Table1 (ordernumber,COLLECTIONTIME,RECEIVETIME,LOCATION,PRIORITY,MRN,DOB,FIRSTNAME,REDTEST,BLUETEST,LAVHEMTEST,GREENTEST,LAVCHEMTEST,GRYTEST,URINEHEM,URINECHEM,BLOODGAS,PROBLEM,CALLS,ORDERCOMMENT,LASTNAME,SENDOUT,SEROLOGY,HEPPETITAS,COLLECTDATE,TECHID,CSFTEST,FLUIDTEST,VIRALLOADTEST) VALUES ('"
        //        + ordernumber.Text + "', '" + collectiontime.Text + "','" + receivetime1 + "','" + comboBoxWard.Text + "', '" + comboBoxWard.Text + "', '" + mrn.Text + "','" + DOB.Text + "','" + firstname.Text + "', '" +
        //        redtest.Text + "', '" + bluetest.Text + "', '" + lavhemtest.Text + "','" + greentest.Text + "', '" + lavchemtest.Text + "', '" + graytest.Text + "','" + urinehem.Text +
        //        "','" + urinechem.Text + "','" + bloodgas.Text + "', '" + problem.Text + "','" + cal1.Text + "','" +
        //        comment.Text + "','" + lastname.Text + "','" + sendout.Text + "','" + ser.Text + "', '" + hepp.Text + "','" + colldate.Text + "','" + ordertechid.Text + "','" + csfbox.Text + "','" + fluidbox.Text + "','" + Viralloadbox.Text + "')";

        //    //execute the insert asynchronously, don't perform an action after the insert completes.
        //    getMySql.Async(this).ExecuteNonQuery(query, () => { });
        //}



        private void ordernumber_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {



            if (e.KeyCode == Keys.Enter)
            {
                if (ComboboxPrinter.Text == string.Empty)
                {
                   var response = Interaction.MsgBox("INVALID PRINTER", MsgBoxStyle.DefaultButton1, "MsgBox");
                    if (response == MsgBoxResult.Ok)
                    {
                        ComboboxPrinter.Focus();
                        return;
                    }

                }
                else
                {
                    if (orderExists())
                    {
                        checkPrinterAndPrintTheDemographicLabels();
                    }
                }
            }
        }

        public bool orderExists()
        {
            Option<DataRow> order = orderLookup(this.ordernumber.Text);

            if (order.isDefined)
            {
                readDowntimeTable(order.get);
            }
            else
            {
                Interaction.MsgBox("Order Does Not exist .", MsgBoxStyle.OkOnly, "MsgBox");
            }



            return order.isDefined;

        }

       

        private void checkPrinterAndPrintTheDemographicLabels()
        {
            if (validateAndPromptPrinter()) {
                if (orderExists())
                {
                        printdemographiclabels();
                }
                else
                {
                    return;
                }
            }

            this.ClearAllTextBoxes();
            ordernumber.Focus();
        }

            /// <summary>
            /// prints demographic labels or routines
            /// </summary>
                public void printdemographiclabels()
                {
                    if (!(this.firstname.Text == string.Empty))
                    {
                        var labelData = new LabelData(this.ordernumber.Text, this.comboBoxWard.Text, this.mrn.Text, this.lastname.Text, this.firstname.Text, this.comboBoxWard.Text,
        this.DateTimePicker1.Text);

                        collectiontime.LabelAppend(labelData, Priority.Routine);
                        collectiontime.LabelAppend(labelData, Priority.Routine);
                        labelData.doPrint(ComboboxPrinter.Text, setupTableData);
                    }

                }

     
     
        private void ComboBoxprinter_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            this.ComboboxPrintType.Enabled = true;            
        }

        private void ComboboxPrintType_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            this.EnableAll<TextBox>();
            this.EnableAll<ComboBox>();
            this.ordernumber.Focus();
        }

        protected override void OnPrintClick() {

            if (validateAndPromptForComboboxWard())
            {
                printLabels();
            }
        }
    }
}
