﻿namespace NumberSortServiceApp
{
    partial class NumbertSortAppForm
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
            this.label1 = new System.Windows.Forms.Label();
            this.numberSortBox = new System.Windows.Forms.RichTextBox();
            this.sortStringButton = new System.Windows.Forms.Button();
            this.sortOutput = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(308, 137);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(176, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number Sort App";
            // 
            // numberSortBox
            // 
            this.numberSortBox.Location = new System.Drawing.Point(313, 165);
            this.numberSortBox.Multiline = false;
            this.numberSortBox.Name = "numberSortBox";
            this.numberSortBox.Size = new System.Drawing.Size(171, 24);
            this.numberSortBox.TabIndex = 1;
            this.numberSortBox.Text = "";
            // 
            // sortStringButton
            // 
            this.sortStringButton.Location = new System.Drawing.Point(360, 194);
            this.sortStringButton.Name = "sortStringButton";
            this.sortStringButton.Size = new System.Drawing.Size(75, 23);
            this.sortStringButton.TabIndex = 2;
            this.sortStringButton.Text = "Sort";
            this.sortStringButton.UseVisualStyleBackColor = true;
            this.sortStringButton.Click += new System.EventHandler(this.sortStringButton_Click);
            // 
            // sortOutput
            // 
            this.sortOutput.AutoSize = true;
            this.sortOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.sortOutput.Location = new System.Drawing.Point(490, 165);
            this.sortOutput.Name = "sortOutput";
            this.sortOutput.Size = new System.Drawing.Size(0, 20);
            this.sortOutput.TabIndex = 3;
            // 
            // NumbertSortAppForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.sortOutput);
            this.Controls.Add(this.sortStringButton);
            this.Controls.Add(this.numberSortBox);
            this.Controls.Add(this.label1);
            this.Name = "NumbertSortAppForm";
            this.Text = "Number Sort App";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox numberSortBox;
        private System.Windows.Forms.Button sortStringButton;
        private System.Windows.Forms.Label sortOutput;
    }
}

