namespace BrandonAntillonsBrowser
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
            this.webBrowser1 = new System.Windows.Forms.WebBrowser();
            this.txtUrl = new System.Windows.Forms.TextBox();
            this.btnGo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cTempInput = new System.Windows.Forms.TextBox();
            this.fTempInput = new System.Windows.Forms.TextBox();
            this.convertCtoF = new System.Windows.Forms.Button();
            this.convertFtoC = new System.Windows.Forms.Button();
            this.fResult = new System.Windows.Forms.Label();
            this.cResult = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.numSortInput = new System.Windows.Forms.TextBox();
            this.runSort = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.sortResult = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // webBrowser1
            // 
            this.webBrowser1.Location = new System.Drawing.Point(2, 41);
            this.webBrowser1.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowser1.Name = "webBrowser1";
            this.webBrowser1.Size = new System.Drawing.Size(701, 558);
            this.webBrowser1.TabIndex = 0;
            this.webBrowser1.DocumentCompleted += new System.Windows.Forms.WebBrowserDocumentCompletedEventHandler(this.webBrowser1_DocumentCompleted);
            // 
            // txtUrl
            // 
            this.txtUrl.Location = new System.Drawing.Point(12, 10);
            this.txtUrl.Name = "txtUrl";
            this.txtUrl.Size = new System.Drawing.Size(589, 20);
            this.txtUrl.TabIndex = 1;
            this.txtUrl.Text = "http://";
            // 
            // btnGo
            // 
            this.btnGo.Location = new System.Drawing.Point(607, 8);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(75, 23);
            this.btnGo.TabIndex = 2;
            this.btnGo.Text = "Go";
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(12, 501);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Temperature Converter";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 522);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "C° to F°";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(12, 549);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "F° to C°";
            // 
            // cTempInput
            // 
            this.cTempInput.Location = new System.Drawing.Point(61, 519);
            this.cTempInput.Name = "cTempInput";
            this.cTempInput.Size = new System.Drawing.Size(100, 20);
            this.cTempInput.TabIndex = 6;
            // 
            // fTempInput
            // 
            this.fTempInput.Location = new System.Drawing.Point(61, 546);
            this.fTempInput.Name = "fTempInput";
            this.fTempInput.Size = new System.Drawing.Size(100, 20);
            this.fTempInput.TabIndex = 7;
            // 
            // convertCtoF
            // 
            this.convertCtoF.Location = new System.Drawing.Point(167, 517);
            this.convertCtoF.Name = "convertCtoF";
            this.convertCtoF.Size = new System.Drawing.Size(75, 23);
            this.convertCtoF.TabIndex = 8;
            this.convertCtoF.Text = "Convert";
            this.convertCtoF.UseVisualStyleBackColor = true;
            this.convertCtoF.Click += new System.EventHandler(this.convertCtoF_Click);
            // 
            // convertFtoC
            // 
            this.convertFtoC.Location = new System.Drawing.Point(167, 546);
            this.convertFtoC.Name = "convertFtoC";
            this.convertFtoC.Size = new System.Drawing.Size(75, 23);
            this.convertFtoC.TabIndex = 9;
            this.convertFtoC.Text = "Convert";
            this.convertFtoC.UseVisualStyleBackColor = true;
            this.convertFtoC.Click += new System.EventHandler(this.convertFtoC_Click);
            // 
            // fResult
            // 
            this.fResult.AutoSize = true;
            this.fResult.Location = new System.Drawing.Point(248, 522);
            this.fResult.Name = "fResult";
            this.fResult.Size = new System.Drawing.Size(23, 13);
            this.fResult.TabIndex = 10;
            this.fResult.Text = "- F°";
            // 
            // cResult
            // 
            this.cResult.AutoSize = true;
            this.cResult.Location = new System.Drawing.Point(248, 551);
            this.cResult.Name = "cResult";
            this.cResult.Size = new System.Drawing.Size(24, 13);
            this.cResult.TabIndex = 11;
            this.cResult.Text = "- C°";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(504, 501);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 15);
            this.label4.TabIndex = 12;
            this.label4.Text = "Number Sorter";
            // 
            // numSortInput
            // 
            this.numSortInput.Location = new System.Drawing.Point(487, 522);
            this.numSortInput.Name = "numSortInput";
            this.numSortInput.Size = new System.Drawing.Size(124, 20);
            this.numSortInput.TabIndex = 13;
            // 
            // runSort
            // 
            this.runSort.Location = new System.Drawing.Point(617, 520);
            this.runSort.Name = "runSort";
            this.runSort.Size = new System.Drawing.Size(45, 23);
            this.runSort.TabIndex = 14;
            this.runSort.Text = "Sort";
            this.runSort.UseVisualStyleBackColor = true;
            this.runSort.Click += new System.EventHandler(this.runSort_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(404, 525);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(77, 13);
            this.label5.TabIndex = 15;
            this.label5.Text = "Enter Numbers";
            // 
            // sortResult
            // 
            this.sortResult.AutoSize = true;
            this.sortResult.Location = new System.Drawing.Point(524, 549);
            this.sortResult.Name = "sortResult";
            this.sortResult.Size = new System.Drawing.Size(52, 13);
            this.sortResult.TabIndex = 16;
            this.sortResult.Text = "Result: ---";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(704, 601);
            this.Controls.Add(this.sortResult);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.runSort);
            this.Controls.Add(this.numSortInput);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.cResult);
            this.Controls.Add(this.fResult);
            this.Controls.Add(this.convertFtoC);
            this.Controls.Add(this.convertCtoF);
            this.Controls.Add(this.fTempInput);
            this.Controls.Add(this.cTempInput);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.txtUrl);
            this.Controls.Add(this.webBrowser1);
            this.Name = "Form1";
            this.Text = "Brandon Antillon\'s Browser";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.WebBrowser webBrowser1;
        private System.Windows.Forms.TextBox txtUrl;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox cTempInput;
        private System.Windows.Forms.TextBox fTempInput;
        private System.Windows.Forms.Button convertCtoF;
        private System.Windows.Forms.Button convertFtoC;
        private System.Windows.Forms.Label fResult;
        private System.Windows.Forms.Label cResult;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox numSortInput;
        private System.Windows.Forms.Button runSort;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label sortResult;
    }
}

