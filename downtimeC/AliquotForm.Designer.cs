namespace downtimeC
{
    partial class AliquotForm
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
            this.ordernumber.KeyUp += new System.Windows.Forms.KeyEventHandler(this.ordernumber_KeyUp);
            // 
            // ComboboxPrinter
            // 
            this.ComboboxPrinter.SelectedIndexChanged += new System.EventHandler(this.ComboBoxprinter_SelectedIndexChanged);
            // 
            // ButtonFill
            // 
            this.DebugButtonFill.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;
            // 
            // ButtonPrint
            // 
            // 
            // label6
            // 
            this.label6.Visible = true;
            // 
            // ComboboxPrintType
            // 
            this.ComboboxPrintType.Visible = true;
            this.ComboboxPrintType.SelectedIndexChanged += new System.EventHandler(this.ComboboxPrintType_SelectedIndexChanged);
            // 
            // AliquotForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(997, 777);
            this.Name = "AliquotForm";
            this.Text = "AliquotForm";
            this.Load += new System.EventHandler(this.aliquotform_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

    }
}