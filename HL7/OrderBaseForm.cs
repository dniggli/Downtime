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
using System.Data.SqlClient;
namespace HL7
{
    public partial class OrderBaseForm : Form
    {
        protected OrderBaseForm()
        {
            InitializeComponent();
        }
        protected readonly SetupTableData setupTableData;
        
        protected readonly GetSqlServer getSqlServer;
        private readonly DataTable testTable;
        protected readonly Hospital hospital;
        public OrderBaseForm(SetupTableData setupTableData, GetSqlServer getSqlServer, Hospital hospital)
            : base()
        {
            InitializeComponent();
            this.setupTableData = setupTableData;
            this.getSqlServer = getSqlServer;
            this.hospital = hospital;
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

            //use SchemaFilledTable to load the table layout
            testTable = getSqlServer.SchemaFilledTable("SELECT TOP 1 [Id], [Name], [Tube], [Location], [Extension], [DiTranslation] FROM [dbo].[TestsWithSpecimenExtension]");
            this.dataGridTests.DataSource = testTable;
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

        //var wardValidOption = comboBoxWard.TextOption.map(text => {
          
        //   string locat1 = Strings.Left(comboBoxWard.Text, 1);

        //   if (!(locat1 == "S" || locat1 == "A"))
        //   {
        //       if (Interaction.MsgBox("Location must start with 'S' for inpatient or 'A' for outpatient", MsgBoxStyle.DefaultButton1, "MsgBox") == MsgBoxResult.Ok)
        //       {
        //           comboBoxWard.Text = "";
        //       }
        //       comboBoxWard.Focus();
        //       return false;
        //   }
        //   else
        //   {
        //       return true;
        //   }
          
        //  });

     

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
            return getSqlServer.FilledRowOption("select TOP 1 * from dtdb1.Table1 where ordernumber like '" + orderNumber + "' ORDER BY ID DESC");
        }

        private void TextBoxTechId_TextChanged(object sender, EventArgs e)
        {
            GlobalMutableState.userName = this.TextBoxTechId.Text;
        }

        /// <summary>
        /// get the list of all ordered tests
        /// </summary>
        protected IEnumerable<DataRow> orderedTests
        {
            get
            {
                return testTable.Rows.Cast<DataRow>()
                    .Where(row => row.RowState != DataRowState.Deleted);
            }
        }

        /// <summary>
        /// get a specific orderedTest
        /// </summary>
        /// <param name="test"></param>
        /// <returns></returns>
        protected Option<DataRow> getOrderedTest(string test)
        {
            return orderedTests
                .Where(row => row["Id"].ToString() == test)
                .headOption();
        }

        private void addTest()
        {
            if (!textBoxAddTest.Validate()) return;

            textBoxAddTest.TextOption.forEach(text =>
            {
                if (getOrderedTest(text).isDefined)
                {
                    MessageBox.Show("Test already ordered.");
                    return;
                }
                buttonAddTest.Enabled = false;

                var orderableAt = (hospital == Hospital.Strong) ? "SmhOrderable" : "HhOrderable";

                var rowOption = getSqlServer.FilledRowOption(string.Format("SELECT [Id], [Name], [Tube], [Location], [Extension], [DiTranslation] FROM [dbo].[TestsWithSpecimenExtension] where Id = @ID AND {0} = 1", orderableAt),
                     new SqlParameter("@ID", text));

                if (rowOption.isDefined)
                {
                    testTable.ImportRow(rowOption.get);
                }
                else
                {
                    MessageBox.Show("Test lookup failed, test ID not found in database");
                }
                buttonAddTest.Enabled = true;
            });
            textBoxAddTest.Clear();
        }

        private void buttonAddTest_Click(object sender, EventArgs e)
        {

            addTest();
        }

      

        private void buttonRemoveTest_Click(object sender, EventArgs e)
        {
            if (!textBoxAddTest.Validate()) return;

            textBoxAddTest.TextOption.forEach(test =>
            {
                getOrderedTest(test).forEach(r => r.Delete());
            });
            
        }

        private void textBoxAddTest_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addTest();
            }
        }


    }
}
