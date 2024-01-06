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
    public partial class FormDanhMucKhoVatTu : Form
    {
        private FormTrangChu formTrangChu;

        public FormDanhMucKhoVatTu(FormTrangChu formTrangChu)
        {
            InitializeComponent();
            this.formTrangChu = formTrangChu;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //sự kiện ẩn hiện groupbox
            this.Load += FormDanhMucKhoVatTu_Load;
        }

        private void txtTB_TextChanged(object sender, EventArgs e)
        {

        }
        private void Back_Click(object sender, EventArgs e)
        {
            this.formTrangChu.Show();
            this.Close();
        }

        private void FormDanhMucKhoVatTu_Load(object sender, EventArgs e)
        {
            //khi hiển thị form thì ẩn groupboxThemThietBi
            groupBoxKho.Visible = false;
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            ShowGroupBoxKhoVatTu();
        }

        private void ShowGroupBoxKhoVatTu()
        {
            groupBoxKho.Visible = true;
        }

        private void buttonHuy_Click(object sender, EventArgs e)
        {
            groupBoxKho.Visible = false;
        }

        private void buttonKhoiTao_Click(object sender, EventArgs e)
        {
            comboBoxDV.Text = string.Empty;
            comboBoxKho.Text = string.Empty;
            txtSoLuongTB.ResetText();
            txtTB.ResetText();
        }
    }
}
