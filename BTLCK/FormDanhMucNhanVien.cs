using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace BTLCK
{
    public partial class FormDanhMucNhanVien : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=HONGNGOC;Initial Catalog=QuanLyThietBi;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        void LoadData()
        {
            command = connection.CreateCommand();
            command.CommandText = "select * from NhanVien";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        public FormDanhMucNhanVien(FormTrangChu formTrangChu)
        {
            try
            {
                InitializeComponent();
                this.formTrangChu = formTrangChu;
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                //sự kiện ẩn hiện groupbox
                this.Load += FormDanhMucNhanVien_Load;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
            
        }
        //nhấn back để trở về trang chủ 
        private FormTrangChu formTrangChu;

        private void Back_Click(object sender, EventArgs e)
        {
            this.formTrangChu.Show();
            this.Close();
        }

        private void FormDanhMucNhanVien_Load(object sender, EventArgs e)
        {
            //khi hiển thị form thì ẩn groupboxThemThietBi
            groupBoxThemNV.Visible = false;
            
            connection = new SqlConnection(str);
            connection.Open();
            LoadData();
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            ShowGroupBoxNV();
        }

        private void ShowGroupBoxNV()
        {
            groupBoxThemNV.Visible = true;
        }

        private void buttonHuy_Click(object sender, EventArgs e)
        {
            groupBoxThemNV.Visible = false;
        }

        private void buttonKhoiTao_Click(object sender, EventArgs e)
        {
            txtMaNV.ResetText();
            checkBox1.Text = string.Empty;
            checkBox2.Text = string.Empty;
            txtHoTen.ResetText();
            txtKho.ResetText();
            txtSDT.ResetText();
            comboBoxCV.Text = string.Empty;
            dateTimePickerNS.Text = string.Empty;
        }

        private void dateTimePickerNS_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerNS.Format = DateTimePickerFormat.Custom;
            dateTimePickerNS.CustomFormat = "yyyy-MM-dd";
        }

        private void FormDanhMucNhanVien_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyThietBiDataSet.NhanVien' table. You can move, or remove it, as needed.
            this.nhanVienTableAdapter.Fill(this.quanLyThietBiDataSet.NhanVien);

        }
    }
}
