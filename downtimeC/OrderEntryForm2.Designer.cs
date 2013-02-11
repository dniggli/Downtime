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
            // DebugButtonFill
            // 
            this.DebugButtonFill.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            // 
            // TextBoxIMMUNO
            // 
            this.TextBoxIMMUNO.LabelPrintMode = downtimeC.LabelPrintMode.Collection;
            // 
            // editorder
            // 
            this.editorder.Visible = true;
            this.editorder.Click += new System.EventHandler(this.editorder_Click);
            // 
            // Buttoneditprevious
            // 
            this.Buttoneditprevious.Visible = true;
            // 
            // ComboBoxoldorder
            // 
            this.ComboBoxoldorder.Visible = true;
            this.ComboBoxoldorder.SelectedIndexChanged += new System.EventHandler(this.ComboBoxoldorder_SelectedIndexChanged);
            // 
            // Label32
            // 
            this.Label32.Visible = true;
            // 
            // OrderEntryForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 787);
            this.Name = "OrderEntryForm2";
            this.Text = "OrderEntryForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

    }
}