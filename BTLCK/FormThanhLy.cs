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
    public partial class FormThanhLy : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=HONGNGOC;Initial Catalog=QuanLyThietBi;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        private FormTrangChu formTrangChu;
        public FormThanhLy(FormTrangChu formTrangChu)
        {
            InitializeComponent();
            this.formTrangChu = formTrangChu;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //sự kiện ẩn hiện groupbox
            this.Load += FormThanhLy_Load;
        }
        
        private void FormThanhLy_Load(object sender, EventArgs e)
        {
            try
            {
                //khi hiển thị form thì ẩn groupboxThemThietBi
                groupBox.Visible = false;

                connection = new SqlConnection(str);
                connection.Open();
                command = connection.CreateCommand();
                // Thực hiện truy vấn SQL để lấy dữ liệu từ bảng khác
                command.CommandText = "select ChiTietThanhLy.IDThanhLy, ChiTietThanhLy.IDThietBi,ThietBi.IDThietBi, ChiTietThanhLy.SoLuong, ChiTietThanhLy.DonGia, ChiTietThanhLy.ThanhTien, NhanVien.HoTen, ChiTietThanhLy.NgayThanhLy\r\nfrom ChiTietThanhLy inner join ThietBi on ChiTietThanhLy.IDThietBi = ThietBi.IDThietBi\r\n\t\t\t\t\tinner join NhanVien on ChiTietThanhLy.IDNhanVien = NhanVien.IDNhanVien;";

                // Đổ dữ liệu vào DataTable
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);

                dataGridView1.DataSource = table;
                dataGridView1.Columns["IDThanhLy"].HeaderText = "Mã thanh lý";
                dataGridView1.Columns["IDThietBi"].HeaderText = "Mã thiết bị";
                dataGridView1.Columns["TenThietBi"].HeaderText = "Tên thiết bị";
                dataGridView1.Columns["SoLuong"].HeaderText = "Số lượng";
                dataGridView1.Columns["DonGia"].HeaderText = "Đơn giá";
                dataGridView1.Columns["ThanhTien"].HeaderText = "Thành tiền";
                dataGridView1.Columns["HoTen"].HeaderText = "Nhân viên thực hiện";
                dataGridView1.Columns["NgayThanhLy"].HeaderText = "Ngày thanh lý";
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

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
