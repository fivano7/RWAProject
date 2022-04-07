using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;

namespace WebFormsProjekt
{
    public class Global : System.Web.HttpApplication
    {
        protected void Application_Start(object sender, EventArgs e)
        {
        }

        protected void Application_Error(object sender, EventArgs e)
        {
            var error = Server.GetLastError().GetBaseException().Message;
            Response.Redirect($"Error.aspx?greska={error}");
        }

    }
}