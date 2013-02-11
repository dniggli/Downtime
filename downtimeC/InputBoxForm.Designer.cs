namespace downtimeC
{
    partial class InputBoxForm
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
            this.LabelTestError = new System.Windows.Forms.Label();
            this.ButtonInput = new System.Windows.Forms.Button();
            this.TextBoxTestFix = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // LabelTestError
            // 
            this.LabelTestError.AutoSize = true;
            this.LabelTestError.Location = new System.Drawing.Point(12, 14);
            this.LabelTestError.Name = "LabelTestError";
            this.LabelTestError.Size = new System.Drawing.Size(29, 13);
            this.LabelTestError.TabIndex = 5;
            this.LabelTestError.Text = "label";
            // 
            // ButtonInput
            // 
            this.ButtonInput.Location = new System.Drawing.Point(12, 100);
            this.ButtonInput.Name = "ButtonInput";
            this.ButtonInput.Size = new System.Drawing.Size(75, 23);
            this.ButtonInput.TabIndex = 4;
            this.ButtonInput.Text = "ok";
            this.ButtonInput.UseVisualStyleBackColor = true;
            this.ButtonInput.Click += new System.EventHandler(this.ButtonInput_Click);
            // 
            // TextBoxTestFix
            // 
            this.TextBoxTestFix.Location = new System.Drawing.Point(12, 52);
            this.TextBoxTestFix.Name = "TextBoxTestFix";
            this.TextBoxTestFix.Size = new System.Drawing.Size(175, 20);
            this.TextBoxTestFix.TabIndex = 3;
            this.TextBoxTestFix.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TextBoxTestFix_KeyPress);
            // 
            // InputBoxForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(216, 147);
            this.Controls.Add(this.LabelTestError);
            this.Controls.Add(this.ButtonInput);
            this.Controls.Add(this.TextBoxTestFix);
            this.Name = "InputBoxForm";
            this.Text = "InputBoxForm";
            this.Load += new System.EventHandler(this.InputBoxForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        internal System.Windows.Forms.Label LabelTestError;
        internal System.Windows.Forms.Button ButtonInput;
        internal System.Windows.Forms.TextBox TextBoxTestFix;
    }
}