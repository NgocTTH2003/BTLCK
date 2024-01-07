using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BTLCK
{
    public partial class FormDanhMucVienKhoa : Form
    {
        public FormDanhMucVienKhoa(FormTrangChu formTrangChu)
        {
            InitializeComponent();
            this.formTrangChu = formTrangChu;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //sự kiện ẩn hiện groupbox
            this.Load += FormDanhMucVienKhoa_Load;
        }
        //nhấn back để trở về trang chủ 
        private FormTrangChu formTrangChu;

        private void Back_Click(object sender, EventArgs e)
        {
            this.formTrangChu.Show();
            this.Close();
        }

        private void FormDanhMucVienKhoa_Load(object sender, EventArgs e)
        {
            //khi hiển thị form thì ẩn groupboxThemThietBi
            groupBoxKhoaPhong.Visible = false;
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            ShowGroupBoxKhoaPhong();
        }

        private void ShowGroupBoxKhoaPhong()
        {
            groupBoxKhoaPhong.Visible = true;
        }

        private void buttonHuy_Click(object sender, EventArgs e)
        {
            groupBoxKhoaPhong.Visible = false;
        }

        private void buttonKhoiTao_Click(object sender, EventArgs e)
        {
            txtMaKhoa.ResetText();
            comboBoxKhoa.Text = string.Empty;
            comboBoxDV.Text = string.Empty;
        }

        private void comboBoxVien_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void FormDanhMucVienKhoa_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyThietBiDataSet3.Khoa' table. You can move, or remove it, as needed.
            this.khoaTableAdapter.Fill(this.quanLyThietBiDataSet3.Khoa);

        }

        private void comboBoxDV_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
