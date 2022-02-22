using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BL;
using Entities;

namespace WebFormsUI
{
    public partial class UrunYonetimi : System.Web.UI.Page
    {
        UrunManager manager = new UrunManager();
        MusteriManager musteriManager = new MusteriManager();
        void Yukle()
        {
            dgvUrunler.DataSource = manager.GetAll();
            dgvUrunler.DataBind();
            cbMusteriler.DataSource = musteriManager.GetAll();
            cbMusteriler.DataBind(); // cbMusteriler drop down list de müşterilerin adının görünmesi için sağ click properties den data text field kısmına Adi yazdık, value kısmında ise Id olması gerektiği için Datavaluefield alanına Id yazıp enter deyip kaydete bastık
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if(!Page.IsPostBack) Yukle(); // Eğer sayfa postback olmamışsa yukle metodunu çalıştır
        }

        protected void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                var sonuc = manager.Add(new Urun
                {
                    AlisTarihi = dtpAlisTarihi.SelectedDate,
                    Cinsi = txtCinsi.Text,
                    MusteriId = Convert.ToInt32(cbMusteriler.SelectedValue),
                    Olcu = txtOlcu.Text,
                    TeslimTarihi = dtpTeslimTarihi.SelectedDate,
                    Tutar = Convert.ToDecimal(txtTutar.Text),
                    UrunAdi = txtUrunAdi.Text
                });
                if (sonuc > 0)
                {
                    Response.Redirect("UrunYonetimi.aspx");
                }
            }
            catch (Exception hata)
            {
                lblMesaj.Text = "Eklemede Hata Oluştu! <hr>" + hata;
            }
        }

        protected void cbMusteriler_SelectedIndexChanged(object sender, EventArgs e)
        {
            var musteri = musteriManager.Find(Convert.ToInt32(cbMusteriler.SelectedValue));

            lblMusteriAdi.Text = musteri.Adi + " " + musteri.Soyadi;
            lblMusteriTelefon.Text = "Telefon : " + musteri.Telefon;
        }

        protected void btnGuncelle_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgvUrunler.SelectedRow.Cells[1].Text);
                var sonuc = manager.Update(new Urun
                {
                    Id = id,
                    AlisTarihi = dtpAlisTarihi.SelectedDate,
                    Cinsi = txtCinsi.Text,
                    MusteriId = Convert.ToInt32(cbMusteriler.SelectedValue),
                    Olcu = txtOlcu.Text,
                    TeslimTarihi = dtpTeslimTarihi.SelectedDate,
                    Tutar = Convert.ToDecimal(txtTutar.Text),
                    UrunAdi = txtUrunAdi.Text
                });
                if (sonuc > 0)
                {
                    Response.Redirect("UrunYonetimi.aspx");
                }
            }
            catch (Exception hata)
            {
                lblMesaj.Text = "Eklemede Hata Oluştu! <hr>" + hata;
            }
        }

        protected void dgvUrunler_SelectedIndexChanged(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvUrunler.SelectedRow.Cells[1].Text);
            var kayit = manager.Find(id);

            txtCinsi.Text = kayit.Cinsi;
            txtOlcu.Text = kayit.Olcu;
            txtTutar.Text = kayit.Tutar.ToString();
            txtUrunAdi.Text = kayit.UrunAdi;
            dtpAlisTarihi.SelectedDate = kayit.AlisTarihi;
            dtpTeslimTarihi.SelectedDate = kayit.TeslimTarihi;

            btnGuncelle.Enabled = true;
            btnSil.Enabled = true;
        }

        protected void btnSil_Click(object sender, EventArgs e)
        {
            try
            {
                int id = Convert.ToInt32(dgvUrunler.SelectedRow.Cells[1].Text);
                var kayit = manager.Find(id);
                var sonuc = manager.Delete(kayit);
                if (sonuc > 0)
                {
                    Response.Redirect("UrunYonetimi.aspx");
                }
                else lblMesaj.Text = "Silmede Hata Oluştu! ";
            }
            catch (Exception hata)
            {
                lblMesaj.Text = "Silmede Hata Oluştu! " + hata.Message;
            }
        }
    }
}