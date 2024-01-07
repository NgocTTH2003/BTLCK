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
using System.Data.SqlClient;

namespace BTLCK
{
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
            InitializePlaceholder();
            
        }

        private void InitializePlaceholder()
        {
            txtUser.Text = "Tài khoản";
            txtUser.ForeColor = Color.White;

            txtUser.Enter += txtUser_GotFocus; 
            txtUser.Leave += txtUser_LostFocus;

            txtPass.Text = "Mật khẩu";
            txtPass.ForeColor = Color.White;

            txtPass.Enter += txtPass_GotFocus;
            txtPass.Leave += txtPass_LostFocus;
        }

        private void txtUser_GotFocus(object sender, EventArgs e)
        {
            if (txtUser.Text == "Tài khoản")
            {
                txtUser.Text = "";
                txtUser.ForeColor = Color.White;
            }
        }
        private void txtPass_GotFocus(object sender, EventArgs e)
        {
            if (txtPass.Text == "Mật khẩu")
            {
                txtPass.Text = "";
                txtPass.ForeColor = Color.White;
            }
        }

        private void txtUser_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUser.Text))
            {
                txtUser.Text = "Tài khoản";
                txtUser.ForeColor = Color.White;
            }
        }

        private void txtPass_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPass.Text))
            {
                txtPass.Text = "Mật khẩu";
                txtPass.ForeColor = Color.White;
            }
        }

        private void txtUser_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtUser.Text))
            {
                txtUser.Text = "Tài khoản";
                txtUser.ForeColor = Color.White; 
            }
        }

        private void txtPass_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtPass.Text))
            {
                txtPass.Text = "Mật khẩu";
                txtPass.ForeColor = Color.White;
            }
        }



        private void BtnSignUp_Click(object sender, EventArgs e)
        {
            FormDangKyTK formDangKyTK = new FormDangKyTK(this);
            formDangKyTK.Show();
            this.Hide();
        }

        private void PicEye_Click(object sender, EventArgs e)
        {
            if (txtPass.PasswordChar == '*')
            {
                txtPass.PasswordChar = '\0';
            }
            else
            {
                txtPass.PasswordChar = '*';
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void btnSignup_Click(object sender, EventArgs e)
        {

        }

        private void txtUser_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtPass_TextChanged(object sender, EventArgs e)
        {
            txtPass.PasswordChar = '*';
        }

        private void buttonEye_Click(object sender, EventArgs e)
        {
            if (txtPass.PasswordChar == '*')
            {
                txtPass.PasswordChar = '\0';
            }
            else
            {
                txtPass.PasswordChar = '*';
            }
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            using (SqlConnection scn = new SqlConnection(@"Data Source=HONGNGOC;Initial Catalog=QuanLyThietBi;Integrated Security=True"))
            {
                try
                {
                    scn.Open();

                    string Query = "SELECT * FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap AND MatKhau = @MatKhau";
                    SqlCommand cmd = new SqlCommand(Query, scn);
                    cmd.Parameters.AddWithValue("@TenDangNhap", txtUser.Text);
                    cmd.Parameters.AddWithValue("@MatKhau", txtPass.Text);

                    SqlDataAdapter adap = new SqlDataAdapter(cmd);

                    DataTable dat = new DataTable();
                    adap.Fill(dat);

                    if (dat.Rows.Count > 0)
                    {
                        Form flog = new FormTrangChu();
                        Hide();
                        flog.Show();
                        flog.Focus();
                    }
                    else
                    {
                        MessageBox.Show("Tài khoản hoặc mật khẩu không hợp lệ!!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txtUser.Clear();
                        txtPass.Clear();

                        txtUser.Focus();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi: " + ex.Message);
                }
            }
        }


        private void btnLogin_Click(object sender, EventArgs e)
        {

        }

    }
}
