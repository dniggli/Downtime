﻿namespace downtimeC
{
    partial class AddOnForm
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
            // DebugButtonFill
            // 
            this.DebugButtonFill.FlatAppearance.BorderColor = System.Drawing.SystemColors.Control;

            // 
            // AddOnForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1012, 798);
            this.Name = "AddOnForm";
            this.Text = "AddOnForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion


    }
}