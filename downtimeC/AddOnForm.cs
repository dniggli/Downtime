using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;
using System;
using System.Collections;
using FunctionalCSharp;
using System.Diagnostics;
using MySql.Data.MySqlClient;
using HL7;
using downtimeC;
using downtimeC.LabelPrinting;
namespace downtimeC
{
    public partial class AddOnForm : Form
    {
        protected AddOnForm()
        {
            InitializeComponent();
        }

        readonly GetMySQL getMySql;
        readonly SetupTableData setupTableData;
        public AddOnForm(GetMySQL getMySql, SetupTableData setupTableData)
        {
            InitializeComponent();
            this.setupTableData = setupTableData;
            this.getMySql = getMySql;
        }

        public void printDowntimeLables(Priority priority)
        {
            //get all tubeTypeTextboxes in this form
            var tubeTypeTextboxes = this.Controls.Cast<Control>().Where(x => x is TubeTypeTextBox).Cast<TubeTypeTextBox>();
            var labelData = new LabelData(this.ordernumber.Text, this.priority.Text, this.mrn.Text, this.lastname.Text, this.firstname.Text, this.locationTextBox.Text,
    this.DateTimePicker1.Text);


            tubeTypeTextboxes.forEach(tb => tb.LabelAppend(labelData, priority));


            labelData.doPrint(ComboBoxprinter.Text, setupTableData);

        }

        //http://www.vbmysql.com/articles/vbnet-mysql-tutorial/the-vbnet-mysql-tutorial-part-4

        public void writeDowntimeTable()
        {
            string alphabet = "abcdefghijklmnopqrstuvwxyz";
            Random ran = new Random();
            int length = ran.Next(0, 20);
            // get a random length

            string ranletter = alphabet.Substring(ran.Next(0, 25), 1);

            getMySql.Async(this).ExecuteNonQuery(() => {},"update dtdb1.Table1 set COLLECTIONTIME = ?CollectionTime, BILLINGNUMBER = '"
                + TextBoxbillingnumber.Text + "', RECEIVETIME = '" + receivetime.Text + ":00" + "',LOCATION = '" + locationTextBox.Text + "',PRIORITY = '" + priority.Text +
                "',MRN = '" + mrn.Text + "',DOB = '" + DOB.Text + "',FIRSTNAME = '" + firstname.Text + "',REDTEST = '" + redtest.Text + "',BLUETEST = '" + bluetest.Text + 
                "',LAVHEMTEST = '" + lavhemtest.Text + "',GREENTEST = '" + greentest.Text + "',LAVCHEMTEST = '" + lavchemtest.Text + "',GRYTEST = '" + graytest.Text + "',URINEHEM = '" + urinehem.Text +
                "',URINECHEM = '" + urinechem.Text + "',BLOODGAS = '" + bloodgas.Text + "',PROBLEM = '" + problem.Text + "',CALLS = '" + cal1.Text + "',ORDERCOMMENT = '" + comment.Text +
                "',LASTNAME = '" + lastname.Text + "',SENDOUT = '" + sendout.Text + "',SEROLOGY = '" + ser.Text + "' ,HEPPETITAS = '" + hepp.Text +
                "',COLLECTDATE = '" + DateTimePicker1.Text + "' ,CSFTEST = '" + csfbox.Text + "' ,FLUIDTEST = '" + fluidbox.Text + 
                "',VIRALLOADTEST = '" + Viralloadbox.Text + "' WHERE ordernumber = '" + ordernumber.Text + "'",
                new MySqlParameter("?CollectionTime",collectiontime.Text));


        }

        private void ButtonWrite_Click(System.Object sender, System.EventArgs e)
        {
            if (this.locationTextBox.Text == string.Empty)
                checklocation();
            if (!(this.locationTextBox.Text == string.Empty))
                writeandprint();
        }


        public void writeandprint()
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

        public void checklocation()
        {
            if (this.locationTextBox.Text == string.Empty)
            {   
               var response = Interaction.MsgBox("No Location Enterd", MsgBoxStyle.DefaultButton1, "MsgBox");
                if (response == MsgBoxResult.Ok)
                    locationTextBox.Text = "";
                locationTextBox.Focus();
                // User chose Yes.
                // Perform some action.

            }

        }


        public void readDowntimeTable()
        {
            MySqlDataAdapter da = new MySqlDataAdapter("select * from dtdb1.Table1 where ordernumber like '" + this.ordernumber.Text + "' ORDER BY ID DESC LIMIT 1", "server=lis-s22104-db1;uid=dniggli;pwd=vvo084;");
            DataTable t = new DataTable();

            da.Fill(t);




            try
            {
                DataRow r = t.Rows[0];


                ordernumber.Text = r["ordernumber"].ToString();
                firstname.Text = r["firstname"].ToString();
                lastname.Text = r["lastname"].ToString();
                mrn.Text = r["mrn"].ToString();
                collectiontime.Text = r["collectiontime"].ToString();
                receivetime.Text = r["receivetime"].ToString();
                priority.Text = r["priority"].ToString();
                locationTextBox.Text = r["location"].ToString();
                bluetest.Text = r["bluetest"].ToString();
                redtest.Text = r["redtest"].ToString();
                greentest.Text = r["greentest"].ToString();
                urinechem.Text = r["urinechem"].ToString();
                urinehem.Text = r["urinehem"].ToString();
                graytest.Text = r["grytest"].ToString();
                comment.Text = r["ordercomment"].ToString();
                problem.Text = r["problem"].ToString();
                lavchemtest.Text = r["lavchemtest"].ToString();
                lavhemtest.Text = r["lavhemtest"].ToString();
                bloodgas.Text = r["bloodgas"].ToString();
                DOB.Text = r["dob"].ToString();
                cal1.Text = r["calls"].ToString();
                sendout.Text = r["SENDOUT"].ToString();
                hepp.Text = r["heppetitas"].ToString();
                ser.Text = r["serology"].ToString();
                colldate.Text = r["collectdate"].ToString();
                csfbox.Text = r["CSFTEST"].ToString();
                fluidbox.Text = r["FLUIDTEST"].ToString();
                Viralloadbox.Text = r["VIRALLOADTEST"].ToString();
                TextBoxbillingnumber.Text = r["BILLINGNUMBER"].ToString();
                Application.DoEvents();
                //Display the changes immediately (redraw the label text)
                System.Threading.Thread.Sleep(500);
                //do it slow enough so we can actually read the text before it changes, pause half a second

            }
            catch (Exception exitsub)
            {
            }
        }

        private void ButtonRead_Click(System.Object sender, System.EventArgs e)
        {
            Buttonpopulate.Visible = false;
            foreach (Control C in this.Controls)
            {
                if (C is TextBox)
                {
                    TextBox TB = (TextBox)C;
                    //string running = "high";
                    string runs = "45654125";

                    string alphabet = "abcdefghijklmnopqrstuvwxyz";
                    Random ran = new Random();
                    int length = ran.Next(0, 20);
                    // get a random length
                    string ranstring = string.Empty;
                    for (int x = 0; x <= length; x++)
                    {
                        ranstring += alphabet.Substring(ran.Next(0, 25), 1);
                    }

                    TB.AppendText(ranstring);
                    ordernumber.Text = runs;
                    mrn.Text = runs;
                    ComboBoxprinter.Text = "s56";
                    DOB.Text = "08/28/2003";
                    priority.Text = "S";
                    DOB.Text = "10";
                    cal1.Text = "585-987-7848";
                    collectiontime.Text = "20:50";
                    receivetime.Text = "20:55";



                }
            }

        }




        

        private void ordernumber_TextChanged(System.Object sender, System.EventArgs e)
        {
            if (ordernumber.Text.Length == 8)
            {
                readDowntimeTable();
            }
            if (this.ordernumber.Text == "11119999")
            {
                this.Buttonpopulate.Visible = true;
                this.ButtonWrite.Visible = true;
                this.ButtonPrint.Visible = true;
                this.buttonRead.Visible = true;
            }
        }

        

        private void read_click(System.Object sender, System.EventArgs e)
        {
            readDowntimeTable();
        }

        private void Addons_Load(System.Object sender, System.EventArgs e)
        {
            printerlist();
            ComboBoxprinter.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
            ComboBoxprinter.AutoCompleteSource = AutoCompleteSource.ListItems;
        }

        private void ComboBoxprinter_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ButtonWrite_Click(this, EventArgs.Empty);
            }
        }

        public void printerlist()
        {
            MySqlDataAdapter ch = new MySqlDataAdapter("select name from pathdirectory.device d join pathdirectory.device_has_group dg on d.Device_ID = dg.Device_ID where Group_ID = '41' order by name", "server=lis-s22104-db1;uid=dniggli;pwd=vvo084;");
            DataTable dtble = new DataTable();
            ch.Fill(dtble);

            foreach (DataRow dr in dtble.Rows)
            {
                ComboBoxprinter.Items.Add(dr["name"].ToString());

            }

        }

    }
}
