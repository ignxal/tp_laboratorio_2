﻿
namespace FormFabrica
{
    partial class FormAuricular
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
            this.chbMicrofono = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // chbMicrofono
            // 
            this.chbMicrofono.AutoSize = true;
            this.chbMicrofono.Location = new System.Drawing.Point(61, 202);
            this.chbMicrofono.Name = "chbMicrofono";
            this.chbMicrofono.Size = new System.Drawing.Size(73, 17);
            this.chbMicrofono.TabIndex = 14;
            this.chbMicrofono.Text = "Micrófono";
            this.chbMicrofono.UseVisualStyleBackColor = true;
            // 
            // FormAuricular
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(225, 294);
            this.Controls.Add(this.chbMicrofono);
            this.Name = "FormAuricular";
            this.Text = "Auricular";
            this.Controls.SetChildIndex(this.chbInalambrico, 0);
            this.Controls.SetChildIndex(this.cmbColor, 0);
            this.Controls.SetChildIndex(this.cmbMarca, 0);
            this.Controls.SetChildIndex(this.txbNroSerie, 0);
            this.Controls.SetChildIndex(this.chbMicrofono, 0);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.CheckBox chbMicrofono;
    }
}