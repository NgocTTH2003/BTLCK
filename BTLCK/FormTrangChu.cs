﻿using System;
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
                if (TheoDoiContainer.Height >= 271)
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
        //mở form danh mục thiết bị
        private void buttonDMThietBi_Click(object sender, EventArgs e)
        {
            FormDanhMucThietBi formDanhMucThietBi = new FormDanhMucThietBi(this);
            formDanhMucThietBi.Show();
            this.Hide();
        }



        private void buttonDMNhaCungCap_Click(object sender, EventArgs e)
        {
            FormDanhMucNhaCungCap formDanhMucNhaCungCap = new FormDanhMucNhaCungCap(this);
            formDanhMucNhaCungCap.Show();
            this.Hide();
        }
        //mở form danh mục nhân viên
        private void buttonDMNhanVien_Click(object sender, EventArgs e)
        {
            FormDanhMucNhanVien formDanhMucNhanVien = new FormDanhMucNhanVien(this);
            formDanhMucNhanVien.Show();
            this.Hide();
        }

        private void buttonDMVienKhoa_Click(object sender, EventArgs e)
        {
            FormDanhMucVienKhoa formDanhMucKhoaPhong = new FormDanhMucVienKhoa(this);
            formDanhMucKhoaPhong.Show();
            this.Hide();
        }

        private void buttonDMKhoVatTu_Click(object sender, EventArgs e)
        {
            FormDanhMucKhoVatTu formDanhMucKhoVatTu = new FormDanhMucKhoVatTu(this);
            formDanhMucKhoVatTu.Show(); 
            this.Hide();
        }

        private void buttonNhapKhoTB_Click(object sender, EventArgs e)
        {
            FormQuanLyNhapKho formQuanLyNhapKho = new FormQuanLyNhapKho(this);
            formQuanLyNhapKho.Show();
            this.Hide();
        }
        
        private void buttonVanChuyenTB_Click(object sender, EventArgs e)
        {
            FormVC formVC = new FormVC(this); 
            formVC.Show();
            this.Hide();
        }

        private void buttonSuaChuaTB_Click(object sender, EventArgs e)
        {
            FormSC formSuaChua = new FormSC(this);
            formSuaChua.Show();
            this.Hide();
        }

        private void buttonBaoTriTB_Click(object sender, EventArgs e)
        {
            FormBT formBT = new FormBT(this);
            formBT.Show();
            this.Hide();
        }

        private void buttonThanhLyTB_Click(object sender, EventArgs e)
        {
            FormThanhLy formThanhLy = new FormThanhLy(this);
            formThanhLy.Show();
            this.Hide();
        }

        private void buttonBaoCaoBaoTri_Click(object sender, EventArgs e)
        {

        }

        private void buttonBaoCaoSuCo_Click(object sender, EventArgs e)
        {

        }

        private void buttonBaoCaoNhapXuat_Click(object sender, EventArgs e)
        {

        }

        private void buttonTKCapNhat_Click(object sender, EventArgs e)
        {

        }

        private void buttonTKDoiMK_Click(object sender, EventArgs e)
        {
            FormTaiKhoan formTaiKhoan = new FormTaiKhoan(this);
            formTaiKhoan.Show();
            this.Hide();
        }

        private void buttonTKDangXuat_Click(object sender, EventArgs e)
        {
            // Tạo một instance của FormDangNhap
            FormDangNhap formDN = new FormDangNhap();
            formDN.Show(); 
            this.Hide();
        }

        private void FormTrangChu_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Kiểm tra xem hành động là do người dùng thực hiện hay không
            if (e.CloseReason == CloseReason.UserClosing)
            {
                // Đóng tất cả các form khác
                foreach (Form form in Application.OpenForms.OfType<Form>().Where(f => f != this))
                {
                    form.Close();
                }
            }
        }

        
    }
}