using Microsoft.Office.Interop.Excel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
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
        // tab tra cứu thông tin chi tiết
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
            LoadDataCapNhat();
            LoadComboBoxTenThietBiData();
            LoadComboBoxTenThietBiData3();
            LoadComboBoxTinhTrangVCData();
            LoadComboBoxTinhTrangVCData3();
            LoadComboBoxNhanVienData();
            LoadComboBoxKhoaVienData();
            dataGridView1.CellContentClick += new DataGridViewCellEventHandler(dataGridView1_CellContentClick);
            dataGridView3.CellContentClick += new DataGridViewCellEventHandler(dataGridView3_CellContentClick);
        }
        // Để hiển thị "Nhập từ khóa cần tìm" khi không có nhập liệu
        private void SetPlaceholderText()
        {
            // Đặt placeholder text ban đầu
            textBoxTimKiem.Text = "Nhập từ khóa cần tìm";
            textBoxTimKiem.ForeColor = Color.Gray;

            textBoxTimKiem3.Text = "Nhập từ khóa cần tìm";
            textBoxTimKiem3.ForeColor = Color.Gray;
        }
        private void textBoxTimKiem_Enter(object sender, EventArgs e)
        {
            // Khi người dùng click vào textBox
            if (textBoxTimKiem.Text == "Nhập từ khóa cần tìm")
            {
                textBoxTimKiem.Text = "";
                textBoxTimKiem.ForeColor = Color.Black;
            }

            if (textBoxTimKiem3.Text == "Nhập từ khóa cần tìm")
            {
                textBoxTimKiem3.Text = "";
                textBoxTimKiem3.ForeColor = Color.Black;
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

        private void textBoxTimKiem3_TextChanged(object sender, EventArgs e)
        {
            string searchValue3 = textBoxTimKiem3.Text;

            if (searchValue3 == "Nhập từ khóa cần tìm")
            {
                return; // Không thực hiện tìm kiếm nếu là placeholder text
            }


            // Tạo bộ lọc cho tất cả các cột
            string filter3 = string.Format("Convert(IDVanChuyen, 'System.String') LIKE '%{0}%' OR " +
                              "Convert(IDThietBi, 'System.String') LIKE '%{0}%' OR " +
                              "TenThietBi LIKE '%{0}%' OR " +
                              "Convert(NgayVanChuyen, 'System.String') LIKE '%{0}%' OR " +
                              "Convert(NgayNhan, 'System.String') LIKE '%{0}%' OR " +
                              "TenKhoa LIKE '%{0}%' OR " +
                              "Convert(SoLuong, 'System.String') LIKE '%{0}%' OR " +
                              "HoTen LIKE '%{0}%' OR " +
                              "TinhTrangVanChuyen LIKE '%{0}%'", searchValue3);

            // Kiểm tra xem table đã được khởi tạo và có dữ liệu
            if (table != null)
            {
                // Áp dụng bộ lọc
                table.DefaultView.RowFilter = filter3;
                dataGridView3.DataSource = table;
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
        //định dạng ngày tháng phù hợp với sql
        private string ConvertToSQLDateFormat(string inputDate)
        {
            try
            {
                DateTime parsedDate = DateTime.ParseExact(inputDate, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                return parsedDate.ToString("yyyy-MM-dd");
            }
            catch
            {
                MessageBox.Show("Định dạng ngày không hợp lệ. Vui lòng nhập ngày theo định dạng MM/DD/YYYY", "Lỗi Định Dạng Ngày", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
        }

        //*************************************************************************************************************************
        // tab2 tạo quá trình vận chuyển

        private void buttonTao2_Click(object sender, EventArgs e)
        {
            //lấy dữ liệu trên form
            string MaTB = txtMaTB2.Text;
            string TenTB = txtTenTB.Text;
            string HoTenNhanVien = comboBoxNhanVien.Text;
            string NoiDen = comboBoxNoiDen.Text;    
            DateTime NgayVC = NgayVC2.Value;
            DateTime NgayNhan = NgayNhan2.Value;
            string TinhTrangVC = comboBoxTinhTrang.Text;
            int SoLuong = 1;

            // Định dạng ngày tháng thành chuỗi "yyyy-MM-dd"
            string ngayVanChuyen = NgayVC.ToString("yyyy-MM-dd");
            string ngayNhan = NgayNhan.ToString("yyyy-MM-dd");

            // Kiểm tra và xử lý các giá trị ngày tháng
            if (string.IsNullOrEmpty(ngayVanChuyen) || string.IsNullOrEmpty(ngayNhan))
            {
                MessageBox.Show("Ngày vận chuyển hoặc ngày nhận không hợp lệ.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string idNhanVien = GetNhanVienID(HoTenNhanVien); // Lấy ID của nhân viên từ tên
            if (idNhanVien == null)
            {
                MessageBox.Show("Không tìm thấy mã nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string idKhoa = GetVienKhoaID(NoiDen); // Lấy ID của viện khoa từ tên
            if (idKhoa == null)
            {
                MessageBox.Show("Không tìm thấy mã viện khoa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string idThietBi = txtMaTB2.Text; // Giả định rằng mã thiết bị đã được lưu vào txtMaTB2 khi một tên thiết bị được chọn từ comboBoxTenTB2
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                string query = @"
                                INSERT INTO ChiTietVanChuyen (IDThietBi, IDVienKhoa, SoLuong, IDNhanVien, NgayVanChuyen, NgayNhan, TinhTrangVanChuyen)
                                VALUES (@IDThietBi, @IDKhoa, @SoLuong, @IDNhanVien, @NgayVanChuyen, @NgayNhan, @TinhTrangVanChuyen)";
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@IDThietBi", idThietBi);
                command.Parameters.AddWithValue("@IDKhoa", idKhoa);
                command.Parameters.AddWithValue("@SoLuong", SoLuong);
                command.Parameters.AddWithValue("@IDNhanVien", idNhanVien);
                command.Parameters.AddWithValue("@NgayVanChuyen", ngayVanChuyen);
                command.Parameters.AddWithValue("@NgayNhan", ngayNhan);
                command.Parameters.AddWithValue("@TinhTrangVanChuyen", TinhTrangVC);

                command.ExecuteNonQuery();
                MessageBox.Show("Quá trình vận chuyển đã được tạo thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi thêm quá trình vận chuyển: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();

                ReloadData(); // Tải lại dữ liệu để cập nhật dataGridView1
            }
        }
        //lấy mã nhân viên từ bảng nhân viên
        private string GetNhanVienID(string hoTen)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                string query = "SELECT IDNhanVien FROM NhanVien WHERE HoTen = @HoTen";
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@HoTen", hoTen);
                var result = command.ExecuteScalar();

                return result?.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi lấy mã nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        //lấy mã viện khoa từ bảng Khoa
        private string GetVienKhoaID(string khoa)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                string query = "SELECT IDVienKhoa FROM Khoa WHERE TenKhoa = @khoa";
                command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@khoa", khoa);
                var result = command.ExecuteScalar();

                return result?.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi lấy mã viện khoa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return null;
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void LoadComboBoxTenThietBiData()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                string query = "SELECT TenThietBi FROM ThietBi";
                command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                comboBoxTenTB2.Items.Clear();

                while (reader.Read())
                {
                    comboBoxTenTB2.Items.Add(reader["TenThietBi"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi tải danh sách tên thiết bị: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
        private void comboBoxTenTB2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy tên thiết bị được chọn từ ComboBox
            string selectedTenThietBi = comboBoxTenTB2.SelectedItem.ToString();

            if (!string.IsNullOrEmpty(selectedTenThietBi))
            {
                try
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open();

                    string query = "SELECT IDThietBi FROM ThietBi WHERE TenThietBi = @TenThietBi";
                    command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@TenThietBi", selectedTenThietBi);

                    var result = command.ExecuteScalar();

                    if (result != null)
                    {
                        txtMaTB2.Text = result.ToString();
                    }
                    else
                    {
                        txtMaTB2.Text = string.Empty;
                        MessageBox.Show("Không tìm thấy mã thiết bị tương ứng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi khi lấy mã thiết bị: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
        }
        private void LoadComboBoxTinhTrangVCData()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                string query = "SELECT DISTINCT  TinhTrangVanChuyen FROM ChiTietVanChuyen";
                command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                comboBoxTinhTrang.Items.Clear();

                while (reader.Read())
                {
                    comboBoxTinhTrang.Items.Add(reader["TinhTrangVanChuyen"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi tải danh sách tình trạng vận chuyển: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
        private void LoadComboBoxNhanVienData()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                string query = "SELECT HoTen FROM NhanVien";
                command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                comboBoxNhanVien.Items.Clear();

                while (reader.Read())
                {
                    comboBoxNhanVien.Items.Add(reader["HoTen"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi tải danh sách tên nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
        private void LoadComboBoxKhoaVienData()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                string query = "SELECT TenKhoa FROM Khoa";
                command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                comboBoxNoiDen.Items.Clear();

                while (reader.Read())
                {
                    comboBoxNoiDen.Items.Add(reader["TenKhoa"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi tải danh sách tên khoa viện: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
        private void buttonKhoiTao2_Click(object sender, EventArgs e)
        {
            txtMaTB2.ResetText();
            comboBoxTenTB2.Text = string.Empty;
            comboBoxNhanVien.Text = string.Empty;   
            comboBoxNoiDen.Text = string.Empty; 
            NgayVC2.Text = string.Empty;
            NgayNhan2.Text = string.Empty;
            comboBoxTinhTrang.Text = string.Empty;
        }

        //******************************************************************************************************************
        // tab 3 cập nhật thông tin
        void ReloadData3()
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
                dataGridView3.DataSource = table;
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
        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView3.CurrentRow.Index;
            textBoxMaVC3.Text = dataGridView3.Rows[i].Cells[0].Value.ToString();
            textBoxMaTB3.Text = dataGridView3.Rows[i].Cells[1].Value.ToString();
            comboBoxTenTB3.Text = dataGridView3.Rows[i].Cells[2].Value.ToString();
            dateTimePickerNVC3.Text = dataGridView3.Rows[i].Cells[3].Value.ToString();
            dateTimePickerNN3.Text = dataGridView3.Rows[i].Cells[4].Value.ToString();
            textBoxNoiNhan3.Text = dataGridView3.Rows[i].Cells[5].Value.ToString();
            textBoxSL.Text = dataGridView3.Rows[i].Cells[6].Value.ToString();
            textBoxNV3.Text = dataGridView3.Rows[i].Cells[7].Value.ToString();
            comboBoxTinhTrang3.Text = dataGridView3.Rows[i].Cells[8].Value.ToString();
        }

        void LoadDataCapNhat()
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
            dataGridView3.DataSource = table;

            //thay đổi tên cột
            dataGridView3.Columns[0].HeaderText = "Mã vận chuyển";
            dataGridView3.Columns[1].HeaderText = "Mã thiết bị";
            dataGridView3.Columns[2].HeaderText = "Tên thiết bị";
            dataGridView3.Columns[3].HeaderText = "Ngày vận chuyển";
            dataGridView3.Columns[4].HeaderText = "Ngày nhận";
            dataGridView3.Columns[5].HeaderText = "Nơi nhận";
            dataGridView3.Columns[6].HeaderText = "Số lượng";
            dataGridView3.Columns[7].HeaderText = "Nhân viên phụ trách";
            dataGridView3.Columns[8].HeaderText = "Tình trạng vận chuyển";
        }

        private void buttonKhoiTao3_Click(object sender, EventArgs e)
        {
            textBoxMaVC3.ResetText();
            textBoxMaTB3.ResetText();
            comboBoxTenTB3.ResetText();
            dateTimePickerNVC3.Text = string.Empty;
            dateTimePickerNN3.Text = string.Empty;
            textBoxNoiNhan3.ResetText();
            textBoxSL.ResetText();
            textBoxNV3.ResetText();
            comboBoxTinhTrang3.ResetText();
        }


        private void buttonCapNhat3_Click(object sender, EventArgs e)
        {
            // Mở kết nối và bắt đầu giao dịch
            if (connection.State != ConnectionState.Open)
                connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                // Lấy các giá trị từ các controls
                string maVanChuyen = textBoxMaVC3.Text;
                string maThietBi = textBoxMaTB3.Text;
                DateTime ngayVanChuyen = dateTimePickerNVC3.Value;
                DateTime ngayNhan = dateTimePickerNN3.Value;
                string noiNhan = textBoxNoiNhan3.Text;
                int soLuong = int.Parse(textBoxSL.Text);
                string nhanVienPhuTrach = textBoxNV3.Text;
                string tinhTrangVanChuyen = comboBoxTinhTrang3.Text;

                // Lấy IDVienKhoa dựa trên tên khoa
                string idVienKhoa = GetVienKhoaID3(noiNhan, transaction); // Adjusted to pass the transaction
                if (idVienKhoa == null)
                {
                    transaction.Rollback(); // Hoàn tác giao dịch
                    MessageBox.Show("Không tìm thấy mã viện khoa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Lấy IDNhanVien dựa trên tên nhân viên
                string idNhanVien = GetNhanVienID3(nhanVienPhuTrach, transaction); // Adjusted to pass the transaction
                if (idNhanVien == null)
                {
                    transaction.Rollback(); // Hoàn tác giao dịch
                    MessageBox.Show("Không tìm thấy mã nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Thực hiện cập nhật dữ liệu vào cơ sở dữ liệu
                string query = @"
                        UPDATE ChiTietVanChuyen
                        SET 
                            IDThietBi = @MaThietBi,
                            IDVienKhoa = @IDVienKhoa,
                            NgayVanChuyen = @NgayVanChuyen,
                            NgayNhan = @NgayNhan,
                            SoLuong = @SoLuong,
                            IDNhanVien = @IDNhanVien,
                            TinhTrangVanChuyen = @TinhTrangVanChuyen
                        WHERE IDVanChuyen = @MaVanChuyen";

                using (SqlCommand command = new SqlCommand(query, connection, transaction))
                {
                    command.Parameters.AddWithValue("@MaThietBi", maThietBi);
                    command.Parameters.AddWithValue("@IDVienKhoa", idVienKhoa);
                    command.Parameters.AddWithValue("@NgayVanChuyen", ngayVanChuyen);
                    command.Parameters.AddWithValue("@NgayNhan", ngayNhan);
                    command.Parameters.AddWithValue("@SoLuong", soLuong);
                    command.Parameters.AddWithValue("@IDNhanVien", idNhanVien);
                    command.Parameters.AddWithValue("@TinhTrangVanChuyen", tinhTrangVanChuyen);
                    command.Parameters.AddWithValue("@MaVanChuyen", maVanChuyen);

                    // Thực thi lệnh
                    int rowsAffected = command.ExecuteNonQuery();

                    // Xử lý kết quả
                    if (rowsAffected > 0)
                    {
                        transaction.Commit(); // Hoàn tất giao dịch
                        MessageBox.Show("Cập nhật thông tin thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadDataCapNhat(); // Tải lại dữ liệu
                    }
                    else
                    {
                        transaction.Rollback(); // Hoàn tác giao dịch
                        MessageBox.Show("Không tìm thấy bản ghi để cập nhật.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback(); // Hoàn tác giao dịch nếu có lỗi
                MessageBox.Show("Có lỗi khi cập nhật thông tin: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close(); // Luôn đóng kết nối trong khối finally
            }
        }

        private string GetNhanVienID3(string hoTen, SqlTransaction transaction)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                string query = "SELECT IDNhanVien FROM NhanVien WHERE HoTen = @HoTen";
                SqlCommand command = new SqlCommand(query, connection);
                command.Transaction = transaction; 
                command.Parameters.AddWithValue("@HoTen", hoTen);
                var result = command.ExecuteScalar();

                return result?.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi lấy mã nhân viên: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                throw;
            }
        }

        private string GetVienKhoaID3(string khoa, SqlTransaction transaction)
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                string query = "SELECT IDVienKhoa FROM Khoa WHERE TenKhoa = @khoa";
                SqlCommand command = new SqlCommand(query, connection);
                command.Transaction = transaction; 
                command.Parameters.AddWithValue("@khoa", khoa);
                var result = command.ExecuteScalar();

                return result?.ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi lấy mã viện khoa: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                throw;
            }
        }


        private void comboBoxTenVC3_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy tên thiết bị được chọn từ ComboBox
            string selectedTenThietBi = comboBoxTenTB3.SelectedItem.ToString();

            if (!string.IsNullOrEmpty(selectedTenThietBi))
            {
                try
                {
                    if (connection.State != ConnectionState.Open)
                        connection.Open();

                    string query = "SELECT IDThietBi FROM ThietBi WHERE TenThietBi = @TenThietBi";
                    command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@TenThietBi", selectedTenThietBi);

                    var result = command.ExecuteScalar();

                    if (result != null)
                    {
                        textBoxMaTB3.Text = result.ToString();
                    }
                    else
                    {
                        textBoxMaTB3.Text = string.Empty;
                        MessageBox.Show("Không tìm thấy mã thiết bị tương ứng.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi khi lấy mã thiết bị: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                finally
                {
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
        }

        private void LoadComboBoxTenThietBiData3()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                string query = "SELECT TenThietBi FROM ThietBi";
                command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                comboBoxTenTB3.Items.Clear();

                while (reader.Read())
                {
                    comboBoxTenTB3.Items.Add(reader["TenThietBi"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi tải danh sách tên thiết bị: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void LoadComboBoxTinhTrangVCData3()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                string query = "SELECT DISTINCT  TinhTrangVanChuyen FROM ChiTietVanChuyen";
                command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                comboBoxTinhTrang3.Items.Clear();

                while (reader.Read())
                {
                    comboBoxTinhTrang3.Items.Add(reader["TinhTrangVanChuyen"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi tải danh sách tình trạng vận chuyển: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }
    }
}
