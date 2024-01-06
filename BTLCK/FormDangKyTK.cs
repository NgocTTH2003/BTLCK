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
    public partial class FormDangKyTK : Form
    {
        private FormDangNhap formDangNhap;
        public FormDangKyTK(FormDangNhap formDangNhap)
        {
            InitializeComponent();
            
            this.formDangNhap = formDangNhap;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            InitializePlaceholder();
        }
        private void InitializePlaceholder()
        {
            txtMaNV.Text = "Mã số nhân viên";
            txtMaNV.ForeColor = Color.Black;

            txtMaNV.Enter += txtMaNV_GotFocus;
            txtMaNV.Leave += txtMaNV_LostFocus;

            txtTK.Text = "Tài khoản";
            txtTK.ForeColor = Color.Black;

            txtTK.Enter += txtTK_GotFocus;
            txtTK.Leave += txtTK_LostFocus;

            txtMK.Text = "Mật khẩu";
            txtMK.ForeColor = Color.Black;

            txtMK.Enter += txtMK_GotFocus;
            txtMK.Leave += txtMK_LostFocus;

            txtXacNhanMK.Text = "Xác nhận mật khẩu";
            txtXacNhanMK.ForeColor = Color.Black;

            txtXacNhanMK.Enter += txtXacNhanMK_GotFocus;
            txtXacNhanMK.Leave += txtXacNhanMK_LostFocus;
        }

        private void txtMaNV_GotFocus(object sender, EventArgs e)
        {
            if (txtMaNV.Text == "Mã số nhân viên")
            {
                txtMaNV.Text = "";
                txtMaNV.ForeColor = Color.Black;
            }
        }
        private void txtTK_GotFocus(object sender, EventArgs e)
        {
            if (txtTK.Text == "Tài khoản")
            {
                txtTK.Text = "";
                txtTK.ForeColor = Color.Black;
            }
        }
        private void txtMK_GotFocus(object sender, EventArgs e)
        {
            if (txtMK.Text == "Mật khẩu")
            {
                txtMK.Text = "";
                txtMK.ForeColor = Color.Black;
            }
        }
        private void txtXacNhanMK_GotFocus(object sender, EventArgs e)
        {
            if (txtXacNhanMK.Text == "Xác nhận mật khẩu")
            {
                txtXacNhanMK.Text = "";
                txtXacNhanMK.ForeColor = Color.Black;
            }
        }

        private void txtMaNV_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                txtMaNV.Text = "Mã số nhân viên";
                txtMaNV.ForeColor = Color.Black;
            }
        }

        private void txtTK_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTK.Text))
            {
                txtTK.Text = "Tài khoản";
                txtTK.ForeColor = Color.Black;
            }
        }
        private void txtMK_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMK.Text))
            {
                txtMK.Text = "Mật khẩu";
                txtMK.ForeColor = Color.Black;
            }
        }
        private void txtXacNhanMK_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtXacNhanMK.Text))
            {
                txtXacNhanMK.Text = "Xác nhận mật khẩu";
                txtXacNhanMK.ForeColor = Color.Black;
            }
        }

        private void txtMaNV_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                txtMaNV.Text = "Mã số nhân viên";
                txtMaNV.ForeColor = Color.Black;
            }
        }

        private void txtTK_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTK.Text))
            {
                txtTK.Text = "Tài khoản";
                txtTK.ForeColor = Color.Black;
            }
        }
        private void txtMK_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMK.Text))
            {
                txtMK.Text = "Mật khẩu";
                txtMK.ForeColor = Color.Black;
            }
        }
        private void txtXacNhanMK_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtXacNhanMK.Text))
            {
                txtXacNhanMK.Text = "Tài khoản";
                txtXacNhanMK.ForeColor = Color.Black;
            }
        }
        private void FormDangKyTK_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnKhoiTao_Click(object sender, EventArgs e)
        {
            txtMaNV.ResetText();
            txtMK.ResetText();
            txtTK.ResetText();
            txtXacNhanMK.ResetText();
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.formDangNhap.Show();
            this.Close();
        }

    }
}
