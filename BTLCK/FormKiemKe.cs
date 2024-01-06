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
    public partial class FormKiemKe : Form
    {
        private FormTrangChu formTrangChu;
        public FormKiemKe(FormTrangChu formTrangChu)
        {
            InitializeComponent();
            this.formTrangChu = formTrangChu;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            //sự kiện ẩn hiện groupbox
            this.Load += FormKiemKe_Load;
        }
        private void FormKiemKe_Load(object sender, EventArgs e)
        {
            //khi hiển thị form thì ẩn groupbox
            groupBox.Visible = false;
        }
        //nhấn back để trở về trang chủ 
        private void Back_Click(object sender, EventArgs e)
        {
            this.formTrangChu.Show();
            this.Close();
        }
        private void buttonThem_Click(object sender, EventArgs e)
        {
            //gọi hàm để hiển thị/ẩn groupbox
            ShowGroupBox();
        }
        private void ShowGroupBox()
        {
            groupBox.Visible = true;
        }

        private void buttonHuy_Click(object sender, EventArgs e)
        {
            groupBox.Visible = false;
        }

        private void buttonKhoiTao_Click(object sender, EventArgs e)
        {

        }
    }
}
