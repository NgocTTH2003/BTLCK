using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTLCK
{
    public partial class FormTaiKhoan : Form
    {
        private FormTrangChu formTrangChu;

        public FormTaiKhoan(FormTrangChu formTrangChu)
        {
            InitializeComponent();
            this.formTrangChu = formTrangChu;
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.formTrangChu.Show();
            this.Hide();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {

        }
    }
}
