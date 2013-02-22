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

using HL7;
using downtimeC;
using System.Data.SqlClient;
namespace downtimeC
{
    public partial class AddOnForm : OrderBaseForm
    {
         //downtimeC.LabelPrintMode.Collection

        protected AddOnForm()
        {
            InitializeComponent();
        }


        public AddOnForm(SetupTableData setupTableData, GetSqlServer getSqlServer, Hospital hospital)
            : base(setupTableData, getSqlServer,hospital)
        {
            InitializeComponent();
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

        /// <summary>
        /// update the order with the ordered tests and patient info
        /// </summary>
        public void updateOrder()
        {
            getSqlServer.Async(this).ExecuteNonQuery(() => { }, 
                "update order set collectiontime = '" + collectiontime.Text + "', BILLINGNUMBER = '"
                + TextBoxbillingnumber.Text + "', receivetime = '" + receivetime.Text + ":00" + "',ward = '" + comboBoxWard.Text + "',priority = '" + comboBoxWard.Text +
                "',mrn = '" + mrn.Text + "',dob = '" + DOB.Text + "',FIRSTNAME = '" + firstname.Text +
                "',PROBLEM = '" + problem.Text + "',CALLS = '" + cal1.Text + "',ORDERCOMMENT = '" + comment.Text +
                "',LASTNAME = '" + lastname.Text + "',COLLECTDATE = '" + DateTimePicker1.Text + "' WHERE ordernumber = '" + ordernumber.Text + "'");
        }

        private void ordernumber_TextChanged(System.Object sender, System.EventArgs e)
        {
            if (ordernumber.Text.Length == 8)
            {
                readDowntimeTable(orderLookup(this.ordernumber.Text, getSqlServer).get);
            }
        }

   

         protected override void OnPrintClick() 
        {
            var immutableOrderData = cloneOrderData(this.ordernumber.Text);
            printLabels(immutableOrderData, this.ComboboxPrinter.Text, setupTableData, orderedTests, TestPrintMode());
                updateOrder();
        }

    }
}
