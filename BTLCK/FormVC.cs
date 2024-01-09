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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BTLCK
{
    public partial class FormVC : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=HONGNGOC;Initial Catalog=QuanLyThietBi;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        System.Data.DataTable table = new System.Data.DataTable();

        private FormTrangChu formTrangChu;
        public FormVC(FormTrangChu formTrangChu)
        {
            InitializeComponent();
            this.formTrangChu = formTrangChu;
        }
        //nhấn back để trở về trang chủ
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
                                    select ChiTietVanChuyen.IDVanChuyen, 
                                           ChiTietVanChuyen.IDThietBi, 
                                           ThietBi.TenThietBi, 
                                           ChiTietVanChuyen.NgayVanChuyen, 
                                           ChiTietVanChuyen.NgayNhan, 
                                           Khoa.TenKhoa, 
                                           ChiTietVanChuyen.SoLuong,
                                           NhanVien.HoTen, 
                                           ChiTietVanChuyen.TinhTrangVanChuyen
                                    from ChiTietVanChuyen 
                                    inner join ThietBi on ChiTietVanChuyen.IDThietBi = ThietBi.IDThietBi
                                    inner join NhanVien on ChiTietVanChuyen.IDNhanVien = NhanVien.IDNhanVien
                                    inner join Khoa on ChiTietVanChuyen.IDVienKhoa = Khoa.IDVienKhoa";

            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;

            //thay đổi tên cột
            dataGridView1.Columns[0].HeaderText = "Mã vận chuyển";
            dataGridView1.Columns[1].HeaderText = "Mã thiết bị";
            dataGridView1.Columns[2].HeaderText = "Tên thiết bị";
            dataGridView1.Columns[3].HeaderText = "Ngày vận chuyển";
            dataGridView1.Columns[4].HeaderText = "Ngày nhận";
            dataGridView1.Columns[5].HeaderText = "Nơi nhận";
            dataGridView1.Columns[6].HeaderText = "Số lượng";
            dataGridView1.Columns[7].HeaderText = "Nhân viên phụ trách";
            dataGridView1.Columns[8].HeaderText = "Tình trạng vận chuyển";
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
            string filter = string.Format("Convert(IDVanChuyen, 'System.String') LIKE '%{0}%' OR " +
                              "Convert(IDThietBi, 'System.String') LIKE '%{0}%' OR " +
                              "TenThietBi LIKE '%{0}%' OR " +
                              "Convert(NgayVanChuyen, 'System.String') LIKE '%{0}%' OR " +
                              "Convert(NgayNhan, 'System.String') LIKE '%{0}%' OR " +
                              "TenKhoa LIKE '%{0}%' OR " +
                              "Convert(SoLuong, 'System.String') LIKE '%{0}%' OR " +
                              "HoTen LIKE '%{0}%' OR " +
                              "TinhTrangVanChuyen LIKE '%{0}%'", searchValue);

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
            txtMaVC.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtMaTB.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtTenTB.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            NgayVC.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            NgayNhan.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            txtNoiNhan.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            txtSL.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
            txtNV.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();
            txtTinhTrang.Text = dataGridView1.Rows[i].Cells[8].Value.ToString();
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
                                    select ChiTietVanChuyen.IDVanChuyen, 
                                           ChiTietVanChuyen.IDThietBi, 
                                           ThietBi.TenThietBi, 
                                           ChiTietVanChuyen.NgayVanChuyen, 
                                           ChiTietVanChuyen.NgayNhan, 
                                           Khoa.TenKhoa, 
                                           Khoa.DiaChi,
                                           NhanVien.HoTen, 
                                           ChiTietVanChuyen.TinhTrangVanChuyen
                                    from ChiTietVanChuyen 
                                    inner join ThietBi on ChiTietVanChuyen.IDThietBi = ThietBi.IDThietBi
                                    inner join NhanVien on ChiTietVanChuyen.IDNhanVien = NhanVien.IDNhanVien
                                    inner join Khoa on ChiTietVanChuyen.IDVienKhoa = Khoa.IDVienKhoa";
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

        private void buttonKhoiTao_Click(object sender, EventArgs e)
        {
            txtMaVC.ResetText();
            txtMaTB.ResetText();
            txtTenTB.ResetText();
            NgayVC.Text = string.Empty;
            NgayNhan.Text = string.Empty;
            txtNoiNhan.ResetText();
            txtSL.ResetText();
            txtNV.ResetText();
            txtTinhTrang.ResetText();
        }
    }
}
