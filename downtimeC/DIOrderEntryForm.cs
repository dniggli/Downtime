using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CodeBase2;
using CodeBase2.EmbeddedResources;
using FunctionalCSharp;
using Microsoft.VisualBasic;
using System.Collections;
using System.Data;
using System.Diagnostics;
using NUnit.Framework;
using AutoItHelper;
using System.Threading;
using System.Text.RegularExpressions;
using MySql.Data.MySqlClient;
using HL7;

namespace downtimeC
{
    [TestFixture()]
    public partial class DIOrderEntryForm : Form
    {
       protected DIOrderEntryForm()
        {
            InitializeComponent();
        }

        readonly GetMySQL getMySql;
        public DIOrderEntryForm(GetMySQL getMySql)
        {
            InitializeComponent();
            this.getMySql = getMySql;
        }

            public static Dictionary<string, string[]> DICT = new Dictionary<string, string[]>();
        public static void DIRecover()
        {
            if (AutoItX.WinExists("Instrument Manager by Data Innovations, Inc. for Roche Diagnostics - [Patient and Order Management]"))
            {
                DIOrderEntryForm myorder = new DIOrderEntryForm();
                Application.Run(myorder);
            }
            else
            {
               var response = Interaction.MsgBox("You must be logged into DI with username: SMS and password: URMCLAB", MsgBoxStyle.DefaultButton1, "MsgBox");
                if (response == MsgBoxResult.Ok)
                {
                    return;
                }
            }
        }
        Thread inputboxx;

        public static string wrongtests = "";
        [Test()]

        public void ButtonSubmit_Click(System.Object sender, System.EventArgs e)
        {

        }



        private void TextBoxOrderNumber_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
        {

        }


        public void msgboxs()
        {

            DialogResult response = default(DialogResult);

            response = MessageBox.Show("Order Has Been Placed.  would you like to place another order?", "Order Finished", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1, MessageBoxOptions.DefaultDesktopOnly, false);

            if (response == System.Windows.Forms.DialogResult.Yes)
            {
                AutoItHelper.AutoItX.ControlClick("Instrument Manager by Data Innovations, Inc. for Roche Diagnostics - [Patient and Order Management]", "", "[CLASS:ThunderRT6PictureBoxDC; INSTANCE:7]", "", 1, 42, 15);


                //Me.Activate()
                //Me.TextBoxOrderNumber.Clear()


            }


            if (response == System.Windows.Forms.DialogResult.No)
            {
                AutoItHelper.AutoItX.ControlClick("Instrument Manager by Data Innovations, Inc. for Roche Diagnostics - [Patient and Order Management]", "", "[CLASS:ThunderRT6PictureBoxDC; INSTANCE:7]", "", 1, 42, 15);
                return;
            }


        }



        private void Button1_Click(System.Object sender, System.EventArgs e)
        {
            DataTable dt = new DataTable();
            MySqlDataAdapter ditests = new MySqlDataAdapter("select * from dtdb1.DITests;", "server=lis-s22104-db1;uid=dniggli;pwd=vvo084;");
            ditests.Fill(dt);

            foreach (DataRow dr in dt.Rows)
            {
                string ditest = dr["TestCode"].ToString();
                string sequence = dr["CodeSequence"].ToString();
                System.Text.RegularExpressions.Match newseq = Regex.Match(sequence, "([A-Z]+)");
                sequence = newseq.Groups[0].Value;
                Console.WriteLine(sequence);

                MySqlCommand comm2 = new MySqlCommand("INSERT INTO dtdb1.DITests1 (TestCode, CodeSequence)Values('" + ditest + "', '" + sequence + "')", new MySqlConnection("server=lis-s22104-db1;uid=dniggli;pwd=vvo084;"));
                comm2.Connection.Open();
                comm2.ExecuteNonQuery();
                comm2.Connection.Close();
            }
        }
}


    }
