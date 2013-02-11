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

        public static void DIRecover()
        {
            if (AutoItX.WinExists("Instrument Manager by Data Innovations, Inc. for Roche Diagnostics - [Patient and Order Management]"))
            {
                DIOrderEntryForm myorder = new DIOrderEntryForm();
                Application.Run(myorder);
            }
            else
            {
                Interaction.MsgBox("You must be logged into DI with username: SMS and password: URMCLAB", MsgBoxStyle.DefaultButton1, "MsgBox");
            }
        }
       
        private void Button1_Click(System.Object sender, System.EventArgs e)
        {
            DataTable dt = getMySql.FilledTable("select * from dtdb1.DITests;");

            foreach (DataRow dr in dt.Rows)
            {
                string ditest = dr["TestCode"].ToString();
                System.Text.RegularExpressions.Match newseq = Regex.Match(dr["CodeSequence"].ToString(), "([A-Z]+)");
                string sequence = newseq.Groups[0].Value;
                Console.WriteLine(sequence);

                getMySql.ExecuteNonQuery("INSERT INTO dtdb1.DITests1 (TestCode, CodeSequence)Values('" + ditest + "', '" + sequence + "')");
            }
        }
}


    }
