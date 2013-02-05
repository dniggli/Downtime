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
            this.ButtonWrite = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ordernumber
            // 
            this.ordernumber.TextChanged += new System.EventHandler(this.ordernumber_TextChanged);
            // 
            // TextBoxbillingnumber
            // 
            this.TextBoxbillingnumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.TextBoxbillingnumber_KeyPress);
            // 
            // ComboBoxprinter
            // 
            this.ComboBoxprinter.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ComboBoxprinter_KeyPress);
            // 
            // OTHERBOX
            // 
            this.OTHERBOX.LabelPrintMode = downtimeC.LabelPrintMode.Collection;
            // 
            // Viralloadbox
            // 
            this.Viralloadbox.LabelPrintMode = downtimeC.LabelPrintMode.Collection;
            // 
            // fluidbox
            // 
            this.fluidbox.LabelPrintMode = downtimeC.LabelPrintMode.Collection;
            // 
            // csfbox
            // 
            this.csfbox.LabelPrintMode = downtimeC.LabelPrintMode.Collection;
            // 
            // sendout
            // 
            this.sendout.LabelPrintMode = downtimeC.LabelPrintMode.Collection;
            // 
            // ser
            // 
            this.ser.LabelPrintMode = downtimeC.LabelPrintMode.Collection;
            // 
            // hepp
            // 
            this.hepp.LabelPrintMode = downtimeC.LabelPrintMode.Collection;
            // 
            // buttonRead
            // 
            this.buttonRead.Click += new System.EventHandler(this.buttonRead_Click_1);
            // 
            // cal1
            // 
            this.cal1.TextChanged += new System.EventHandler(this.cal1_TextChanged);
            // 
            // bloodgas
            // 
            this.bloodgas.LabelPrintMode = downtimeC.LabelPrintMode.Collection;
            // 
            // urinechem
            // 
            this.urinechem.LabelPrintMode = downtimeC.LabelPrintMode.Collection;
            // 
            // urinehem
            // 
            this.urinehem.LabelPrintMode = downtimeC.LabelPrintMode.Collection;
            // 
            // graytest
            // 
            this.graytest.LabelPrintMode = downtimeC.LabelPrintMode.Collection;
            // 
            // lavchemtest
            // 
            this.lavchemtest.LabelPrintMode = downtimeC.LabelPrintMode.Collection;
            // 
            // greentest
            // 
            this.greentest.LabelPrintMode = downtimeC.LabelPrintMode.Collection;
            // 
            // lavhemtest
            // 
            this.lavhemtest.LabelPrintMode = downtimeC.LabelPrintMode.Collection;
            // 
            // bluetest
            // 
            this.bluetest.LabelPrintMode = downtimeC.LabelPrintMode.Collection;
            // 
            // redtest
            // 
            this.redtest.LabelPrintMode = downtimeC.LabelPrintMode.Collection;
            // 
            // ButtonFill
            // 
            this.ButtonFill.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            // 
            // TextBoxIMMUNO
            // 
            this.TextBoxIMMUNO.LabelPrintMode = downtimeC.LabelPrintMode.Collection;
            // 
            // ComboBoxoldorder
            // 
            this.ComboBoxoldorder.SelectedIndexChanged += new System.EventHandler(this.ComboBoxoldorder_SelectedIndexChanged);
            // 
            // ButtonWrite
            // 
            this.ButtonWrite.Location = new System.Drawing.Point(773, 340);
            this.ButtonWrite.Name = "ButtonWrite";
            this.ButtonWrite.Size = new System.Drawing.Size(160, 23);
            this.ButtonWrite.TabIndex = 185;
            this.ButtonWrite.Text = "Print";
            this.ButtonWrite.UseVisualStyleBackColor = true;
            this.ButtonWrite.Click += new System.EventHandler(this.ButtonPrint_Click);
            // 
            // OrderEntryForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 769);
            this.Controls.Add(this.ButtonWrite);
            this.Name = "OrderEntryForm2";
            this.Text = "OrderEntryForm";
            this.Controls.SetChildIndex(this.firstname, 0);
            this.Controls.SetChildIndex(this.ButtonFill, 0);
            this.Controls.SetChildIndex(this.lastname, 0);
            this.Controls.SetChildIndex(this.collectiontime, 0);
            this.Controls.SetChildIndex(this.receivetime, 0);
            this.Controls.SetChildIndex(this.ComboBoxPriority, 0);
            this.Controls.SetChildIndex(this.mrn, 0);
            this.Controls.SetChildIndex(this.DOB, 0);
            this.Controls.SetChildIndex(this.redtest, 0);
            this.Controls.SetChildIndex(this.bluetest, 0);
            this.Controls.SetChildIndex(this.lavhemtest, 0);
            this.Controls.SetChildIndex(this.greentest, 0);
            this.Controls.SetChildIndex(this.lavchemtest, 0);
            this.Controls.SetChildIndex(this.graytest, 0);
            this.Controls.SetChildIndex(this.urinehem, 0);
            this.Controls.SetChildIndex(this.urinechem, 0);
            this.Controls.SetChildIndex(this.bloodgas, 0);
            this.Controls.SetChildIndex(this.problem, 0);
            this.Controls.SetChildIndex(this.cal1, 0);
            this.Controls.SetChildIndex(this.comment, 0);
            this.Controls.SetChildIndex(this.buttonRead, 0);
            this.Controls.SetChildIndex(this.hepp, 0);
            this.Controls.SetChildIndex(this.ser, 0);
            this.Controls.SetChildIndex(this.sendout, 0);
            this.Controls.SetChildIndex(this.DateTimePicker1, 0);
            this.Controls.SetChildIndex(this.TextboxCollectDate, 0);
            this.Controls.SetChildIndex(this.ordertechid, 0);
            this.Controls.SetChildIndex(this.csfbox, 0);
            this.Controls.SetChildIndex(this.fluidbox, 0);
            this.Controls.SetChildIndex(this.Viralloadbox, 0);
            this.Controls.SetChildIndex(this.OTHERBOX, 0);
            this.Controls.SetChildIndex(this.ComboBoxprinter, 0);
            this.Controls.SetChildIndex(this.comboBoxWard, 0);
            this.Controls.SetChildIndex(this.TextBoxIMMUNO, 0);
            this.Controls.SetChildIndex(this.editorder, 0);
            this.Controls.SetChildIndex(this.Buttoneditprevious, 0);
            this.Controls.SetChildIndex(this.ComboBoxoldorder, 0);
            this.Controls.SetChildIndex(this.ButtonWrite, 0);
            this.Controls.SetChildIndex(this.ordernumber, 0);
            this.Controls.SetChildIndex(this.TextBoxbillingnumber, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Button ButtonWrite;
    }
}