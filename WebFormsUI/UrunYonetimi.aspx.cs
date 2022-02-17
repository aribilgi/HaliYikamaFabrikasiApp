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
        }
        protected void Page_Load(object sender, EventArgs e)
        {
            Yukle();
        }

        protected void btnEkle_Click(object sender, EventArgs e)
        {
            try
            {
                var sonuc = manager.Add(new Urun
                {
                    AlisTarihi = Convert.ToDateTime(TxtAlisTarihi.Text),
                    Cinsi = TxtCinsi.Text,
                    MusteriId = Convert.ToInt32(cbMusteriler.SelectedValue),
                    Olcu = TxtOlcu.Text,
                    TeslimTarihi = Convert.ToDateTime(TxtTeslimTarihi.Text),
                    Tutar = Convert.ToDecimal(TxtTutar.Text),
                    UrunAdi = TxtUrunAdi.Text
                });
                if (sonuc < 0)
                {
                    Response.Redirect("UrunYonetimi.aspx");
                }
            }
            catch (Exception)
            {

            }
        }
    }
}