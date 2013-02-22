using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using downtimeC;
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
        protected readonly DataTable testTable;
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
            readDowntimeTable(orderLookup(this.ordernumber.Text,getSqlServer).get);
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

            if (this.testTable.Rows.Count == 0)
            {
                MessageBox.Show("You must have a Test before you can create an order.");
                this.textBoxAddTest.Focus();
                return false;
            }

            return true;   
        }


         

        private void DebugButtonFill_Click(System.Object sender, System.EventArgs e)
        {
                    //ordernumber.Text = RandomString.get(8);
                    mrn.Text = RandomString.numeric(12);
                    ComboboxPrinter.SelectedIndex = 0;
                    ComboBoxPriority.SelectedIndex = 1;
                    DOB.Text = "08/28/2003";
                    comboBoxWard.SelectedIndex = 1;
                    DOB.Text = "10/10/10";
                    cal1.Text = "585-987-7848";
                    collectiontime.Text = "20:50";
                    receivetime.Text = "20:55";
                    firstname.Text = RandomString.get(8);
                    lastname.Text = RandomString.get(8);
                    addTestToGrid("CMP");
                    addTestToGrid("BMP");
                    addTestToGrid("TROP");

        }

        protected static void printDemographicLabelsOnly(ImmutableOrderData immutableOrderData, string printer,
            SetupTableData setupTableData)
        {

            Func<LabelData,LabelData> configureLabels = labelData =>
            {  //print collection label
                labelData.LabelAppendDemographic(immutableOrderData.collectionTime, "", "");
                labelData.LabelAppendDemographic(immutableOrderData.collectionTime, "", "");
                return labelData;
            };

            _printLabels(immutableOrderData, printer, setupTableData, configureLabels);
          
        }

           /// <summary>
        /// Print collection, comment, and (collection or aliquot) labels
        /// </summary>
        private static void _printLabels(ImmutableOrderData immutableOrderData, string printer,
            SetupTableData setupTableData, Func<LabelData,LabelData> configureLabels) {
            
            //PrintDowntimeLabels
            var labelData = new LabelData(immutableOrderData.orderNumber, immutableOrderData.priority,
                immutableOrderData.mrn, immutableOrderData.lastName, immutableOrderData.firstName, immutableOrderData.ward);

         //   configureLabels(labelData).doPrint(printer, setupTableData);
        }

        /// <summary>
        /// Print collection, comment, and (collection or aliquot) labels
        /// </summary>
        protected static void printLabels(ImmutableOrderData immutableOrderData, string printer, 
            SetupTableData setupTableData, IEnumerable<DataRow> orderedTests, LabelPrintMode testPrintMode)
        {
               Func<LabelData, LabelData> configureLabels = labelData =>
               {  //print collection label
                   //print collection label
                   labelData.LabelAppendDemographic(immutableOrderData.collectionTime, "", "");
                   labelData.LabelAppendDemographic(immutableOrderData.collectionTime, "", "");
                   //print comment label
                   labelData.LabelAppendComment(immutableOrderData.comment, "CMT", "");

                   orderedTests.forEach(dr =>
                        labelData.AppendTestLabel(immutableOrderData.getPriority,
                        testPrintMode, dr["Id"].ToString(),
                        dr["Tube"].ToString(), dr["Extension"].ToString()));

                   return labelData;
               };

               _printLabels(immutableOrderData, printer, setupTableData, configureLabels);
        }

        protected virtual LabelPrintMode TestPrintMode() {
            return LabelPrintMode.Collection;
        }

        public void readDowntimeTable(DataRow order)
        {

            this.Controls.Cast<Control>().Where(c => c is IStoredControl).Cast<IStoredControl>().forEach(storedControl =>
                storedControl.setValue(order[storedControl.DataColumnName].ToString())
            );
            getSqlServer.FilledColumn(string.Format("SELECT [test] FROM [downtime].[dbo].[testOnOrder] WHERE [ordernumberId] = {0}", order["ID"]))
                .forEach(addTestToGrid);
            
            Application.DoEvents();
            //Display the changes immediately (redraw the label text)
            System.Threading.Thread.Sleep(500);
            //do it slow enough so we can actually read the text before it changes, pause half a second
        }

        public static Option<DataRow> orderLookup(string orderNumber, GetSqlServer getSqlServer)
        {
            return getSqlServer.FilledRowOption("select TOP 1 * FROM [ordered] where ordernumber like '" + orderNumber + "' ORDER BY ID DESC");
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

        private void addTextBoxAddTestToGrid()
        {
            if (!textBoxAddTest.Validate()) return;
            buttonAddTest.Enabled = false;
            textBoxAddTest.TextOption.forEach(addTestToGrid);
            
            textBoxAddTest.Clear();
            buttonAddTest.Enabled = true;
        }

        private void addTestToGrid(string test)
        {
            if (getOrderedTest(test).isDefined)
                {
                    MessageBox.Show("Test already ordered.");
                    return;
                }
               
                var orderableAt = (hospital == Hospital.Strong) ? "SmhOrderable" : "HhOrderable";

                var rowOption = getSqlServer.FilledRowOption(string.Format("SELECT [Id], [Name], [Tube], [Location], [Extension], [DiTranslation] FROM [dbo].[TestsWithSpecimenExtension] where Id = @ID AND {0} = 1", orderableAt),
                     new SqlParameter("@ID", test));

                if (rowOption.isDefined)
                {
                    testTable.ImportRow(rowOption.get);
                }
                else
                {
                    MessageBox.Show("Test lookup failed, test ID not found in database");
                }
                

        }

        private void buttonAddTest_Click(object sender, EventArgs e)
        {

            addTextBoxAddTestToGrid();
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
                addTextBoxAddTestToGrid();
            }
        }

        /// <summary>
        /// Capture all of the current Order Data
        /// </summary>
        /// <returns></returns>
        public ImmutableOrderData cloneFormOrderData(string orderNum)
        {
            Func<string, bool> queryTestSent = test => getSqlServer
                .asBoolOption(string.Format("SELECT [hl7Sent] FROM [downtime].[dbo].[ordersWithTests] where ordernumber = '{0}' and test = '{1}'", orderNum, test))
                .getOrElse(() => false);
            
            var testsToOrder = new Dictionary<DataRow, bool>();
            this.orderedTests.forEach(x => testsToOrder.Add(x, queryTestSent.Invoke(x["Id"].ToString())));

            return new ImmutableOrderData(orderNum, collectiontime.Text, receivetime.Text,
                 comboBoxWard.Text, ComboBoxPriority.Text, mrn.Text, DOB.Text,
                 firstname.Text, problem.Text, cal1.Text, comment.Text,
                 lastname.Text, TextBoxTechId.Text, TextBoxbillingnumber.Text,this.TextboxCollectDate.Text,
                 testsToOrder.ToReadOnly());
        }

        private void testGridSelectionChange(object sender, EventArgs e)
        {
            this.textBoxAddTest.Text = this.testTable.Rows[this.dataGridTests.SelectedRows[0].Index]["Id"].ToString();
        }
    }
}
