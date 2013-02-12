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
    public partial class AddOnForm : OrderBaseForm
    {
        protected AddOnForm()
        {
            InitializeComponent();
        }

        readonly GetMySQL getMySql;
        readonly SetupTableData setupTableData;
        public AddOnForm(GetMySQL getMySql, SetupTableData setupTableData)  : base(setupTableData,getMySql)
        {
            InitializeComponent();
            this.setupTableData = setupTableData;
            this.getMySql = getMySql;
        }

    //    public void printDowntimeLables(Priority priority)
    //    {
    //        //get all tubeTypeTextboxes in this form
    //        var tubeTypeTextboxes = this.Controls.Cast<Control>().Where(x => x is TubeTypeTextBox).Cast<TubeTypeTextBox>();
    //        var labelData = new LabelData(this.ordernumber.Text, this.comboBoxWard.Text, this.mrn.Text, this.lastname.Text, this.firstname.Text, this.comboBoxWard.Text,
    //this.DateTimePicker1.Text);


    //        tubeTypeTextboxes.forEach(tb => tb.LabelAppend(labelData, priority));


    //        labelData.doPrint(ComboboxPrinter.Text, setupTableData);

    //    }

        //http://www.vbmysql.com/articles/vbnet-mysql-tutorial/the-vbnet-mysql-tutorial-part-4

        public void writeDowntimeTable()
        {
            getMySql.Async(this).ExecuteNonQuery(() => {},"update dtdb1.Table1 set COLLECTIONTIME = ?CollectionTime, BILLINGNUMBER = '"
                + TextBoxbillingnumber.Text + "', RECEIVETIME = '" + receivetime.Text + ":00" + "',LOCATION = '" + comboBoxWard.Text + "',PRIORITY = '" + comboBoxWard.Text +
                "',MRN = '" + mrn.Text + "',DOB = '" + DOB.Text + "',FIRSTNAME = '" + firstname.Text + "',REDTEST = '" + redtest.Text + "',BLUETEST = '" + bluetest.Text + 
                "',LAVHEMTEST = '" + lavhemtest.Text + "',GREENTEST = '" + greentest.Text + "',LAVCHEMTEST = '" + lavchemtest.Text + "',GRYTEST = '" + graytest.Text + "',URINEHEM = '" + urinehem.Text +
                "',URINECHEM = '" + urinechem.Text + "',BLOODGAS = '" + bloodgas.Text + "',PROBLEM = '" + problem.Text + "',CALLS = '" + cal1.Text + "',ORDERCOMMENT = '" + comment.Text +
                "',LASTNAME = '" + lastname.Text + "',SENDOUT = '" + sendout.Text + "',SEROLOGY = '" + ser.Text + "' ,HEPPETITAS = '" + hepp.Text +
                "',COLLECTDATE = '" + DateTimePicker1.Text + "' ,CSFTEST = '" + csfbox.Text + "' ,FLUIDTEST = '" + fluidbox.Text + 
                "',VIRALLOADTEST = '" + Viralloadbox.Text + "' WHERE ordernumber = '" + ordernumber.Text + "'",
                new MySqlParameter("?CollectionTime",collectiontime.Text));


        }

        private void ordernumber_TextChanged(System.Object sender, System.EventArgs e)
        {
            if (ordernumber.Text.Length == 8)
            {
                readDowntimeTable(this.orderLookup(this.ordernumber.Text).get);
            }
        }

   

         protected override void OnPrintClick() 
        {
                printLabels();
                writeDowntimeTable();
        }

    }
}
