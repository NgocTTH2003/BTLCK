using Microsoft.Office.Interop.Excel;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace BTLCK
{
    public partial class FormBaoCaoNhapXuatTB : Form
    {
        private FormTrangChu formTrangChu;

        public FormBaoCaoNhapXuatTB(FormTrangChu formTrangChu)
        {
            InitializeComponent();
            this.formTrangChu = formTrangChu;
        }

        private void Back_Click(object sender, EventArgs e)
        {
            this.formTrangChu.Show();
            this.Close();
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            chart1.Series.Clear();
            // Create a new series and set its chart type to column
            System.Windows.Forms.DataVisualization.Charting.Series series = new System.Windows.Forms.DataVisualization.Charting.Series("ThongKeSoLuongTBTheoVT")
            {
                ChartType = SeriesChartType.Column
            };
            // Add the series to the chart
            chart1.Series.Add(series);

            using (SqlConnection sql = new SqlConnection("Data Source=HONGNGOC;Initial Catalog=QuanLyThietBi;Integrated Security=True"))
            {
                try
                {
                    sql.Open();

                    // SQL queries to fetch data
                    string[] sqlQueries = new string[]
                    {
                        "SELECT SUM(SoLuong) as Total FROM KhoVatTu_ThietBi",
                        "SELECT SUM(SoLuong) as Total FROM ChiTietVanChuyen WHERE TinhTrangVanChuyen = N'Thành công'",
                        "SELECT SUM(SoLuong) as Total FROM ChiTietThanhLy"
                    };

                    string[] columnNames = new string[]
                    {
                        "Kho Vật Tư",
                        "Khoa",
                        "Đã Thanh Lý"
                    };

                    for (int i = 0; i < sqlQueries.Length; i++)
                    {
                        SqlCommand command = new SqlCommand(sqlQueries[i], sql);
                        object result = command.ExecuteScalar();
                        double total = (result != DBNull.Value) ? Convert.ToDouble(result) : 0;

                        // Add data points to the series
                        series.Points.AddXY(columnNames[i], total);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
                }
                finally
                {
                    sql.Close();
                }
            }
        }
    }
}
