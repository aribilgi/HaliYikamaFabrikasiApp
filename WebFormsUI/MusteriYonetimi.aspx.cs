using BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

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
        }
    }
}