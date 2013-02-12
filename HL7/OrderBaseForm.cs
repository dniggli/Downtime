using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using downtimeC;
using downtimeC.LabelPrinting;
using FunctionalCSharp;
using Microsoft.VisualBasic;
namespace HL7
{
    public partial class OrderBaseForm : Form
    {
        protected OrderBaseForm()
        {
            InitializeComponent();
        }
        readonly SetupTableData setupTableData;
        readonly GetMySQL getMySql;
        public OrderBaseForm(SetupTableData setupTableData, GetMySQL getMySql)
            : base()
        {
            InitializeComponent();
            this.setupTableData = setupTableData;
            this.getMySql = getMySql;
        #if DEBUG
            this.DebugButtonFill.Visible = true;
            this.DebugButtonRead.Visible = true;
        #endif
            this.TextBoxTechId.Text = GlobalMutableState.userName;

            ComboboxPrinter.Items.AddRange(setupTableData.LabelersByIp.Keys.ToArray());
            comboBoxWard.Items.AddRange(setupTableData.wards);


            ComboboxPrinter.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            ComboboxPrinter.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBoxWard.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxWard.AutoCompleteSource = AutoCompleteSource.ListItems;

        }


        private void OrderBaseForm_Load(object sender, EventArgs e)
        {


        }

        /// <summary>
        /// true if printer is valid, other prompt and return false
        /// </summary>
        /// <returns></returns>
        protected bool validateAndPromptPrinter()
        {
            if (ComboboxPrinter.Text == string.Empty)
            {
                if (Interaction.MsgBox("INVALID PRINTER", MsgBoxStyle.DefaultButton1, "MsgBox") == MsgBoxResult.Ok)
                {
                    ComboboxPrinter.Focus();
                    return false;
                }

            }
            return true;
        }

        private void DebugButtonRead_click(System.Object sender, System.EventArgs e)
        {
            readDowntimeTable(this.orderLookup(this.ordernumber.Text).get);
        }

        /// <summary>
        /// overridden in subforms to handle the print button
        /// </summary>
        protected virtual void OnPrintClick() {}

        private void ComboBoxprinter_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (validateInputControls())
                {
                    OnPrintClick();
                }
            }
        }

        private void ButtonPrint_Click(object sender, System.EventArgs e)
        {
            if (validateInputControls())
            {
                OnPrintClick();
            }
        }

        /// <summary>
        /// check all required controls.  prompt the user to fill them out if they have not
        /// </summary>
        /// <returns> true if all are valid. false if one needs to be filled out</returns>
        protected bool validateInputControls()
        {
            //get all the required controls.
            var optionControls = this.Controls.Cast<Control>().Where(x => x is IOption).Cast<IOption>()
                .Where(x => x.Required);

            //run validation on each one. this will prompt the user to fill them out if they have not
            foreach (var oc in optionControls) {
                if (!oc.Validate()) return false;
            }
            return true;   
        }

        private void DebugButtonFill_Click(System.Object sender, System.EventArgs e)
        {
            //Buttonpopulate.Visible = false;
            foreach (Control C in this.Controls)
            {
                if (C is TextBox)
                {
                    TextBox TB = (TextBox)C;
                    //string running = "high";
                    string runs = "45654125";

                    string ranstring = "";
                    for (int x = 0; x <= 8; x++)
                    {
                        ranstring += RandomLetter.get;
                    }

                    TB.AppendText(ranstring);
                    ordernumber.Text = runs;
                    mrn.Text = runs;
                    ComboboxPrinter.Text = "s56";
                    DOB.Text = "08/28/2003";
                    comboBoxWard.Text = "S";
                    DOB.Text = "10";
                    cal1.Text = "585-987-7848";
                    collectiontime.Text = "20:50";
                    receivetime.Text = "20:55";
               }
            }

        }


        /// <summary>
        /// Return all TubeTypeTextBoxes that match the given LabelPrintMode
        /// </summary>
        public IEnumerable<TubeTypeTextBox> getTubeTypeTextBoxesMatching(params LabelPrintMode[] printMode)
        {           
                 return this.Controls.Cast<Control>().Where(x => x is TubeTypeTextBox).Cast<TubeTypeTextBox>().Where(x =>printMode.Contains(x.LabelPrintMode)).OrderBy(x =>x.SpecimenExtension);
            
        }

        /// <summary>
        /// Return all TubeTypeTextBoxes that match the given LabelPrintMode
        /// </summary>
        public IEnumerable<TubeTypeTextBox> getTestLabelTextBoxes
        {
            get {
            return getTubeTypeTextBoxesMatching(LabelPrintMode.Aliquot, LabelPrintMode.Collection);
        }
        }

        ///// <summary>
        ///// true if comboBoxWard is not empty, if empty prompts user to enter ward,then focuses on ward and returns false.
        ///// </summary>
        ///// <returns></returns>
        //public bool validateAndPromptForComboboxWard()
        //{
        //    if (this.comboBoxWard.Text == string.Empty)
        //    {
        //        var response = Interaction.MsgBox("No Location Entered", MsgBoxStyle.DefaultButton1, "MsgBox");
        //        if (response == MsgBoxResult.Ok)
        //            comboBoxWard.Text = "";
        //        comboBoxWard.Focus();
        //    }
        //    return this.comboBoxWard.Text != string.Empty;
        //}

        /// <summary>
        /// Print collection, comment, and (collection or aliquot) labels
        /// </summary>
        protected void printLabels()
        {
                //PrintDowntimeLabels
                var labelData = new LabelData(this.ordernumber.Text, this.ComboBoxPriority.Text, this.mrn.Text, this.lastname.Text, this.firstname.Text, this.comboBoxWard.Text,
        this.DateTimePicker1.Text);


                collectiontime.LabelAppend(labelData, ComboBoxPriority.getPriorityOption.get);
                comment.LabelAppend(labelData, ComboBoxPriority.getPriorityOption.get);
                getTestLabelTextBoxes.forEach(tb => tb.LabelAppend(labelData, ComboBoxPriority.getPriorityOption.get));


                labelData.doPrint(this.ComboboxPrinter.Text, setupTableData);
        }


        //protected bool priorityValidate()
        //{
        //    if (ComboBoxPriority.getPriorityOption.isEmpty)
        //    {
        //        MessageBox.Show("Priority needs to be set", "Priority needs to be set", MessageBoxButtons.OK);
        //        ComboBoxPriority.Focus();
        //    }
        //    return ComboBoxPriority.getPriorityOption.isDefined;
        //}

        public void readDowntimeTable(DataRow order)
        {

            this.Controls.Cast<Control>().Where(c => c is IStoredControl).Cast<IStoredControl>().forEach(storedControl =>
                storedControl.setValue(order[storedControl.DataColumnName].ToString())
            );

            Application.DoEvents();
            //Display the changes immediately (redraw the label text)
            System.Threading.Thread.Sleep(500);
            //do it slow enough so we can actually read the text before it changes, pause half a second
        }

        public Option<DataRow> orderLookup(string orderNumber)
        {
            return getMySql.FilledRowOption("select * from dtdb1.Table1 where ordernumber like '" + orderNumber + "' ORDER BY ID DESC LIMIT 1");
        }

        private void TextBoxTechId_TextChanged(object sender, EventArgs e)
        {
            GlobalMutableState.userName = this.TextBoxTechId.Text;
        }


    }
}
