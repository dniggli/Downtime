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
            // ButtonWrite
            // 
            this.ButtonWrite.Location = new System.Drawing.Point(773, 340);
            this.ButtonWrite.Name = "ButtonWrite";
            this.ButtonWrite.Size = new System.Drawing.Size(160, 23);
            this.ButtonWrite.TabIndex = 185;
            this.ButtonWrite.Text = "Print";
            this.ButtonWrite.UseVisualStyleBackColor = true;
            this.ButtonWrite.Click += new System.EventHandler(this.ButtonWrite_Click);
            // 
            // OrderEntryForm2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 769);
            this.Controls.Add(this.ButtonWrite);
            this.Name = "OrderEntryForm2";
            this.Text = "OrderEntryForm";
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