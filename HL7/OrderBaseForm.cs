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

        public OrderBaseForm(DateTime StartupTime, SetupTableData setupTableData, GetMySQL getMySQL)
            : base(StartupTime)
        {
            InitializeComponent();

        #if DEBUG
            this.ButtonFill.Visible = true;
            this.buttonRead.Visible = true;
        #endif

            ComboBoxprinter.Items.Add(getMySQL.FilledColumn("select name from pathdirectory.device d join pathdirectory.device_has_group dg on d.Device_ID = dg.Device_ID where Group_ID = '41' order by name"));
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

        //prints demographic labels or routines
        public void printdemographiclabels()
        {
            if (!(this.firstname.Text == string.Empty))
            {
                var labelData = new LabelData(this.ordernumber.Text, this.priority.Text, this.mrn.Text, this.lastname.Text, this.firstname.Text, this.comboBoxWard.Text,
this.DateTimePicker1.Text);

                collectiontime.LabelAppend(labelData, Priority.Routine);
                collectiontime.LabelAppend(labelData, Priority.Routine);
                labelData.doPrint(ComboBoxprinter.Text);
            }

        }

        public IEnumerable<TubeTypeTextBox> getAllTubeTypeTextBoxes
        {
            get
            {
             return this.Controls.Cast<Control>().Where(x => x is TubeTypeTextBox).Cast<TubeTypeTextBox>();
            }
        }

        public void printDowntimeLables(Priority priority)
        {
            //get all tubeTypeTextboxes in this form
           
            var labelData = new LabelData(this.ordernumber.Text, this.priority.Text, this.mrn.Text, this.lastname.Text, this.firstname.Text, this.comboBoxWard.Text,
    this.DateTimePicker1.Text);


            getAllTubeTypeTextBoxes.forEach(tb => tb.LabelAppend(labelData, priority));


            labelData.doPrint(ComboBoxprinter.Text);

        }

        protected void writeandprint()
        {
            //writeDowntimeTable()
            if (priority.Text == "S")
            {
                this.priority.Text = "STAT";
                printDowntimeLables(Priority.Stat);
            }
            if (priority.Text == "R")
                printDowntimeLables(Priority.Routine);
            if (priority.Text == "U")
                printDowntimeLables(Priority.Stat);

            this.ClearAllTextBoxes();

            ordernumber.Focus();
        }

    }
}
