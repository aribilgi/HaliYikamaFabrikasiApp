//using DAL; Dal katmanına kullanıcı arayüzünden direk erişmemeliyiz!!!
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
    public partial class KullaniciYonetimi : Form
    {
        public KullaniciYonetimi()
        {
            InitializeComponent();
        }
        //DatabaseContext databaseContext = new DatabaseContext();
        /*
         * Hangi katman nereye erişmeli
         * Entities katmanı en alt katmanımız ve buraya diğer tüm katmanlar erişebilir
         * WindowsFormsUI kullanıcı arayüz katmanımız, burası Entities ve BL katmanına erişebilir
         * BL katmanı iş katmanımız, burası entities ve DAL katmanına erişebilir
         * DAL katmanı veri erişim katmanımız ve burası sadece entities katmanına erişebilir
         * Bir katmana başka bir katmandan erişebilmek için, örneğin bl den dal ve entitiese erişmek için bl katmanındaki references a sağ tık > add reference > açılan pencerede soldan projects - solution a tıklayıp oradaki projelerden dal ve entities projelerine tik koyup ok ile pencereleri kapatmalıyız.
         */
        KullaniciManager manager = new KullaniciManager();
        private void KullaniciYonetimi_Load(object sender, EventArgs e)
        {
            //dgvKullanicilar.DataSource = databaseContext.Kullanicilar.ToList();
            dgvKullanicilar.DataSource = manager.GetAll();
        }

        private void btnEkle_Click(object sender, EventArgs e)
        {
            //databaseContext.Kullanicilar.Add(new Entities.Kullanici { Adi = "Halil" });
            int sonuc = manager.Add(new Kullanici
            {
                Adi = txtAdi.Text,
                Soyadi = txtSoyadi.Text,
                Durum = cbDurum.Checked,
                Email = txtEmail.Text,
                KullaniciAdi = txtKullaniciAdi.Text,
                Sifre = txtSifre.Text
            });
            if (sonuc > 0)
            {
                Temizle();
                dgvKullanicilar.DataSource = manager.GetAll();
                MessageBox.Show("Kayıt Başarılı!");
            }
            else MessageBox.Show("Kayıt Başarısız!");
        }
        void Temizle()
        {
            txtAdi.Text = string.Empty;
            txtEmail.Text = "";
            txtKullaniciAdi.Text = string.Empty;
            txtSifre.Text = "";
            txtSoyadi.Text = string.Empty;
            cbDurum.Checked = false;
        }

        private void dgvKullanicilar_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int id = Convert.ToInt32(dgvKullanicilar.CurrentRow.Cells[0].Value);
            Kullanici kullanici = manager.Find(id);
            txtAdi.Text = kullanici.Adi;
            txtSoyadi.Text = kullanici.Soyadi;
            txtEmail.Text = kullanici.Email;
            txtSifre.Text = kullanici.Sifre;
            txtKullaniciAdi.Text = kullanici.KullaniciAdi;
            cbDurum.Checked = kullanici.Durum;
        }

        private void btnGuncelle_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvKullanicilar.CurrentRow.Cells[0].Value);
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
                Temizle();
                dgvKullanicilar.DataSource = manager.GetAll();
                MessageBox.Show("Kayıt Başarılı!");
            }
            else MessageBox.Show("Kayıt Başarısız!");
        }

        private void btnSil_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(dgvKullanicilar.CurrentRow.Cells[0].Value);
            Kullanici kullanici = manager.Find(id);
            int sonuc = manager.Delete(kullanici);
            if (sonuc > 0)
            {
                Temizle();
                dgvKullanicilar.DataSource = manager.GetAll();
                MessageBox.Show("Silme Başarılı!");
            }
            else MessageBox.Show("Silme Başarısız!");
        }
    }
}
