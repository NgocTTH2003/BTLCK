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
    public partial class FormVanChuyen : Form
    {
        SqlConnection connection;
        SqlCommand command;
        string str = "Data Source=HONGNGOC;Initial Catalog=QuanLyThietBi;Integrated Security=True";
        SqlDataAdapter adapter = new SqlDataAdapter();
        DataTable table = new DataTable();
        
        public FormVanChuyen(FormTrangChu formTrangChu)
        {
            try
            {
                InitializeComponent();
                this.formTrangChu = formTrangChu;
                this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
                //sự kiện ẩn hiện groupbox
                this.Load += FormVanChuyen_Load;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private FormTrangChu formTrangChu;

        private void FormVanChuyen_Load(object sender, EventArgs e)
        {
            try
            {
                //khi hiển thị form thì ẩn groupboxThemThietBi
                groupBox.Visible = false;

                connection = new SqlConnection(str);
                connection.Open();
                command = connection.CreateCommand();
                // Thực hiện truy vấn SQL để lấy dữ liệu từ bảng khác
                command.CommandText = "SELECT ChiTietVanChuyen.IDVanChuyen, ChiTietVanChuyen.IDThietBi, ChiTietVanChuyen.SoLuong, ChiTietVanChuyen.NgayVanChuyen, ChiTietVanChuyen.NgayNhan, ChiTietVanChuyen.TinhTrangVanChuyen, ThietBi.TenThietBi, NhanVien.HoTen, Khoa.TenKhoa FROM ChiTietVanChuyen " +
                        "INNER JOIN ThietBi ON ChiTietVanChuyen.IDThietBi = ThietBi.IDThietBi " +
                        "INNER JOIN NhanVien ON ChiTietVanChuyen.IDNhanVien = NhanVien.IDNhanVien " +
                        "INNER JOIN Khoa ON ChiTietVanChuyen.IDVienKhoa = Khoa.IDVienKhoa";

                // Đổ dữ liệu vào DataTable
                adapter.SelectCommand = command;
                table.Clear();
                adapter.Fill(table);

                dataGridView1.DataSource = table;
                dataGridView1.Columns["TenThietBi"].HeaderText = "Tên thiết bị";
                dataGridView1.Columns["HoTen"].HeaderText = "Nhân viên phụ trạc";
                dataGridView1.Columns["TenKhoa"].HeaderText = "Nơi nhận";
                dataGridView1.Columns["IDVanChuyen"].HeaderText = "Mã vận chuyển";
                dataGridView1.Columns["IDThietBi"].HeaderText = "Mã thiết bị";
                dataGridView1.Columns["SoLuong"].HeaderText = "Số lượng";
                dataGridView1.Columns["NgayVanChuyen"].HeaderText = "Ngày giao";
                dataGridView1.Columns["NgayNhan"].HeaderText = "Ngày nhận";
                dataGridView1.Columns["TinhTrangVanChuyen"].HeaderText = "Tình trạng vận chuyển";
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

        private void txtSoLuong_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void buttonKhoiTao_Click(object sender, EventArgs e)
        {

        }

        private void buttonXoa_Click(object sender, EventArgs e)
        {

        }

        private void groupBox_Enter(object sender, EventArgs e)
        {

        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void textBoxMaNV_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePickerNN_ValueChanged(object sender, EventArgs e)
        {

        }

        private void txtDonGia_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMaTB_TextChanged(object sender, EventArgs e)
        {

        }

        private void labelMaNV_Click(object sender, EventArgs e)
        {

        }

        private void labelMaNCC_Click(object sender, EventArgs e)
        {

        }

        private void labelNSX_Click(object sender, EventArgs e)
        {

        }

        private void labelGiaTB_Click(object sender, EventArgs e)
        {

        }

        private void labelSoLuong_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void buttonLuu_Click(object sender, EventArgs e)
        {

        }

        private void textBoxTimKiem_TextChanged(object sender, EventArgs e)
        {

        }

        private void pictureBox5_Click(object sender, EventArgs e)
        {

        }

        private void labelTTTBYT_Click(object sender, EventArgs e)
        {

        }

        private void buttonSua_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void chiTietVanChuyenBindingSource_CurrentChanged(object sender, EventArgs e)
        {

        }

        private void labelTimKiem_Click(object sender, EventArgs e)
        {

        }
    }
}
