using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NumberSortServiceApp
{
    public partial class NumbertSortAppForm : Form
    {
        public NumbertSortAppForm()
        {
            InitializeComponent();
        }

        private void sortStringButton_Click(object sender, EventArgs e)
        {
            // instantiate our service
            NumberSortServiceRef.NumberSortServiceClient numberSortClient = new NumberSortServiceRef.NumberSortServiceClient();

            // sort the numbers by calling sort service
            string sortResponse = numberSortClient.sortString(numberSortBox.Text);

            // update the label with new response
            sortOutput.Text = sortResponse;
        }
    }
}
