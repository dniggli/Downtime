namespace downtimeC
{
    partial class MolisEntry
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
            this.Label1 = new System.Windows.Forms.Label();
            this.TextBoxOrderNumber = new System.Windows.Forms.TextBox();
            this.ButtonRun = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(12, 18);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(73, 13);
            this.Label1.TabIndex = 5;
            this.Label1.Text = "Order Number";
            // 
            // TextBoxOrderNumber
            // 
            this.TextBoxOrderNumber.Location = new System.Drawing.Point(12, 37);
            this.TextBoxOrderNumber.Name = "TextBoxOrderNumber";
            this.TextBoxOrderNumber.Size = new System.Drawing.Size(132, 20);
            this.TextBoxOrderNumber.TabIndex = 4;
            this.TextBoxOrderNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxOrderNumber_KeyPress);
            // 
            // ButtonRun
            // 
            this.ButtonRun.Location = new System.Drawing.Point(15, 98);
            this.ButtonRun.Name = "ButtonRun";
            this.ButtonRun.Size = new System.Drawing.Size(75, 23);
            this.ButtonRun.TabIndex = 6;
            this.ButtonRun.Text = "Run";
            this.ButtonRun.UseVisualStyleBackColor = true;
            this.ButtonRun.Click += new System.EventHandler(this.ButtonRun_Click);
            // 
            // MolisEntry
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(191, 142);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.TextBoxOrderNumber);
            this.Controls.Add(this.ButtonRun);
            this.Name = "MolisEntry";
            this.Text = "MolisEntry";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox TextBoxOrderNumber;
        internal System.Windows.Forms.Button ButtonRun;
    }
}