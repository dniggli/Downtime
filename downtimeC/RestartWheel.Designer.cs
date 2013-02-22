namespace downtimeC
{
    partial class RestartWheel
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
            this.SplitContainer1 = new System.Windows.Forms.SplitContainer();
            this.Label1 = new System.Windows.Forms.Label();
            this.ComboBoxNewOrderNumber = new System.Windows.Forms.ComboBox();
            this.ButtonNumberReset = new System.Windows.Forms.Button();
            this.Button1 = new System.Windows.Forms.Button();
            this.Buttondelettrack = new System.Windows.Forms.Button();
            this.SplitContainer1.Panel1.SuspendLayout();
            this.SplitContainer1.Panel2.SuspendLayout();
            this.SplitContainer1.SuspendLayout();
            this.SuspendLayout();
            // 
            // SplitContainer1
            // 
            this.SplitContainer1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.SplitContainer1.Location = new System.Drawing.Point(12, 12);
            this.SplitContainer1.Name = "SplitContainer1";
            // 
            // SplitContainer1.Panel1
            // 
            this.SplitContainer1.Panel1.Controls.Add(this.Label1);
            this.SplitContainer1.Panel1.Controls.Add(this.ComboBoxNewOrderNumber);
            this.SplitContainer1.Panel1.Controls.Add(this.ButtonNumberReset);
            this.SplitContainer1.Panel1.Controls.Add(this.Button1);
            // 
            // SplitContainer1.Panel2
            // 
            this.SplitContainer1.Panel2.Controls.Add(this.Buttondelettrack);
            this.SplitContainer1.Size = new System.Drawing.Size(430, 167);
            this.SplitContainer1.SplitterDistance = 206;
            this.SplitContainer1.TabIndex = 6;
            // 
            // Label1
            // 
            this.Label1.AutoSize = true;
            this.Label1.Location = new System.Drawing.Point(53, 21);
            this.Label1.Name = "Label1";
            this.Label1.Size = new System.Drawing.Size(73, 13);
            this.Label1.TabIndex = 5;
            this.Label1.Text = "Select Order#";
            // 
            // ComboBoxNewOrderNumber
            // 
            this.ComboBoxNewOrderNumber.FormattingEnabled = true;
            this.ComboBoxNewOrderNumber.Location = new System.Drawing.Point(35, 37);
            this.ComboBoxNewOrderNumber.Name = "ComboBoxNewOrderNumber";
            this.ComboBoxNewOrderNumber.Size = new System.Drawing.Size(133, 21);
            this.ComboBoxNewOrderNumber.TabIndex = 4;
            this.ComboBoxNewOrderNumber.KeyDown += new System.Windows.Forms.KeyEventHandler(this.ComboBoxNewOrderNumber_KeyDown);
            // 
            // ButtonNumberReset
            // 
            this.ButtonNumberReset.Location = new System.Drawing.Point(35, 79);
            this.ButtonNumberReset.Name = "ButtonNumberReset";
            this.ButtonNumberReset.Size = new System.Drawing.Size(133, 23);
            this.ButtonNumberReset.TabIndex = 3;
            this.ButtonNumberReset.Text = "Reset Order Number";
            this.ButtonNumberReset.UseVisualStyleBackColor = true;
            this.ButtonNumberReset.Click += new System.EventHandler(this.ButtonNumberReset_Click);
            // 
            // Button1
            // 
            this.Button1.Location = new System.Drawing.Point(35, 121);
            this.Button1.Name = "Button1";
            this.Button1.Size = new System.Drawing.Size(133, 23);
            this.Button1.TabIndex = 2;
            this.Button1.Text = "Clear All Data";
            this.Button1.UseVisualStyleBackColor = true;
            this.Button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Buttondelettrack
            // 
            this.Buttondelettrack.Location = new System.Drawing.Point(41, 54);
            this.Buttondelettrack.Name = "Buttondelettrack";
            this.Buttondelettrack.Size = new System.Drawing.Size(112, 23);
            this.Buttondelettrack.TabIndex = 4;
            this.Buttondelettrack.Text = "Reset Tracking";
            this.Buttondelettrack.UseVisualStyleBackColor = true;
            this.Buttondelettrack.Click += new System.EventHandler(this.Buttondelettrack_Click);
            // 
            // RestartWheel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(463, 194);
            this.Controls.Add(this.SplitContainer1);
            this.Name = "RestartWheel";
            this.Text = "RestartWheel";
            this.Load += new System.EventHandler(this.restartwheel_Load);
            this.SplitContainer1.Panel1.ResumeLayout(false);
            this.SplitContainer1.Panel1.PerformLayout();
            this.SplitContainer1.Panel2.ResumeLayout(false);
            this.SplitContainer1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        internal System.Windows.Forms.SplitContainer SplitContainer1;
        internal System.Windows.Forms.Label Label1;
        internal System.Windows.Forms.ComboBox ComboBoxNewOrderNumber;
        internal System.Windows.Forms.Button ButtonNumberReset;
        internal System.Windows.Forms.Button Button1;
        internal System.Windows.Forms.Button Buttondelettrack;
    }
}