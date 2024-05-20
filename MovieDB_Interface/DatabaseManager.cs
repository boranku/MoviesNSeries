using System;
using System.Data;
using System.Data.SqlClient;

namespace MovieDB_Interface
{
    public class DatabaseManager
    {
        //static string connectionString = @"Server=DESKTOP-KLO3VO6; Database=MoviesNSeries; Integrated Security=True;"; boran
        static SqlConnection connection;
        static SqlCommand command;
        static SqlDataReader reader;

        public static void ExecuteSelectQuery()
        {
            string query = "SELECT * FROM Movies";
            using (connection = new SqlConnection(connectionString))
            {
                command = new SqlCommand(query, connection);

                try
                {
                    connection.Open();
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        for (int i = 0; i < reader.FieldCount; i++)  // Iterate through each column in the row
                        {
                            string columnName = reader.GetName(i);  // Get the column name
                            string value = reader.IsDBNull(i) ? "NULL" : reader.GetValue(i).ToString();  // Handle NULL values
                            System.Diagnostics.Debug.WriteLine($"{columnName}: {value}");  // Print column name and value
                        }
                        System.Diagnostics.Debug.WriteLine("");
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
        }

        public static void ExecuteInsertQuery(string name, int releaseYear, double rate)
        {
            string query = "INSERT INTO Movie (name, release_year, rate) VALUES (@name, @release_year, @rate)";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);

                // Parametreleri ekleyin ve değerlere atayın
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@release_year", releaseYear);
                command.Parameters.AddWithValue("@rate", rate);

                try
                {
                    connection.Open();
                    int rowsAffected = command.ExecuteNonQuery(); // Değiştirilen satır sayısını alır

                    System.Diagnostics.Debug.WriteLine($"{rowsAffected} row(s) inserted.");
                }
                catch (Exception ex)
                {
                    System.Diagnostics.Debug.WriteLine(ex.Message);
                }
            }
        }




        // Diğer veritabanı işlevleri...
    }
}