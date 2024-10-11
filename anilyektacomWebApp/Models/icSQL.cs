using System;
using Microsoft.Data.SqlClient;

namespace anilyektacomWebApp.Models
{
    public class icSQL
    {
        private string connectionString;

        public icSQL()
        {
            connectionString = "Server=10.10.1.22;Database=anilyektacom;User Id=sa;Password=Q1w2e3r4;TrustServerCertificate=True;";
        }
          
        public SqlConnection OpenConnection()
        {
            SqlConnection connection = new SqlConnection(connectionString);
            try
            {
                connection.Open(); 
                Console.WriteLine("SQL bağlantısı başarılı.");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("SQL bağlantısı başarısız: " + ex.Message);
            }
            return connection;
        }

        public void CloseConnection(SqlConnection connection)
        {
            if (connection != null && connection.State == System.Data.ConnectionState.Open)
            {
                connection.Close();
                Console.WriteLine("SQL bağlantısı kapatıldı.");
            }
        }

        public int ExecuteScalarQuery(string password, bool sqlinjection)
        {
            int result = 0;
            using (SqlConnection connection = OpenConnection())
            { 
                if(!sqlinjection) 
                {
                    string query = "SELECT COUNT(*) FROM Kullanicilar WHERE pin = @password";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@password", password);
                    try
                    {
                        result = (int)command.ExecuteScalar();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("SQL sorgusu hatası: " + ex.Message);
                    }
                    finally
                    {
                        CloseConnection(connection);
                    }
                }
                else
                {
                    string query = "SELECT COUNT(*) FROM Kullanicilar WHERE pin = '" + password + "'";
                    SqlCommand command = new SqlCommand(query, connection);
                    try
                    {
                        result = (int)command.ExecuteScalar();
                    }
                    catch (SqlException ex)
                    {
                        Console.WriteLine("SQL sorgusu hatası: " + ex.Message);
                    }
                    finally
                    {
                        CloseConnection(connection);
                    }
                }
            }
            return result;
        }
    }
}