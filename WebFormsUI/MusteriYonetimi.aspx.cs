using BL;
using Entities;
using System;

namespace WebFormsUI
{
    public partial class MusteriYonetimi : System.Web.UI.Page
    {
        MusteriManager manager = new MusteriManager();
        protected void Page_Load(object sender, EventArgs e)
        {
            Yukle();
        }
        void Yukle()
        {
            dgvMusteriler.DataSource = manager.GetAll();
            dgvMusteriler.DataBind();
        }

        protected void btnEkle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtAdi.Text))
            {
                int sonuc = manager.Add(new Musteri
                {
                    Adi = txtAdi.Text,
                    Soyadi = txtSoyadi.Text,
                    Adres = txtAdres.Text,
                    Email = txtEmail.Text,
                    Telefon = txtTelefon.Text
                });
                if (sonuc > 0)
                {
                    Response.Redirect("MusteriYonetimi.aspx");
                }
            }            
        }

        protected void dgvMusteriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvMusteriler.SelectedRow.Cells[1].Text);
            var musteri = manager.Find(id);
            txtAdi.Text = musteri.Adi;
            txtSoyadi.Text = musteri.Soyadi;
            txtEmail.Text = musteri.Email;
            txtTelefon.Text = musteri.Telefon;
            txtAdres.Text = musteri.Adres;

            btnGuncelle.Enabled = true;
            btnSil.Enabled = true;
        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgvMusteriler.SelectedRow.Cells[1].Text);

                int sonuc = manager.Update(new Musteri
                {
                    Id = id,
                    Adi = txtAdi.Text,
                    Soyadi = txtSoyadi.Text,
                    Adres = txtAdres.Text,
                    Email = txtEmail.Text,
                    Telefon = txtTelefon.Text
                });
                if (sonuc > 0)
                {
                    Response.Redirect("MusteriYonetimi.aspx");
                }
            }
            catch (Exception)
            {
                txtAdres.Text = "Güncellemede Hata Oluştu!";
            }

        }

        protected void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgvMusteriler.SelectedRow.Cells[1].Text);
                var musteri = manager.Find(id);
                int sonuc = manager.Delete(musteri);

                if (sonuc > 0)
                {
                    Response.Redirect("MusteriYonetimi.aspx");
                }
            }
            catch (Exception)
            {
                txtAdres.Text = "Silmede Hata Oluştu!";
            }
        }
    }
}