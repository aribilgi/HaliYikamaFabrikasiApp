//using DAL; Dal katmanına kullanıcı arayüzünden direk erişmemeliyiz!!!
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

        }
    }
}
