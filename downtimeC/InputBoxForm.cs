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

namespace downtimeC
{
    public partial class InputBoxForm : Form
    {
        public InputBoxForm()
        {
            InitializeComponent();
        }

    private void InputBoxForm_Load(object sender, System.EventArgs e)
    {
        this.TopMost = true;
        this.Activate();

        string a = "Please enter correct test for:" + " " + RecoveryForm.tests;


        this.LabelTestError.Text = a;


        this.TextBoxTestFix.Focus();
        //InputBoxFormRecover.TextBoxTestFix.Text = b
        //Me.label()


    }


    private void ButtonInput_Click(object sender, System.EventArgs e)
    {
        RecoveryForm.fixTEST = TextBoxTestFix.Text;
        this.Close();
    }
    public void label()
    {
        string a = "Please enter correct test for:";
        string b = a + " " + RecoveryForm.tests;
        this.LabelTestError.Text = b;
        Console.WriteLine(this.LabelTestError.Text);
    }



    private void TextBoxTestFix_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
    {
        if (e.KeyChar == Strings.Chr(13)) {
            ButtonInput_Click(this, EventArgs.Empty);
        }

    }

    }
}
