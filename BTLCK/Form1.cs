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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            registerEvent();
        }

        #region Event

        void registerEvent()
        {
            lblClose.Click += LblClose_Click;
            btnSignUp.Click += BtnSignUp_Click;
        }

        private void LblClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnSignUp_Click(object sender, EventArgs e)
        {
            FormSignUp signUpForm = new FormSignUp();
            signUpForm.FormClosed += SignUpForm_FormClosed;
            signUpForm.Show();
            this.Hide();
        }
        private void SignUpForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            this.Close();
        }

        #endregion
        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void lblClose_Click(object sender, EventArgs e)
        {
         
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void btnSignup_Click(object sender, EventArgs e)
        {

        }
    }
}
