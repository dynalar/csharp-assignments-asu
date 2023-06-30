using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_7.UserControls
{
    public partial class LoginFormControl : System.Web.UI.UserControl
    {
        public event EventHandler<LoginEventArgs> LoginClicked;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Clear any previous login error messages
                errorMessageLabel.Text = string.Empty;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = usernameEntry.Text;
            string password = passwordEntry.Text;

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                errorMessageLabel.Text = "Please enter both username and password.";
                return;
            } else
            {
                // Raise the LoginClicked event
                OnLoginClicked(new LoginEventArgs(username));
            }
        }

        protected virtual void OnLoginClicked(LoginEventArgs e)
        {
            LoginClicked?.Invoke(this, e);
        }
    }

    public class LoginEventArgs : EventArgs
    {
        public string Username { get; }

        public LoginEventArgs(string username)
        {
            Username = username;
        }
    }
}