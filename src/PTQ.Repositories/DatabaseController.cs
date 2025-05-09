using System.Data;
using Microsoft.Data.SqlClient;
using PTQ.Models;

namespace PTQ.Repositories;

public class DatabaseController
{
    private string connectionString;

    public DatabaseController(string connectionString)
    {
        this.connectionString = connectionString;
    }

    public List<GetAllTestResponseBody> GetAllTests()
    {
        List<GetAllTestResponseBody> result = new();
        using (SqlConnection connection = new(connectionString))
        {
            connection.Open();
            using (SqlCommand command = new("Select Id, Name FROM Quiz", connection))
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                    result.Add(new GetAllTestResponseBody(reader.GetInt32(0), reader.GetString(1)));
                reader.Close();
            }
        }
        return result;
    }

    public Quiz GetTestById(int id)
    {
        using (SqlConnection connection = new(connectionString))
        {
            connection.Open();
            using (SqlCommand command = new ("Select * FROM Quiz Where Id = @Id", connection))
            {
                command.Parameters.Add("@Id", SqlDbType.Int);
                command.Parameters["@Id"].Value = id;
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                return new Quiz(reader.GetInt32(0), reader.GetString(1), reader.GetInt32(2), reader.GetString(3));
            }
        }
    }
}