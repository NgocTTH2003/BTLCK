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
    public partial class FormDanhMucNhanVien : Form
    {
        public FormDanhMucNhanVien(FormTrangChu formTrangChu)
        {
            InitializeComponent();
            this.formTrangChu = formTrangChu;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //sự kiện ẩn hiện groupbox
            this.Load += FormDanhMucNhanVien_Load;
        }
        //nhấn back để trở về trang chủ 
        private FormTrangChu formTrangChu;

        private void Back_Click(object sender, EventArgs e)
        {
            this.formTrangChu.Show();
            this.Close();
        }

        private void FormDanhMucNhanVien_Load(object sender, EventArgs e)
        {
            //khi hiển thị form thì ẩn groupboxThemThietBi
            groupBoxThemNV.Visible = false;
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            ShowGroupBoxNV();
        }

        private void ShowGroupBoxNV()
        {
            groupBoxThemNV.Visible = true;
        }

        private void buttonHuy_Click(object sender, EventArgs e)
        {
            groupBoxThemNV.Visible = false;
        }

        private void buttonKhoiTao_Click(object sender, EventArgs e)
        {
            txtGT.ResetText();
            txtHoTen.ResetText();
            txtKho.ResetText();
            txtSDT.ResetText();
            comboBoxCV.Text = string.Empty;
            dateTimePickerNS.Text = string.Empty;
        }

        private void dateTimePickerNS_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerNS.Format = DateTimePickerFormat.Custom;
            dateTimePickerNS.CustomFormat = "yyyy-MM-dd";
        }
    }
}
