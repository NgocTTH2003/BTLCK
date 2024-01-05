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
    public partial class FormTrangChu : Form
    {
        bool DanhMucExpand = false;
        bool NhapVaKiemKeExpand = false;
        bool TheoDoiExpand = false;
        bool BaoCaoExpand = false;
        bool TaiKhoanExpand = false;
        public FormTrangChu()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DanhMucPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {

        }

        private void DanhMucTimer_Tick(object sender, EventArgs e)
        {
            if (DanhMucExpand == false)
            {
                DanhMucContainer.Height += 5;
                if (DanhMucContainer.Height >= 380)
                {
                    DanhMucTimer.Stop();
                    DanhMucExpand = true;
                }
            }
            else
            {
                DanhMucContainer.Height -= 5;
                if (DanhMucContainer.Height <= 58)
                {
                    DanhMucTimer.Stop();
                    DanhMucExpand = false;
                }
            }
        }

        private void DanhMuc_Click(object sender, EventArgs e)
        {
            DanhMucTimer.Start();
        }

        private void flowLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void NhapVaKiemKeTimer_Tick(object sender, EventArgs e)
        {
            if (NhapVaKiemKeExpand == false)
            {
                NhapVaKiemKeContainer.Height += 5;
                if (NhapVaKiemKeContainer.Height >= 197)
                {
                    NhapVaKiemKeTimer.Stop();
                    NhapVaKiemKeExpand = true;
                }
            }
            else
            {
                NhapVaKiemKeContainer.Height -= 5;
                if (NhapVaKiemKeContainer.Height <= 58)
                {
                    NhapVaKiemKeTimer.Stop();
                    NhapVaKiemKeExpand = false;
                }
            }
        }



        private void NhapVaKiemKe_Click(object sender, EventArgs e)
        {
            NhapVaKiemKeTimer.Start();
        }

        private void TheoDoiTimer_Tick(object sender, EventArgs e)
        {
            if (TheoDoiExpand == false)
            {
                TheoDoiContainer.Height += 5;
                if (TheoDoiContainer.Height >= 337)
                {
                    TheoDoiTimer.Stop();
                    TheoDoiExpand = true;
                }
            }
            else
            {
                TheoDoiContainer.Height -= 5;
                if (TheoDoiContainer.Height <= 58)
                {
                    TheoDoiTimer.Stop();
                    TheoDoiExpand = false;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            TheoDoiTimer.Start();
        }

        private void BaoCaoTimer_Tick(object sender, EventArgs e)
        {
            if (BaoCaoExpand == false)
            {
                BaoCaoContainer.Height += 5;
                if (BaoCaoContainer.Height >= 317)
                {
                    BaoCaoTimer.Stop();
                    BaoCaoExpand = true;
                }
            }
            else
            {
                BaoCaoContainer.Height -= 5;
                if (BaoCaoContainer.Height <= 58)
                {
                    BaoCaoTimer.Stop();
                    BaoCaoExpand = false;
                }
            }
        }

        private void BaoCao_Click(object sender, EventArgs e)
        {
            BaoCaoTimer.Start();
        }

        private void TaiKhoanTimer_Tick(object sender, EventArgs e)
        {
            if (TaiKhoanExpand == false)
            {
                TaiKhoanContainer.Height += 5;
                if (TaiKhoanContainer.Height >= 256)
                {
                    TaiKhoanTimer.Stop();
                    TaiKhoanExpand = true;
                }
            }
            else
            {
                TaiKhoanContainer.Height -= 5;
                if (TaiKhoanContainer.Height <= 58)
                {
                    TaiKhoanTimer.Stop();
                    TaiKhoanExpand = false;
                }
            }
        }

        private void button6_Click(object sender, EventArgs e)
        {
            TaiKhoanTimer.Start();
        }

        private void button15_Click(object sender, EventArgs e)
        {

        }

        private void BaoCaoContainer_Paint(object sender, PaintEventArgs e)
        {

        }
        //mở form danh mục thiết bị
        private void buttonDMThietBi_Click(object sender, EventArgs e)
        {
            FormDanhMucThietBi formDanhMucThietBi = new FormDanhMucThietBi(this);
            formDanhMucThietBi.Show();
            this.Hide();
        }

        private void panel25_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonDMNhaCungCap_Click(object sender, EventArgs e)
        {

        }
        //mở form danh mục nhân viên
        private void buttonDMNhanVien_Click(object sender, EventArgs e)
        {
            FormDanhMucNhanVien formDanhMucNhanVien = new FormDanhMucNhanVien(this);
            formDanhMucNhanVien.Show();
            this.Hide();
        }

        private void buttonDMKhoaPhong_Click(object sender, EventArgs e)
        {

        }

        private void buttonDMKhoVatTu_Click(object sender, EventArgs e)
        {

        }
    }
}