using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsUI
{
    public partial class AnaEkran : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["admin"] == null) // Eğer sisteme giriş yapmış bir yönetici yoksa
            {
                Response.Redirect("Login.aspx"); // sistemdeki sayfalara gelen isteği login sayfasına yönlendir
            }
        }
    }
}