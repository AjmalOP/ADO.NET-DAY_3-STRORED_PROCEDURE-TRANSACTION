using ADO.NET_DAY_3_STRORED_PROCEDURE_TRANSACTION.Model;
using Microsoft.Data.SqlClient;
using System.Data;
using System.Data.Common;

namespace ADO.NET_DAY_3_STRORED_PROCEDURE_TRANSACTION.Service
{
    public class Service : IService
    {
        public string CString = "data source = AJMAL ; database = 4TH_WEEK ; integrated security = SSPI ; TrustServerCertificate = true";
        public List<D3STD> allstd()
        {
            List<D3STD> students = new List<D3STD>();
            using(SqlConnection connection = new SqlConnection(CString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("GetAll", connection);
                command.CommandType = CommandType.StoredProcedure;
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    D3STD std = new D3STD();
                    std.Id = Convert.ToInt32(reader["Id"]);
                    std.Name = reader["Name"].ToString();
                    std.Age = Convert.ToInt32(reader["Age"]);
                    students.Add(std);
                }
            }
            return students;
        }
        public D3STD GetById(int id) 
        { 
            using(SqlConnection connection = new SqlConnection(CString))
            {
                D3STD std = new D3STD();
                connection.Open();
                SqlCommand command = new SqlCommand("GetById", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", id);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    std.Id = (int)reader["Id"];
                    std.Name = (string)reader["Name"];
                    std.Age = (int)reader["Age"];
                }
                return std;
            }
        }
        public string InsertStd(D3STD std)
        {
            using (SqlConnection connection = new SqlConnection(CString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("InsertSTD", connection);
                command.CommandType= CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@name", std.Name);
                command.Parameters.AddWithValue("@age", std.Age);
                command.ExecuteNonQuery();
            }
            return "Inserted Successfully";
        }
        public string UpdateStd(D3STD std)
        {
            using (SqlConnection connection = new SqlConnection(CString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UpdateSTD", connection);
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@Id", std.Id);
                command.Parameters.AddWithValue("@name", std.Name);
                command.Parameters.AddWithValue("@age", std.Age);
                command.ExecuteNonQuery();
            }
            return "Updated Successfully";
        }
        public string DeleteStd(int id)
        {
            using(SqlConnection connection = new SqlConnection(CString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();
                try
                {
                    SqlCommand command = new SqlCommand("DeleteSTD", connection, transaction);
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                    transaction.Commit();
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    Console.WriteLine(ex.ToString());
                }
            }
            return "Deleted Successfully";
        }
    }
}
