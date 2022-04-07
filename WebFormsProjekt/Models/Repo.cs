using Microsoft.ApplicationBlocks.Data;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;

namespace WebFormsProjekt.Models
{
    public class Repo
    {
        private static string cs = ConfigurationManager.ConnectionStrings["cs"].ConnectionString;


        public static bool ProvjeraUspjesnostiLogiranja(string email, string lozinka) {

            try
            {
                DataRow row = SqlHelper.ExecuteDataset(cs, "ProvjeraUspjesnostiLogiranja", email, lozinka).Tables[0].Rows[0];
                return true;
            }
            catch (Exception)
            {

                return false;
            } 

           
        }
    }
}