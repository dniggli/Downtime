﻿namespace downtimeC
{
    partial class TrackUrineHemForm : TrackingBase
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
            // trklocatn
            // 
            this.trklocatn.Items.AddRange(new object[] {
            "UA->STORE"});
            // 
            // LabelTrackingTagFormat
            // 
            this.LabelTrackingTagFormat.Size = new System.Drawing.Size(75, 13);
            this.LabelTrackingTagFormat.Text = "Format (?###)";
            // 
            // TrackUrineHemForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(724, 468);
            this.Name = "TrackUrineHemForm";
            this.Text = "TrackUrineHemForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}