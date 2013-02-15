using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using System.Collections;
using Microsoft.VisualBasic;
using CodeBase2;
using FunctionalCSharp;
using HL7;

namespace downtimeC
{
    public partial class MainMenu : Form
    {
        readonly Dictionary<string, Func<string>> interactions = new Dictionary<string, Func<string>>();
        readonly Dictionary<string, string> queries = new Dictionary<string, string>();

        //mysql database connection
        readonly GetSqlServer getSqlServer = new GetSqlServer();
        readonly Hospital hospital;
        public MainMenu(Hospital hospital): base()
        {
            InitializeComponent();
            this.hospital = hospital;
            var setupTableData = new SetupTableData(getSqlServer, hospital);
            
            //setup buttons handlers
            new FormStart(ButtonOrderEntry, () => new OrderEntryForm2(setupTableData, getSqlServer, hospital));
            new FormStart(ButtonSmsArchiveTracking, () => new TrackSmsForm(getSqlServer));
            new FormStart(ButtonAliquotReprint, () => new AliquotForm(setupTableData,getSqlServer,hospital));
            new FormStart(ButtonPlaceAddon, () => new AddOnForm(setupTableData, getSqlServer, hospital));
            new FormStart(ButtonHemArchiveTracking, () => new TrackHemForm(getSqlServer));
            new FormStart(ButtonUrineHemTracking, () => new TrackUrineHemForm(getSqlServer));
            new FormStart(ButtonUrineChemTracking, () => new TrackUrineChemForm(getSqlServer));
            new FormStart(ButtonCoagArchiveTracking, () => new TrackCoagForm(getSqlServer));
            new FormStart(ButtonDowntimeRecovery, () => new RecoveryForm(getSqlServer));
            new FormStart(ButtonMolisEntry, () => new MolisEntry(getSqlServer));
            

            queries.Add("STAT Query", "SELECT order.ordernumber, order.COLLECTIONTIME, order.RECEIVETIME, order.LOCATION, order.PRIORITY, order.LASTNAME, order.BLUETEST, order.REDTEST, order.LAVHEMTEST, order.GREENTEST, order.OTHERTEST, order.LAVCHEMTEST, order.GRYTEST, order.URINEHEM, order.URINECHEM, order.BLOODGAS, order.TECHID, order.CALLS FROM [ordered] GROUP BY order.COLLECTIONTIME, order.RECEIVETIME, order.LOCATION, order.PRIORITY, order.LASTNAME, order.BLUETEST, order.REDTEST, order.LAVHEMTEST, order.GREENTEST, order.LAVCHEMTEST, order.GRYTEST, order.URINEHEM, order.URINECHEM, order.BLOODGAS, order.TECHID, order.CALLS HAVING(((order.PRIORITY) Like \"S\")) ORDER BY order.ordernumber;");

            interactions.Add("Last Name Query", () => Interaction.InputBox("LastName", "EnterLastName"));
            queries.Add("Last Name Query", "SELECT order.ordernumber, order.COLLECTIONTIME, order.LOCATION, order.PRIORITY, order.FIRSTNAME, order.LASTNAME, order.CALLS, order.REDTEST, order.LAVCHEMTEST, order.BLUETEST, order.LAVHEMTEST, order.GREENTEST, order.GRYTEST, order.URINEHEM, order.URINECHEM, order.BLOODGAS, order.TECHID, order.ORDERCOMMENT FROM(Table1) WHERE order.LASTNAME='{0}' ORDER BY ID;");

            interactions.Add("Tracking Query", () => Interaction.InputBox("ordernumber", "enterordernumber"));
            queries.Add("Tracking Query", "SELECT dttracking.ordernumber, dttracking.TRACKING, dttracking.TRACKINGCOMMENT, dttracking.tracklocation, dttracking.TIMESTAMP, dttracking.tracktechid FROM (dttracking) where dttracking.ordernumber = '{0}';");
            queries.Add("Tracking Query*", "SELECT * FROM dttracking where tracklocation = 'OT->STOR';");

            interactions.Add("Med Req Query", () => Interaction.InputBox("Med Req Number (Must Enter All 12 Digits - ############)", "EnterMedReqNumber"));
            queries.Add("Med Req Query", "SELECT order.ordernumber, order.COLLECTIONTIME, order.LOCATION, order.PRIORITY, order.MRN, order.FIRSTNAME, order.LASTNAME,order.CALLS, order.REDTEST, order.LAVCHEMTEST, order.BLUETEST, order.LAVHEMTEST, order.GREENTEST, order.GRYTEST, order.URINEHEM, order.URINECHEM, order.BLOODGAS, order.OTHERTEST, order.TECHID, order.ORDERCOMMENT FROM Table1 where order.MRN = '{0}';");

            queries.Add("Coag Query", "SELECT order.ordernumber, order.COLLECTIONTIME, order.LOCATION, order.PRIORITY, order.FIRSTNAME, order.LASTNAME, order.CALLS, order.BLUETEST, order.OTHERTEST, order.ORDERCOMMENT FROM Table1 where BLUETEST <> '' ;");

            queries.Add("Chemistry Query", "SELECT order.ordernumber, order.COLLECTIONTIME, order.LOCATION, order.PRIORITY, order.FIRSTNAME, order.LASTNAME, order.CALLS, order.REDTEST, order.LAVCHEMTEST, order.GREENTEST, order.GRYTEST, order.OTHERTEST, order.TECHID, order.ORDERCOMMENT FROM Table1 where REDTEST <> '' or LAVCHEMTEST <> '' OR GREENTEST <> '' or GRYTEST <> '' ;");

            queries.Add("Bloodgas Query", "SELECT T.ordernumber, T.COLLECTIONTIME, T.LOCATION, T.PRIORITY, T.FIRSTNAME, T.LASTNAME, T.CALLS, T.BLOODGAS, T.OTHERTEST, T.TECHID, T.ORDERCOMMENT FROM Table1 T where BLOODGAS <> '';");

            queries.Add("Hematology Query", "SELECT T.ordernumber, T.COLLECTIONTIME, T.LOCATION, T.PRIORITY, T.FIRSTNAME, T.LASTNAME, T.CALLS, T.LAVHEMTEST, T.OTHERTEST, T.TECHID, T.ORDERCOMMENT FROM Table1 T where LAVHEMTEST <> '';");

            queries.Add("Urinalisys Query", "SELECT T.ordernumber, T.COLLECTIONTIME, T.LOCATION, T.PRIORITY, T.FIRSTNAME, T.LASTNAME, T.CALLS, T.URINEHEM, T.FLUIDTEST, T.CSFTEST, T.OTHERTEST, T.TECHID FROM Table1 T where URINEHEM <> '' OR FLUIDTEST <> '' OR CSFTEST <> '';");

        }


   

        private void ComboBoxSelectQuery_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
           

            //if there is an interaction, do the interaction
           var readiedQuery = interactions.get(this.ComboBoxSelectQuery.Text).map(interaction => interaction()).Match()
               //use the interaction as an argument to the query, do some special processing for 'Tracking Query'
                .Some<string>(arg => 
                    string.Format((this.ComboBoxSelectQuery.Text == "Tracking Query" && arg == "*")
                      ? queries["Tracking Query*"] : queries[this.ComboBoxSelectQuery.Text]
                    , arg)
                )
                //if there was no argument just use the query
                .None<string>(() => queries[this.ComboBoxSelectQuery.Text])
                //return the readiedQuery
                .Return<string>();

            var queryForm =  new StatOrderQueryForm(readiedQuery, this.ComboBoxSelectQuery.Text, getSqlServer);
            queryForm.Show();
        }


        private void ButtonRestartOrderNumber_Click(System.Object sender, System.EventArgs e)
        {
          Interaction.MsgBox("Must enter user name 'URMCLAB' with NO password!", MsgBoxStyle.OkOnly, "Reminder");

          StartupLoginForm Login = new StartupLoginForm();
            Login.ShowDialog();

            if (Login.valid)
            {
                 new RestartWheel(getSqlServer).ShowDialog();
            }
        }


   
    }

    /// <summary>
    /// Attaches a Button to a Form running in a separate thread
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class FormStart
    {
        readonly Func<Form> newOp;
        public FormStart(Button button, Func<Form> newOp)
        {
            this.newOp = newOp;
            button.Click += new EventHandler(startForm);
        }

        /// <summary>
        /// Actually starts/restarts the thread and associated form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void startForm(System.Object sender, System.EventArgs e)
        {
            Form form = newOp();
            form.Show();
        }
    }

}
