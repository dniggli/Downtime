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
using HL7;
using System.Data.SqlClient;
using FunctionalCSharp;

namespace downtimeC
{
    public partial class TrackingBase : Form
    {
        readonly GetSqlServer getSqlServer;
        /// <summary>
        /// Required for VisualStudio designer
        /// </summary>
        public TrackingBase(GetSqlServer getSqlServer) : base()
        {
            InitializeComponent();
            this.getSqlServer = getSqlServer;
        }

        public void writeDowntimeTable2()
        {
            string ordernumber1 = string.Empty;
            string trackcomnt = string.Empty;
            string tracktag = string.Empty;
            string trakloct = string.Empty;
            string trcktech = string.Empty;

            ordernumber1 = ORDERNUMBER.Text;
            trackcomnt = trackcomment.Text;
            tracktag = tracktagbox.Text;
            trakloct = trklocatn.Text;
            trcktech = Techidbox.Text;



            getSqlServer.ExecuteNonQuery("insert into dttracking (ordernumber,TRACKING,TRACKINGCOMMENT,tracklocation,tracktechid)VALUES('" + ordernumber1 + "','" + tracktag + "','" + trackcomnt + "','" + trakloct + "','" + trcktech + "')");

        }


        public void writeDowntimeTable()
        {
      



            string ordernumber1 = string.Empty;
            string trackcomnt = string.Empty;
            string tracktag = string.Empty;
            string trakloct = string.Empty;
            string trcktech = string.Empty;

            ordernumber1 = ORDERNUMBER.Text;
            trackcomnt = trackcomment.Text;
            tracktag = tracktagbox.Text;
            trakloct = trklocatn.Text;
            trcktech = Techidbox.Text;


            getSqlServer.ExecuteNonQuery("update dttracking set ordernumber = @ordernumber,TRACKING= '" + tracktag + "',TRACKINGCOMMENT='" + trackcomnt + "',tracklocation = '" + trakloct + "', tracktechid = '" + trcktech + "'  WHERE ordernumber = '" + ordernumber1 + "' and tracklocation = '" + trakloct + "'",
                new SqlParameter("@ordernumber", ordernumber1));

            ORDERNUMBER.Focus();

        }

        public void readDowntimeTable()
        {
            SUBMITTRACK.Focus();

            Option<DataRow> rowOption = getSqlServer.FilledRowOption("select TOP 1 * from dttracking where ordernumber like '" + this.ORDERNUMBER.Text + "' and tracklocation like '" + this.trklocatn.Text + "' ORDER BY ID DESC");

            rowOption.forEach(r =>
            {
                ORDERNUMBER.Text = r["ordernumber"].ToString();
                OLDTRACKTAG.Text = r["tracking"].ToString();
                oldtrackingcomment.Text = r["trackingcomment"].ToString();
                OLDTECH.Text = r["tracktechid"].ToString();
                OLDTRKLOCATN.Text = r["tracklocation"].ToString();
                if (this.OLDTRACKTAG.Text == OLDTRACKTAG.Text)
                {
                    string msg = null;
                    string title = null;
                    MsgBoxStyle style = default(MsgBoxStyle);
                    MsgBoxResult response = default(MsgBoxResult);
                    msg = "Do you wish to edit tracking information?";
                    // Define message.
                    style = MsgBoxStyle.YesNo;
                    title = "MsgBox";
                    // Define title.
                    // Display message.
                    response = Interaction.MsgBox(msg, style, title);
                    if (response == MsgBoxResult.Yes)
                        trackcomment.Focus();
                    if (response == MsgBoxResult.No)
                        msgboxno();
                }
                trackcomment.Text = OLDTRACKTAG.Text + "," + oldtrackingcomment.Text;

                Application.DoEvents();
                //Display the changes immediately (redraw the label text)
                System.Threading.Thread.Sleep(500);
                //do it slow enough so we can actually read the text before it changes, pause half a second

            });
      

          
        }




        public void readtracking1()
        {
            SUBMITTRACK.Visible = true;
            readDowntimeTable();
            Techidbox.Text = GlobalMutableState.userName;

        }


        public void msgboxno()
        {
            foreach (Control C in this.Controls)
            {
                if (C is TextBox)
                {
                    TextBox TB = (TextBox)C;
                    if (object.ReferenceEquals(TB, this.tracktagbox))
                    {
                        string tag = TB.Text;
                        TB.Text = tag;
                        continue;
                    }
                    TB.Clear();
                }
            }
        }


        public void trackmsgbox()
        {
            string msg = null;
            string title = null;
            MsgBoxStyle style = default(MsgBoxStyle);
            MsgBoxResult response = default(MsgBoxResult);

            msg = "Track Tag Does Not Match Expected Format";
            // Define message.
            style = MsgBoxStyle.OkOnly;
            title = "MsgBox";
            // Define title.
            // Display message.
            response = Interaction.MsgBox(msg, style, title);

            if (response == MsgBoxResult.Ok)
                return;
        }

        /// <summary>
        /// The calculation to increment the tracking tag
        /// </summary>
        /// <param name="tag"></param>
        /// <returns></returns>
        protected virtual string IncrementTrackingTag(string tag)
        {
            throw new NotImplementedException("This function must be overridden in all derived classes.");
        }

        /// <summary>
        /// the Length that the Tracking Tag must be to be valid
        /// </summary>
        /// <returns></returns>
        protected virtual int RequiredTagLength()
        {
            throw new NotImplementedException("This function must be overridden in all derived classes.");
        }

        private void SUBMITTRACK_Click(System.Object sender, System.EventArgs e)
        {

            if (tracktagbox.Text == "")
            {
                Interaction.MsgBox("track tag missing", MsgBoxStyle.OkOnly, "MsgBox");

                return;
            }
            if (trklocatn.Text == "")
            {
                Interaction.MsgBox("no tracking location selected", MsgBoxStyle.OkOnly, "MsgBox");

                return;
            }

            if (tracktagbox.Text.Length != RequiredTagLength())
            {
                MessageBox.Show("Track Tag Does Not Match Expected Format", "MsgBox");
            }
            
            if (trackcomment.Text == "")
            {
                writeDowntimeTable2();
            }

            if (!(trackcomment.Text == ""))
            {
                writeDowntimeTable();
            }

            this.ClearAllInputControls(this.tracktagbox);
            this.tracktagbox.Text = IncrementTrackingTag(this.tracktagbox.Text);
          

            ORDERNUMBER.Enabled = true;
            ORDERNUMBER.Focus();
        }


        public void ORDERNUMBER_keypress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == Strings.Chr(13)) //check for Enter key
            {
                SUBMITTRACK.Enabled = true;
                if (tracktagbox.Text == string.Empty)
                {
                    checktracktag();
                }
                if (ORDERNUMBER.Text.Length == 10)
                {
                    readDowntimeTable();
                    tracktagbox.Focus();
                }
                Techidbox.Text = GlobalMutableState.userName;
            }

        }

     
        public void checktracktag()
        {
            ORDERNUMBER.Enabled = false;   

            Interaction.MsgBox("enter requierd info in Track Tag feild.",
                MsgBoxStyle.OkOnly, "MsgBox");
   
            tracktagbox.Focus();

        }

        private void Techidbox_TextChanged(System.Object sender, System.EventArgs e)
        {
            Techidbox.Text = GlobalMutableState.userName; ;
        }


        public void tracktag_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {
            if (e.KeyChar == Strings.Chr(13))
            {
                SUBMITTRACK_Click(this, EventArgs.Empty);
            }

        }


        private void trklocatn_SelectedIndexChanged(System.Object sender, System.EventArgs e)
        {
            bool valid = trklocatn.Text.Length > 0;

            trackcomment.Enabled = valid;
            tracktagbox.Enabled = valid;
            ORDERNUMBER.Enabled = valid;
            
            ORDERNUMBER.Focus();
        }
    }
}

