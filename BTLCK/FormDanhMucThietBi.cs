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
        }

        private void labelTimKiem_Click(object sender, EventArgs e)
        {

        }

        private void labelTimKiem_Click_1(object sender, EventArgs e)
        {

        }

        private void FormDanhMucThietBi_Load(object sender, EventArgs e)
        {

        }

        //nhấn back để trở về trang chủ 
        private FormTrangChu formTrangChu;
        
        private void Back_Click(object sender, EventArgs e)
        {
            this.formTrangChu.Show();
            this.Close();
        }

        private void groupBoxThemThietBi_Enter(object sender, EventArgs e)
        {

        }

        private void dateTimePickerNSX_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerNSX.Format = DateTimePickerFormat.Custom;
            dateTimePickerNSX.CustomFormat = "yyyy-MM-dd";
        }
    }
}
