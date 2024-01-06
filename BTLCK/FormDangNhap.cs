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
    public partial class FormDangNhap : Form
    {
        public FormDangNhap()
        {
            InitializeComponent();
            InitializePlaceholder();
            registerEvent();
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

        #region Event

        void registerEvent()
        {
            btnSignUp.Click += BtnSignUp_Click;
            picEye.Click += PicEye_Click;
        }


        private void BtnSignUp_Click(object sender, EventArgs e)
        {
            FormDangKyTK signUpForm = new FormDangKyTK();
            signUpForm.FormClosed += SignUpForm_FormClosed;
            signUpForm.Show();
            this.Hide();
        }
        private void SignUpForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
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

        #endregion

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
    }
}
