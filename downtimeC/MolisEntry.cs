using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System.Collections;
using System.Diagnostics;
using CodeBase2.AutoItX;
using System.Threading;
using System.Text.RegularExpressions;

using HL7;

namespace downtimeC
{
    public partial class MolisEntry : Form
    {
     protected MolisEntry()
        {
            InitializeComponent();
        }

     readonly GetSqlServer getSqlServer;
        public MolisEntry(GetSqlServer getSqlServer)
        {
            InitializeComponent();
            this.getSqlServer = getSqlServer;
        }

    static MolisEntry myOrder;
    public static void MolisEnter()
    {

        if (AutoIt.WinExists("Molis")) {
            myOrder = new MolisEntry();
            Application.Run(myOrder);

        } else {
    
           var response = Interaction.MsgBox("You must be logged into Molis",  MsgBoxStyle.DefaultButton1, "MsgBox");
            if (response == MsgBoxResult.Ok) {
                return;
            }
        }

        if (myOrder != null) {
            myOrder.TextBoxOrderNumber.Focus();
            myOrder.TextBoxOrderNumber.Clear();
        }

    }


    public void RetriveDTData()
    {
        string ordernumbers = Strings.Left(TextBoxOrderNumber.Text, 8);

        DataTable t = getSqlServer.FilledTable("select TOP 1 * FROM [ordered] where ordernumber like '" + ordernumbers + "' ORDER BY ID DESC");

        try {
            DataRow r = t.Rows[0];

            string ordernumber = r["ordernumber"].ToString();
            string firstname = r["firstname"].ToString();
            string lastname = r["lastname"].ToString();
            string mrn = r["mrn"].ToString();
            string collectiontime = r["collectiontime"].ToString();
            string receivetime = r["receivetime"].ToString();
            string priority = r["priority"].ToString();
            string ComboBoxWard = r["ward"].ToString();
            string bluetest = r["bluetest"].ToString();
            string redtest = r["redtest"].ToString();
            string greentest = r["greentest"].ToString();
            string urinechem = r["urinechem"].ToString();
            string urinehem = r["urinehem"].ToString();
            string graytest = r["grytest"].ToString();
            string comment = r["ordercomment"].ToString();
            string problem = r["problem"].ToString();
            string lavchemtest = r["lavchemtest"].ToString();
            string lavhemtest = r["lavhemtest"].ToString();
            string bloodgas = r["bloodgas"].ToString();
            string DOB = r["dob"].ToString();
            string cal1 = r["calls"].ToString();
            string sendout = r["SENDOUT"].ToString();
            string hepp = r["heppetitas"].ToString();
            string ser = r["serology"].ToString();
            string colldate = r["collectdate"].ToString();
            string csfbox = r["CSFTEST"].ToString();
            string fluidbox = r["FLUIDTEST"].ToString();
            string Viralloadbox = r["VIRALLOADTEST"].ToString();
            string OTHERBOX = r["OTHERTEST"].ToString();
            string BILLING = r["BILLINGNUMBER"].ToString();

            string redlength = redtest.Length.ToString();

            Match dates = Regex.Match(DOB, "([0-9]+)/([0-9]+)/([0-9]+)");
            string days = dates.Groups[0].Value;
            string month = dates.Groups[1].Value;
            string year = dates.Groups[2].Value;
            while (days.ToString().Length < 2) {
                days = "0" + days;
            }
            while (month.ToString().Length < 2) {
                month = "0" + month;
            }


            string fullname = lastname + "," + firstname;

            string lavtest = Strings.Right(TextBoxOrderNumber.Text, 2);

            Dictionary<string, string[]> d = new Dictionary<string, string[]>();


            if (lavtest == "18") {
                string lavordernumber = ordernumber + "18";

                AutoIt.WinActivate("Molis", "MWMSBE 30");
                //AutoIt.ControlClick("Molis", "", "[CLASS:UniCanvas; INSTANCE:1]", "", 1, 163, 57)

                AutoIt.Sleep(200);
                AutoIt.ControlSend("Molis", "", "[CLASS:UniCanvas; INSTANCE:1]", lavordernumber, 0);

                AutoIt.Send("{TAB}");
                if (priority == "S")
                    AutoIt.Send("{SPACE}");

                AutoIt.Sleep(200);
                AutoIt.Send("{TAB}");
                AutoIt.ControlSend("Molis", "", "[CLASS:UniCanvas; INSTANCE:1]", fullname, 0);

                AutoIt.Sleep(200);
                AutoIt.Send("{TAB}");
                AutoIt.ControlSend("Molis", "", "[CLASS:UniCanvas; INSTANCE:1]", mrn, 0);

                AutoIt.Sleep(200);
                AutoIt.Send("{TAB}");
                AutoIt.ControlSend("Molis", "", "[CLASS:UniCanvas; INSTANCE:1]", DOB, 0);

                AutoIt.Sleep(200);
                AutoIt.Send("{TAB}");
                AutoIt.Send("{TAB}");
                AutoIt.Send("{TAB}");
                AutoIt.Send("{TAB}");
                AutoIt.Send("{TAB}");
                AutoIt.ControlSend("Molis", "", "[CLASS:UniCanvas; INSTANCE:1]", ComboBoxWard, 0);


                AutoIt.Sleep(200);
                AutoIt.Send("{TAB}");
                AutoIt.Send("{DELETE}");
                AutoIt.Send("{DELETE}");
                AutoIt.Send("{DELETE}");
                AutoIt.Send("{DELETE}");
                AutoIt.Send("{DELETE}");
                AutoIt.Send("{DELETE}");
                AutoIt.Send("{DELETE}");
                AutoIt.Send("{DELETE}");
                AutoIt.Send("{DELETE}");
                AutoIt.Send("{DELETE}");
                AutoIt.ControlSend("Molis", "", "[CLASS:UniCanvas; INSTANCE:1]", colldate, 0);




                AutoIt.Sleep(200);
                AutoIt.Send("{TAB}");
                AutoIt.ControlSend("Molis", "", "[CLASS:UniCanvas; INSTANCE:1]", collectiontime, 0);


                AutoIt.Sleep(200);
                AutoIt.Send("{TAB}");
                AutoIt.Send("{TAB}");
                AutoIt.Send("{DELETE}");
                AutoIt.Send("{DELETE}");
                AutoIt.Send("{DELETE}");
                AutoIt.Send("{DELETE}");
                AutoIt.Send("{DELETE}");
                AutoIt.ControlSend("Molis", "", "[CLASS:UniCanvas; INSTANCE:1]", receivetime, 0);

                AutoIt.Sleep(200);
                //AutoIt.Send("{TAB}")

                string[] e = lavhemtest.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);
         
                foreach (string iInE in e) {
                    string test = iInE;
                    if (iInE == "SPLT")  test = "PLT";
                    if (iInE == "SHCT")  test = "HCT";
                    if (iInE == " SPLT") test = "PLT";
                    if (iInE == " SHCT") test = "HCT";
                    if (iInE == " PLT")  test = "PLT";
                    if (iInE == " HCT")  test = "HCT";
                    if (iInE == " CBCD") test = "CBCD";
                    if (iInE == " CBC")  test = "CBC";
                    if (iInE == " RETA") test = "RET";
                    if (iInE == "RETA")  test = "RET";
                    if (iInE == " HH")   test = "HH";

                    AutoIt.Sleep(200);
                    AutoIt.ControlClick("Molis", "", "[CLASS:UniCanvas; INSTANCE:1]", "", 1, 179, 601);
                    AutoIt.Send(test);
                    AutoIt.Send("{TAB}");

                    AutoIt.Send("{DELETE}");
                    AutoIt.Send("{DELETE}");
                    AutoIt.Send("{DELETE}");
                    AutoIt.Send("{DELETE}");
                    AutoIt.Send("{DELETE}");
                    AutoIt.Send("{DELETE}");
                    AutoIt.Send("{DELETE}");
                    AutoIt.Sleep(400);

                    //'clicking on test buttons
                    //If i = "CBC" Then
                    //    AutoIt.Sleep(200)
                    //    AutoIt.ControlClick("Molis", "CBC", "[CLASS:Button; INSTANCE:3]", "Button3", 1, 59, 30)
                    //    AutoIt.Send("{SPACE}")
                    //End If


                    //If i = "CBCD" Then

                    //    AutoIt.Sleep(200)
                    //    AutoIt.ControlClick("Molis", "CBCD", "[CLASS:Button; INSTANCE:11]", "Button11", 1, 41, 32)
                    //    AutoIt.Send("{SPACE}")

                    //End If

                    //If i = "HH" Then
                    //    AutoIt.Sleep(200)
                    //    AutoIt.ControlClick("Molis", "HH", "[CLASS:Button; INSTANCE:15]", "Button15", 1, 87, 45)
                    //    AutoIt.Send("{SPACE}")
                    //End If


                    //'Mnualy entering test text
                    //If i = "HCT" Then
                    //    AutoIt.Sleep(200)
                    //    AutoIt.ControlClick("Molis", "", "[CLASS:UniCanvas; INSTANCE:1]", "", 1, 179, 601)
                    //    AutoIt.Send(i)
                    //    AutoIt.Send("{TAB}")
                    //End If

                    //If i = "PLT" Then
                    //    AutoIt.Sleep(200)
                    //    AutoIt.ControlClick("Molis", "", "[CLASS:UniCanvas; INSTANCE:1]", "", 1, 179, 601)
                    //    AutoIt.Send(i)
                    //    AutoIt.Send("{TAB}")
                    //End If
                }


            }
            AutoIt.Sleep(800);

            AutoIt.Send("{TAB}");
            AutoIt.Send("{SPACE}");

            AutoIt.Sleep(200);

            AutoIt.WinActivate("MolisEntry");
            TextBoxOrderNumber.Focus();
            TextBoxOrderNumber.Clear();


        } catch {
        }
    }

    private void ButtonRun_Click(System.Object sender, System.EventArgs e)
    {
        RetriveDTData();
    }

    private void TextBoxOrderNumber_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
        if (e.KeyChar == Strings.Chr(13)) {
            ButtonRun_Click(this, EventArgs.Empty);
        }
    }
}
    }

