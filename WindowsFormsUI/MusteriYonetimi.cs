using BL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entities;

namespace WindowsFormsUI
{
    public partial class MusteriYonetimi : Form
    {
        public MusteriYonetimi()
        {
            InitializeComponent();
        }
        MusteriManager manager = new MusteriManager();
        private void MusteriYonetimi_Load(object sender, EventArgs e)
        {
            Yukle();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtAdi.Text))
            {
                int sonuc = manager.Add(new Musteri
                {
                    Adi = txtAdi.Text,
                    Soyadi = txtSoyadi.Text,
                    Adres = rtbAdres.Text,
                    Email = txtEmail.Text,
                    Telefon = txtTelefon.Text
                });
                if (sonuc > 0)
                {
                    Yukle();
                    Temizle();
                    MessageBox.Show("Kayıt Başarılı!");
                }
            }
            else MessageBox.Show("Lütfen Tüm Alanları Doldurunuz!");
        }
        void Yukle()
        {
            dgvMusteriler.DataSource = manager.GetAll();
        }
        void Temizle()
        {
            var nesneler = groupBox1.Controls.OfType<TextBox>(); // groupBox1 in içerisindeki kontrollerden tipi textbox olanları listele
            foreach (var item in nesneler)
            {
                item.Clear(); //listedeki textbox ları temizle
            }
            rtbAdres.Text = string.Empty;
        }

        private void dgvMusteriler_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dgvMusteriler.CurrentRow.Cells[0].Value);
            var musteri = manager.Find(id);
            txtAdi.Text = musteri.Adi;
            txtSoyadi.Text = musteri.Soyadi;
            txtEmail.Text = musteri.Email;
            txtTelefon.Text = musteri.Telefon;
            rtbAdres.Text = musteri.Adres;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvMusteriler.CurrentRow.Cells[0].Value);
            if (!string.IsNullOrWhiteSpace(txtAdi.Text))
            {
                int sonuc = manager.Update(new Musteri
                {
                    Id = id,
                    Adi = txtAdi.Text,
                    Soyadi = txtSoyadi.Text,
                    Adres = rtbAdres.Text,
                    Email = txtEmail.Text,
                    Telefon = txtTelefon.Text
                });
                if (sonuc > 0)
                {
                    Yukle();
                    Temizle();
                    MessageBox.Show("Kayıt Başarılı!");
                }
            }
            else MessageBox.Show("Lütfen Tüm Alanları Doldurunuz!");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Kaydı Silmek İstiyor Musunuz?", "Uyarı! Kayıt Silinecek!", MessageBoxButtons.YesNo, MessageBoxIcon.Error) == DialogResult.Yes)
            {
                int id = Convert.ToInt32(dgvMusteriler.CurrentRow.Cells[0].Value);
                var musteri = manager.Find(id);
                int sonuc = manager.Delete(musteri);
                if (sonuc > 0)
                {
                    Temizle();
                    Yukle();
                    MessageBox.Show("Silme Başarılı!");
                }
                else MessageBox.Show("Silme Başarısız!");
            }
        }
    }
}
