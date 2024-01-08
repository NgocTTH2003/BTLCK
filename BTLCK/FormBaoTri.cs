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
    public partial class FormBaoTri : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=HONGNGOC;Initial Catalog=QuanLyThietBi;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        private FormTrangChu formTrangChu;
        public FormBaoTri(FormTrangChu formTrangChu)
        {
            InitializeComponent();
            this.formTrangChu = formTrangChu;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            //sự kiện ẩn hiện groupbox
            this.Load += FormBaoTri_Load;
        }
        private void FormBaoTri_Load(object sender, EventArgs e)
        {
            try
            {
                //khi hiển thị form thì ẩn groupboxThemThietBi
                groupBox.Visible = false;

                connection = new SqlConnection(str);
                connection.Open();
                command = connection.CreateCommand();
                // Thực hiện truy vấn SQL để lấy dữ liệu từ bảng khác
                command.CommandText = "select ChiTietBaoTri.IDBaoTri, ChiTietBaoTri.IDThietBi,tThietBi.TenThietBi, ChiTietBaoTri.SoLuong,ChiTietBaoTri.DonViBaoTri,ChiTietBaoTri.ChiPhiBaoTri,ChiTietBaoTri.NgayBaoTri,ChiTietBaoTri.NgayHoanThanh,ChiTietBaoTri.TinhTrangBaoTri from ChiTietBaoTri left join ThietBi on ChiTietBaoTri.IDThietBi = ThietBi.IDThietBi";

                // Đổ dữ liệu vào DataTable
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);

                dataGridView1.DataSource = table;
                dataGridView1.Columns["IDBaoTri"].HeaderText = "Mã bảo trì";
                dataGridView1.Columns["IDThietBi"].HeaderText = "Mã thiết bị";
                dataGridView1.Columns["TenThietBi"].HeaderText = "Tên thiết bị";
                dataGridView1.Columns["SoLuong"].HeaderText = "Số lượng";
                dataGridView1.Columns["DonViBaoTri"].HeaderText = "Đơn vị bảo trì";
                dataGridView1.Columns["ChiPhiBaoTri"].HeaderText = "Chi phí bảo trì";
                dataGridView1.Columns["NgayBaoTri"].HeaderText = "Ngày bảo trì";
                dataGridView1.Columns["NgayHoanThanh"].HeaderText = "Ngày hoàn thành";
                dataGridView1.Columns["TinhTrangBaoTri"].HeaderText = "Tình trạng";
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
