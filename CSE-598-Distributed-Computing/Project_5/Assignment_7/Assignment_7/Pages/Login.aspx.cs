﻿using Assignment_7.UserControls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Assignment_7.Pages
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loginControl_LoginClicked(object sender, LoginEventArgs e)
        {
            // Handle the login event here
            string username = e.Username;
            // Perform any necessary authentication or redirection logic
        }
    }
}