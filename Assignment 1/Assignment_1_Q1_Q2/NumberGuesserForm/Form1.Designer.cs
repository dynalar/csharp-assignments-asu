namespace NumberGuesserForm
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.LowerLimit = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.UpperLimit = new System.Windows.Forms.TextBox();
            this.secretNumGeneratorButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.Guess = new System.Windows.Forms.TextBox();
            this.playButton = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.attempts = new System.Windows.Forms.Label();
            this.numberResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(98, 65);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(69, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lower Limit";
            // 
            // LowerLimit
            // 
            this.LowerLimit.Location = new System.Drawing.Point(173, 62);
            this.LowerLimit.Name = "LowerLimit";
            this.LowerLimit.Size = new System.Drawing.Size(100, 23);
            this.LowerLimit.TabIndex = 1;
            this.LowerLimit.Tag = "";
            this.LowerLimit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateIntegersOnly);
            this.LowerLimit.KeyUp += new System.Windows.Forms.KeyEventHandler(this.EnableSecretNumberButton);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(303, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 15);
            this.label2.TabIndex = 2;
            this.label2.Text = "Upper Limit";
            // 
            // UpperLimit
            // 
            this.UpperLimit.Location = new System.Drawing.Point(378, 62);
            this.UpperLimit.Name = "UpperLimit";
            this.UpperLimit.Size = new System.Drawing.Size(100, 23);
            this.UpperLimit.TabIndex = 3;
            this.UpperLimit.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateIntegersOnly);
            this.UpperLimit.KeyUp += new System.Windows.Forms.KeyEventHandler(this.EnableSecretNumberButton);
            // 
            // secretNumGeneratorButton
            // 
            this.secretNumGeneratorButton.Enabled = false;
            this.secretNumGeneratorButton.Location = new System.Drawing.Point(484, 61);
            this.secretNumGeneratorButton.Name = "secretNumGeneratorButton";
            this.secretNumGeneratorButton.Size = new System.Drawing.Size(177, 23);
            this.secretNumGeneratorButton.TabIndex = 4;
            this.secretNumGeneratorButton.Text = "Generate a Secret Number";
            this.secretNumGeneratorButton.UseVisualStyleBackColor = true;
            this.secretNumGeneratorButton.Click += new System.EventHandler(this.GenerateSecretNumber_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(173, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Make a Guess";
            // 
            // Guess
            // 
            this.Guess.Location = new System.Drawing.Point(258, 125);
            this.Guess.Name = "Guess";
            this.Guess.Size = new System.Drawing.Size(100, 23);
            this.Guess.TabIndex = 6;
            this.Guess.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.ValidateIntegersOnly);
            // 
            // playButton
            // 
            this.playButton.Location = new System.Drawing.Point(364, 125);
            this.playButton.Name = "playButton";
            this.playButton.Size = new System.Drawing.Size(177, 23);
            this.playButton.TabIndex = 7;
            this.playButton.Text = "Play";
            this.playButton.UseVisualStyleBackColor = true;
            this.playButton.Click += new System.EventHandler(this.Play_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(364, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(67, 15);
            this.label4.TabIndex = 8;
            this.label4.Text = "Attempts - ";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(484, 161);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(93, 15);
            this.label5.TabIndex = 9;
            this.label5.Text = "The number is - ";
            // 
            // attempts
            // 
            this.attempts.AutoSize = true;
            this.attempts.Location = new System.Drawing.Point(424, 161);
            this.attempts.Name = "attempts";
            this.attempts.Size = new System.Drawing.Size(29, 15);
            this.attempts.TabIndex = 10;
            this.attempts.Text = "N/A";
            // 
            // numberResult
            // 
            this.numberResult.AutoSize = true;
            this.numberResult.Location = new System.Drawing.Point(573, 161);
            this.numberResult.Name = "numberResult";
            this.numberResult.Size = new System.Drawing.Size(29, 15);
            this.numberResult.TabIndex = 11;
            this.numberResult.Text = "N/A";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.numberResult);
            this.Controls.Add(this.attempts);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.playButton);
            this.Controls.Add(this.Guess);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.secretNumGeneratorButton);
            this.Controls.Add(this.UpperLimit);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.LowerLimit);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private TextBox LowerLimit;
        private Label label2;
        private TextBox UpperLimit;
        private Button secretNumGeneratorButton;
        private Label label3;
        private TextBox Guess;
        private Button playButton;
        private Label label4;
        private Label label5;
        private Label attempts;
        private Label numberResult;
    }
}