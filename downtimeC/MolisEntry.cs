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
using NUnit.Framework;
using AutoItHelper;
using System.Threading;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using HL7;

namespace downtimeC
{
    public partial class MolisEntry : Form
    {
     protected MolisEntry()
        {
            InitializeComponent();
        }

        readonly GetMySQL getMySql;
        public MolisEntry(GetMySQL getMySql)
        {
            InitializeComponent();
            this.getMySql = getMySql;
        }

    static MolisEntry myOrder;
    public static void MolisEnter()
    {

        if (AutoItX.WinExists("Molis")) {
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

        DataTable t = getMySql.FilledTable("select * from dtdb1.Table1 where ordernumber like '" + ordernumbers + "' ORDER BY ID DESC LIMIT 1");

        try {
            DataRow r = t.Rows[0];

            string ordernumber = r["ordernumber"].ToString();
            string firstname = r["firstname"].ToString();
            string lastname = r["lastname"].ToString();
            string mrn = r["mrn"].ToString();
            string collectiontime = r["collectiontime"].ToString();
            string receivetime = r["receivetime"].ToString();
            string priority = r["priority"].ToString();
            string ComboBoxWard = r["location"].ToString();
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

                AutoItX.WinActivate("Molis", "MWMSBE 30");
                //AutoItHelper.AutoItX.ControlClick("Molis", "", "[CLASS:UniCanvas; INSTANCE:1]", "", 1, 163, 57)

                AutoItHelper.AutoItX.Sleep(200);
                AutoItHelper.AutoItX.ControlSend("Molis", "", "[CLASS:UniCanvas; INSTANCE:1]", lavordernumber, 0);

                AutoItHelper.AutoItX.Send("{TAB}");
                if (priority == "S")
                    AutoItHelper.AutoItX.Send("{SPACE}");

                AutoItHelper.AutoItX.Sleep(200);
                AutoItHelper.AutoItX.Send("{TAB}");
                AutoItHelper.AutoItX.ControlSend("Molis", "", "[CLASS:UniCanvas; INSTANCE:1]", fullname, 0);

                AutoItHelper.AutoItX.Sleep(200);
                AutoItHelper.AutoItX.Send("{TAB}");
                AutoItHelper.AutoItX.ControlSend("Molis", "", "[CLASS:UniCanvas; INSTANCE:1]", mrn, 0);

                AutoItHelper.AutoItX.Sleep(200);
                AutoItHelper.AutoItX.Send("{TAB}");
                AutoItHelper.AutoItX.ControlSend("Molis", "", "[CLASS:UniCanvas; INSTANCE:1]", DOB, 0);

                AutoItHelper.AutoItX.Sleep(200);
                AutoItHelper.AutoItX.Send("{TAB}");
                AutoItHelper.AutoItX.Send("{TAB}");
                AutoItHelper.AutoItX.Send("{TAB}");
                AutoItHelper.AutoItX.Send("{TAB}");
                AutoItHelper.AutoItX.Send("{TAB}");
                AutoItHelper.AutoItX.ControlSend("Molis", "", "[CLASS:UniCanvas; INSTANCE:1]", ComboBoxWard, 0);


                AutoItHelper.AutoItX.Sleep(200);
                AutoItHelper.AutoItX.Send("{TAB}");
                AutoItHelper.AutoItX.Send("{DELETE}");
                AutoItHelper.AutoItX.Send("{DELETE}");
                AutoItHelper.AutoItX.Send("{DELETE}");
                AutoItHelper.AutoItX.Send("{DELETE}");
                AutoItHelper.AutoItX.Send("{DELETE}");
                AutoItHelper.AutoItX.Send("{DELETE}");
                AutoItHelper.AutoItX.Send("{DELETE}");
                AutoItHelper.AutoItX.Send("{DELETE}");
                AutoItHelper.AutoItX.Send("{DELETE}");
                AutoItHelper.AutoItX.Send("{DELETE}");
                AutoItHelper.AutoItX.ControlSend("Molis", "", "[CLASS:UniCanvas; INSTANCE:1]", colldate, 0);




                AutoItHelper.AutoItX.Sleep(200);
                AutoItHelper.AutoItX.Send("{TAB}");
                AutoItHelper.AutoItX.ControlSend("Molis", "", "[CLASS:UniCanvas; INSTANCE:1]", collectiontime, 0);


                AutoItHelper.AutoItX.Sleep(200);
                AutoItHelper.AutoItX.Send("{TAB}");
                AutoItHelper.AutoItX.Send("{TAB}");
                AutoItHelper.AutoItX.Send("{DELETE}");
                AutoItHelper.AutoItX.Send("{DELETE}");
                AutoItHelper.AutoItX.Send("{DELETE}");
                AutoItHelper.AutoItX.Send("{DELETE}");
                AutoItHelper.AutoItX.Send("{DELETE}");
                AutoItHelper.AutoItX.ControlSend("Molis", "", "[CLASS:UniCanvas; INSTANCE:1]", receivetime, 0);

                AutoItHelper.AutoItX.Sleep(200);
                //AutoItHelper.AutoItX.Send("{TAB}")

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

                    AutoItHelper.AutoItX.Sleep(200);
                    AutoItHelper.AutoItX.ControlClick("Molis", "", "[CLASS:UniCanvas; INSTANCE:1]", "", 1, 179, 601);
                    AutoItHelper.AutoItX.Send(test);
                    AutoItHelper.AutoItX.Send("{TAB}");

                    AutoItHelper.AutoItX.Send("{DELETE}");
                    AutoItHelper.AutoItX.Send("{DELETE}");
                    AutoItHelper.AutoItX.Send("{DELETE}");
                    AutoItHelper.AutoItX.Send("{DELETE}");
                    AutoItHelper.AutoItX.Send("{DELETE}");
                    AutoItHelper.AutoItX.Send("{DELETE}");
                    AutoItHelper.AutoItX.Send("{DELETE}");
                    AutoItHelper.AutoItX.Sleep(400);

                    //'clicking on test buttons
                    //If i = "CBC" Then
                    //    AutoItHelper.AutoItX.Sleep(200)
                    //    AutoItHelper.AutoItX.ControlClick("Molis", "CBC", "[CLASS:Button; INSTANCE:3]", "Button3", 1, 59, 30)
                    //    AutoItHelper.AutoItX.Send("{SPACE}")
                    //End If


                    //If i = "CBCD" Then

                    //    AutoItHelper.AutoItX.Sleep(200)
                    //    AutoItHelper.AutoItX.ControlClick("Molis", "CBCD", "[CLASS:Button; INSTANCE:11]", "Button11", 1, 41, 32)
                    //    AutoItHelper.AutoItX.Send("{SPACE}")

                    //End If

                    //If i = "HH" Then
                    //    AutoItHelper.AutoItX.Sleep(200)
                    //    AutoItHelper.AutoItX.ControlClick("Molis", "HH", "[CLASS:Button; INSTANCE:15]", "Button15", 1, 87, 45)
                    //    AutoItHelper.AutoItX.Send("{SPACE}")
                    //End If


                    //'Mnualy entering test text
                    //If i = "HCT" Then
                    //    AutoItHelper.AutoItX.Sleep(200)
                    //    AutoItHelper.AutoItX.ControlClick("Molis", "", "[CLASS:UniCanvas; INSTANCE:1]", "", 1, 179, 601)
                    //    AutoItHelper.AutoItX.Send(i)
                    //    AutoItHelper.AutoItX.Send("{TAB}")
                    //End If

                    //If i = "PLT" Then
                    //    AutoItHelper.AutoItX.Sleep(200)
                    //    AutoItHelper.AutoItX.ControlClick("Molis", "", "[CLASS:UniCanvas; INSTANCE:1]", "", 1, 179, 601)
                    //    AutoItHelper.AutoItX.Send(i)
                    //    AutoItHelper.AutoItX.Send("{TAB}")
                    //End If
                }


            }
            AutoItHelper.AutoItX.Sleep(800);

            AutoItHelper.AutoItX.Send("{TAB}");
            AutoItHelper.AutoItX.Send("{SPACE}");

            AutoItHelper.AutoItX.Sleep(200);

            AutoItHelper.AutoItX.WinActivate("MolisEntry");
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

