using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;

namespace BTLCK
{
    class ClassLayDuLieu
    {
        string DataSources = "Data Source=HONGNGOC;Initial Catalog=QuanLyThietBi;Integrated Security=True";
        public void LayDuLieuBangNhanVien()
        {
            string queryNhanVien = "SELECT * FROM NhanVien";

            using (SqlConnection connection = new SqlConnection(DataSources))
            {
                SqlCommand command = new SqlCommand(queryNhanVien, connection);
                connection.Open();

                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        Console.WriteLine(reader.GetValue(i));
                    }
                }

                reader.Close();
            }
        }

        public void LayDuLieuBangThietBi()
        {
            string queryThietBi = "SELECT * FROM ThietBi";
            using (SqlConnection connection = new SqlConnection(DataSources))
            {
                SqlCommand command = new SqlCommand(queryThietBi, connection);
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();


            }    
        }
    }
}
