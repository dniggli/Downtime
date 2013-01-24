using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Threading;
using downtime;
using System.Collections;
using Microsoft.VisualBasic;
using CodeBase2;
using FunctionalCSharp;

namespace downtimeC
{
    public partial class MainMenu : BaseForm
    {
        readonly Dictionary<string, Func<string>> interactions = new Dictionary<string, Func<string>>();
        readonly Dictionary<string, string> queries = new Dictionary<string, string>();

  
        public MainMenu(DateTime StartupTime): base(StartupTime)
        {
            InitializeComponent();
            //setup buttons handlers
            new FormStart(ButtonOrderEntry, () => new OrderEntryForm(StartupTime));
            new FormStart(ButtonSmsArchiveTracking, () => new TrackSmsForm(StartupTime));
            new FormStart(ButtonAutolabReprint, () => new AutolabAliquotForm());
            new FormStart(ButtonAliquotReprint, () => new AliquotForm());
            new FormStart(ButtonPlaceAddon, () => new Addons());
            new FormStart(ButtonHemArchiveTracking, () => new TrackHemForm(StartupTime));
            new FormStart(ButtonUrineHemTracking, () => new TrackUrineHemForm(StartupTime));
            new FormStart(ButtonUrineChemTracking, () => new TrackUrineChemForm(StartupTime));
            new FormStart(ButtonCoagArchiveTracking, () => new TrackCoagForm(StartupTime));
            new FormStart(ButtonDowntimeRecovery, () => new RecoveryForm());
            new FormStart(ButtonDIEntry, () => new DIOrderEntryForm());
            new FormStart(ButtonMolisEntry, () => new MolisEntry());
            

            queries.Add("STAT Query", "SELECT Table1.ordernumber, Table1.COLLECTIONTIME, Table1.RECEIVETIME, Table1.LOCATION, Table1.PRIORITY, Table1.LASTNAME, Table1.BLUETEST, Table1.REDTEST, Table1.LAVHEMTEST, Table1.GREENTEST, Table1.OTHERTEST, Table1.LAVCHEMTEST, Table1.GRYTEST, Table1.URINEHEM, Table1.URINECHEM, Table1.BLOODGAS, Table1.TECHID, Table1.CALLS FROM dtdb1.Table1 GROUP BY Table1.COLLECTIONTIME, Table1.RECEIVETIME, Table1.LOCATION, Table1.PRIORITY, Table1.LASTNAME, Table1.BLUETEST, Table1.REDTEST, Table1.LAVHEMTEST, Table1.GREENTEST, Table1.LAVCHEMTEST, Table1.GRYTEST, Table1.URINEHEM, Table1.URINECHEM, Table1.BLOODGAS, Table1.TECHID, Table1.CALLS HAVING(((Table1.PRIORITY) Like \"S\")) ORDER BY Table1.ordernumber;");

            interactions.Add("Last Name Query", () => Interaction.InputBox("LastName", "EnterLastName"));
            queries.Add("Last Name Query", "SELECT Table1.ordernumber, Table1.COLLECTIONTIME, Table1.LOCATION, Table1.PRIORITY, Table1.FIRSTNAME, Table1.LASTNAME, Table1.CALLS, Table1.REDTEST, Table1.LAVCHEMTEST, Table1.BLUETEST, Table1.LAVHEMTEST, Table1.GREENTEST, Table1.GRYTEST, Table1.URINEHEM, Table1.URINECHEM, Table1.BLOODGAS, Table1.TECHID, Table1.ORDERCOMMENT FROM(Table1) WHERE Table1.LASTNAME='{0}' ORDER BY ID;");

            interactions.Add("Tracking Query", () => Interaction.InputBox("ordernumber", "enterordernumber"));
            queries.Add("Tracking Query", "SELECT dttracking.ordernumber, dttracking.TRACKING, dttracking.TRACKINGCOMMENT, dttracking.tracklocation, dttracking.TIMESTAMP, dttracking.tracktechid FROM (dttracking) where dttracking.ordernumber = '{0}';");
            queries.Add("Tracking Query*", "SELECT * FROM dtdb1.dttracking where tracklocation = 'OT->STOR';");

            interactions.Add("Med Req Query", () => Interaction.InputBox("Med Req Number (Must Enter All 12 Digits - ############)", "EnterMedReqNumber"));
            queries.Add("Med Req Query", "SELECT Table1.ordernumber, Table1.COLLECTIONTIME, Table1.LOCATION, Table1.PRIORITY, Table1.MRN, Table1.FIRSTNAME, Table1.LASTNAME,Table1.CALLS, Table1.REDTEST, Table1.LAVCHEMTEST, Table1.BLUETEST, Table1.LAVHEMTEST, Table1.GREENTEST, Table1.GRYTEST, Table1.URINEHEM, Table1.URINECHEM, Table1.BLOODGAS, Table1.OTHERTEST, Table1.TECHID, Table1.ORDERCOMMENT FROM dtdb1.Table1 where Table1.MRN = '{0}';");

            queries.Add("Coag Query", "SELECT Table1.ordernumber, Table1.COLLECTIONTIME, Table1.LOCATION, Table1.PRIORITY, Table1.FIRSTNAME, Table1.LASTNAME, Table1.CALLS, Table1.BLUETEST, Table1.OTHERTEST, Table1.ORDERCOMMENT FROM dtdb1.Table1 where BLUETEST <> '' ;");

            queries.Add("Chemistry Query", "SELECT Table1.ordernumber, Table1.COLLECTIONTIME, Table1.LOCATION, Table1.PRIORITY, Table1.FIRSTNAME, Table1.LASTNAME, Table1.CALLS, Table1.REDTEST, Table1.LAVCHEMTEST, Table1.GREENTEST, Table1.GRYTEST, Table1.OTHERTEST, Table1.TECHID, Table1.ORDERCOMMENT FROM dtdb1.Table1 where REDTEST <> '' or LAVCHEMTEST <> '' OR GREENTEST <> '' or GRYTEST <> '' ;");

            queries.Add("Bloodgas Query", "SELECT T.ordernumber, T.COLLECTIONTIME, T.LOCATION, T.PRIORITY, T.FIRSTNAME, T.LASTNAME, T.CALLS, T.BLOODGAS, T.OTHERTEST, T.TECHID, T.ORDERCOMMENT FROM dtdb1.Table1 T where BLOODGAS <> '';");

            queries.Add("Hematology Query", "SELECT T.ordernumber, T.COLLECTIONTIME, T.LOCATION, T.PRIORITY, T.FIRSTNAME, T.LASTNAME, T.CALLS, T.LAVHEMTEST, T.OTHERTEST, T.TECHID, T.ORDERCOMMENT FROM dtdb1.Table1 T where LAVHEMTEST <> '';");

            queries.Add("Urinalisys Query", "SELECT T.ordernumber, T.COLLECTIONTIME, T.LOCATION, T.PRIORITY, T.FIRSTNAME, T.LASTNAME, T.CALLS, T.URINEHEM, T.FLUIDTEST, T.CSFTEST, T.OTHERTEST, T.TECHID FROM dtdb1.Table1 T where URINEHEM <> '' OR FLUIDTEST <> '' OR CSFTEST <> '';");

        }


   

        private void ComboBoxSelectQuery_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
           

            //if there is an interaction, do the interaction
           var readiedQuery = interactions.get(this.ComboBoxSelectQuery.Text).map(interaction => interaction()).Match()
               //use the interaction as an argument to the query, do some special processing for 'Tracking Query'
                .Some<string>(arg => string.Format(
                    (this.ComboBoxSelectQuery.Text == "Tracking Query" && arg == "*")
                      ?
                        queries["Tracking Query*"]
                      : 
                        queries[this.ComboBoxSelectQuery.Text]
                    , arg)
                )
                //if there was no argument just use the query
                .None<string>(() => queries[this.ComboBoxSelectQuery.Text])
                //return the readiedQuery
                .Return<string>();

           runqueryForm(readiedQuery, this.ComboBoxSelectQuery.Text);

 
        }


        public void runqueryForm(string q, string Queryname)
        {
            Hashtable args = new Hashtable();
            args.Add("Query", q);
            args.Add("QueryName", Queryname);

            ParameterizedThreadStart param = new ParameterizedThreadStart(StatOrderQueryForm.ThreadStart);
            new Thread(param).Start(args);
        }





        private void ButtonRestartOrderNumber_Click(System.Object sender, System.EventArgs e)
        {
          Interaction.MsgBox("Must enter user name 'URMCLAB' with NO password!", MsgBoxStyle.OkOnly, "Reminder");

            LoginForm2 Login = new LoginForm2();
            Login.ShowDialog();

            if (Login.Valid)
            {
                 new RestartWheel().ShowDialog();
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
