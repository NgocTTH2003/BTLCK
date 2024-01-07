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
    public partial class FormSuaChua : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=HONGNGOC;Initial Catalog=QuanLyThietBi;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        private FormTrangChu formTrangChu;
        public FormSuaChua(FormTrangChu formTrangChu)
        {
            InitializeComponent();
            this.formTrangChu = formTrangChu;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //sự kiện ẩn hiện groupbox
            this.Load += FormSuaChua_Load;
            this.formTrangChu = formTrangChu;
        }

        private void FormSuaChua_Load(object sender, EventArgs e)
        {
            try
            {
                //khi hiển thị form thì ẩn groupboxThemThietBi
                groupBox.Visible = false;

                connection = new SqlConnection(str);
                connection.Open();
                command = connection.CreateCommand();
                // Thực hiện truy vấn SQL để lấy dữ liệu từ bảng khác
                command.CommandText = "select ChiTietSuaChua.IDSua,ChiTietSuaChua.IDThietBi,ChiTietSuaChua.DonViSua,ChiTietSuaChua.ChiPhiSua,ChiTietSuaChua.NgaySua,ChiTietSuaChua.NgayHoanThanh,ChiTietSuaChua.TinhTrangSua,ChiTietSuaChua.SoLuong, ThietBi.TenThietBi from ChiTietSuaChua left join ThietBi on ChiTietSuaChua.IDThietBi = ThietBi.IDThietBi";

                // Đổ dữ liệu vào DataTable
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);

                dataGridView1.DataSource = table;
                dataGridView1.Columns["TenThietBi"].HeaderText = "Tên thiết bị";
                dataGridView1.Columns["IDSua"].HeaderText = "Mã sửa chữa";
                dataGridView1.Columns["IDThietBi"].HeaderText = "Mã thiết bị";
                dataGridView1.Columns["DonViSua"].HeaderText = "Đơn vị sửa";
                dataGridView1.Columns["ChiPhiSua"].HeaderText = "Chi phí sửa";
                dataGridView1.Columns["NgaySua"].HeaderText = "Ngày sửa";
                dataGridView1.Columns["NgayHoanThanh"].HeaderText = "Ngày hoàn thành";
                dataGridView1.Columns["SoLuong"].HeaderText = "Số lượng";
                dataGridView1.Columns["TinhTrangSua"].HeaderText = "Tình trạng";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.formTrangChu.Show();
            this.Close();
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
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

        private void FormSuaChua_Load_1(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'quanLyThietBiDataSet4.ChiTietSuaChua' table. You can move, or remove it, as needed.
            this.chiTietSuaChuaTableAdapter.Fill(this.quanLyThietBiDataSet4.ChiTietSuaChua);

        }
    }
}
