using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_4_5.PhoneNotificationService
{
    public partial class TryIt : System.Web.UI.Page
    {
        PhoneNotificationServiceRef.PhoneNotificationServiceClient phoneNotificationServiceClient = new PhoneNotificationServiceRef.PhoneNotificationServiceClient();

        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            // get all of the items from the fields
            string phoneNumber = PhoneNumberTextBox.Text.Trim();
            string carrier = CarrierTextBox.Text.Trim();
            string latitude = LatitudeTextBox.Text.Trim();
            string longitude = LongitudeTextBox.Text.Trim();
            string currentTemperature = CurrentTemperatureTextBox.Text.Trim();

            // call our service to register the phone number.
            try
            {
                phoneNotificationServiceClient.registerPhoneNumberNotification(phoneNumber, carrier, latitude, longitude, currentTemperature);
                ResultLiteral.Text = "Phone number has been recorded!";
            } catch (Exception ex) {
                ResultLiteral.Text = "Error recording phone number! Reason: " + ex.Message;
            }
        }

        protected void SimulateNotification_Click(object sender, EventArgs e)
        {
            string phoneNumber = PhoneNumberSimTextBox.Text.Trim();
            string currentTemperature = CurrentTemperatureSimTextBox.Text.Trim();

            try
            {
                string notificationResponse = phoneNotificationServiceClient.sendPhoneNotificationText(phoneNumber, currentTemperature);

                ResultLiteralSimulator.Text = notificationResponse;

            } catch (Exception ex)
            {
                ResultLiteralSimulator.Text = "Error recording phone number! Reason: " + ex.Message;
            }
        }
    }
}