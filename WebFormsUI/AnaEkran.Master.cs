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
                //Session nesnesi web tarafında geçerli, sunucuda saklanan bir durum yönetim nesnesidir. Sayfalar arasında veri taşıyabilir. Belirli bir yaşam süresi vardır (standart 20 dk). Süre dolumunda veya sunucuda oluşabilecek teknik bir sorunda session yok olabilir, bu durumda kullanıcının yeniden giriş yapması gerekir.
                Response.Redirect("Login.aspx"); // sistemdeki sayfalara gelen isteği login sayfasına yönlendir
            }
        }

        protected void lbCikis_Click(object sender, EventArgs e)
        {
            Session.Remove("admin"); // Session u sil
            Response.Redirect("Login.aspx"); // sayfayı login sayfasına yönlendir
        }
    }
}