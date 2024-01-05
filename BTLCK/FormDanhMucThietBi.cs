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
    public partial class FormDanhMucThietBi : Form
    {
        public FormDanhMucThietBi(FormTrangChu formTrangChu)
        {
            InitializeComponent();
            this.formTrangChu = formTrangChu;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;

            //sự kiện ẩn hiện groupbox
            this.Load += FormDanhMucThietBi_Load;
        }

        private void FormDanhMucThietBi_Load(object sender, EventArgs e)
        {
            //khi hiển thị form thì ẩn groupboxThemThietBi
            groupBoxThemThietBi.Visible = false;
        }

        private void labelTimKiem_Click(object sender, EventArgs e)
        {

        }

        private void labelTimKiem_Click_1(object sender, EventArgs e)
        {

        }


        //nhấn back để trở về trang chủ 
        private FormTrangChu formTrangChu;
        
        private void Back_Click(object sender, EventArgs e)
        {
            this.formTrangChu.Show();
            this.Close();
        }

        private void dateTimePickerNSX_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerNSX.Format = DateTimePickerFormat.Custom;
            dateTimePickerNSX.CustomFormat = "yyyy-MM-dd";
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            //gọi hàm để hiển thị/ẩn groupbox
            ShowGroupBox();
        }


        private void ShowGroupBox()
        {
            groupBoxThemThietBi.Visible = true;
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {

        }

        private void buttonKhoiTao_Click(object sender, EventArgs e)
        {
            textBoxTenTB.ResetText();
            textBoxGiaTB.ResetText();
            textBoxMaKho.ResetText();
            textBoxMaNV.ResetText();
            textBoxNCC.ResetText();
            comboBoxLoaiTB.Text = string.Empty;
            comboBoxTTTB.Text = string.Empty;
            comboBoxVTDat.Text = string.Empty;
            dateTimePickerNSX.Text = string.Empty;
        }

        private void buttonHuy_Click(object sender, EventArgs e)
        {
            groupBoxThemThietBi.Visible = false;
        }


    }
}
