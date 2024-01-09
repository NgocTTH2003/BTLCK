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
using Microsoft.Office.Interop.Excel;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BTLCK
{
    public partial class FormThanhLy : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=HONGNGOC;Initial Catalog=QuanLyThietBi;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        System.Data.DataTable table = new System.Data.DataTable();

        void LoadData()
        {
            //tải dữ liệu
            command = connection.CreateCommand();
            command.CommandText = "select ChiTietThanhLy.IDThanhLy,ChiTietThanhLy.IDThietBi, ThietBi.TenThietBi, ChiTietThanhLy.DonGia, " +
                                    "ChiTietThanhLy.SoLuong, ChiTietThanhLy.ThanhTien, " +
                                    "NhanVien.HoTen, KhoVatTu.TenKho, ChiTietThanhLy.NgayThanhLy " +
                                    "from ChiTietThanhLy " +
                                    "inner join ThietBi on ChiTietThanhLy.IDThietBi = ThietBi.IDThietBi " +
                                    "inner join NhanVien on ChiTietThanhLy.IDNhanVien = NhanVien.IDNhanVien " +
                                    "inner join KhoVatTu_ThietBi on ThietBi.IDThietBi = KhoVatTu_ThietBi.IDThietBi " +
                                    "inner join KhoVatTu on KhoVatTu.IDKhoVatTu = KhoVatTu_ThietBi.IDKhoVatTu";

            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;

            //thay đổi tên cột
            dataGridView1.Columns[0].HeaderText = "Mã thanh lý";
            dataGridView1.Columns[1].HeaderText = "Mã thiết bị";
            dataGridView1.Columns[2].HeaderText = "Tên thiết bị";
            dataGridView1.Columns[3].HeaderText = "Đơn giá thanh lý";
            dataGridView1.Columns[4].HeaderText = "Số lượng";
            dataGridView1.Columns[5].HeaderText = "Thành tiền";
            dataGridView1.Columns[6].HeaderText = "Tên nhân viên";
            dataGridView1.Columns[7].HeaderText = "Kho vật tư";
            dataGridView1.Columns[8].HeaderText = "Ngày thanh lý";
        }
        private FormTrangChu formTrangChu;
        public FormThanhLy(FormTrangChu formTrangChu)
        {
            InitializeComponent();
            SetPlaceholderText();
            this.formTrangChu = formTrangChu;
        }

        private void FormThanhLy_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            LoadData();
            comboBox2.SelectedIndexChanged += comboBox2_SelectedIndexChanged;
            comboBox4.SelectedIndexChanged += comboBox4_SelectedIndexChanged;
            dataGridView1.CellContentClick += new DataGridViewCellEventHandler(dataGridView1_CellContentClick);
            textBox1.TextChanged += new EventHandler(textBox1_TextChanged);
            numericUpDown1.ValueChanged += new EventHandler(numericUpDown1_ValueChanged);
            LoadTenNhanVienData();
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
            string filter = string.Format("Convert(IDThanhLy, 'System.String') LIKE '%{0}%' OR " +
                                  "Convert(IDThietBi, 'System.String') LIKE '%{0}%' OR " +
                                  "TenThietBi LIKE '%{0}%' OR " +
                                  "Convert(DonGia, 'System.String') LIKE '%{0}%' OR " +
                                  "Convert(SoLuong, 'System.String') LIKE '%{0}%' OR " +
                                  "Convert(ThanhTien, 'System.String') LIKE '%{0}%' OR " +
                                  "HoTen LIKE '%{0}%' OR " +
                                  "TenKho LIKE '%{0}%' OR " +                                
                                  "Convert(NgayThanhLy, 'System.String') LIKE '%{0}%'", searchValue);

            // Kiểm tra xem table đã được khởi tạo và có dữ liệu
            if (table != null)
            {
                // Áp dụng bộ lọc
                table.DefaultView.RowFilter = filter;
                dataGridView1.DataSource = table;
            }
        }
        private void Back_Click(object sender, EventArgs e)
        {
            this.formTrangChu.Show();
            this.Close();
        }

         private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            textBox5.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            comboBox4.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            textBox1.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            numericUpDown1.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            textBox3.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            comboBox2.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
            textBoxKho.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();
            dateTimePickerNN.Text = dataGridView1.Rows[i].Cells[8].Value.ToString();
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
                command.CommandText = "SELECT ChiTietThanhLy.IDThanhLy, ChiTietThanhLy.IDThietBi, ThietBi.TenThietBi, ChiTietThanhLy.DonGia, ChiTietThanhLy.SoLuong, ChiTietThanhLy.ThanhTien, KhoVatTu.TenKho,  ChiTietThanhLy.IDNhanVien, NhanVien.HoTen, ChiTietThanhLy.NgayThanhLy FROM ChiTietThanhLy INNER JOIN ThietBi ON ChiTietThanhLy.IDThietBi = ThietBi.IDThietBi INNER JOIN NhanVien ON ChiTietThanhLy.IDNhanVien = NhanVien.IDNhanVien INNER JOIN KhoVatTu_ThietBi ON ThietBi.ID";
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

        private void LoadTenNhanVienData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(str))
                {
                    connection.Open();

                    // Tạo một SqlCommand để truy vấn danh sách TenKhoVatTu từ bảng KhoVatTu
                    SqlCommand command = new SqlCommand("SELECT NhanVien.HoTen, KhoVatTu.TenKho FROM NhanVien inner join KhoVatTu on NhanVien.IDKho = KhoVatTu.IDKhoVatTu", connection);
                    SqlDataReader reader = command.ExecuteReader();

                    // Xóa tất cả các mục hiện có trong comboBox2
                    comboBox2.Items.Clear();

                    // Đọc dữ liệu từ SqlDataReader và thêm nó vào comboBox2
                    while (reader.Read())
                    {
                        comboBox2.Items.Add(reader["HoTen"].ToString());
                    }

                    // Đóng SqlDataReader
                    reader.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi tải danh sách nhân viên: " + ex.Message);
            }
        }

        private void buttonKhoiTao_Click(object sender, EventArgs e)
        {
            textBoxKho.ResetText();
            comboBox2.Text = string.Empty;
            comboBox4.Text = string.Empty;
            textBox5.ResetText();
            textBox3.Text = string.Empty;
            textBox1.Text = string.Empty;
            dateTimePickerNN.Text = string.Empty;
            numericUpDown1.Text = string.Empty;
            textBoxTimKiem.Text = string.Empty;
            textBoxTongTien.Text = string.Empty;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy tên nhân viên được chọn từ comboBox2
            string selectedNhanVien = comboBox2.SelectedItem.ToString();

            try
            {
                using (SqlConnection connection = new SqlConnection(str))
                {
                    connection.Open();

                    // Tạo một SqlCommand để truy vấn IDKho và tên kho dựa trên tên nhân viên
                    SqlCommand command = new SqlCommand("SELECT KhoVatTu.IDKhoVatTu, KhoVatTu.TenKho FROM NhanVien INNER JOIN KhoVatTu ON NhanVien.IDKho = KhoVatTu.IDKhoVatTu WHERE NhanVien.HoTen = @HoTen", connection);
                    command.Parameters.AddWithValue("@HoTen", selectedNhanVien);

                    // Thực thi SqlCommand và lấy thông tin kho
                    SqlDataReader reader = command.ExecuteReader();
                    string khoInfo = "";
                    int IDKho = 0;

                    if (reader.Read())
                    {
                        khoInfo = reader["TenKho"].ToString();
                        IDKho = (int)reader["IDKhoVatTu"];
                    }

                    // Hiển thị thông tin kho trong textBoxKho
                    textBoxKho.Text = khoInfo;

                    // Đóng SqlDataReader
                    reader.Close();

                    // Kiểm tra nếu IDKho không hợp lệ, không cần truy vấn thiết bị
                    if (IDKho == 0) return;

                    // Tạo một SqlCommand để truy vấn thông tin ThietBi từ IDKho
                    SqlCommand cmdThietBi = new SqlCommand("SELECT ThietBi.TenThietBi FROM KhoVatTu_ThietBi INNER JOIN ThietBi ON KhoVatTu_ThietBi.IDThietBi = ThietBi.IDThietBi WHERE KhoVatTu_ThietBi.IDKhoVatTu = @IDKho", connection);
                    cmdThietBi.Parameters.AddWithValue("@IDKho", IDKho);

                    SqlDataReader readerThietBi = cmdThietBi.ExecuteReader();

                    // Xóa các mục hiện tại trong combobox4
                    comboBox4.Items.Clear();

                    // Đọc dữ liệu từ SqlDataReader và thêm vào combobox4
                    while (readerThietBi.Read())
                    {
                        comboBox4.Items.Add(readerThietBi["TenThietBi"].ToString());
                    }

                    // Đóng SqlDataReader
                    readerThietBi.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi tải thông tin kho và thiết bị: " + ex.Message);
            }
        }
        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy tên thiết bị được chọn từ comboBox4
            string selectedTenThietBi = comboBox4.SelectedItem.ToString();

            try
            {
                using (SqlConnection connection = new SqlConnection(str))
                {
                    connection.Open();

                    // Tạo một SqlCommand để truy vấn IDThietBi, GiaThietBi từ tên thiết bị
                    SqlCommand command = new SqlCommand("SELECT ThietBi.IDThietBi, ThietBi.GiaThietBi FROM ThietBi WHERE ThietBi.TenThietBi = @TenThietBi", connection);
                    command.Parameters.AddWithValue("@TenThietBi", selectedTenThietBi);

                    // Thực thi SqlCommand và lấy thông tin
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            // Hiển thị IDThietBi, GiaThietBi
                            textBox5.Text = reader["IDThietBi"].ToString();
                            textBox1.Text = reader["GiaThietBi"].ToString();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi tải thông tin thiết bị" + ex.Message);
            }
        }

        private void buttonThem_Click_1(object sender, EventArgs e)
        {
            // Kiểm tra kết nối và mở nếu cần thiết
            if (connection.State != ConnectionState.Open)
                connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                // Kiểm tra số lượng là số dương
                if (numericUpDown1.Value <= 0)
                {
                    MessageBox.Show("Số lượng thiết bị phải là số dương");
                    return; // Dừng xử lý nếu số lượng không hợp lệ
                }
                // Truy vấn để lấy IDNhanVien tương ứng với TenNhanVien
                string getIDNhanVienQuery = "SELECT IDNhanVien FROM NhanVien WHERE HoTen = @HoTen";
                SqlCommand getIDNhanVienCommand = new SqlCommand(getIDNhanVienQuery, connection, transaction); // Chú ý thêm tham số transaction ở đây
                getIDNhanVienCommand.Parameters.AddWithValue("@HoTen", comboBox2.Text);
                object idNhanVien = getIDNhanVienCommand.ExecuteScalar();

                // Truy vấn để lấy IDThietBi tương ứng với TenThietBi
                string getIDThietBiQuery = "SELECT IDThietBi FROM ThietBi WHERE TenThietBi = @TenThietBi";
                SqlCommand getIDThietBiCommand = new SqlCommand(getIDThietBiQuery, connection, transaction); // Chú ý thêm tham số transaction ở đây
                getIDThietBiCommand.Parameters.AddWithValue("@TenThietBi", comboBox4.Text);
                object idThietBi = getIDThietBiCommand.ExecuteScalar();

                if (idThietBi != null)
                {
                    // Kiểm tra số lượng trong kho
                    string checkSoLuongQuery = "SELECT SoLuong FROM KhoVatTu_ThietBi WHERE IDThietBi = @IDThietBi";
                    SqlCommand checkSoLuongCommand = new SqlCommand(checkSoLuongQuery, connection, transaction);
                    checkSoLuongCommand.Parameters.AddWithValue("@IDThietBi", idThietBi);
                    object soLuongTrongKho = checkSoLuongCommand.ExecuteScalar();

                    if (soLuongTrongKho != null && numericUpDown1.Value > Convert.ToDecimal(soLuongTrongKho))
                    {
                        MessageBox.Show("Số lượng thanh lý lớn hơn số lượng trong kho");
                        transaction.Rollback(); // Hoàn tác giao dịch
                        return;
                    }


                    if (idNhanVien != null && idThietBi != null)
                    {
                        // Truy vấn chèn dữ liệu vào ChiTietNhap
                        string insertQuery = "INSERT INTO ChiTietThanhLy (IDThietBi,SoLuong,DonGia,ThanhTien,IDNhanVien,NgayThanhLy) VALUES (@idThietBi, @SoLuong, @DonGia, @ThanhTien, @IDNhanVien, @NgayThanhLy)";
                        SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                        insertCommand.Parameters.AddWithValue("@idThietBi", idThietBi);
                        insertCommand.Parameters.AddWithValue("@SoLuong", numericUpDown1.Value);
                        insertCommand.Parameters.AddWithValue("@DonGia", textBox1.Text);
                        insertCommand.Parameters.AddWithValue("@ThanhTien", textBox3.Text);
                        insertCommand.Parameters.AddWithValue("@IDNhanVien", idNhanVien);
                        insertCommand.Parameters.AddWithValue("@NgayThanhLy", dateTimePickerNN.Value);

                        insertCommand.Transaction = transaction; // Áp dụng giao dịch cho lệnh này
                        insertCommand.ExecuteNonQuery();

                        // Cập nhật số lượng trong KhoVatTu_ThietBi
                        string updateSoLuongQuery = "UPDATE KhoVatTu_ThietBi SET SoLuong = SoLuong - @SoLuongMoi WHERE IDThietBi = @IDThietBi";
                        SqlCommand updateSoLuongCommand = new SqlCommand(updateSoLuongQuery, connection);
                        updateSoLuongCommand.Parameters.AddWithValue("@SoLuongMoi", numericUpDown1.Value);
                        updateSoLuongCommand.Parameters.AddWithValue("@IDThietBi", idThietBi);

                        updateSoLuongCommand.Transaction = transaction; // Áp dụng giao dịch cho lệnh này
                        updateSoLuongCommand.ExecuteNonQuery();

                        MessageBox.Show("Thêm chi tiết thành công");
                        transaction.Commit();
                        LoadData(); // Cập nhật lại dữ liệu trên DataGridView
                    }
                    else
                    {
                        MessageBox.Show("Tên nhân viên hoặc thiết bị không tồn tại.");
                        transaction.Rollback(); // Hoàn tác giao dịch
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                transaction.Rollback(); // Rollback giao dịch nếu có lỗi
            }
            finally
            {
                // Đóng kết nối
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            UpdateTotalAmount();
        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {
            UpdateTotalAmount();
        }

        private void UpdateTotalAmount()
        {
            if (decimal.TryParse(textBox1.Text, out decimal price) && numericUpDown1.Value > 0)
            {
                decimal totalAmount = price * numericUpDown1.Value;
                textBox3.Text = totalAmount.ToString();
            }
            else
            {
                textBox3.Text = "0";
            }
        }

        private void buttonTongTien_Click(object sender, EventArgs e)
        {
            decimal tongTien = 0m; // 'm' biểu thị một chữ thập phân

            // Duyệt qua mỗi dòng trong DataGridView
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                // Kiểm tra xem dòng có dữ liệu không (không phải dòng mới)
                if (!row.IsNewRow)
                {
                    // Lấy giá trị từ cột thứ 6 (cột có index là 5)
                    if (row.Cells[5].Value != DBNull.Value && row.Cells[5].Value != null)
                    {
                        // Cộng dồn vào tổng tiền
                        tongTien += Convert.ToDecimal(row.Cells[5].Value);
                    }
                }
            }

            // Hiển thị tổng tiền trong textBoxTongTien
            textBoxTongTien.Text = tongTien.ToString("N2"); // Định dạng số thành chuỗi với 2 chữ số thập phân
        }
    }
}
