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
    public partial class FormTaiKhoan : Form
    {
        private FormTrangChu formTrangChu;
        public FormTaiKhoan(FormTrangChu formTrangChu)
        {
            InitializeComponent();
            this.formTrangChu = formTrangChu;
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.formDangNhap.Show();
            this.Close();
        }

        private void btnHuy_Click(object sender, EventArgs e)
        {
            txtTDN.ResetText();
            txtMKHT.ResetText();
            txtMKM.ResetText();
            txtXacNhanMK.ResetText();
        }

        private void btnXacNhan_Click(object sender, EventArgs e)
        {
            // Kiểm tra nếu một trong các TextBox không được điền
            if (string.IsNullOrEmpty(txtTDN.Text)||string.IsNullOrEmpty(txtMKM.Text) || string.IsNullOrEmpty(txtXacNhanMK.Text) ||
                txtMKM.Text == "Mật khẩu mới" || txtXacNhanMK.Text == "Xác nhận mật khẩu")
            {
                MessageBox.Show("Hãy điền hết các dòng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; // Dừng thực thi nếu có lỗi
            }

            // So sánh giá trị của txtMKHT trong FormTaiKhoan và txtPass trong FormDangNhap
            if (txtMKM.Text != txtXacNhanMK.Text)
            {
                MessageBox.Show("Xác nhận mật khẩu không đúng", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                try
                {
                    using (SqlConnection scn = new SqlConnection(@"Data Source=HONGNGOC;Initial Catalog=QuanLyThietBi;Integrated Security=True"))
                    {
                        scn.Open();  // Mở kết nối

                        // Kiểm tra xem tên đăng nhập đã tồn tại hay chưa
                        string checkUserQuery = "SELECT COUNT(*) FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap";
                        using (SqlCommand checkUserCmd = new SqlCommand(checkUserQuery, scn))
                        {
                            checkUserCmd.Parameters.AddWithValue("@TenDangNhap", txtTDN.Text);
                            int userCount = (int)checkUserCmd.ExecuteScalar();

                            if (userCount > 0)
                            {
                                // Tên đăng nhập đã tồn tại, kiểm tra mật khẩu
                                string checkPasswordQuery = "SELECT MatKhau FROM TaiKhoan WHERE TenDangNhap = @TenDangNhap";
                                using (SqlCommand checkPasswordCmd = new SqlCommand(checkPasswordQuery, scn))
                                {
                                    checkPasswordCmd.Parameters.AddWithValue("@TenDangNhap", txtTDN.Text);
                                    string storedPassword = checkPasswordCmd.ExecuteScalar()?.ToString();

                                    // Kiểm tra mật khẩu
                                    if (storedPassword != txtMKHT.Text)
                                    {
                                        MessageBox.Show("Sai tài khoản hoặc mật khẩu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                    }
                                    else
                                    {
                                        // Đã xác nhận đúng tài khoản và mật khẩu, cập nhật mật khẩu mới
                                        string updatePasswordQuery = "UPDATE TaiKhoan SET MatKhau = @MatKhau WHERE TenDangNhap = @TenDangNhap";
                                        using (SqlCommand updatePasswordCmd = new SqlCommand(updatePasswordQuery, scn))
                                        {
                                            updatePasswordCmd.Parameters.AddWithValue("@MatKhau", txtMKM.Text);
                                            updatePasswordCmd.Parameters.AddWithValue("@TenDangNhap", txtTDN.Text);
                                            updatePasswordCmd.ExecuteNonQuery();
                                        }

                                        MessageBox.Show("Cập nhật mật khẩu thành công", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    }
                                }
                            }
                            else
                            {
                                MessageBox.Show("Sai tài khoản hoặc mật khẩu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi khi kết nối cơ sở dữ liệu: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.formTrangChu.Show();
            this.Close();
        }
    }
}
