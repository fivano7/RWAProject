using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using WebFormsProjekt.Models;

namespace WebFormsProjekt
{
    public partial class PrikazPodatakaWF : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["Uspjeh"] == null || (string)Session["Uspjeh"] == "Neuspjeh")
            {
                Response.Redirect("Login.aspx");
            }
            

            if (IsPostBack)
            {

                try
                {
                    int brojStranica = int.Parse(ddlBrojStavki.SelectedValue);
                    tablicaKupci.PageSize = brojStranica;

                }
                catch (Exception)
                {

                    tablicaKupci.PageSize = 10;

                }
               
            }
        }

    }
}