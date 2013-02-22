namespace Automator
{
    partial class Main
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
            this.buttonStart = new System.Windows.Forms.Button();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.textboxMaxStringLen = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.textboxDelayButton = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textboxDelayKeyEntry = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.buttonSaveSettings = new System.Windows.Forms.Button();
            this.buttonQuit = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.buttonUndoChanges = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.textboxKeyMetrics = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.textboxKeyTotal = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.textboxTimeElapsed = new System.Windows.Forms.TextBox();
            this.textboxTimeStart = new System.Windows.Forms.TextBox();
            this.textboxTimeEnd = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(395, 119);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(90, 47);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Start";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.textboxMaxStringLen);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.textboxDelayButton);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label6);
            this.groupBox2.Controls.Add(this.textboxDelayKeyEntry);
            this.groupBox2.Controls.Add(this.label5);
            this.groupBox2.Location = new System.Drawing.Point(202, 12);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(391, 101);
            this.groupBox2.TabIndex = 2;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Settings ";
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(174, 72);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(180, 13);
            this.label17.TabIndex = 24;
            this.label17.Text = "( Maximum string length for answers )";
            // 
            // textboxMaxStringLen
            // 
            this.textboxMaxStringLen.Location = new System.Drawing.Point(101, 69);
            this.textboxMaxStringLen.Name = "textboxMaxStringLen";
            this.textboxMaxStringLen.Size = new System.Drawing.Size(69, 20);
            this.textboxMaxStringLen.TabIndex = 22;
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(9, 72);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(81, 13);
            this.label15.TabIndex = 21;
            this.label15.Text = "Max String Len.";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(174, 47);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(171, 13);
            this.label9.TabIndex = 18;
            this.label9.Text = "( Next action delay in milliseconds )";
            // 
            // textboxDelayButton
            // 
            this.textboxDelayButton.Location = new System.Drawing.Point(101, 43);
            this.textboxDelayButton.Name = "textboxDelayButton";
            this.textboxDelayButton.Size = new System.Drawing.Size(69, 20);
            this.textboxDelayButton.TabIndex = 17;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(9, 46);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(67, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Action Delay";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(174, 21);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(186, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "( Typing speed, keypress delay in ms )";
            // 
            // textboxDelayKeyEntry
            // 
            this.textboxDelayKeyEntry.Location = new System.Drawing.Point(101, 17);
            this.textboxDelayKeyEntry.Name = "textboxDelayKeyEntry";
            this.textboxDelayKeyEntry.Size = new System.Drawing.Size(69, 20);
            this.textboxDelayKeyEntry.TabIndex = 11;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(9, 20);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(82, 13);
            this.label5.TabIndex = 10;
            this.label5.Text = "Key Entry Delay";
            // 
            // buttonSaveSettings
            // 
            this.buttonSaveSettings.Location = new System.Drawing.Point(203, 119);
            this.buttonSaveSettings.Name = "buttonSaveSettings";
            this.buttonSaveSettings.Size = new System.Drawing.Size(90, 47);
            this.buttonSaveSettings.TabIndex = 3;
            this.buttonSaveSettings.Text = "Save Settings";
            this.buttonSaveSettings.UseVisualStyleBackColor = true;
            this.buttonSaveSettings.Click += new System.EventHandler(this.buttonSaveSettings_Click);
            // 
            // buttonQuit
            // 
            this.buttonQuit.Location = new System.Drawing.Point(491, 119);
            this.buttonQuit.Name = "buttonQuit";
            this.buttonQuit.Size = new System.Drawing.Size(90, 47);
            this.buttonQuit.TabIndex = 4;
            this.buttonQuit.Text = "Quit";
            this.buttonQuit.UseVisualStyleBackColor = true;
            this.buttonQuit.Click += new System.EventHandler(this.buttonQuit_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.AutoSize = true;
            this.labelStatus.Location = new System.Drawing.Point(9, 23);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(37, 13);
            this.labelStatus.TabIndex = 5;
            this.labelStatus.Text = "Status";
            // 
            // buttonUndoChanges
            // 
            this.buttonUndoChanges.Location = new System.Drawing.Point(299, 119);
            this.buttonUndoChanges.Name = "buttonUndoChanges";
            this.buttonUndoChanges.Size = new System.Drawing.Size(90, 47);
            this.buttonUndoChanges.TabIndex = 6;
            this.buttonUndoChanges.Text = "&Undo Changes";
            this.buttonUndoChanges.UseVisualStyleBackColor = true;
            this.buttonUndoChanges.Click += new System.EventHandler(this.buttonUndoChanges_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.textboxKeyMetrics);
            this.groupBox3.Controls.Add(this.label18);
            this.groupBox3.Controls.Add(this.textboxKeyTotal);
            this.groupBox3.Controls.Add(this.label13);
            this.groupBox3.Controls.Add(this.label12);
            this.groupBox3.Controls.Add(this.textboxTimeElapsed);
            this.groupBox3.Controls.Add(this.textboxTimeStart);
            this.groupBox3.Controls.Add(this.textboxTimeEnd);
            this.groupBox3.Controls.Add(this.label11);
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(184, 155);
            this.groupBox3.TabIndex = 7;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Timer / Performance Metrics ";
            // 
            // textboxKeyMetrics
            // 
            this.textboxKeyMetrics.Location = new System.Drawing.Point(11, 124);
            this.textboxKeyMetrics.Name = "textboxKeyMetrics";
            this.textboxKeyMetrics.Size = new System.Drawing.Size(159, 20);
            this.textboxKeyMetrics.TabIndex = 8;
            this.textboxKeyMetrics.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(8, 101);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(59, 13);
            this.label18.TabIndex = 7;
            this.label18.Text = "Keystrokes";
            // 
            // textboxKeyTotal
            // 
            this.textboxKeyTotal.Location = new System.Drawing.Point(73, 98);
            this.textboxKeyTotal.Name = "textboxKeyTotal";
            this.textboxKeyTotal.Size = new System.Drawing.Size(97, 20);
            this.textboxKeyTotal.TabIndex = 6;
            this.textboxKeyTotal.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(8, 49);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(52, 13);
            this.label13.TabIndex = 5;
            this.label13.Text = "End Time";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(8, 75);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(45, 13);
            this.label12.TabIndex = 4;
            this.label12.Text = "Elapsed";
            // 
            // textboxTimeElapsed
            // 
            this.textboxTimeElapsed.Location = new System.Drawing.Point(73, 72);
            this.textboxTimeElapsed.Name = "textboxTimeElapsed";
            this.textboxTimeElapsed.Size = new System.Drawing.Size(97, 20);
            this.textboxTimeElapsed.TabIndex = 3;
            this.textboxTimeElapsed.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textboxTimeStart
            // 
            this.textboxTimeStart.Location = new System.Drawing.Point(73, 20);
            this.textboxTimeStart.Name = "textboxTimeStart";
            this.textboxTimeStart.Size = new System.Drawing.Size(97, 20);
            this.textboxTimeStart.TabIndex = 2;
            this.textboxTimeStart.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // textboxTimeEnd
            // 
            this.textboxTimeEnd.Location = new System.Drawing.Point(73, 46);
            this.textboxTimeEnd.Name = "textboxTimeEnd";
            this.textboxTimeEnd.Size = new System.Drawing.Size(97, 20);
            this.textboxTimeEnd.TabIndex = 1;
            this.textboxTimeEnd.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(8, 23);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(55, 13);
            this.label11.TabIndex = 0;
            this.label11.Text = "Start Time";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.labelStatus);
            this.groupBox4.Location = new System.Drawing.Point(12, 172);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(581, 52);
            this.groupBox4.TabIndex = 8;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Status";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(605, 236);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.buttonUndoChanges);
            this.Controls.Add(this.buttonSaveSettings);
            this.Controls.Add(this.buttonQuit);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.buttonStart);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Main";
            this.Text = "The \"Automator\"";
            this.Load += new System.EventHandler(this.Main_Load);
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Main_FormClosing);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button buttonSaveSettings;
        private System.Windows.Forms.Button buttonQuit;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textboxDelayKeyEntry;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label labelStatus;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox textboxDelayButton;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button buttonUndoChanges;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox textboxTimeElapsed;
        private System.Windows.Forms.TextBox textboxTimeStart;
        private System.Windows.Forms.TextBox textboxTimeEnd;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.TextBox textboxMaxStringLen;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.TextBox textboxKeyTotal;
        private System.Windows.Forms.TextBox textboxKeyMetrics;

    }
}

