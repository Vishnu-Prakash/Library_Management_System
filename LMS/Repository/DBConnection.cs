using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Repository
{
    class DBConnection
    {
        public SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString);
        public SqlConnection GetCon()
        {
            if (con.State == ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }
        public int ExeNonQuery(SqlCommand cmd)
        {
            cmd.Connection = GetCon();
            int rowsaffected = -1;
            rowsaffected = cmd.ExecuteNonQuery();
            con.Close();
            return rowsaffected;
        }
        public object ExeScalar(SqlCommand cmd)
        {
            cmd.Connection = GetCon();
            object obj = -1;
            obj = cmd.ExecuteScalar();
            con.Close();
            return obj;
        }
        public DataTable ExeReader(SqlCommand cmd)
        {
            cmd.Connection = GetCon();
            SqlDataReader sdr;
            DataTable dt = new DataTable();

            sdr = cmd.ExecuteReader();
            dt.Load(sdr);
            con.Close();
            return dt;
        }
    }
}