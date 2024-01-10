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
	                               ChiTietBaoTri.TinhTrangBaoTri
                                   from ChiTietBaoTri inner join ThietBi on ChiTietBaoTri.IDThietBi = ThietBi.IDThietBi";

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
        }

        private void FormBT_Load(object sender, EventArgs e)
        {
            connection = new SqlConnection(str);
            connection.Open();
            LoadData();
            LoadDataCapNhat();
            LoadComboBoxTenThietBiData3();
            LoadComboBoxTinhTrangBTData3();
            LoadComboBoxDVBTData3();
            LoadComboBoxTenThietBiData2();
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

            // Khi người dùng rời khỏi textBox mà không nhập gì
            if (string.IsNullOrWhiteSpace(textBoxTimKiem3.Text))
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
                              "TinhTrangBaoTri LIKE '%{0}%' ", searchValue);

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
	                                ChiTietBaoTri.TinhTrangBaoTri
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
        }


        //*******************************************************************************************************************************
        // tab3 cập nhật thông tin 
        void LoadDataCapNhat()
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
	                               ChiTietBaoTri.TinhTrangBaoTri
                                   from ChiTietBaoTri inner join ThietBi on ChiTietBaoTri.IDThietBi = ThietBi.IDThietBi;";

            adapter.SelectCommand = command;
            table.Clear();
            adapter.Fill(table);
            dataGridView3.DataSource = table;

            //thay đổi tên cột
            dataGridView3.Columns[0].HeaderText = "Mã bảo trì";
            dataGridView3.Columns[1].HeaderText = "Mã thiết bị";
            dataGridView3.Columns[2].HeaderText = "Tên thiết bị";
            dataGridView3.Columns[3].HeaderText = "Ngày bảo trì";
            dataGridView3.Columns[4].HeaderText = "Ngày hoàn thành";
            dataGridView3.Columns[5].HeaderText = "Chi phí";
            dataGridView3.Columns[6].HeaderText = "Đơn vị bảo trì";
            dataGridView3.Columns[7].HeaderText = "Tình trạng bảo trì";
        }

        private void textBoxTimKiem3_TextChanged(object sender, EventArgs e)
        {
            string searchValue = textBoxTimKiem3.Text;

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
                              "TinhTrangBaoTri LIKE '%{0}%'" , searchValue);

            // Kiểm tra xem table đã được khởi tạo và có dữ liệu
            if (table != null)
            {
                // Áp dụng bộ lọc
                table.DefaultView.RowFilter = filter;
                dataGridView3.DataSource = table;
            }
        }

        private void dataGridView3_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int i;
            i = dataGridView1.CurrentRow.Index;
            textBoxMaBT3.Text = dataGridView1.Rows[i].Cells[0].Value.ToString();
            textBoxMaTB3.Text = dataGridView1.Rows[i].Cells[1].Value.ToString();
            comboBoxTenTB3.Text = dataGridView1.Rows[i].Cells[2].Value.ToString();
            dateTimePickerNBT3.Text = dataGridView1.Rows[i].Cells[3].Value.ToString();
            dateTimePickerNHT3.Text = dataGridView1.Rows[i].Cells[4].Value.ToString();
            textBoxChiPhiBT3.Text = dataGridView1.Rows[i].Cells[5].Value.ToString();
            comboBoxDVBT3.Text = dataGridView1.Rows[i].Cells[6].Value.ToString();
            comboBoxTTBT3.Text = dataGridView1.Rows[i].Cells[7].Value.ToString();
        }

        private void buttonKhoiTao3_Click(object sender, EventArgs e)
        {
            textBoxMaBT3.ResetText();
            textBoxMaTB3.ResetText();
            comboBoxTenTB3.ResetText();
            dateTimePickerNBT3.Text = string.Empty;
            dateTimePickerNHT3.Text = string.Empty;
            textBoxChiPhiBT3.ResetText();
            comboBoxDVBT3.ResetText();
            comboBoxTTBT3.ResetText();
        }

        // Hàm để tải lại dữ liệu từ cơ sở dữ liệu và cập nhật DataGridView3
        void ReloadData3()
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
	                                ChiTietBaoTri.TinhTrangBaoTri
                                    from ChiTietBaoTri inner join ThietBi on ChiTietBaoTri.IDThietBi = ThietBi.IDThietBi;";
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

        //chức năng cập nhật
        private void buttonCapNhat3_Click(object sender, EventArgs e)
        {
            // Mở kết nối và bắt đầu giao dịch
            if (connection.State != ConnectionState.Open)
                connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                // Lấy các giá trị từ các controls
                string MaBT = textBoxMaBT3.Text;
                string MaTB = textBoxMaTB3.Text;
                string TenTB = comboBoxTTBT3.Text;
                DateTime NBT = dateTimePickerNBT3.Value;
                DateTime NHT = dateTimePickerNHT3.Value;
                float ChiPhiBT = float.Parse(textBoxChiPhiBT3.Text);
                string DVBT = comboBoxDVBT3.Text;
                string tinhTrangBT = comboBoxTTBT3.Text;

                // Thực hiện cập nhật dữ liệu vào cơ sở dữ liệu
                string query = @"
                UPDATE ChiTietBaoTri
                SET 
                    IDThietBi = @MaTB,
                    DonViBaoTri = @DVBT,
                    ChiPhiBaoTri = @ChiPhiBT,
                    NgayBaoTri = @NBT,
                    NgayHoanThanh = @NHT,
                    TinhTrangBaoTri = @TinhTrangBT
                WHERE IDBaoTri = @MaBT";

                using (SqlCommand command = new SqlCommand(query, connection, transaction))
                {
                    command.Parameters.AddWithValue("@MaTB", MaTB);
                    command.Parameters.AddWithValue("@DVBT", DVBT);
                    command.Parameters.AddWithValue("@ChiPhiBT", ChiPhiBT);
                    command.Parameters.AddWithValue("@NBT", NBT);
                    command.Parameters.AddWithValue("@NHT", NHT);
                    command.Parameters.AddWithValue("@TinhTrangBT", tinhTrangBT);
                    command.Parameters.AddWithValue("@MaBT", MaBT);

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

        private void LoadComboBoxTinhTrangBTData3()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                string query = "SELECT DISTINCT  TinhTrangBaoTri FROM ChiTietBaoTri";
                command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                comboBoxTTBT3.Items.Clear();

                while (reader.Read())
                {
                    comboBoxTTBT3.Items.Add(reader["TinhTrangBaoTri"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi tải danh sách tình trạng bảo tì: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void LoadComboBoxDVBTData3()
        {
            try
            {
                if (connection.State != ConnectionState.Open)
                    connection.Open();

                string query = "SELECT DISTINCT  DonViBaoTri FROM ChiTietBaoTri";
                command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();

                comboBoxDVBT3.Items.Clear();

                while (reader.Read())
                {
                    comboBoxDVBT3.Items.Add(reader["DonViBaoTri"].ToString());
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi khi tải danh sách tình trạng bảo tì: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close();
            }
        }

        private void comboBoxTenTB3_SelectedIndexChanged(object sender, EventArgs e)
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



        //*******************************************************************************************************************************
        //tab2 Lập kế hoạch bảo trì 
        private void buttonKhoiTao2_Click(object sender, EventArgs e)
        {
            comboBoxTenTB2.Text = string.Empty;
            textBoxMaTB2.ResetText();
            dateTimePickerNBT2.Text = string.Empty;
            dateTimePickerNHT2.Text = string.Empty;
            textBoxDVBT2.ResetText();
        }

        private void buttonTaoKH2_Click(object sender, EventArgs e)
        {
            // Mở kết nối và bắt đầu giao dịch
            if (connection.State != ConnectionState.Open)
                connection.Open();
            SqlTransaction transaction = connection.BeginTransaction();

            try
            {
                // Lấy các giá trị từ các controls
                string MaTB = textBoxMaTB2.Text;
                string TenTB = comboBoxTenTB2.Text; // Tên thiết bị, không sử dụng trong truy vấn này
                DateTime NBT = dateTimePickerNBT2.Value;
                DateTime NHT = dateTimePickerNHT2.Value;
                string DVBT = textBoxDVBT2.Text;

                // Thực hiện cập nhật dữ liệu vào cơ sở dữ liệu
                string query = @"
                                INSERT INTO ChiTietBaoTri (IDThietBi, DonViBaoTri, ChiPhiBaoTri, NgayBaoTri, NgayHoanThanh, TinhTrangBaoTri)
                                VALUES (@MaTB, @DVBT, 0, @NBT, @NHT, N'Không thành công')";

                using (SqlCommand command = new SqlCommand(query, connection, transaction))
                {
                    command.Parameters.AddWithValue("@MaTB", MaTB);
                    command.Parameters.AddWithValue("@DVBT", DVBT);
                    command.Parameters.AddWithValue("@NBT", NBT);
                    command.Parameters.AddWithValue("@NHT", NHT);

                    // Thực thi lệnh
                    int rowsAffected = command.ExecuteNonQuery();

                    // Xử lý kết quả
                    if (rowsAffected > 0)
                    {
                        transaction.Commit(); // Hoàn tất giao dịch
                        MessageBox.Show("Lập kế hoạch thành công.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // Gọi hàm để tải lại dữ liệu nếu cần
                    }
                    else
                    {
                        transaction.Rollback(); // Hoàn tác giao dịch
                        MessageBox.Show("Không tạo được kế hoạch mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
            catch (Exception ex)
            {
                transaction.Rollback(); // Hoàn tác giao dịch nếu có lỗi
                MessageBox.Show("Có lỗi khi lập kế hoạch: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (connection.State == ConnectionState.Open)
                    connection.Close(); // Luôn đóng kết nối trong khối finally
            }
        }


        private void LoadComboBoxTenThietBiData2()
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
                        textBoxMaTB2.Text = result.ToString();
                    }
                    else
                    {
                        textBoxMaTB2.Text = string.Empty;
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
    }
}
