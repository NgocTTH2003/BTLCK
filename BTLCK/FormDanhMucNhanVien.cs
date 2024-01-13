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
using BTLCK.QuanLyThietBiDataSet6TableAdapters;

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
            //tải dữ liệu
            command = connection.CreateCommand();
            command.CommandText = "select NhanVien.IDNhanVien, NhanVien.HoTen, NhanVien.NgaySinh, NhanVien.GioiTinh, KhoVatTu.TenKho, NhanVien.ChucVu, NhanVien.SDT, NhanVien.TrangThaiHoatDong from NhanVien inner join KhoVatTu on NhanVien.IDKho = KhoVatTu.IDKhoVatTu";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;

            //thay đổi tên cột
            dataGridView1.Columns[0].HeaderText = "Mã nhân viên";
            dataGridView1.Columns[1].HeaderText = "Họ tên nhân viên";
            dataGridView1.Columns[2].HeaderText = "Ngày sinh";
            dataGridView1.Columns[3].HeaderText = "Giới tính";
            dataGridView1.Columns[4].HeaderText = "Tên kho";
            dataGridView1.Columns[5].HeaderText = "Chức vụ";
            dataGridView1.Columns[6].HeaderText = "Số điện thoại";
            dataGridView1.Columns[7].HeaderText = "Trạng thái hoạt động";
        }
        private void FormDanhMucNhanVien_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            LoadData();
            LoadComboBoxKhoData();
        }
        public FormDanhMucNhanVien(FormTrangChu formTrangChu)
        {
            InitializeComponent();
            SetPlaceholderText();
            this.formTrangChu = formTrangChu;
        }
        //nhấn back để trở về trang chủ 
        private FormTrangChu formTrangChu;

        private void Back_Click(object sender, EventArgs e)
        {
            this.formTrangChu.Show();
            this.Close();
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
            string filter = string.Format("Convert(IDNhanVien, 'System.String') LIKE '%{0}%' OR HoTen LIKE '%{0}%' OR Convert(NgaySinh, 'System.String') LIKE '%{0}%' OR GioiTinh LIKE '%{0}%' OR TenKho LIKE '%{0}%' OR ChucVu LIKE '%{0}%' OR SDT LIKE '%{0}%' OR Convert(TrangThaiHoatDong, 'System.String') LIKE '%{0}%'", searchValue);

            // Kiểm tra xem table đã được khởi tạo và có dữ liệu
            if (table != null)
            {
                // Áp dụng bộ lọc
                table.DefaultView.RowFilter = filter;
                dataGridView1.DataSource = table;
            }
        }

        private void buttonThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem txtMaNV có được điền hay không
            if (!string.IsNullOrEmpty(txtMaNV.Text))
            {
                MessageBox.Show("Yêu cầu không nhập mã nhân viên");
                return; // Ngăn không cho hàm thực thi tiếp
            }

            // Kiểm tra kết nối và mở nếu cần thiết
            if (connection.State != ConnectionState.Open)
                connection.Open();

            try
            {
                // Truy vấn để lấy IDKho tương ứng với TenKhoVatTu
                string getIDKhoQuery = "SELECT IDKhoVatTu FROM KhoVatTu WHERE TenKho = @TenKho";
                SqlCommand getIDKhoCommand = new SqlCommand(getIDKhoQuery, connection);
                getIDKhoCommand.Parameters.AddWithValue("@TenKho", comboBoxKho.Text); 

                object idKho = getIDKhoCommand.ExecuteScalar();

                if(idKho != null)
                {
                    // Truy vấn chèn dữ liệu vào NhanVien sử dụng IDKho
                    string insertQuery = "INSERT INTO NhanVien (HoTen, NgaySinh, GioiTinh, IDKho, ChucVu, SDT, TrangThaiHoatDong) VALUES (@HoTen, @NgaySinh, @GioiTinh, @IDKho, @ChucVu, @SDT, @TrangThaiHoatDong)";
                    SqlCommand insertCommand = new SqlCommand(insertQuery, connection);
                    insertCommand.Parameters.AddWithValue("@HoTen", txtHoTen.Text);
                    insertCommand.Parameters.AddWithValue("@NgaySinh", dateTimePickerNS.Value);
                    insertCommand.Parameters.AddWithValue("@GioiTinh", comboBoxGT.Text);
                    insertCommand.Parameters.AddWithValue("@IDKho", idKho);
                    insertCommand.Parameters.AddWithValue("@ChucVu", comboBoxCV.Text);
                    insertCommand.Parameters.AddWithValue("@SDT", txtSDT.Text);
                    insertCommand.Parameters.AddWithValue("@TrangThaiHoatDong", txtTTHD.Text);
            
                    insertCommand.ExecuteNonQuery();
                    MessageBox.Show("Thêm thành công.");
                    LoadData(); // Cập nhật lại dữ liệu trên DataGridView
                }
                else
                {
                    MessageBox.Show("Thêm không thành công.");
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

        private void buttonKhoiTao_Click(object sender, EventArgs e)
        {
            txtMaNV.ResetText();
            comboBoxGT.Text = string.Empty;
            txtHoTen.ResetText();
            comboBoxKho.Text = string.Empty;
            txtSDT.ResetText();
            comboBoxCV.Text = string.Empty;
            dateTimePickerNS.Text = string.Empty;
            txtTTHD.ResetText();
        }

        private void dateTimePickerNS_ValueChanged(object sender, EventArgs e)
        {
            dateTimePickerNS.Format = DateTimePickerFormat.Custom;
            dateTimePickerNS.CustomFormat = "yyyy-MM-dd";
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            txtMaNV.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtHoTen.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            dateTimePickerNS.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            comboBoxGT.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            comboBoxKho.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            comboBoxCV.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            txtSDT.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
            txtTTHD.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần xóa.");
                return;
            }

            // Lấy ID của nhân viên được chọn
            string idNhanVien = dataGridView1.CurrentRow.Cells["IDNhanVien"].Value.ToString();
            bool TrangThaiHienTai = Convert.ToBoolean(dataGridView1.CurrentRow.Cells["TrangThaiHoatDong"].Value);

            // Kiểm tra nếu nhân viên đã bị đánh dấu không hoạt động
            if (!TrangThaiHienTai)
            {
                MessageBox.Show("Nhân viên này đã được đánh dấu là không hoạt động từ trước.");
                return;
            }

            // Kiểm tra kết nối và mở nếu cần thiết
            if (connection.State != ConnectionState.Open)
                connection.Open();

            // Bắt đầu giao dịch
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                // Kiểm tra xem nhân viên có tài khoản hay không
                SqlCommand commandCheckAccount = new SqlCommand("SELECT COUNT(*) FROM TaiKhoan WHERE IDNhanVien = @IDNhanVien", connection, transaction);
                commandCheckAccount.Parameters.AddWithValue("@IDNhanVien", idNhanVien);
                int accountExists = (int)commandCheckAccount.ExecuteScalar();

                if (accountExists > 0)
                {
                    // Xóa tài khoản của nhân viên từ bảng TaiKhoan
                    SqlCommand commandDeleteAccount = new SqlCommand("DELETE FROM TaiKhoan WHERE IDNhanVien = @IDNhanVien", connection, transaction);
                    commandDeleteAccount.Parameters.AddWithValue("@IDNhanVien", idNhanVien);
                    commandDeleteAccount.ExecuteNonQuery();
                }

                // Cập nhật trạng thái hoạt động của nhân viên sang không hoạt động
                SqlCommand commandUpdateStatus = new SqlCommand("UPDATE NhanVien SET TrangThaiHoatDong = 0 WHERE IDNhanVien = @IDNhanVien", connection, transaction);
                commandUpdateStatus.Parameters.AddWithValue("@IDNhanVien", idNhanVien);
                commandUpdateStatus.ExecuteNonQuery();

                // Hoàn tất giao dịch
                transaction.Commit();
                MessageBox.Show("Nhân viên đã được chuyển sang trạng thái không hoạt động" + (accountExists > 0 ? " và tài khoản của họ đã được xóa." : "."));
                LoadData(); // Cập nhật lại dữ liệu trên DataGridView
            }
            catch (Exception ex)
            {
                // Có lỗi xảy ra, quay lại giao dịch
                transaction.Rollback();
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
            if (dataGridView1.CurrentRow == null)
            {
                MessageBox.Show("Vui lòng chọn nhân viên cần cập nhật thông tin.");
                return;
            }

            // Lấy ID của nhân viên được chọn
            string idNhanVien = dataGridView1.CurrentRow.Cells["IDNhanVien"].Value.ToString();
            bool TrangThaiHienTai = Convert.ToBoolean(dataGridView1.CurrentRow.Cells["TrangThaiHoatDong"].Value);

            // Kiểm tra xem mã nhân viên có được thay đổi trong txtMaNV hay không
            if (txtMaNV.Text != idNhanVien)
            {
                MessageBox.Show("Không thể chỉnh sửa mã nhân viên.");
                return;
            }
            // Kiểm tra xem nhân viên có còn hoạt động không
            if (!TrangThaiHienTai)
            {
                DialogResult dialogResult = MessageBox.Show("Nhân viên này không còn hoạt động. Bạn có muốn tiếp tục chỉnh sửa không?", "Xác nhận", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.No)
                {
                    return; // Dừng hành động chỉnh sửa nếu người dùng chọn 'No'
                }
            }

            // Kiểm tra kết nối và mở nếu cần thiết
            if (connection.State != ConnectionState.Open)
                connection.Open();

            try
            {
                // Truy vấn để lấy IDKho tương ứng với TenKhoVatTu
                string getIDKhoQuery = "SELECT IDKhoVatTu FROM KhoVatTu WHERE TenKho = @TenKho";
                SqlCommand getIDKhoCommand = new SqlCommand(getIDKhoQuery, connection);
                getIDKhoCommand.Parameters.AddWithValue("@TenKho", comboBoxKho.Text); // txtKho chứa tên kho do người dùng nhập vào

                object idKho = getIDKhoCommand.ExecuteScalar();

                if (idKho != null)
                {
                    string updateQuery = @"
                                        UPDATE NhanVien 
                                        SET 
                                            HoTen = @HoTen, 
                                            NgaySinh = @NgaySinh, 
                                            GioiTinh = @GioiTinh, 
                                            IDKho = @IDKho, 
                                            ChucVu = @ChucVu, 
                                            SDT = @SDT, 
                                            TrangThaiHoatDong = @TrangThaiHoatDong 
                                        WHERE IDNhanVien = @IDNhanVien";

                    SqlCommand command = new SqlCommand(updateQuery, connection);

                    // Thêm các thông số vào câu lệnh SQL để ngăn chặn lỗi SQL Injection
                    command.Parameters.AddWithValue("@HoTen", txtHoTen.Text);
                    command.Parameters.AddWithValue("@NgaySinh", dateTimePickerNS.Value);
                    command.Parameters.AddWithValue("@GioiTinh", comboBoxGT.Text);
                    command.Parameters.AddWithValue("@IDKho", idKho);
                    command.Parameters.AddWithValue("@ChucVu", comboBoxCV.Text);
                    command.Parameters.AddWithValue("@SDT", txtSDT.Text);
                    command.Parameters.AddWithValue("@TrangThaiHoatDong", txtTTHD.Text); // Giả sử bạn sử dụng CheckBox cho Trạng Thái Hoạt Động
                    command.Parameters.AddWithValue("@IDNhanVien", idNhanVien);

                    int result = command.ExecuteNonQuery();

                    if (result > 0)
                    {
                        MessageBox.Show("Cập nhật thông tin nhân viên thành công.");
                        LoadData(); // Cập nhật lại dữ liệu trên DataGridView
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật thông tin nhân viên thất bại.");
                    }
                }
                else
                {
                    MessageBox.Show("Tên kho không tồn tại.");
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

        private void LoadComboBoxKhoData()
        {
            try
            {
                // Mở kết nối nếu chưa mở
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                // Truy vấn lấy danh sách tên kho
                string query = "SELECT TenKho FROM KhoVatTu";
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                // Xóa dữ liệu cũ trong comboBoxKho
                comboBoxKho.Items.Clear();

                // Đọc và thêm dữ liệu vào comboBoxKho
                while (reader.Read())
                {
                    comboBoxKho.Items.Add(reader["TenKho"].ToString());
                }

                // Đóng SqlDataReader
                reader.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra khi tải dữ liệu kho: " + ex.Message);
            }
            finally
            {
                // Đóng kết nối
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void txtTTHD_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
