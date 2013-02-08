using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using NUnit.Framework;
using AutoItHelper;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using HL7;

namespace downtimeC
{
    
[TestFixture()]
    public partial class RecoveryForm : Form
    {
       protected RecoveryForm()
        {
            InitializeComponent();
        }

        readonly GetMySQL getMySql;
        public RecoveryForm(GetMySQL getMySql)
        {
            InitializeComponent();
            this.getMySql = getMySql;
        }

    public static string fixTEST = "";

    public static string tests = "";
    [Test()]
    public void Button1_Click(System.Object sender, System.EventArgs e)
    {

        if (AutoItX.WinExists("Search")) {

            // If Not Me.TextBoxOrderNumber.Text = String.Empty Then
            //If Not Me.TextBox1.Text = String.Empty Then
            this.Visible = false;
            string numberstart = TextBoxOrderNumber.Text;
            // Dim numberend As String = TextBox1.Text
            //Do While (n < (numberend + 1))
            //System.Threading.Thread.Sleep(500)
            automatedrecovery(numberstart);
        //n = n + 1
        // Loop
        //Else
        //    Dim msg As String
        //    Dim title As String
        //    Dim style As MsgBoxStyle
        //    Dim response As MsgBoxResult

        //    msg = "Must Enter Ending Order Number"   ' Define message.
        //    style = MsgBoxStyle.DefaultButton1
        //    title = "MsgBox"   ' Define title.
        //    ' Display message.
        //    response = MsgBox(msg, style, title)
        //    If response = MsgBoxResult.Ok Then TextBox1.Focus()

        //End If

        //Else

        //Dim msg As String
        //Dim title As String
        //Dim style As MsgBoxStyle
        //Dim response As MsgBoxResult

        //msg = "Must Enter Starting Order Number"   ' Define message.
        //style = MsgBoxStyle.DefaultButton1
        //title = "MsgBox"   ' Define title.
        //' Display message.
        //response = MsgBox(msg, style, title)
        //If response = MsgBoxResult.Ok Then TextBoxOrderNumber.Focus()

        //End If


        } else {
         Interaction.MsgBox("Must Open OrderEntry Lookup Screen", MsgBoxStyle.OkOnly, "MsgBox");
        }

    }

    public void automatedrecovery(string startnumber)
    {

        var t = getMySql.FilledTable("select * from dtdb1.Table1 where ordernumber like '" + startnumber + "' ORDER BY ID DESC LIMIT 1");
 

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

            if (BILLING == string.Empty) {
 
             var response = Interaction.MsgBox("No Billing #", MsgBoxStyle.DefaultButton1, "MsgBox");
                if (response == MsgBoxResult.Ok) {
                    this.Visible = true;
                    TextBoxOrderNumber.Focus();

                    return;
                }
            }

            Dictionary<string, string[]> DICT = new Dictionary<string, string[]>();

            DICT.Add("bluetest", Strings.Split(bluetest, ","));

            DICT.Add("redtest", Strings.Split(redtest, ","));

            DICT.Add("greentest", Strings.Split(greentest, ","));

            DICT.Add("lavhemtest", Strings.Split(lavhemtest, ","));


            DICT.Add("lavchemtest", Strings.Split(lavchemtest, ","));



            DICT.Add("serology", Strings.Split(ser, ","));

            DICT.Add("heppat", Strings.Split(hepp, ","));

            DICT.Add("urinehem", Strings.Split(urinehem, ","));

            DICT.Add("urinechem", Strings.Split(urinechem, ","));

            DICT.Add("bloodgas", Strings.Split(bloodgas, ","));



            DICT.Add("gray", Strings.Split(graytest, ","));

            DICT.Add("viral", Strings.Split(Viralloadbox, ","));

            DICT.Add("csf", Strings.Split(csfbox, ","));

            DICT.Add("fluid", Strings.Split(fluidbox, ","));



            AutoItHelper.AutoItX.Sleep(500);
            AutoItX.WinActivate("Search");
            AutoItHelper.AutoItX.ControlSend("Search", "", "[CLASS:Edit; INSTANCE:7]", BILLING, 0);
            AutoItHelper.AutoItX.Sleep(200);
            AutoItX.WinActivate("Search");
            AutoItHelper.AutoItX.Send("{ENTER}");
            AutoItHelper.AutoItX.Sleep(200);
            AutoItHelper.AutoItX.Send("!w");
            AutoItHelper.AutoItX.Sleep(200);
            AutoItHelper.AutoItX.Send("{o}");

            AutoItHelper.AutoItX.Sleep(500);

            if (AutoItX.WinWaitActive("Order info", "", 1))
            {
                AutoItHelper.AutoItX.Send("{ENTER}");
            }

            AutoItHelper.AutoItX.Sleep(500);
            AutoItHelper.AutoItX.Send("SD");

            AutoItHelper.AutoItX.Sleep(100);
            AutoItHelper.AutoItX.Send("{TAB}");
            AutoItHelper.AutoItX.Sleep(100);
            int n = 0;
            string reqdr = AutoItHelper.AutoItX.WinGetText("Order Entry - [New Order  - Edit Mode]", "");
            Console.WriteLine(reqdr);
            string[] drname = reqdr.Split('&');

            Match newseq = Regex.Match(reqdr, "\\bDr:\\n([A-Z 0-9]+)\\n.+$", RegexOptions.Multiline);

            //Do While n < 10
            //    Dim tstcd As String = newtest.Groups(n).Value
            //    n = n + 1
            //    Console.WriteLine(tstcd)
            //Loop
            //'dim testdr As String =  

            //'For Each d As String In drname

            //'    Dim parsetest = drname(n)
            //'    n = n + 1
            //'    Console.WriteLine(parsetest)
            //'Next
            //Dim drcodearray As String = drname(2)

            //Dim drfirst As Array = drcodearray.Split(" ")

            //Dim drcodesect As String = drfirst(1).ToString


            //Dim newseq As Match = Regex.Match(drcodesect, "^Dr:\n([A-Z 0-9]+)\n.+$", RegexOptions.Multiline)



            string drcode = newseq.Groups[1].Value;





            AutoItHelper.AutoItX.ControlSend("Order Entry - [New Order  - Edit Mode]", "", "[CLASS:Edit; INSTANCE:33]", drcode, 0);

            //AutoItHelper.AutoItX.Send("{TAB}")
            //AutoItHelper.AutoItX.Sleep(100)
            //AutoItHelper.AutoItX.Send("{TAB}")
            //AutoItHelper.AutoItX.Sleep(100)
            //AutoItHelper.AutoItX.Send("{TAB}")
            //AutoItHelper.AutoItX.Sleep(100)
            //AutoItHelper.AutoItX.Send("{F2}")
            //AutoItHelper.AutoItX.Sleep(200)
            //'AutoItHelper.AutoItX.Send(drlast)
            //AutoItHelper.AutoItX.Sleep(100)
            //AutoItHelper.AutoItX.Send("{TAB}")
            //'AutoItHelper.AutoItX.Send(drfirst)
            //AutoItHelper.AutoItX.Send("!F")
            //WinWaitClose("Doctor Search Screen")
            //AutoItHelper.AutoItX.ControlFocus("Order Entry - [New Order  - Edit Mode]", "", "[CLASS:Edit; INSTANCE:2]")


            //AutoItHelper.AutoItX.Send("^V")


            AutoItHelper.AutoItX.ControlSend("Order Entry - [New Order  - Edit Mode]", "", "[CLASS:ComboBox; INSTANCE:1]", priority, 0);
            AutoItHelper.AutoItX.Sleep(500);
            AutoItHelper.AutoItX.ControlSend("Order Entry - [New Order  - Edit Mode]", "", "[CLASS:Edit; INSTANCE:15]", ordernumber, 0);

            AutoItHelper.AutoItX.Sleep(700);
            AutoItX.WinActivate("Order Entry - [New Order  - Edit Mode]");
            AutoItHelper.AutoItX.Send("!2");
            //AutoItHelper.AutoItX.SetOptions(true)

            foreach (string testtype in DICT.Keys) {

                foreach (string test in DICT[testtype]) {
                    AutoItHelper.AutoItX.Send(test);
                    AutoItHelper.AutoItX.Send("{ENTER}");
                    AutoItHelper.AutoItX.Sleep(300);

                    if (AutoItX.WinExists("Order Entry", "RBS"))
                    {
                        while (!(AutoItHelper.AutoItX.WinExists("Order Entry", "RBS") == false)) {
                            AutoItX.WinActivate("Order Entry", "RBS");
                            AutoItHelper.AutoItX.Sleep(100);
                            AutoItX.Send("{ENTER}");
                            AutoItHelper.AutoItX.Sleep(200);
                        }

                    }
                    if (AutoItX.WinExists("Order Entry", "RBS <SSIGN>: reflex 'SSIGN' on Ord# NEW"))
                    {
                        while (!(AutoItHelper.AutoItX.WinExists("Order Entry", "RBS <SSIGN>: reflex 'SSIGN' on Ord# NEW") == false)) {
                            AutoItX.WinActivate("Order Entry", "RBS <SSIGN>: reflex 'SSIGN' on Ord# NEW");
                            AutoItHelper.AutoItX.Sleep(100);
                            AutoItX.Send("{ENTER}");
                            AutoItHelper.AutoItX.Sleep(200);
                        }
                    }
                    if (AutoItX.WinExists("Order Entry", "not defined"))
                    {
                        AutoItHelper.AutoItX.Sleep(100);
                        AutoItX.Send("{ENTER}");
                        AutoItHelper.AutoItX.Sleep(200);
                        tests = test;
                        InputBoxForm Iform = new InputBoxForm();

                        Iform.ShowDialog(this);
                        AutoItHelper.AutoItX.Sleep(200);
                        Iform.Focus();
                        //TopMost = True
                        //Dim testfix As String = InputBox("Correct unknown test: " & test)
                        //TopMost = False
                        Console.WriteLine(fixTEST);
                        AutoItHelper.AutoItX.ControlSend("Order Entry", "New Order  - Edit Mode", "[CLASS:Edit; INSTANCE:1]", fixTEST, 0);
                        AutoItHelper.AutoItX.Sleep(100);
                        AutoItX.WinActivate("Order Entry - [New Order  - Edit Mode]");
                        AutoItHelper.AutoItX.Sleep(50);
                        AutoItX.Send("{ENTER}");

                    }

                    AutoItHelper.AutoItX.Sleep(200);
                }
            }
            AutoItHelper.AutoItX.Send("{F9}");
            AutoItHelper.AutoItX.Sleep(200);
            AutoItHelper.AutoItX.Send(";");
            AutoItHelper.AutoItX.Sleep(200);
            AutoItHelper.AutoItX.Send("{TAB}");
            AutoItHelper.AutoItX.Send(collectiontime);
            AutoItHelper.AutoItX.Send("{TAB}");
            AutoItHelper.AutoItX.Send(DateTimeFunctions.datetoordentry(colldate));
            AutoItHelper.AutoItX.Send("{TAB}");
            AutoItHelper.AutoItX.Send("{TAB}");
            AutoItHelper.AutoItX.Send(receivetime);
            AutoItHelper.AutoItX.Send("{TAB}");
            AutoItHelper.AutoItX.Send(DateTimeFunctions.datetoordentry(colldate));
            AutoItHelper.AutoItX.Send("{ENTER}");
            AutoItHelper.AutoItX.Sleep(200);
            AutoItHelper.AutoItX.Send("^s");
            AutoItHelper.AutoItX.Sleep(1000);

            if (AutoItX.WinExists("Result must be entered for this test:"))
            {
                AutoItX.WinWaitClose("Result must be entered for this test:");
            }


            if (AutoItX.WinExists("Results must be entered for these tests:"))
            {
                AutoItX.WinWaitClose("Results must be entered for these tests:");
            }

            AutoItHelper.AutoItX.Send("y");
            AutoItHelper.AutoItX.Sleep(500);
            AutoItX.WinWaitActive("Standard Label", 1);
            AutoItHelper.AutoItX.Send("{TAB}");
            AutoItHelper.AutoItX.Send("{TAB}");
            AutoItHelper.AutoItX.Send("{TAB}");
            AutoItHelper.AutoItX.Send("{TAB}");
            //AutoItHelper.AutoItX.Send("{TAB}")
            AutoItHelper.AutoItX.Send("{ENTER}");
            AutoItHelper.AutoItX.Sleep(500);


        //For Each kv As KeyValuePair(Of String, String()) In DICT

        //    Console.WriteLine(kv.Key)


        //Next


        } catch (Exception ex) {
        }
        this.Visible = true;
    }



    private void TextBoxOrderNumber_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
        if (e.KeyChar == Strings.Chr(13)) {
            Button1_Click(this, EventArgs.Empty);
        }
    }

    }
}
