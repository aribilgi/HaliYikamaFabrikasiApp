using System;
using System.Web.UI.WebControls;
using BL;
using Entities;

namespace WebFormsUI
{
    public partial class KullaniciYonetimi : System.Web.UI.Page
    {
        KullaniciManager manager = new KullaniciManager();
        
        protected void Page_Load(object sender, EventArgs e)
        {
            Yukle();
        }
        void Yukle()
        {
            dgvKullanicilar.DataSource = manager.GetAll();
            dgvKullanicilar.DataBind(); // webde dataların gridview a yüklenemesi için burası gerekli!
        }

        protected void btnEkle_Click(object sender, EventArgs e)
        {
            int sonuc = manager.Add(new Kullanici
            {
                Adi = txtAdi.Text,
                Soyadi = txtSoyadi.Text,
                Durum = cbDurum.Checked,
                Email = txtEmail.Text,
                KullaniciAdi = txtKullaniciAdi.Text,
                Sifre = txtSifre.Text
            });
            if (sonuc > 0) // Eğer kayıt eklendiyse
            {
                Response.Redirect("KullaniciYonetimi.aspx"); // Sayfayı KullaniciYonetimi.aspx e yönlendir
            }
            else ltMesaj.Text = "<h1>Kayıt Başarısız!</h1>";
        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvKullanicilar.SelectedRow.Cells[1].Text);
            int sonuc = manager.Update(new Kullanici
            {
                Id = id,
                Adi = txtAdi.Text,
                Soyadi = txtSoyadi.Text,
                Durum = cbDurum.Checked,
                Email = txtEmail.Text,
                KullaniciAdi = txtKullaniciAdi.Text,
                Sifre = txtSifre.Text
            });
            if (sonuc > 0)
            {
                Response.Redirect("KullaniciYonetimi.aspx");
            }
            else ltMesaj.Text = "<h1>Kayıt Başarısız!</h1>";
        }

        protected void dgvKullanicilar_SelectedIndexChanged(object sender, EventArgs e)
        {
            // web tarafında gridview da cellclick olmadığı için events kısmından SelectedIndexChanged olayını kullanıyoruz
            try
            {
                btnGuncelle.Enabled = true;
                btnSil.Enabled = true;

                GridViewRow row = dgvKullanicilar.SelectedRow;

                int id = Convert.ToInt32(row.Cells[1].Text);
                Kullanici kullanici = manager.Find(id);
                txtAdi.Text = kullanici.Adi;
                txtSoyadi.Text = kullanici.Soyadi;
                txtEmail.Text = kullanici.Email;
                txtSifre.Text = kullanici.Sifre;
                txtKullaniciAdi.Text = kullanici.KullaniciAdi;
                cbDurum.Checked = kullanici.Durum;
            }
            catch (Exception)
            {
                ltMesaj.Text = "<h1>Hata Oluştu! Kayıt Getirilemedi!</h1>";
            }
        }

        protected void btnSil_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvKullanicilar.SelectedRow.Cells[1].Text);
            Kullanici kullanici = manager.Find(id);
            int sonuc = manager.Delete(kullanici);
            if (sonuc > 0)
            {
                Response.Redirect("KullaniciYonetimi.aspx");
            }
            else ltMesaj.Text = "<h1>Kayıt Başarısız!</h1>";
        }
    }
}