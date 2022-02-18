using BL;
using Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsUI
{
    public partial class UrunYonetimi : Form
    {
        public UrunYonetimi()
        {
            InitializeComponent();
        }
        UrunManager manager = new UrunManager();
        MusteriManager musteriManager = new MusteriManager();
        void Yukle()
        {
            dgvUrunler.DataSource = manager.GetAll();
            cbMusteriler.DataSource = musteriManager.GetAll();
        }
        void Temizle()
        {
            var nesneler = groupBox1.Controls.OfType<TextBox>();
            foreach (var item in nesneler)
            {
                item.Clear();
            }
        }
        private void UrunYonetimi_Load(object sender, EventArgs e)
        {
            Yukle();
            cbMusteriler.DataSource = musteriManager.GetAll();

        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            var sonuc = manager.Add(new Urun
            {
                AlisTarihi = dtpAlisTarihi.Value,
                Cinsi = txtCinsi.Text,
                MusteriId = (int)cbMusteriler.SelectedValue,
                Olcu = txtOlcu.Text,
                TeslimTarihi = dtpTeslimTarihi.Value,
                Tutar = Convert.ToDecimal(txtTutar.Text),
                UrunAdi = txtUrunAdi.Text
            });
            if (sonuc > 0)
            {
                Temizle();
                Yukle();
                MessageBox.Show("Kayıt Başarılı!");
            }
            else MessageBox.Show("Kayıt Başarısız!");
        }

        private void dgvUrunler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dgvUrunler.CurrentRow.Cells[0].Value);
            var kayit = manager.Find(id);

            txtCinsi.Text = kayit.Cinsi;
            txtOlcu.Text = kayit.Olcu;
            txtTutar.Text = kayit.Tutar.ToString();
            txtUrunAdi.Text = kayit.UrunAdi;
            dtpAlisTarihi.Value = kayit.AlisTarihi;
            dtpTeslimTarihi.Value = kayit.TeslimTarihi;
        }
    }
}
