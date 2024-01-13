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
    public partial class FormDanhMucVienKhoa : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=HONGNGOC;Initial Catalog=QuanLyThietBi;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();

        private FormTrangChu formTrangChu;
        public FormDanhMucVienKhoa(FormTrangChu formTrangChu)
        {
            InitializeComponent();
            SetPlaceholderText();
            this.formTrangChu = formTrangChu;
        }

        //tải dữ liệu
        void LoadData()
        {
            //tải dữ liệu
            command = connection.CreateCommand();
            command.CommandText = "select * from Khoa";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;

            //thay đổi tên cột
            dataGridView1.Columns[0].HeaderText = "Mã Khoa";
            dataGridView1.Columns[1].HeaderText = "Tên khoa";
            dataGridView1.Columns[2].HeaderText = "Địa chỉ";
        }

        private void FormDanhMucVienKhoa_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            LoadData();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            txtMaKhoa.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            txtTenKhoa.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            txtDiaChi.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
        }
        private void SetPlaceholderText()
        {
            // Đặt placeholder text ban đầu
            textBoxTimKiem.Text = "Nhập từ khóa cần tìm";
            textBoxTimKiem.ForeColor = Color.Gray;
        }

        //nút tìm kiếm
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
            string filter = string.Format("Convert(IDVienKhoa, 'System.String') LIKE '%{0}%' OR TenKhoa LIKE '%{0}%' OR  DiaChi LIKE '%{0}%'", searchValue);

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


        private void buttonThem_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem txtMaNCC có được điền hay không
            if (!string.IsNullOrEmpty(txtMaKhoa.Text))
            {
                MessageBox.Show("Yêu cầu không nhập mã khoa");
                return; // Ngăn không cho hàm thực thi tiếp
            }
            // Kiểm tra kết nối và mở nếu cần thiết
            if (connection.State != ConnectionState.Open)
                connection.Open();

            try
            {
                string insertQuery = "INSERT INTO Khoa (TenKhoa, DiaChi) VALUES (@TenKhoa, @DiaChi)";
                SqlCommand command = new SqlCommand(insertQuery, connection);

                // Thêm các thông số vào câu lệnh SQL
                command.Parameters.AddWithValue("@TenKhoa", txtTenKhoa.Text);
                command.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);

                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Thêm thành công.");
                    LoadData(); // Cập nhật lại dữ liệu trên DataGridView1
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
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void buttonKhoiTao_Click(object sender, EventArgs e)
        {
            txtMaKhoa.ResetText();
            txtTenKhoa.ResetText();
            txtDiaChi.ResetText();
            textBoxTimKiem.ResetText();
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem các dòng có được nhập không
            if (string.IsNullOrEmpty(txtMaKhoa.Text) ||
                string.IsNullOrEmpty(txtTenKhoa.Text) ||
                string.IsNullOrEmpty(txtDiaChi.Text))
            {
                MessageBox.Show("Nhập hết các dòng.");
                return; // Ngăn không cho hàm thực thi tiếp nếu có dòng nào chưa nhập
            }

            // Kiểm tra kết nối và mở nếu cần thiết
            if (connection.State != ConnectionState.Open)
                connection.Open();

            try
            {
                // Kiểm tra xem MaKhoa có tồn tại hay không
                string checkExistQuery = "SELECT COUNT(*) FROM Khoa WHERE IDVienKhoa = @IDKhoa";
                SqlCommand checkExistCommand = new SqlCommand(checkExistQuery, connection);
                checkExistCommand.Parameters.AddWithValue("@IDKhoa", txtMaKhoa.Text);

                int count = (int)checkExistCommand.ExecuteScalar();

                if (count == 0)
                {
                    MessageBox.Show("Khoa không tồn tại.");
                    return; // Ngăn không cho hàm thực thi tiếp nếu Nhà cung cấp không tồn tại
                }

                // Thực hiện cập nhật
                string updateQuery = "UPDATE Khoa SET TenKhoa = @TenKhoa, DiaChi = @DiaChi where IDVienKhoa = @IDKhoa";
                SqlCommand command = new SqlCommand(updateQuery, connection);

                // Thêm các thông số vào câu lệnh SQL
                command.Parameters.AddWithValue("@IDKhoa", txtMaKhoa.Text);
                command.Parameters.AddWithValue("@TenKhoa", txtTenKhoa.Text);
                command.Parameters.AddWithValue("@DiaChi", txtDiaChi.Text);

                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Sửa thành công.");
                    LoadData(); // Cập nhật lại dữ liệu trên DataGridView1
                }
                else
                {
                    MessageBox.Show("Sửa không thành công.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sẽ nâng cấp sau");
        }
    }
}
