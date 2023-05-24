using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BrandonAntillonsBrowser
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // suppress the errors about script issues when running web browser
            webBrowser1.ScriptErrorsSuppressed = true;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            webBrowser1.Navigate(txtUrl.Text);
        }
    }
}
