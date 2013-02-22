namespace downtimeC
{
    partial class OrderEntryForm2
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            FunctionalCSharp.None<string> none_117 = new FunctionalCSharp.None<string>();
            FunctionalCSharp.None<string> none_118 = new FunctionalCSharp.None<string>();
            FunctionalCSharp.None<string> none_119 = new FunctionalCSharp.None<string>();
            FunctionalCSharp.None<string> none_120 = new FunctionalCSharp.None<string>();
            FunctionalCSharp.None<string> none_121 = new FunctionalCSharp.None<string>();
            FunctionalCSharp.None<string> none_122 = new FunctionalCSharp.None<string>();
            FunctionalCSharp.None<string> none_123 = new FunctionalCSharp.None<string>();
            FunctionalCSharp.None<string> none_124 = new FunctionalCSharp.None<string>();
            FunctionalCSharp.None<string> none_125 = new FunctionalCSharp.None<string>();
            FunctionalCSharp.None<string> none_126 = new FunctionalCSharp.None<string>();
            FunctionalCSharp.None<string> none_127 = new FunctionalCSharp.None<string>();
            FunctionalCSharp.None<string> none_128 = new FunctionalCSharp.None<string>();
            FunctionalCSharp.None<string> none_129 = new FunctionalCSharp.None<string>();
            FunctionalCSharp.None<string> none_130 = new FunctionalCSharp.None<string>();
            FunctionalCSharp.None<string> none_131 = new FunctionalCSharp.None<string>();
            FunctionalCSharp.None<string> none_132 = new FunctionalCSharp.None<string>();
            this.ButtonReset = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ordernumber
            // 
            this.ordernumber.TextOption = none_117;
            this.ordernumber.TextChanged += new System.EventHandler(this.ordernumber_TextChanged);
            this.ordernumber.Leave += new System.EventHandler(this.orderNumberTextBox_Leave);
            // 
            // TextBoxbillingnumber
            // 
            this.TextBoxbillingnumber.TextOption = none_118;
            this.TextBoxbillingnumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxbillingnumber_KeyPress);
            // 
            // comboBoxWard
            // 
            this.comboBoxWard.TextOption = none_119;
            // 
            // TextboxCollectDate
            // 
            this.TextboxCollectDate.TextOption = none_120;
            // 
            // comment
            // 
            this.comment.TextOption = none_121;
            // 
            // cal1
            // 
            this.cal1.TextOption = none_122;
            // 
            // problem
            // 
            this.problem.TextOption = none_123;
            // 
            // DOB
            // 
            this.DOB.TextOption = none_124;
            // 
            // mrn
            // 
            this.mrn.TextOption = none_125;
            // 
            // receivetime
            // 
            this.receivetime.TextOption = none_126;
            // 
            // collectiontime
            // 
            this.collectiontime.TextOption = none_127;
            // 
            // lastname
            // 
            this.lastname.TextOption = none_128;
            // 
            // DebugButtonFill
            // 
            this.DebugButtonFill.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            // 
            // firstname
            // 
            this.firstname.TextOption = none_129;
            // 
            // ButtonEditorder
            // 
            this.ButtonEditorder.Visible = true;
            this.ButtonEditorder.Click += new System.EventHandler(this.editorder_Click);
            // 
            // Buttoneditprevious
            // 
            this.Buttoneditprevious.Text = "Edit Recent Order";
            this.Buttoneditprevious.Visible = true;
            this.Buttoneditprevious.Click += new System.EventHandler(this.Buttoneditprevious_Click);
            // 
            // ComboBoxoldorder
            // 
            this.ComboBoxRecentOrder.Visible = true;
            this.ComboBoxRecentOrder.SelectedIndexChanged += new System.EventHandler(this.ComboBoxRecentOrder_SelectedIndexChanged);
            // 
            // ComboBoxPriority
            // 
            this.ComboBoxPriority.TextOption = none_130;
            // 
            // Label32
            // 
            this.Label32.Visible = true;
            // 
            // ComboboxPrinter
            // 
            this.ComboboxPrinter.TextOption = none_131;
            // 
            // textBoxAddTest
            // 
            this.textBoxAddTest.TextOption = none_132;
            // 
            // ButtonReset
            // 
            this.ButtonReset.Location = new System.Drawing.Point(45, 54);
            this.ButtonReset.Name = "ButtonReset";
            this.ButtonReset.Size = new System.Drawing.Size(75, 23);
            this.ButtonReset.TabIndex = 283;
            this.ButtonReset.Text = "Reset Form";
            this.ButtonReset.UseVisualStyleBackColor = true;
            this.ButtonReset.Click += new System.EventHandler(this.ButtonReset_Click);
            // 
            // OrderEntryForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 787);
            this.Controls.Add(this.ButtonReset);
            this.Name = "OrderEntryForm2";
            this.Text = "OrderEntryForm";
            this.Controls.SetChildIndex(this.ButtonReset, 0);
            this.Controls.SetChildIndex(this.ordernumber, 0);
            this.Controls.SetChildIndex(this.firstname, 0);
            this.Controls.SetChildIndex(this.DebugButtonFill, 0);
            this.Controls.SetChildIndex(this.lastname, 0);
            this.Controls.SetChildIndex(this.collectiontime, 0);
            this.Controls.SetChildIndex(this.receivetime, 0);
            this.Controls.SetChildIndex(this.mrn, 0);
            this.Controls.SetChildIndex(this.DOB, 0);
            this.Controls.SetChildIndex(this.problem, 0);
            this.Controls.SetChildIndex(this.cal1, 0);
            this.Controls.SetChildIndex(this.comment, 0);
            this.Controls.SetChildIndex(this.DebugButtonRead, 0);
            this.Controls.SetChildIndex(this.DateTimePicker1, 0);
            this.Controls.SetChildIndex(this.TextboxCollectDate, 0);
            this.Controls.SetChildIndex(this.TextBoxTechId, 0);
            this.Controls.SetChildIndex(this.ComboboxPrinter, 0);
            this.Controls.SetChildIndex(this.TextBoxbillingnumber, 0);
            this.Controls.SetChildIndex(this.comboBoxWard, 0);
            this.Controls.SetChildIndex(this.ButtonEditorder, 0);
            this.Controls.SetChildIndex(this.Buttoneditprevious, 0);
            this.Controls.SetChildIndex(this.ComboBoxRecentOrder, 0);
            this.Controls.SetChildIndex(this.Label32, 0);
            this.Controls.SetChildIndex(this.ComboBoxPriority, 0);
            this.Controls.SetChildIndex(this.ComboboxPrintType, 0);
            this.Controls.SetChildIndex(this.label6, 0);
            this.Controls.SetChildIndex(this.textBoxAddTest, 0);
            this.Controls.SetChildIndex(this.buttonAddTest, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button ButtonReset;

    }
}