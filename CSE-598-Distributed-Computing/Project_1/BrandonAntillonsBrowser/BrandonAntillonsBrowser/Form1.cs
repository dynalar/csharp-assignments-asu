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

        private void btnGo_Click(object sender, EventArgs e)
        {
            // send browser to entered url in text box
            webBrowser1.Navigate(txtUrl.Text);
        }

        private void convertCtoF_Click(object sender, EventArgs e)
        {
            int number;

            // ensure that a number was entered
            if(int.TryParse(cTempInput.Text, out number))
            {
                // get the celsius temperature from the text box input
                int inputCTemp = Convert.ToInt32(cTempInput.Text);

                // temperature service instance
                TemperatureServiceRef.TemperatureServiceClient temperatureServiceClient = new TemperatureServiceRef.TemperatureServiceClient();

                // convert temperature with service
                int convertedFTemp = temperatureServiceClient.c2f(inputCTemp);

                // update user interface with correct output
                fResult.Text = convertedFTemp.ToString() + " F°";
            }
            else
            {
                fResult.Text = "Please enter a valid number!";
            }
        }

        private void convertFtoC_Click(object sender, EventArgs e)
        {
            int number;

            // ensure that a number was entered
            if (int.TryParse(fTempInput.Text, out number))
            {
                // get the celsius temperature from the text box input
                int inputFTemp = Convert.ToInt32(fTempInput.Text);

                // temperature service instance
                TemperatureServiceRef.TemperatureServiceClient temperatureServiceClient = new TemperatureServiceRef.TemperatureServiceClient();

                // convert temperature with service
                int convertedFTemp = temperatureServiceClient.f2c(inputFTemp);

                // update user interface with correct output
                cResult.Text = convertedFTemp.ToString() + " C°";
            }
            else
            {
                cResult.Text = "Please enter a valid number!";
            }
        }

        private void runSort_Click(object sender, EventArgs e)
        {
            // make instance of num sort client
            NumberSortServiceRef.NumberSortServiceClient numSortClient = new NumberSortServiceRef.NumberSortServiceClient();

            // get response from client
            string sortResponse = numSortClient.sortString(numSortInput.Text);

            // edit the label with the response
            sortResult.Text = "Result: " + sortResponse;
        }
    }
}
