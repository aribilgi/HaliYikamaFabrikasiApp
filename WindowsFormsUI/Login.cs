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

namespace WindowsFormsUI
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
        KullaniciManager manager = new KullaniciManager();
        private void btnGiris_Click(object sender, EventArgs e)
        {
            var sonuc = manager.GetAll().Where(k=>k.KullaniciAdi == txtKullaniciAdi.Text.Trim() & k.Sifre == txtSifre.Text.Trim() & k.Durum); // trim metodu textboxdan gelen metnin önündeki ve sonundaki boşlukları kaldırır
            if (sonuc != null)
            {
                AnaEkran anaEkran = new AnaEkran();
                anaEkran.Show();
            }
            else MessageBox.Show("Kullanıcı Adı veya Şifre Geçersiz!");
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }
    }
}
