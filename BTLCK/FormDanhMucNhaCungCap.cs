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
    public partial class FormDanhMucNhaCungCap : Form
    {
        public FormDanhMucNhaCungCap(FormTrangChu formTrangChu)
        {
            InitializeComponent();
            this.formTrangChu = formTrangChu;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //sự kiện ẩn hiện groupbox
            this.Load += FormDanhMucNhaCungCap_Load;
        }

        //nhấn back để trở về trang chủ 
        private FormTrangChu formTrangChu;

        private void Back_Click(object sender, EventArgs e)
        {
            this.formTrangChu.Show();
            this.Close();
        }

        private void FormDanhMucNhaCungCap_Load(object sender, EventArgs e)
        {
            //khi hiển thị form thì ẩn groupboxThemThietBi
            groupBoxTTNCC.Visible = false;
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            ShowGroupBoxNCC();
        }

        private void ShowGroupBoxNCC()
        {
            groupBoxTTNCC.Visible = true;
        }

        private void buttonHuy_Click(object sender, EventArgs e)
        {
            groupBoxTTNCC.Visible = false;
        }

        private void buttonKhoiTao_Click(object sender, EventArgs e)
        {
            txtTenNCC.ResetText();
            txtEmail.ResetText();
            txtSDT.ResetText();
            comboBoxDC.Text = string.Empty;
        }
    }
}
