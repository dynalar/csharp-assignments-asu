using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TemperatureServiceApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void ConvertToFButton_Click(object sender, EventArgs e)
        {
            int number;

            // validation that number was entered.
            if(int.TryParse(celsius.Text, out number))
            {
                // get the celsius temperature from the text box input
                int c = Convert.ToInt32(celsius.Text);

                // instantiate our webservice
                TemperatureServiceRef.TemperatureServiceClient temperatureService = new TemperatureServiceRef.TemperatureServiceClient();

                // call function that converts c to f
                int convertedCelsiusTemp = temperatureService.c2f(c);

                // update user interface with correct output
                celsiusOutput.Text = convertedCelsiusTemp.ToString() + ' ' + 'F';

                // clear error message if any
                errorMesgC.Text = "";
            } else
            {
                errorMesgC.Text = "Please enter a valid number!"; ;
            }
        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void ConvertToCButton_Click(object sender, EventArgs e)
        {
            int number;

            if(int.TryParse(farenheit.Text, out number))
            {
                // get the farenheit temperature from the 
                int f = Convert.ToInt32(farenheit.Text);

                // instantiate our webservice
                TemperatureServiceRef.TemperatureServiceClient temperatureService = new TemperatureServiceRef.TemperatureServiceClient();

                // call function that converts f to c
                int convertedCelsiusTemp = temperatureService.f2c(f);

                // update user interface with correct output
                farenheitOutput.Text = convertedCelsiusTemp.ToString() + ' ' + 'C';

                // clear error message if any
                errorMesgF.Text = "";
            } else
            {
                errorMesgF.Text = "Please enter a valid number!"; ;
            }
        }
    }
}
