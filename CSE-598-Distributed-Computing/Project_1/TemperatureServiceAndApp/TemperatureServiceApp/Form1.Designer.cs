namespace TemperatureServiceApp
{
    partial class Form1
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
            this.celsius = new System.Windows.Forms.RichTextBox();
            this.ConvertToFButton = new System.Windows.Forms.Button();
            this.celsiusOutput = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.farenheit = new System.Windows.Forms.RichTextBox();
            this.ConvertToCButton = new System.Windows.Forms.Button();
            this.farenheitOutput = new System.Windows.Forms.Label();
            this.errorMesgC = new System.Windows.Forms.Label();
            this.errorMesgF = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(285, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(154, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Celsius to Fahrenheit Converter";
            // 
            // celsius
            // 
            this.celsius.Location = new System.Drawing.Point(287, 128);
            this.celsius.Multiline = false;
            this.celsius.Name = "celsius";
            this.celsius.Size = new System.Drawing.Size(152, 20);
            this.celsius.TabIndex = 1;
            this.celsius.Text = "";
            // 
            // ConvertToFButton
            // 
            this.ConvertToFButton.Location = new System.Drawing.Point(300, 154);
            this.ConvertToFButton.Name = "ConvertToFButton";
            this.ConvertToFButton.Size = new System.Drawing.Size(123, 23);
            this.ConvertToFButton.TabIndex = 2;
            this.ConvertToFButton.Text = "Convert To F";
            this.ConvertToFButton.UseVisualStyleBackColor = true;
            this.ConvertToFButton.Click += new System.EventHandler(this.ConvertToFButton_Click);
            // 
            // celsiusOutput
            // 
            this.celsiusOutput.AutoSize = true;
            this.celsiusOutput.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.celsiusOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.celsiusOutput.Location = new System.Drawing.Point(456, 126);
            this.celsiusOutput.Name = "celsiusOutput";
            this.celsiusOutput.Size = new System.Drawing.Size(35, 22);
            this.celsiusOutput.TabIndex = 3;
            this.celsiusOutput.Text = "- F°";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(284, 222);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(154, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Fahrenheit to Celsius Converter";
            // 
            // farenheit
            // 
            this.farenheit.Location = new System.Drawing.Point(286, 238);
            this.farenheit.Multiline = false;
            this.farenheit.Name = "farenheit";
            this.farenheit.Size = new System.Drawing.Size(152, 20);
            this.farenheit.TabIndex = 5;
            this.farenheit.Text = "";
            // 
            // ConvertToCButton
            // 
            this.ConvertToCButton.Location = new System.Drawing.Point(300, 264);
            this.ConvertToCButton.Name = "ConvertToCButton";
            this.ConvertToCButton.Size = new System.Drawing.Size(123, 23);
            this.ConvertToCButton.TabIndex = 6;
            this.ConvertToCButton.Text = "Convert To C";
            this.ConvertToCButton.UseMnemonic = false;
            this.ConvertToCButton.UseVisualStyleBackColor = true;
            this.ConvertToCButton.Click += new System.EventHandler(this.ConvertToCButton_Click);
            // 
            // farenheitOutput
            // 
            this.farenheitOutput.AutoSize = true;
            this.farenheitOutput.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.farenheitOutput.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.farenheitOutput.Location = new System.Drawing.Point(456, 236);
            this.farenheitOutput.Name = "farenheitOutput";
            this.farenheitOutput.Size = new System.Drawing.Size(36, 22);
            this.farenheitOutput.TabIndex = 7;
            this.farenheitOutput.Text = "- C°";
            // 
            // errorMesgC
            // 
            this.errorMesgC.AutoSize = true;
            this.errorMesgC.ForeColor = System.Drawing.Color.Red;
            this.errorMesgC.Location = new System.Drawing.Point(453, 159);
            this.errorMesgC.Name = "errorMesgC";
            this.errorMesgC.Size = new System.Drawing.Size(0, 13);
            this.errorMesgC.TabIndex = 8;
            // 
            // errorMesgF
            // 
            this.errorMesgF.AutoSize = true;
            this.errorMesgF.ForeColor = System.Drawing.Color.Red;
            this.errorMesgF.Location = new System.Drawing.Point(456, 273);
            this.errorMesgF.Name = "errorMesgF";
            this.errorMesgF.Size = new System.Drawing.Size(0, 13);
            this.errorMesgF.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.errorMesgF);
            this.Controls.Add(this.errorMesgC);
            this.Controls.Add(this.farenheitOutput);
            this.Controls.Add(this.ConvertToCButton);
            this.Controls.Add(this.farenheit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.celsiusOutput);
            this.Controls.Add(this.ConvertToFButton);
            this.Controls.Add(this.celsius);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Temperature Converter App";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RichTextBox celsius;
        private System.Windows.Forms.Button ConvertToFButton;
        private System.Windows.Forms.Label celsiusOutput;

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox farenheit;
        private System.Windows.Forms.Button ConvertToCButton;
        private System.Windows.Forms.Label farenheitOutput;
        private System.Windows.Forms.Label errorMesgC;
        private System.Windows.Forms.Label errorMesgF;
    }
}

