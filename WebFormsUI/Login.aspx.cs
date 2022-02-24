using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebFormsUI
{
    public partial class Login : System.Web.UI.Page
    {
        //KullaniciManager manager = new KullaniciManager();
        LoginManager manager = new LoginManager();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnGiris_Click(object sender, EventArgs e)
        {
            var sonuc = manager.Get(k => k.KullaniciAdi == txtKullaniciAdi.Text.Trim() & k.Sifre == txtSifre.Text.Trim() & k.Durum); // trim metodu textboxdan gelen metnin önündeki ve sonundaki boşlukları kaldırır
            if (sonuc != null)
            {
                Session["admin"] = sonuc.KullaniciAdi; // Adı admin olan bir session oluştur ve bu session nesnesine kullanıcının sonuc değerinden gelen kullanıcı adını aktar
                Response.Redirect("MusteriYonetimi.aspx");
            }
            else Response.Write("<script>alert('Giriş Başarısız!')</script>");
        }
    }
}