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
using MySql.Data.MySqlClient;
using System.Text.RegularExpressions;
using System.IO;
using ADODB;
using HL7;
using FunctionalCSharp;
using Microsoft.VisualBasic.CompilerServices;
using downtimeC.LabelPrinting;

namespace downtimeC
{
    public partial class OrderEntryForm2 : OrderBaseForm
    {

        protected OrderEntryForm2()
        {
            InitializeComponent();
        }

        readonly GetMySQL mySql;

        readonly SetupTableData setupTableData;
        readonly Hospital hospital;
   
        public OrderEntryForm2(SetupTableData setupTableData, GetMySQL getMySql, Hospital hospital)
            : base(setupTableData, getMySql)
        {
            Load += orderentry_Load;
            InitializeComponent();
            this.mySql = getMySql;
            this.setupTableData = setupTableData;
            this.hospital = hospital;

        }




        private void orderentry_Load(System.Object sender, System.EventArgs e)
        {
            this.DisableAll<TextBox>();
            this.DisableAll<ComboBox>();
     
            TextBoxbillingnumber.Enabled = true;
        }

        //http://www.vbmysql.com/articles/vbnet-mysql-tutorial/the-vbnet-mysql-tutorial-part-4

        public bool NotAn_X_Mrn
        {
            get
            {
                return !Operators.LikeString(mrn.Text, "X*", CompareMethod.Text);
            }
        }

        public void writeDowntimeTable()
        {
            TextboxCollectDate.Text = DateTimePicker1.Text;

            if (NotAn_X_Mrn)
            {
                while (mrn.Text.Length < 12)
                {
                    mrn.Text = "0" + mrn.Text;
                }
            }

            var p = new MySqlParameter("?CollectionTime", collectiontime.Text);
            mySql.ExecuteNonQuery("update dtdb1.Table1 set COLLECTIONTIME = ?CollectionTime, RECEIVETIME = '" + receivetime.Text + "',LOCATION = '" + comboBoxWard.Text + "',PRIORITY = '" + ComboBoxPriority.Text + "',MRN = '" + mrn.Text + "',DOB = '" + DOB.Text + "',FIRSTNAME = '" + firstname.Text + "',REDTEST = '" + redtest.Text + "',BLUETEST = '" + bluetest.Text + "',LAVHEMTEST = '" + lavhemtest.Text + "',GREENTEST = '" + greentest.Text + "',LAVCHEMTEST = '" + lavchemtest.Text + "',GRYTEST = '" + graytest.Text + "',URINEHEM = '" + urinehem.Text + "',URINECHEM = '" + urinechem.Text + "',BLOODGAS = '" + bloodgas.Text + "',PROBLEM = '" + problem.Text + "',CALLS = '" + cal1.Text + "',ORDERCOMMENT = '" + comment.Text + "',LASTNAME = '" + lastname.Text + "',SENDOUT = '" + sendout.Text + "',SEROLOGY = '" + ser.Text + "' ,HEPPETITAS = '" + hepp.Text + "',COLLECTDATE = '" + TextboxCollectDate.Text + "',TECHID = '" + TextBoxTechId.Text + "',CSFTEST = '" + csfbox.Text + "' ,FLUIDTEST = '" + fluidbox.Text + "',VIRALLOADTEST = '" + Viralloadbox.Text + "',OTHERTEST = '" + OTHERBOX.Text + "', BILLINGNUMBER = '" + TextBoxbillingnumber.Text + "', IMMUNOTEST = '" + TextBoxIMMUNO.Text + "' WHERE ordernumber = '" + ordernumber.Text + "'", p);


            this.DisableAll<TextBox>();
            this.DisableAll<ComboBox>();
          
            ComboboxPrinter.Enabled = true;
            ComboBoxoldorder.Enabled = true;
            TextBoxbillingnumber.Enabled = true;
        }


        public static object date2ordernumber(DateTime dates)
        {
            string ordend = dates.ToString();

            System.Text.RegularExpressions.Match dateend = Regex.Match(ordend, "([0-9]+)/([0-9]+)/([0-9]+)");
            string endmonth = dateend.Groups[1].Value;
            string endday = dateend.Groups[2].Value;
            string endyear = dateend.Groups[3].Value;
            while (endday.Length < 2)
            {
                endday = "0" + endday;
            }



            int endmnth = int.Parse(endyear) + -2004;
            endmnth = endmnth * 12;


            string monthend = Convert.ToString(Convert.ToInt32(endmonth) + Convert.ToInt32(endmnth));

            if (int.Parse(monthend) > 99)
            {
                int newmonthstart = int.Parse(Strings.Left(monthend, 2));
                string newmonthend = Strings.Right(monthend, 1);
                newmonthstart = newmonthstart + 55;
                monthend = Strings.Chr(newmonthstart) + newmonthend;
            }

            return  monthend + endday;

        }

        /// <summary>
        /// If the Date changes, wipe out the table of orderNumbers and restart ordering
        /// </summary>
        /// <remarks></remarks>

        public void TruncateOrderNumbersOnDateChange()
        {
            if (!(System.DateTime.Now.Day == GlobalMutableState.StartupDate.Day))
            {
                var dtable = mySql.FilledTable("select * from dtdb1.ordernumber");

                if (!(dtable.Rows.Count == 1))
                {
                    mySql.ExecuteNonQuery("truncate TABLE dtdb1.ordernumber");
                    mySql.ExecuteNonQuery("insert into dtdb1.ordernumber (OrderLast,Ordernumber)values ('1', '7500');");
                }
                GlobalMutableState.StartupDate = System.DateTime.Now;
            }

        }

        /// <summary>
        /// use the DB to generate a new orderNumber 
        /// </summary>
        /// <returns></returns>
        /// <remarks></remarks>
        public string getOrderNumber()
        {
            DataRow q = mySql.FilledRowOption("insert into dtdb1.ordernumber (OrderLast,Ordernumber) select OrderLast+1, ordernumber+1 from dtdb1.ordernumber ORDER BY OrderLast DESC LIMIT 1; select OrderLast, Ordernumber from dtdb1.ordernumber ORDER BY OrderLast DESC LIMIT 1;").get;

            string neworernumber = q["Ordernumber"].ToString();

            //........//////  un-comment to use alpha-numeric ordernumbers (also un-comment line items 47-50 in Restartwheel) \\\\\\......

            if (neworernumber.Length > 4)
            {
                string letters = Strings.Left(neworernumber, 2);
                string ordernums = Strings.Right(neworernumber, 3);
                neworernumber = Strings.Chr(int.Parse(letters)) + ordernums;

                //Dim alphanum As String = date2ordernumber(Date.Now) + h

            }
            string alphanum = date2ordernumber(System.DateTime.Now) + neworernumber;
            mySql.ExecuteNonQuery("insert into dtdb1.Table1(ordernumber)value('" + alphanum + "');");

            return alphanum;
        }

        bool validateTimeFormat(string fieldName, string fieldValue, Control control)
        {
            System.Text.RegularExpressions.Match F = Regex.Match(fieldValue, "([0-9]{2}):([0-9]{2})");
            if (!F.Success)
            {
                if (Interaction.MsgBox(string.Format("{0} must be in proper format(##:##)",fieldName), MsgBoxStyle.DefaultButton1, "MsgBox") == MsgBoxResult.Ok)
                {
                    control.Focus();
                    return false;
                       // User chose Yes.
                    // Perform some action.
                }
            }
            return true;
        }

        bool validateControlIsFilled(string message, string fieldValue, Control control)
        {
            if (fieldValue == string.Empty)
            {
                if (Interaction.MsgBox(message, MsgBoxStyle.DefaultButton1, "MsgBox") == MsgBoxResult.Ok)
                {
                    control.Focus();
                    return false;
                }
            }
            return true;
        }

        private void validateAndPrint()
        {
            if (!string.IsNullOrEmpty(redtest.Text))
            {
                var eAS = redtest.Text.Split(new char[] { ',' }).Select(x => x.Trim(' '));

                Dictionary<string, string> dict = new Dictionary<string, string>();
                foreach (string newtest in eAS)
                {
                    dict.Add(newtest, "Redtest");
                }



                Dictionary<string, string> drs = new Dictionary<string, string>();

                var dt = mySql.FilledTable("select * from dtdb1.DITests;");

                foreach (DataRow dr in dt.Rows)
                {
                    var ditest = dr["TestCode"].ToString();
                    var sequence = dr["CodeSequence"].ToString();
                    drs.Add(ditest, sequence);
                    Console.WriteLine(ditest);
                }
                foreach (string testtype in dict.Keys)
                {
                    testtype.Replace(" ", "");
                    try
                    {
                        string checkstest = drs[testtype];
                    }
                    catch
                    {
                        if (Interaction.MsgBox("Please Enter Correct SST Test For: '" + testtype + "' " + Constants.vbNewLine + "Tests must be seperated with a comma!", MsgBoxStyle.DefaultButton1, "MsgBox") == MsgBoxResult.Ok)
                        {
                            redtest.Focus();
                        }


                        return;
                    }


                }

            }



            if (this.ordernumber.Enabled == true)
                this.ordernumber.Enabled = false;
            try
            {
                var locat = string.Empty;
                locat = comboBoxWard.Text;
                string locat1 = Strings.Left(locat, 1);

                if (!(locat1 == "S" || locat1 == "A"))
                {
                    if (Interaction.MsgBox("Location must start with 'S' for inpatient or 'A' for outpatient", MsgBoxStyle.DefaultButton1, "MsgBox") == MsgBoxResult.Ok)
                    {
                        comboBoxWard.Text = "";
                    }
                    comboBoxWard.Focus();
                    // User chose Yes.
                    // Perform some action.

                }
            }
            catch (Exception msgbox)
            {
            }

            if (!validateControlIsFilled("No Location Entered", comboBoxWard.Text, comboBoxWard)) return;

            if (!validateTimeFormat("Collection Time", collectiontime.Text, collectiontime)) return;

            if (!validateTimeFormat("Receive Time", receivetime.Text, receivetime)) return;

            if (!(Strings.Left(mrn.Text, 1) == "X"))
            {
                if (!validateControlIsFilled("Must enter MRN", mrn.Text, mrn)) return;
            }

            if (BillingNumberNotLike_S000_SX)
            {
                if (Interaction.MsgBox("MUST ENTER BILLING # LIKE 'S000##########' OR 'SX#######'", MsgBoxStyle.DefaultButton1, "MsgBox") == MsgBoxResult.Ok)
                {
                    TextBoxbillingnumber.Focus();
                    return;
                    // User chose Yes.
                    // Perform some action.
                }
            }

            if (this.ordernumber.Text == string.Empty)
            {
                TruncateOrderNumbersOnDateChange();

                ordernumber.Text = getOrderNumber();
            }


            foreach (TubeTypeTextBox box in getTestLabelTextBoxes)
            {
                var tests = box.Text;
                if ((!string.IsNullOrEmpty(tests)))
                {
                    var codes = tests.Split(',').Select(x => x.Trim());
                    //TODO: choose type of Highland or SMH
                    var diSpecimenType = box.getSpecimenType(hospital, setupTableData);
                    foreach (string code in codes)
                    {
                        var indiCodes = GroupTestToIndividualTest.getIndividualTests(code);
                        sendHL7(this.mrn.Text, this.firstname.Text, this.lastname.Text, this.ordernumber.Text, this.comboBoxWard.Text, indiCodes, diSpecimenType);
                    }
                }
            }

            printLabels();
            writeDowntimeTable(); //update data about the order in the DB

            editorder.Enabled = true;
            Buttoneditprevious.Enabled = true;
            if (!string.IsNullOrEmpty(ordernumber.Text))
            {
                ComboBoxoldorder.Items.Add(ordernumber.Text + "   " + lastname.Text + "," + firstname.Text);
            }
            this.ClearAllInputControls(this.ComboboxPrinter, this.TextBoxTechId);
            ordernumber.Focus();
        }
        protected override void OnPrintClick() {
            this.ordernumber.TextChanged -= ordernumber_TextChanged;
            validateAndPrint();
            this.ordernumber.TextChanged += ordernumber_TextChanged;
           
        }
        public void sendHL7(string mrn, string firstName, string lastName, string ordernumber, string ward, IEnumerable<string> codes, SpecimenType specimenType)
        {
            //set the IP and port to send to
            var sendhl = new SendHl7("172.18.140.209", 10013);

            //create the HL7 message
            var co = new OrderMessage(mrn, firstName, lastName, ordernumber, "", ward, Sex.U, codes, specimenType);
            var hl = co.toHl7();

            if (DialogResult.Yes == MessageBox.Show("Send HL7 to DI?", "Send HL7 to DI?", MessageBoxButtons.YesNo))
            {

                //send the hl7 message
                var status = sendhl.SendHL7(hl);
                if ((status == HL7Status.NOCONNECTION))
                {
                    MessageBox.Show("HL7 connection failed");
                }
                else if ((status == HL7Status.NACK))
                {
                    //  MessageBox.Show("HL7 connection Successful, but NACK returned")
                }
                else if ((status == HL7Status.EXCEPTION))
                {
                    MessageBox.Show("HL7 connection tried, but exception thrown");
                }



            }

        }


       

        public void checklocation()
        {
            try
            {
                var locat = comboBoxWard.Text;
                string locat1 = Strings.Left(locat, 1);

                if (!(locat1 == "S") || (locat1 == "A"))
                {
                    if (Interaction.MsgBox("Location must start with 'S' for inpatient or 'A' for outpatient", MsgBoxStyle.DefaultButton1, "MsgBox") == MsgBoxResult.Ok)
                       this.comboBoxWard.Text = "";
                    comboBoxWard.Focus();
                    // User chose Yes.
                    // Perform some action.

                }
            }
            catch (Exception msgbox)
            {
            }
            if (this.comboBoxWard.Text == string.Empty)
            {
                if (Interaction.MsgBox("No Location Enterd", MsgBoxStyle.DefaultButton1, "MsgBox") == MsgBoxResult.Ok)
                {
                    comboBoxWard.Focus();
                    return;
                }
            }

        }

        public void checkmrn()
        {
            if (this.mrn.Text.Length < 12)
            {
                if (Interaction.MsgBox("Must have 12 digits for MRN", MsgBoxStyle.DefaultButton1, "MsgBox") == MsgBoxResult.Ok)
                    mrn.Focus();
                // User chose Yes.
                // Perform some action.

            }
        }

     

        /// <summary>
        /// Make sure Billing number TextBox does not match: "S000*" or "SX*"
        /// </summary>
        public bool BillingNumberNotLike_S000_SX
        {
            get {
              return !(Operators.LikeString(TextBoxbillingnumber.Text, "S000*",CompareMethod.Text) || Operators.LikeString(TextBoxbillingnumber.Text, "SX*",CompareMethod.Text));
            }
        }

        public void FINDDEMOGRAPHIC()
        {
            if (BillingNumberNotLike_S000_SX)
            {
                if (Interaction.MsgBox("MUST ENTER BILLING # LIKE 'S000##########' OR 'SX#######'", MsgBoxStyle.DefaultButton1, "MsgBox") == MsgBoxResult.Ok)
                {
                    TextBoxbillingnumber.Focus();
                    return;
                    // User chose Yes.
                    // Perform some action.
                }
            }

            var t = mySql.FilledTable("select * from dtdb1.Table1 where billingnumber like '" + this.TextBoxbillingnumber.Text + "' ORDER BY ID DESC LIMIT 1");


            try
            {
                DataRow r = t.Rows[0];


                var fristname1 = r["firstname"].ToString();
                var lastname1 = r["lastname"].ToString();
                var mrn1 = r["mrn"].ToString();

                MsgBoxResult response = Interaction.MsgBox("ADD VISIT TO " + Constants.vbNewLine + " " + Constants.vbNewLine + " " + lastname1 + ", " + fristname1 + "  " + Constants.vbNewLine + " MRN: " + mrn1 + "", MsgBoxStyle.YesNo, "MsgBox");

                if (response == MsgBoxResult.Yes)
                {
                    firstname.Text = r["firstname"].ToString();
                    lastname.Text = r["lastname"].ToString();
                    mrn.Text = r["mrn"].ToString();
                    comboBoxWard.Text = r["location"].ToString();
                    DOB.Text = r["dob"].ToString();


                    this.EnableAll<TextBox>();
                    this.EnableAll<ComboBox>();

                    ComboBoxPriority.Focus();

                    return;
                }
                if (response == MsgBoxResult.No)
                {
                    var response1 = Interaction.MsgBox("WOULD YOU LIKE TO ADD A NEW PATIENT?", MsgBoxStyle.YesNo, "MsgBox");
                    if (response1 == MsgBoxResult.Yes)
                    {
                        this.EnableAll<TextBox>();
                        this.EnableAll<ComboBox>();

                        lastname.Focus();

                    }
                    if (response1 == MsgBoxResult.No)
                    {
                        TextBoxbillingnumber.Focus();
                    }
                }


            }
            catch
            {
                this.EnableAll<TextBox>();
                this.EnableAll<ComboBox>();
                lastname.Focus();
            }
        }




        private void ordernumber_TextChanged(System.Object sender, System.EventArgs e)
        {
            if (ordernumber.Text.Length == 8)
            {
                ordernumber.Enabled = false;
                TextBoxTechId.Text = GlobalMutableState.userName;

                Option<DataRow> order = orderLookup(this.ordernumber.Text);

                if (order.isDefined)
                {
                    MsgBoxResult response = Interaction.MsgBox("Order already exists. Do you wish to edit?", MsgBoxStyle.YesNo, "MsgBox");
                    if (response == MsgBoxResult.Yes)
                    {
                        readDowntimeTable(order.get);

                    }
                    else
                    {
                        ordernumber.Clear();
                        return;
                    }
                }
                else
                {
                    // Display message.
                    Interaction.MsgBox("Order Does Not exist.", MsgBoxStyle.OkOnly, "MsgBox");

                    ordernumber.Clear();
                    editorder.Enabled = true;
                    Buttoneditprevious.Enabled = true;
                }
                this.EnableAll<TextBox>();
                this.EnableAll<ComboBox>();
            }

        }
        




        private void editorder_Click(System.Object sender, System.EventArgs e)
        {
            Buttoneditprevious.Enabled = false;
            ordernumber.Enabled = true;
            DebugButtonRead.Enabled = true;
            editorder.Enabled = false;
            ordernumber.Focus();

        }



        private void cal1_TextChanged(System.Object sender, System.EventArgs e)
        {
            if (this.cal1.Text == "1111999")
            {
                this.ordernumber.Enabled = true;
            }
        }

        private void ComboBoxoldorder_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            if (ComboBoxoldorder.Text.Length > 8)
            {
                var ordnum = ComboBoxoldorder.Text;
                string ordnum1 = Strings.Left(ordnum, 8);
                ordernumber.Text = ordnum1;
                editorder.Enabled = false;
                ordernumber.Enabled = false;

            }

        }

        protected override bool ProcessTabKey(bool forward)
        {

            if (TextBoxbillingnumber.Focused)
            {
                return false;

            }
            else
            {

                return base.ProcessTabKey(forward);
            }

        }

        private void TextBoxbillingnumber_KeyPress(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Tab)
            {
                FINDDEMOGRAPHIC();       
            }
        }

        //private void buttonRead_Click_1(System.Object sender, System.EventArgs e)
        //{
        //    int n = 98106501;
        //    int nend = 98107000;
        //    while ((n < nend))
        //    {
        //        AddOrders(n.ToString());
        //        n = n + 1;
        //    }

        //}


        //public void AddOrders(string ordernumber)
        //{

        //    var alphabet = "abcdefghijklmnopqrstuvwxyz";
        //    Random ran = new Random();
        //    int length = ran.Next(0, 20);
        //    // get a random length

        //    var ranletter = alphabet.Substring(ran.Next(0, 25), 1);




        //    var lastname1 = lastname.Text;
        //    var collectiontime1 = collectiontime.Text;
        //    var receivetime1 = receivetime.Text;
        //    var location1 = comboBoxWard.Text;
        //    var dob1 = DOB.Text;

        //    var bt = bluetest.Text;
        //    var lht = lavhemtest.Text;
        //    var gt = greentest.Text;
        //    var lct = lavchemtest.Text;
        //    var grt = graytest.Text;
        //    var uh = urinehem.Text;
        //    var uc = urinechem.Text;
        //    var bg = bloodgas.Text;
        //    var prob = problem.Text;
        //    var ordcmt = comment.Text;
        //    var cal = cal1.Text;
        //    var hep = hepp.Text;
        //    var serr = ser.Text;
        //    var senot = sendout.Text;

        //    var techids = TextBoxTechId.Text;
        //    var csf = csfbox.Text;
        //    var fluid = fluidbox.Text;
        //    var viral = Viralloadbox.Text;
        //    var other = OTHERBOX.Text;
        //    var BILLING = TextBoxbillingnumber.Text;
        //    var IMMUNO = TextBoxIMMUNO.Text;

        //    TextboxCollectDate.Text = DateTimePicker1.Text;

        //    if (NotAn_X_Mrn)
        //    {
        //        while (mrn.Text.Length < 12)
        //        {
        //            mrn.Text = "0" + mrn.Text;
        //        }
        //    }



        //    mySql.ExecuteNonQuery("insert into dtdb1.Table1 (ordernumber,COLLECTIONTIME,RECEIVETIME,LOCATION,PRIORITY,MRN,DOB,FIRSTNAME,REDTEST,BLUETEST,LAVHEMTEST,GREENTEST,LAVCHEMTEST,GRYTEST,URINEHEM,URINECHEM,BLOODGAS,PROBLEM,CALLS,ORDERCOMMENT,LASTNAME,SENDOUT,SEROLOGY,HEPPETITAS,COLLECTDATE,TECHID,CSFTEST,FLUIDTEST,VIRALLOADTEST, BILLINGNUMBER)VALUES('" + ordernumber + "', '" + collectiontime1 + "','" + receivetime1 + "','" + location1 + "', '" + ComboBoxPriority.Text + "', '" + mrn.Text + "','" + dob1 + "','" + firstname.Text + "', '" + redtest.Text + "', '" + bt + "', '" + lht + "','" + gt + "', '" + lct + "', '" + grt + "','" + uh + "','" + uc + "','" + bg + "', '" + prob + "','" + cal + "','" + ordcmt + "','" + lastname1 + "','" + senot + "','" + serr + "', '" + hep + "','" + TextboxCollectDate.Text + "','" + techids + "','" + csf + "','" + fluid + "','" + viral + "', '" + BILLING + "')");
        //}

     

    

 
    }
}

