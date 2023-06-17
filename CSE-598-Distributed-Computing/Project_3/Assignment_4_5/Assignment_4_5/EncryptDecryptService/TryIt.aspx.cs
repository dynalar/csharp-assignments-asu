using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_4_5.EncryptDecryptService
{
    public partial class TryIt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void SubmitButton_Click(object sender, EventArgs e)
        {
            EncryptDecryptServiceRef.EncryptDecryptServiceClient encryptDecryptClient = new EncryptDecryptServiceRef.EncryptDecryptServiceClient();

            string stringToEncrypt = EncryptStringTextBox.Text.Trim();

            try
            {
                ResultLiteral.Text = encryptDecryptClient.encryptString(stringToEncrypt);
            } catch(Exception ex)
            {
                ResultLiteral.Text = "Failed to encrypt string. Reason: " + ex.Message;
            }
        } 
        
        protected void SubmitButtonDecryptor_Click(object sender, EventArgs e)
        {
            EncryptDecryptServiceRef.EncryptDecryptServiceClient encryptDecryptClient = new EncryptDecryptServiceRef.EncryptDecryptServiceClient();

            string stringToDecrypt = DecryptStringTextBox.Text.Trim();

            try
            {
                ResultLiteralDecryptor.Text = encryptDecryptClient.decryptString(stringToDecrypt);
            } catch(Exception ex)
            {
                ResultLiteralDecryptor.Text = "Failed to decrypt string. Reason: " + ex.Message;
            }
        }
    }
}