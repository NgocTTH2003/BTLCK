using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BTLCK
{
    public partial class FormDanhMucThietBi : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=HONGNGOC;Initial Catalog=QuanLyThietBi;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        void LoadData()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from ThietBi";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }
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
            // TODO: This line of code loads data into the 'quanLyThietBiDataSet1.ThietBi' table. You can move, or remove it, as needed.
            this.thietBiTableAdapter.Fill(this.quanLyThietBiDataSet1.ThietBi);
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
