namespace downtimeC
{
    partial class RecoveryForm
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
            this.Button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(55, 26);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(73, 13);
            this.Label1.TabIndex = 4;
            this.Label1.Text = "Order Number";
            // 
            // TextBoxOrderNumber
            // 
            this.TextBoxOrderNumber.Location = new System.Drawing.Point(37, 52);
            this.TextBoxOrderNumber.MaxLength = 10;
            this.TextBoxOrderNumber.Name = "TextBoxOrderNumber";
            this.TextBoxOrderNumber.Size = new System.Drawing.Size(121, 20);
            this.TextBoxOrderNumber.TabIndex = 3;
            this.TextBoxOrderNumber.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxOrderNumber_KeyPress);
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(62, 103);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(75, 23);
            this.Button1.TabIndex = 2;
            this.Button1.Text = "Button1";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // RecoveryForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(214, 164);
            this.Controls.Add(this.Label1);
            this.Controls.Add(this.TextBoxOrderNumber);
            this.Controls.Add(this.Button1);
            this.Name = "RecoveryForm";
            this.Text = "RecoveryForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.TextBox TextBoxOrderNumber;
        internal System.Windows.Forms.Button Button1;
    }
}