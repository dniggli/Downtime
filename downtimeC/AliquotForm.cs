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
namespace downtimeC
{
    public partial class AliquotForm : OrderBaseForm
    {
        //downtimeC.LabelPrintMode.Aliquot
        protected AliquotForm()
        {
            InitializeComponent();
        }


        public AliquotForm(SetupTableData setupTableData, GetSqlServer getSqlServer, Hospital hospital)
            : base(setupTableData, getSqlServer, hospital)
        {
            InitializeComponent();

        }

        private void aliquotform_Load(System.Object sender, System.EventArgs e)
        {
            this.DisableAll<TextBox>();
            this.DisableAll<ComboBox>(this.ComboboxPrinter);
        }
    
        public bool orderExists()
        {
            Option<DataRow> order = orderLookup(this.ordernumber.Text, getSqlServer);

            if (order.isDefined)
            {
                readDowntimeTable(order.get);
            }
            else
            {
                Interaction.MsgBox("Order Does Not exist.", MsgBoxStyle.OkOnly, "MsgBox");
            }

            return order.isDefined;

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
            var immutableOrderData = cloneFormOrderData(this.ordernumber.Text);
            if (this.ComboboxPrintType.Text == "Print Demographic Labels")
            {
                printDemographicLabelsOnly(immutableOrderData, this.ComboboxPrinter.Text, setupTableData);
            }
            else
            {
                printLabels(immutableOrderData, this.ComboboxPrinter.Text, setupTableData, orderedTests, TestPrintMode());
            }
          
            this.ClearAllInputControls(ComboboxPrinter, ComboBoxRecentOrder, ComboboxPrintType);
            testTable.Clear();
            ordernumber.Focus();
        }

        protected override LabelPrintMode TestPrintMode()
        {
            return LabelPrintMode.Aliquot;
        }

        private void ordernumber_KeyDown(object sender, KeyEventArgs e)
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
                        ButtonPrint.PerformClick();
                        ordernumber.Focus();
                    }
                }
                e.SuppressKeyPress = true;
            }
        }
    }
}
