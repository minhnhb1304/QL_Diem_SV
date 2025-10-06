using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace QL_Diem
{
    internal class ConnectData
    {
        SqlConnection sqlConn; //doi tuong ket noi CSDL
        SqlDataAdapter da;  //doi tuong trung gian lay du lieu tu CSDL
        DataSet ds;     //doi tuong chua du lieu tu CSDL

        //Ham ket noi CSDL
        public ConnectData()
        {
            //chuoi ket noi CSDL
            string strCnn = "Data Source=localhost;Initial Catalog=QuanLySinhVien;Integrated Security=True;TrustServerCertificate=True";
            sqlConn = new SqlConnection(strCnn);
        }

        //phuong thuc thuc hien cau lenh strSQL truy van du lieu
        public DataTable Execute(string strSQL)
        {
            da = new SqlDataAdapter(strSQL, sqlConn);
            ds = new DataSet();
            da.Fill(ds);
            return ds.Tables[0];
        }

        //phuong thuc thuc hien cau lenh Them, Xoa, Sua
        public void ExecuteNonQuery(string strSQL)
        {
            SqlCommand sqlCmd = new SqlCommand(strSQL, sqlConn);
            sqlConn.Open();
            sqlCmd.ExecuteNonQuery();
            sqlConn.Close();
        }
    }
}
