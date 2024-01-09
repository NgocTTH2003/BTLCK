using Microsoft.Office.Interop.Excel;
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
    public partial class FormBT : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=HONGNGOC;Initial Catalog=QuanLyThietBi;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        System.Data.DataTable table = new System.Data.DataTable();

        private FormTrangChu formTrangChu;
        public FormBT(FormTrangChu formTrangChu)
        {
            InitializeComponent();
            this.formTrangChu = formTrangChu;
        }
        private void Back_Click(object sender, EventArgs e)
        {
            this.formTrangChu.Show();
            this.Close();
        }
        void LoadData()
        {
            //tải dữ liệu
            command = connection.CreateCommand();
            command.CommandText = @"
                                   select ChiTietBaoTri.IDBaoTri,
	                               ChiTietBaoTri.IDThietBi,
	                               ThietBi.TenThietBi,
	                               ChiTietBaoTri.NgayBaoTri,
	                               ChiTietBaoTri.NgayHoanThanh,
	                               ChiTietBaoTri.ChiPhiBaoTri,
	                               ChiTietBaoTri.DonViBaoTri,
	                               ChiTietBaoTri.TinhTrangBaoTri,
	                               ChiTietBaoTri.SoLan
                                   from ChiTietBaoTri inner join ThietBi on ChiTietBaoTri.IDThietBi = ThietBi.IDThietBi;";

            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;

            //thay đổi tên cột
            dataGridView1.Columns[0].HeaderText = "Mã bảo trì";
            dataGridView1.Columns[1].HeaderText = "Mã thiết bị";
            dataGridView1.Columns[2].HeaderText = "Tên thiết bị";
            dataGridView1.Columns[3].HeaderText = "Ngày bảo trì";
            dataGridView1.Columns[4].HeaderText = "Ngày hoàn thành";
            dataGridView1.Columns[5].HeaderText = "Chi phí";
            dataGridView1.Columns[6].HeaderText = "Đơn vị bảo trì";
            dataGridView1.Columns[7].HeaderText = "Tình trạng bảo trì";
            dataGridView1.Columns[8].HeaderText = "Số lần";
        }

        private void FormVC_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            LoadData();
            dataGridView1.CellContentClick += new DataGridViewCellEventHandler(dataGridView1_CellContentClick);
        }
        // Để hiển thị "Nhập từ khóa cần tìm" khi không có nhập liệu
        private void SetPlaceholderText()
        {
            // Đặt placeholder text ban đầu
            textBoxTimKiem.Text = "Nhập từ khóa cần tìm";
            textBoxTimKiem.ForeColor = Color.Gray;
        }
        private void textBoxTimKiem_Enter(object sender, EventArgs e)
        {
            // Khi người dùng click vào textBox
            if (textBoxTimKiem.Text == "Nhập từ khóa cần tìm")
            {
                textBoxTimKiem.Text = "";
                textBoxTimKiem.ForeColor = Color.Black;
            }
        }

        private void textBoxTimKiem_Leave(object sender, EventArgs e)
        {
            // Khi người dùng rời khỏi textBox mà không nhập gì
            if (string.IsNullOrWhiteSpace(textBoxTimKiem.Text))
            {
                SetPlaceholderText();
            }
        }
        private void textBoxTimKiem_TextChanged(object sender, EventArgs e)
        {
            string searchValue = textBoxTimKiem.Text;

            // Kiểm tra xem nếu đang sử dụng placeholder text
            if (searchValue == "Nhập từ khóa cần tìm")
            {
                return; // Không thực hiện tìm kiếm nếu là placeholder text
            }

            // Tạo bộ lọc cho tất cả các cột
            string filter = string.Format("Convert(IDBaoTri, 'System.String') LIKE '%{0}%' OR " +
                              "Convert(IDThietBi, 'System.String') LIKE '%{0}%' OR " +
                              "TenThietBi LIKE '%{0}%' OR " +
                              "Convert(NgayBaoTri, 'System.String') LIKE '%{0}%' OR " +
                              "Convert(NgayHoanThanh, 'System.String') LIKE '%{0}%' OR " +
                              "Convert(ChiPhiBaoTri, 'System.String') LIKE '%{0}%' OR " +
                              "DonViBaoTri LIKE '%{0}%' OR " +
                              "TinhTrangBaoTri LIKE '%{0}%' OR " +
                              "Convert(SoLan, 'System.String') LIKE '%{0}%'", searchValue);

            // Kiểm tra xem table đã được khởi tạo và có dữ liệu
            if (table != null)
            {
                // Áp dụng bộ lọc
                table.DefaultView.RowFilter = filter;
                dataGridView1.DataSource = table;
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            txtMaBT.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtMaTB.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtTenTB.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            NgayBT.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            NgayHT.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            txtChiPhi.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            txtDonViBT.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
            txtTinhTrang.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();
            txtSoLan.Text = dataGridView1.Rows[i].Cells[8].Value.ToString();
        }

        //xuất file
        private void ExportDataGridViewToExcel()
        {
            // Tạo một ứng dụng Excel mới
            var excelApp = new Microsoft.Office.Interop.Excel.Application();
            excelApp.Workbooks.Add();

            _Worksheet workSheet = (_Worksheet)excelApp.ActiveSheet;

            // Đặt tiêu đề cho các cột
            for (int i = 1; i < dataGridView1.Columns.Count + 1; i++)
            {
                workSheet.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
            }

            // Chuyển dữ liệu
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                // Kiểm tra xem dòng này có phải là dòng mới (chưa được commit) không
                if (!dataGridView1.Rows[i].IsNewRow)
                {
                    for (int j = 0; j < dataGridView1.Columns.Count; j++)
                    {
                        // Kiểm tra giá trị null trước khi gọi phương thức ToString()
                        workSheet.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value?.ToString() ?? "";
                    }
                }
            }

            // Hiển thị Excel và đưa người dùng quyết định lưu file
            excelApp.Visible = true;
            // Hiển thị thông báo sau khi Excel được mở
            MessageBox.Show("Xuất file Excel thành công");
        }

        private void buttonXuat_Click(object sender, EventArgs e)
        {
            ExportDataGridViewToExcel();
        }

        // Hàm để tải lại dữ liệu từ cơ sở dữ liệu và cập nhật DataGridView
        void ReloadData()
        {
            try
            {
                connection.Open();
                command = connection.CreateCommand();
                command.CommandText = @"
                                    select ChiTietBaoTri.IDBaoTri,
	                                ChiTietBaoTri.IDThietBi,
	                                ThietBi.TenThietBi,
	                                ChiTietBaoTri.NgayBaoTri,
	                                ChiTietBaoTri.NgayHoanThanh,
	                                ChiTietBaoTri.ChiPhiBaoTri,
	                                ChiTietBaoTri.DonViBaoTri,
	                                ChiTietBaoTri.TinhTrangBaoTri,
	                                ChiTietBaoTri.SoLan
                                    from ChiTietBaoTri inner join ThietBi on ChiTietBaoTri.IDThietBi = ThietBi.IDThietBi;";
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi tải lại dữ liệu: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                {
                    connection.Close();
                }
            }
        }

        private void buttonKhoiTao1_Click(object sender, EventArgs e)
        {
            txtMaBT.ResetText();
            txtMaTB.ResetText();
            txtTenTB.ResetText();
            NgayBT.Text = string.Empty;
            NgayHT.Text = string.Empty;
            txtChiPhi.ResetText();
            txtDonViBT.ResetText();
            txtTinhTrang.ResetText();
            txtSoLan.ResetText();
        }
    }
}
