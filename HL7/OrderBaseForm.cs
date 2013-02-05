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
namespace HL7
{
    public partial class OrderBaseForm : BaseForm
    {
        protected OrderBaseForm()
        {
            InitializeComponent();
        }
        readonly SetupTableData setupTableData;
        public OrderBaseForm(SetupTableData setupTableData, GetMySQL getMySQL)
            : base()
        {
            InitializeComponent();
            this.setupTableData = setupTableData;
        #if DEBUG
            this.ButtonFill.Visible = true;
            this.buttonRead.Visible = true;
        #endif

            ComboBoxprinter.Items.AddRange(setupTableData.LabelersByIp.Keys.ToArray());
            comboBoxWard.Items.AddRange(setupTableData.wards);


            ComboBoxprinter.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            ComboBoxprinter.AutoCompleteSource = AutoCompleteSource.ListItems;
            comboBoxWard.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            comboBoxWard.AutoCompleteSource = AutoCompleteSource.ListItems;

        }



        private void OrderBaseForm_Load(object sender, EventArgs e)
        {
      

        }

        private void buttonRead_Click(object sender, EventArgs e)
        {

        }

        //prints demographic labels
        //public void printdemographiclabels(LabelData labelData)
        //{
        //    if (!(this.firstname.Text == string.Empty))
        //    {
        //        collectiontime.LabelAppend(labelData, ComboBoxPriority.getPriority);
        //        collectiontime.LabelAppend(labelData, ComboBoxPriority.getPriority);
        //    }

        //}
      
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


        /// <summary>
        /// Print collection, comment, and (collection or aliquot) labels
        /// </summary>
        protected void printLabels()
        {
            //PrintDowntimeLabels
            var labelData = new LabelData(this.ordernumber.Text, this.ComboBoxPriority.Text, this.mrn.Text, this.lastname.Text, this.firstname.Text, this.comboBoxWard.Text,
    this.DateTimePicker1.Text);

         
            collectiontime.LabelAppend(labelData, ComboBoxPriority.getPriority);
            comment.LabelAppend(labelData, ComboBoxPriority.getPriority);
            getTestLabelTextBoxes.forEach(tb => tb.LabelAppend(labelData, ComboBoxPriority.getPriority));
            
         

          //  labelData.doPrint(ComboBoxprinter.Text, setupTableData);

          
        }

    }
}
