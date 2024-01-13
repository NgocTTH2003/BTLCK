using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace BTLCK
{
    public partial class FormDanhMucThietBi : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=HONGNGOC;Initial Catalog=QuanLyThietBi;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        private FormTrangChu formTrangChu;

        void LoadData()
        {
            command = connection.CreateCommand();
            command.CommandText = "SELECT tb.IDThietBi, tb.TenThietBi, tb.LoaiThietBi, tb.GiaThietBi, tb.NgaySanXuat, " +
                                  "ncc.IDNhaCungCap, ncc.TenNhaCungCap, tb.ViTriDat, kvt.IDKhoVatTu, kvt.TenKho, tb.TinhTrangThietBi " +
                                  "FROM ThietBi tb INNER JOIN KhoVatTu_ThietBi ON tb.IDThietBi = KhoVatTu_ThietBi.IDThietBi " +
                                  "INNER JOIN KhoVatTu kvt ON KhoVatTu_ThietBi.IDKhoVatTu = kvt.IDKhoVatTu " +
                                  "inner join NhaCungCap ncc on ncc.IDNhaCungCap = tb.IDNhaCungCap";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;

            //thay đổi tên cột
            dataGridView1.Columns[0].HeaderText = "Mã thiết bị";
            dataGridView1.Columns[1].HeaderText = "Tên thiết bị";
            dataGridView1.Columns[2].HeaderText = "Loại thiết bị";
            dataGridView1.Columns[3].HeaderText = "Giá thiết bị";
            dataGridView1.Columns[4].HeaderText = "Ngày sản xuất";
            dataGridView1.Columns[5].HeaderText = "Mã nhà cung cấp";
            dataGridView1.Columns[6].HeaderText = "Tên nhà cung cấp";
            dataGridView1.Columns[7].HeaderText = "Vị trí đặt";
            dataGridView1.Columns[8].HeaderText = "Mã kho";
            dataGridView1.Columns[9].HeaderText = "Tên kho";
            dataGridView1.Columns[10].HeaderText = "Tình trạng thiết bị";
        }

        private void FormDanhMucThiettBi_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            LoadData();

            ClassLayDuLieu ClassLayDuLieu = new ClassLayDuLieu();
            ClassLayDuLieu.LayDuLieuBangNhanVien();
        }
        public FormDanhMucThietBi(FormTrangChu formTrangChu)
        {
            InitializeComponent();
            SetPlaceholderText();
            this.formTrangChu = formTrangChu;
            this.comboBoxMaNCC.SelectedIndexChanged += new System.EventHandler(this.comboBoxMaNCC_SelectedIndexChanged);
            this.comboBoxMaKho.SelectedIndexChanged += new System.EventHandler(this.comboBoxMaKho_SelectedIndexChanged);
        }

        private void FormDanhMucThietBi_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            LoadData();
            LoadComboBoxDataThietBi();
            LoadComboBoxDataNhaCungCap();
            LoadComboBoxDataKhoVatTu();
        }
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
            string filter = string.Format("Convert(IDThietBi, 'System.String') LIKE '%{0}%' OR " +
                                  "TenThietBi LIKE '%{0}%' OR " +
                                  "LoaiThietBi LIKE '%{0}%' OR " +
                                  "Convert(GiaThietBi, 'System.String') LIKE '%{0}%' OR " +
                                  "Convert(NgaySanXuat, 'System.String') LIKE '%{0}%' OR " +
                                  "Convert(IDNhaCungCap, 'System.String') LIKE '%{0}%' OR " +
                                  "TenNhaCungCap LIKE '%{0}%' OR " +
                                  "ViTriDat LIKE '%{0}%' OR " +
                                  "Convert(IDKhoVatTu,'System.String') LIKE '%{0}%' OR " +
                                  "TenKho LIKE '%{0}%' OR " +
                                  "Convert(TinhTrangThietBi, 'System.String') LIKE '%{0}%'", searchValue);

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

        private void dateTimePickerNSX_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerNSX.Format = DateTimePickerFormat.Custom;
            dateTimePickerNSX.CustomFormat = "yyyy-MM-dd";
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            string maTB = textBoxMaTB.Text.Trim();
            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (row.Cells[0].Value != null && row.Cells[0].Value.ToString().Equals(maTB))
                {
                    MessageBox.Show("Vui lòng không nhập mã thiết bị do mã thiết bị cập nhật tự động.");
                    return;
                }
            }
            string sql = "INSERT INTO ThietBi (TenThietBi, LoaiThietBi, GiaThietBi, NgaySanXuat, IDNhaCungCap, ViTriDat, TinhTrangThietBi) VALUES (@TenThietBi, @LoaiThietBi, @GiaThietBi, @NgaySanXuat, @IDNhaCungCap, @ViTriDat, @TinhTrangThietBi)";

            //kết nối
            if (connection.State != ConnectionState.Open)
                connection.Open();
            try
            {
                using (SqlCommand command = new SqlCommand(sql, connection))
                {
                    // Thêm các tham số vào lệnh SQL
                    command.Parameters.AddWithValue("@TenThietBi", textBoxTenTB.Text.Trim());
                    command.Parameters.AddWithValue("@LoaiThietBi", comboBoxLoaiTB.SelectedItem.ToString());
                    command.Parameters.AddWithValue("@GiaThietBi", textBoxGiaTB.Text.Trim());
                    command.Parameters.AddWithValue("@NgaySanXuat", dateTimePickerNSX.Value);
                    command.Parameters.AddWithValue("@IDNhaCungCap", comboBoxMaNCC.SelectedItem.ToString());
                    command.Parameters.AddWithValue("@ViTriDat", comboBoxVTDat.SelectedItem.ToString());
                    command.Parameters.AddWithValue("@TinhTrangThietBi", comboBoxTTTB.SelectedItem.ToString());

                    // Thực thi lệnh
                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Thêm thiết bị thành công.");
                LoadData(); // Tải lại dữ liệu để cập nhật DataGridView
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
            finally
            {
                // Đóng kết nối
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }

        }

        private void buttonSua_Click(object sender, EventArgs e)
        {

        }

        private void buttonKhoiTao_Click(object sender, EventArgs e)
        {
            textBoxMaTB.ResetText();
            textBoxTenTB.ResetText();
            comboBoxLoaiTB.ResetText();
            textBoxGiaTB.ResetText();
            dateTimePickerNSX.ResetText();
            comboBoxMaNCC.ResetText();
            textBoxTenNCC.ResetText();
            comboBoxVTDat.ResetText();
            comboBoxMaKho.ResetText();
            textBoxTenKho.ResetText();
            comboBoxTTTB.ResetText();   
            textBoxTimKiem.ResetText();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            textBoxMaTB.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            textBoxTenTB.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            comboBoxLoaiTB.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            textBoxGiaTB.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            dateTimePickerNSX.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            comboBoxMaNCC.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            textBoxTenNCC.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
            comboBoxVTDat.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();
            comboBoxMaKho.Text = dataGridView1.Rows[i].Cells[8].Value.ToString();
            textBoxTenKho.Text = dataGridView1.Rows[i].Cells[9].Value.ToString();
            comboBoxTTTB.Text = dataGridView1.Rows[i].Cells[10].Value.ToString();
        }

        private void LoadComboBoxDataThietBi()
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();

            comboBoxLoaiTB.Items.Clear();
            comboBoxTTTB.Items.Clear();
            comboBoxVTDat.Items.Clear();

            try
            {
                using (SqlCommand command = new SqlCommand("SELECT DISTINCT LoaiThietBi FROM ThietBi", connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboBoxLoaiTB.Items.Add(reader["LoaiThietBi"].ToString());
                    }
                }

                using (SqlCommand command2 = new SqlCommand("SELECT DISTINCT TinhTrangThietBi FROM ThietBi", connection))
                using (SqlDataReader reader2 = command2.ExecuteReader())
                {
                    while (reader2.Read())
                    {
                        comboBoxTTTB.Items.Add(reader2["TinhTrangThietBi"].ToString());
                    }
                }

                using (SqlCommand command3 = new SqlCommand("SELECT DISTINCT ViTriDat FROM ThietBi", connection))
                using (SqlDataReader reader3 = command3.ExecuteReader())
                {
                    while (reader3.Read())
                    {
                        comboBoxVTDat.Items.Add(reader3["ViTriDat"].ToString());
                    }
                }
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void LoadComboBoxDataNhaCungCap()
        {
            if (connection.State != ConnectionState.Open)
                connection.Open();

            comboBoxMaNCC.Items.Clear();

            try
            {
                using (SqlCommand command = new SqlCommand("SELECT IDNhaCungCap FROM NhaCungCap", connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        comboBoxMaNCC.Items.Add(reader["IDNhaCungCap"].ToString());
                    }
                }
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void LoadComboBoxDataKhoVatTu()
        {
            // Mở kết nối nếu chưa mở
            if (connection.State != ConnectionState.Open)
                connection.Open();

            // Xóa dữ liệu cũ trong comboBoxMaKho
            comboBoxMaKho.Items.Clear();

            try
            {
                string query = "SELECT IDKhoVatTu FROM KhoVatTu";
                using (SqlCommand command = new SqlCommand(query, connection))
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    // Đọc và thêm dữ liệu vào comboBoxMaKho
                    while (reader.Read())
                    {
                        comboBoxMaKho.Items.Add(reader["IDKhoVatTu"].ToString());
                    }
                }
            }
            finally
            {
                // Đóng kết nối
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void comboBoxMaNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy mã nhà cung cấp đã chọn
            string selectedMaNCC = comboBoxMaNCC.SelectedItem.ToString();

            if (!string.IsNullOrEmpty(selectedMaNCC))
            {
                // Tạo và mở kết nối với cơ sở dữ liệu nếu chưa mở
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                try
                {
                    string query = "SELECT TenNhaCungCap FROM NhaCungCap WHERE IDNhaCungCap = @MaNCC";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm tham số vào truy vấn
                        command.Parameters.AddWithValue("@MaNCC", selectedMaNCC);

                        // Thực hiện truy vấn
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Đặt tên nhà cung cấp vào textBoxTenNCC
                                textBoxTenNCC.Text = reader["TenNhaCungCap"].ToString();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                }
                finally
                {
                    // Đóng kết nối
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
        }

        private void comboBoxMaKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Lấy mã kho đã chọn
            string selectedMaKho = comboBoxMaKho.SelectedItem.ToString();

            if (!string.IsNullOrEmpty(selectedMaKho))
            {
                // Mở kết nối với cơ sở dữ liệu nếu chưa mở
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                try
                {
                    string query = "SELECT TenKho FROM KhoVatTu WHERE IDKhoVatTu = @MaKho";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Thêm tham số vào truy vấn
                        command.Parameters.AddWithValue("@MaKho", selectedMaKho);

                        // Thực hiện truy vấn
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Đặt tên kho vào textBoxTenKho hoặc một textBox khác
                                textBoxTenKho.Text = reader["TenKho"].ToString();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                }
                finally
                {
                    // Đóng kết nối
                    if (connection.State == ConnectionState.Open)
                        connection.Close();
                }
            }
        }

        private void buttonSua_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("Hệ thống đang nâng cấp");
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Hệ thống đang nâng cấp");
        }
    }
}
