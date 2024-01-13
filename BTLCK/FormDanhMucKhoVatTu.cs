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
    public partial class FormDanhMucKhoVatTu : Form
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
            command.CommandText = "select * from KhoVatTu";
            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView1.DataSource = table;

            //thay đổi tên cột
            dataGridView1.Columns[0].HeaderText = "Mã kho vật tư";
            dataGridView1.Columns[1].HeaderText = "Tên kho";
            dataGridView1.Columns[2].HeaderText = "Địa chỉ";

            //thêm items vào comboBoxKho
            comboBoxKho.DataSource = table;
            comboBoxKho.DisplayMember = "TenKho";

            // Đặt sự kiện SelectedIndexChanged cho comboBoxKho
            comboBoxKho.SelectedIndexChanged += ComboBoxKho_SelectedIndexChanged;
        }
        private void FormDanhMucKhoVatTu_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            LoadData();
        }
        private FormTrangChu formTrangChu;

        public FormDanhMucKhoVatTu(FormTrangChu formTrangChu)
        {
            InitializeComponent();
            SetPlaceholderText();
            this.formTrangChu = formTrangChu;
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
            string filter = string.Format("Convert(IDKhoVatTu, 'System.String') LIKE '%{0}%' OR TenKho LIKE '%{0}%' OR  DiaChi LIKE '%{0}%'", searchValue);

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
            // Kiểm tra xem txtMaNV có được điền hay không
            if (!string.IsNullOrEmpty(txtMaKVT.Text))
            {
                MessageBox.Show("Yêu cầu không nhập mã kho");
                return; // Ngăn không cho hàm thực thi tiếp
            }
            // Kiểm tra kết nối và mở nếu cần thiết
            if (connection.State != ConnectionState.Open)
                connection.Open();

            try
            {
                string insertQuery = "INSERT INTO KhoVatTu (TenKho, DiaChi) VALUES (@TenKho, @DiaChi)";
                SqlCommand command = new SqlCommand(insertQuery, connection);

                // Thêm các thông số vào câu lệnh SQL
                //command.Parameters.AddWithValue("@IDKhoVatTu", txtMaKVT.Text);
                command.Parameters.AddWithValue("@TenKho", comboBoxKho.Text); 
                command.Parameters.AddWithValue("@DiaChi", textBoxDC.Text); 

                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Thêm kho vật tư thành công.");
                    LoadData(); // Cập nhật lại dữ liệu trên DataGridView1
                    //cập nhật vào comboBox
                    comboBoxKho.Items.Add(comboBoxKho.Text);
                }
                else
                {
                    MessageBox.Show("Thêm kho vật tư thất bại.");
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
            txtMaKVT.ResetText();  
            comboBoxKho.Text = string.Empty;
            textBoxDC.Text = string.Empty;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i = dataGridView1.CurrentRow.Index;
            txtMaKVT.Text = dataGridView1.Rows[i].Cells[0].Value.ToString(); 
            comboBoxKho.Text = dataGridView1.Rows[i].Cells[1].Value.ToString(); 
            textBoxDC.Text = dataGridView1.Rows[i].Cells[2].Value.ToString(); 
        }

        private void buttonSua_Click(object sender, EventArgs e)
        {
            // Kiểm tra kết nối và mở nếu cần thiết
            if (connection.State != ConnectionState.Open)
                connection.Open();

            try
            {
                string updateQuery = "UPDATE KhoVatTu SET TenKho = @TenKho, DiaChi = @DiaChi WHERE IDKhoVatTu = @IDKhoVatTu";
                SqlCommand command = new SqlCommand(updateQuery, connection);

                // Thêm các thông số vào câu lệnh SQL
                command.Parameters.AddWithValue("@IDKhoVatTu", txtMaKVT.Text);
                command.Parameters.AddWithValue("@TenKho", comboBoxKho.Text); 
                command.Parameters.AddWithValue("@DiaChi", textBoxDC.Text); 

                int result = command.ExecuteNonQuery();

                if (result > 0)
                {
                    MessageBox.Show("Sửa thành công.");
                    LoadData(); // Cập nhật lại dữ liệu trên DataGridView1
                    //cập nhật vào comboBox
                    comboBoxKho.Items.Add(comboBoxKho.Text);
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

        private void ComboBoxKho_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Hiển thị DiaChi tương ứng trên textBoxDC khi comboBoxKho thay đổi
            string selectedKho = comboBoxKho.Text;
            DataRow[] rows = table.Select($"TenKho = '{selectedKho}'");

            if (rows.Length > 0)
            {
                string diaChi = rows[0]["DiaChi"].ToString();
                textBoxDC.Text = diaChi;
            }
        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Sẽ nâng cấp sau");
        }
    }
}
