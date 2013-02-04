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
using CodeBase2.MySql.URMC;
using downtimeC;
using HL7;
using downtimeC.LabelPrinting;
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
    public partial class AutolabAliquotForm : Form
    {
        public AutolabAliquotForm()
        {
            InitializeComponent();
        }

        readonly GetMySQL getMySql;
        public AutolabAliquotForm(GetMySQL mysql)
        {
            this.getMySql = mysql;
        }



        public void printdemographiclabels()
        {
            if (!(this.firstname.Text == string.Empty))
            {
                var labelData = new LabelData(this.ordernumber.Text, this.priority.Text, this.mrn.Text, this.lastname.Text, this.firstname.Text, this.locationTextBox.Text,
this.DateTimePicker1.Text);

                collectiontime.LabelAppend(labelData, Priority.Routine);
                collectiontime.LabelAppend(labelData, Priority.Routine);
                labelData.doPrint(ComboBoxprinter.Text);
            }

        }


        public void printDowntimeLables(Priority priority)
        {
            //get all tubeTypeTextboxes in this form
            var tubeTypeTextboxes = this.Controls.Cast<Control>().Where(x => x is TubeTypeTextBox).Cast<TubeTypeTextBox>();
            var labelData = new LabelData(this.ordernumber.Text, this.priority.Text, this.mrn.Text, this.lastname.Text, this.firstname.Text, this.locationTextBox.Text,
    this.DateTimePicker1.Text);


            tubeTypeTextboxes.forEach(tb => tb.LabelAppend(labelData, priority));


            labelData.doPrint(ComboBoxprinter.Text);

        }


        //public void writeDowntimeTable()
        //{
        //    string alphabet = "abcdefghijklmnopqrstuvwxyz";
        //    Random ran = new Random();
        //    int length = ran.Next(0, 20);
        //    // get a random length

        //    string ranletter = alphabet.Substring(ran.Next(0, 25), 1);


        //    string receivetime1 = receivetime.Text + ":00";

        //    string query = "insert into dtdb1.Table1 (ordernumber,COLLECTIONTIME,RECEIVETIME,LOCATION,PRIORITY,MRN,DOB,FIRSTNAME,REDTEST,BLUETEST,LAVHEMTEST,GREENTEST,LAVCHEMTEST,GRYTEST,URINEHEM,URINECHEM,BLOODGAS,PROBLEM,CALLS,ORDERCOMMENT,LASTNAME,SENDOUT,SEROLOGY,HEPPETITAS,COLLECTDATE,TECHID,CSFTEST,FLUIDTEST,VIRALLOADTEST) VALUES ('"
        //        + ordernumber.Text + "', '" + collectiontime.Text + "','" + receivetime1 + "','" + locationTextBox.Text + "', '" + priority.Text + "', '" + mrn.Text + "','" + DOB.Text + "','" + firstname.Text + "', '" +
        //        redtest.Text + "', '" + bluetest.Text + "', '" + lavhemtest.Text + "','" + greentest.Text + "', '" + lavchemtest.Text + "', '" + graytest.Text + "','" + urinehem.Text +
        //        "','" + urinechem.Text + "','" + bloodgas.Text + "', '" + problem.Text + "','" + cal1.Text + "','" +
        //        comment.Text + "','" + lastname.Text + "','" + sendout.Text + "','" + ser.Text + "', '" + hepp.Text + "','" + colldate.Text + "','" + ordertechid.Text + "','" + csfbox.Text + "','" + fluidbox.Text + "','" + Viralloadbox.Text + "')";

        //    //execute the insert asynchronously, don't perform an action after the insert completes.
        //    getMySql.Async(this).ExecuteNonQuery(query, () => { });
        //}


        private void ButtonWrite_Click(System.Object sender, System.EventArgs e)
        {
            if (this.locationTextBox.Text == string.Empty)
            {
                checklocation();
            }
            else
            {
                writeandprint();
            }
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
            getMySql.Async(this).FilledRow("select * from dtdb1.Table1 where ordernumber like '" + this.ordernumber.Text + "' ORDER BY ID DESC LIMIT 1", r =>
            {
                try
                {
                    this.Controls.Cast<Control>().Where(c => c is IStoredControl).Cast<IStoredControl>().forEach(storedControl =>
                  storedControl.setValue(r[storedControl.DataColumnName].ToString())
                   );

                    //ordernumber.Text = r["ordernumber"].ToString();
                    //firstname.Text = r["firstname"].ToString();
                    //lastname.Text = r["lastname"].ToString();
                    //mrn.Text = r["mrn"].ToString();
                    //collectiontime.Text = r["collectiontime"].ToString();
                    //receivetime.Text = r["receivetime"].ToString();
                    //priority.Text = r["priority"].ToString();
                    //ComboBoxWard.Text = r["location"].ToString();
                    //bluetest.Text = r["bluetest"].ToString();
                    //redtest.Text = r["redtest"].ToString();
                    //greentest.Text = r["greentest"].ToString();
                    //urinechem.Text = r["urinechem"].ToString();
                    //urinehem.Text = r["urinehem"].ToString();
                    //graytest.Text = r["grytest"].ToString();
                    //comment.Text = r["ordercomment"].ToString();
                    //problem.Text = r["problem"].ToString();
                    //lavchemtest.Text = r["lavchemtest"].ToString();
                    //lavhemtest.Text = r["lavhemtest"].ToString();
                    //bloodgas.Text = r["bloodgas"].ToString();
                    //DOB.Text = r["dob"].ToString();
                    //cal1.Text = r["calls"].ToString();
                    //sendout.Text = r["SENDOUT"].ToString();
                    //hepp.Text = r["heppetitas"].ToString();
                    //ser.Text = r["serology"].ToString();
                    //colldate.Text = r["collectdate"].ToString();
                    //csfbox.Text = r["CSFTEST"].ToString();
                    //fluidbox.Text = r["FLUIDTEST"].ToString();
                    //Viralloadbox.Text = r["VIRALLOADTEST"].ToString();
                    //OTHERBOX.Text = r["OTHERTEST"].ToString();
                    Application.DoEvents();
                    //Display the changes immediately (redraw the label text)
                    System.Threading.Thread.Sleep(500);
                    //do it slow enough so we can actually read the text before it changes, pause half a second

                }
                catch (Exception exitsub)
                {
                }
            });




        }

        public bool checkfororder()
        {
            bool functionReturnValue = false;

            try
            {
                DataRow q = getMySql.FilledRow("select * from dtdb1.Table1 where ordernumber like '" + this.ordernumber.Text + "' ORDER BY ID DESC LIMIT 1");
                if (q["firstname"].ToString() != string.Empty)
                {
                    readDowntimeTable();
                    functionReturnValue = false;
                }
                else
                {
                    Interaction.MsgBox("Order Does Not exist .", MsgBoxStyle.OkOnly, "MsgBox");
                    functionReturnValue = true;
                }

            }
            catch (Exception msgbox)
            {
            }


            return functionReturnValue;


        }

        private void ButtonRead_Click(System.Object sender, System.EventArgs e)
        {
            Buttonpopulate.Visible = false;
            foreach (Control C in this.Controls)
            {
                if (C is TextBox)
                {
                    TextBox TB = (TextBox)C;
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





        private void ComboBoxprinter_KeyPress(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                ButtonWrite_Click(this, EventArgs.Empty);
            }

        }


        private void ordernumber_KeyUp(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                checkfororder();
            }
        }



        private void read_click(System.Object sender, System.EventArgs e)
        {
            readDowntimeTable();
        }



        private void printdem_Click(System.Object sender, System.EventArgs e)
        {
            if (ComboBoxprinter.Text == string.Empty)
            {
                var response = Interaction.MsgBox("INVALID PRINTER", MsgBoxStyle.DefaultButton1, "MsgBox");
                if (response == MsgBoxResult.Ok)
                {
                    ComboBoxprinter.Focus();
                    return;
                }

            }
            else
            {
                if (checkfororder() == false)
                {
                    if (priority.Text == "S") this.priority.Text = "STAT";

                    printdemographiclabels();
                }
                else
                {
                    return;
                }
            }


            this.ClearAllTextBoxes();
            ordernumber.Focus();
        }



        private void aliquotform_Load(System.Object sender, System.EventArgs e)
        {
            getMySql.Async(this).FilledTable("select name from pathdirectory.device d join pathdirectory.device_has_group dg on d.Device_ID = dg.Device_ID where Group_ID = '41' order by name",
                dt =>
                {
                    foreach (DataRow dr in dt.Rows)
                    {
                        ComboBoxprinter.Items.Add(dr["name"].ToString());
                    }

                    ComboBoxprinter.AutoCompleteMode = AutoCompleteMode.SuggestAppend;
                    ComboBoxprinter.AutoCompleteSource = AutoCompleteSource.ListItems;

                    foreach (Control C in this.Controls)
                    {
                        if (C is TextBox)
                        {
                            C.Enabled = false;
                        }
                    }

                }
                );
        }



        private void ComboBoxprinter_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            foreach (Control C in this.Controls)
            {
                if (C is TextBox)
                {
                    C.Enabled = true;
                    ordernumber.Focus();
                }
            }
        }

        private void ComboBoxWard_TextChanged(object sender, EventArgs e)
        {

        }

        private void Label6_Click(object sender, EventArgs e)
        {

        }
    }
}
