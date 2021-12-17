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

        }
    }
}
