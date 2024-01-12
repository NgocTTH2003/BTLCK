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

namespace BTLCK
{
    public partial class FormDangKyTK : Form
    {
        private FormDangNhap formDangNhap;
        public FormDangKyTK(FormDangNhap formDangNhap)
        {
            InitializeComponent();
            this.formDangNhap = formDangNhap;
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            InitializePlaceholder();
            
        }
        private void InitializePlaceholder()
        {
            txtMaNV.Text = "Mã số nhân viên";
            txtMaNV.ForeColor = Color.Black;

            txtMaNV.Enter += txtMaNV_GotFocus;
            txtMaNV.Leave += txtMaNV_LostFocus;

            txtTK.Text = "Tài khoản";
            txtTK.ForeColor = Color.Black;

            txtTK.Enter += txtTK_GotFocus;
            txtTK.Leave += txtTK_LostFocus;

            txtMK.Text = "Mật khẩu";
            txtMK.ForeColor = Color.Black;

            txtMK.Enter += txtMK_GotFocus;
            txtMK.Leave += txtMK_LostFocus;

            txtXacNhanMK.Text = "Xác nhận mật khẩu";
            txtXacNhanMK.ForeColor = Color.Black;

            txtXacNhanMK.Enter += txtXacNhanMK_GotFocus;
            txtXacNhanMK.Leave += txtXacNhanMK_LostFocus;
        }

        private void txtMaNV_GotFocus(object sender, EventArgs e)
        {
            if (txtMaNV.Text == "Mã số nhân viên")
            {
                txtMaNV.Text = "";
                txtMaNV.ForeColor = Color.Black;
            }
        }
        private void txtTK_GotFocus(object sender, EventArgs e)
        {
            if (txtTK.Text == "Tài khoản")
            {
                txtTK.Text = "";
                txtTK.ForeColor = Color.Black;
            }
        }
        private void txtMK_GotFocus(object sender, EventArgs e)
        {
            if (txtMK.Text == "Mật khẩu")
            {
                txtMK.Text = "";
                txtMK.ForeColor = Color.Black;
            }
        }
        private void txtXacNhanMK_GotFocus(object sender, EventArgs e)
        {
            if (txtXacNhanMK.Text == "Xác nhận mật khẩu")
            {
                txtXacNhanMK.Text = "";
                txtXacNhanMK.ForeColor = Color.Black;
            }
        }

        private void txtMaNV_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                txtMaNV.Text = "Mã số nhân viên";
                txtMaNV.ForeColor = Color.Black;
            }
        }

        private void txtTK_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTK.Text))
            {
                txtTK.Text = "Tài khoản";
                txtTK.ForeColor = Color.Black;
            }
        }
        private void txtMK_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMK.Text))
            {
                txtMK.Text = "Mật khẩu";
                txtMK.ForeColor = Color.Black;
            }
        }
        private void txtXacNhanMK_LostFocus(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtXacNhanMK.Text))
            {
                txtXacNhanMK.Text = "Xác nhận mật khẩu";
                txtXacNhanMK.ForeColor = Color.Black;
            }
        }

        private void txtMaNV_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMaNV.Text))
            {
                txtMaNV.Text = "Mã số nhân viên";
                txtMaNV.ForeColor = Color.Black;
            }
        }

        private void txtTK_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtTK.Text))
            {
                txtTK.Text = "Tài khoản";
                txtTK.ForeColor = Color.Black;
            }
        }
        private void txtMK_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtMK.Text))
            {
                txtMK.Text = "Mật khẩu";
                txtMK.ForeColor = Color.Black;
            }
        }
        private void txtXacNhanMK_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtXacNhanMK.Text))
            {
                txtXacNhanMK.Text = "Tài khoản";
                txtXacNhanMK.ForeColor = Color.Black;
            }
        }
        private void FormDangKyTK_Load(object sender, EventArgs e)
        {

        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.formDangNhap.Show();
            this.Close();
        }

        private void btnKhoiTao_Click(object sender, EventArgs e)
        {
            txtMaNV.ResetText();
            txtMK.ResetText();
            txtTK.ResetText();
            txtXacNhanMK.ResetText();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem các ô nhập liệu có được nhập đầy đủ không
            if (string.IsNullOrWhiteSpace(txtMaNV.Text) ||
                string.IsNullOrWhiteSpace(txtTK.Text) ||
                string.IsNullOrWhiteSpace(txtMK.Text) ||
                string.IsNullOrWhiteSpace(txtXacNhanMK.Text) ||
                txtMaNV.Text == "Mã số nhân viên" ||
                txtTK.Text == "Tài khoản" ||
                txtMK.Text == "Mật khẩu" ||
                txtXacNhanMK.Text == "Xác nhận mật khẩu")
            {
                // Hiển thị thông báo nếu có ô nào đó trống
                MessageBox.Show("Điền hết dữ liệu trống", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if (txtMK.Text != txtXacNhanMK.Text)
            {
                // Hiển thị thông báo nếu mật khẩu và xác nhận mật khẩu khác nhau
                MessageBox.Show("Xác nhận lại mật khẩu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                using (SqlConnection scn = new SqlConnection(@"Data Source=HONGNGOC;Initial Catalog=QuanLyThietBi;Integrated Security=True"))
                {
                    try
                    {
                        scn.Open();

                        // Kiểm tra xem giá trị của txtMaNV có tồn tại trong bảng NhanVien không
                        string checkExistNhanVienQuery = $"SELECT COUNT(*) FROM NhanVien WHERE IDNhanVien = '{txtMaNV.Text}'";
                        SqlCommand checkExistNhanVienCmd = new SqlCommand(checkExistNhanVienQuery, scn);

                        int countNhanVien = Convert.ToInt32(checkExistNhanVienCmd.ExecuteScalar());

                        if (countNhanVien > 0)
                        {
                            // txtMaNV tồn tại trong bảng NhanVien, kiểm tra xem TenDangNhap đã tồn tại chưa
                            string checkExistTaiKhoanQuery = $"SELECT COUNT(*) FROM TaiKhoan WHERE TenDangNhap = '{txtTK.Text}'";
                            SqlCommand checkExistTaiKhoanCmd = new SqlCommand(checkExistTaiKhoanQuery, scn);

                            int countTaiKhoan = Convert.ToInt32(checkExistTaiKhoanCmd.ExecuteScalar());

                            if (countTaiKhoan > 0)
                            {
                                // txtTK đã tồn tại trong bảng TaiKhoan
                                MessageBox.Show("Tài khoản đã tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                            else
                            {
                                // txtTK chưa tồn tại trong bảng TaiKhoan, thực hiện chèn dữ liệu vào bảng TaiKhoan
                                string insertQuery = "INSERT INTO TaiKhoan (IDNhanVien, TenDangNhap, MatKhau) VALUES (@IDNhanVien, @TaiKhoan, @MatKhau)";
                                SqlCommand insertCmd = new SqlCommand(insertQuery, scn);

                                insertCmd.Parameters.AddWithValue("@IDNhanVien", txtMaNV.Text);
                                insertCmd.Parameters.AddWithValue("@TaiKhoan", txtTK.Text);
                                insertCmd.Parameters.AddWithValue("@MatKhau", txtMK.Text);

                                insertCmd.ExecuteNonQuery();

                                MessageBox.Show("Tạo tài khoản thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            // txtMaNV không tồn tại trong bảng NhanVien
                            MessageBox.Show("Mã số nhân viên không tồn tại", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }

            }
        }
       }

}
