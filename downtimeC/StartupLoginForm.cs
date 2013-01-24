﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.VisualBasic;

namespace downtimeC
{
    public partial class StartupLoginForm : Form
    {

        public StartupLoginForm()
        {
            InitializeComponent();
        }

        public Boolean valid = true;

        public string userName = "";

        private void OK_Click(System.Object sender, System.EventArgs e)
        {

            //valid = AD.Authenticate(Me.UsernameTextBox.Text, Me.PasswordTextBox.Text)
            
            if (valid)
            {
                userName = UsernameTextBox.Text;
                this.Close();
            }
            else
            {
               var response = Interaction.MsgBox("invalid username or password", MsgBoxStyle.OkOnly, "MsgBox");
                if (response == MsgBoxResult.Ok)
                    UsernameTextBox.Focus();
            }

        }

        private void Cancel_Click(System.Object sender, System.EventArgs e)
        {
            this.Close();
        }
    }
}
