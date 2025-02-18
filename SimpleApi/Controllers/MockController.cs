using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Security;

namespace SimpleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MockController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            //string connectionString = "Data Source=host.docker.internal;Initial Catalog=SimpleDatabase;User ID=sa;Password=********;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
            string connectionString = "Server=host.docker.internal,1433;Database=SimpleDatabase;User Id=sa;Password=yourStrong(!)Password;TrustServerCertificate=True;";

            string query = "SELECT * FROM SimpleTable WHERE id = 1;";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@id", 1); // Parameterized query to prevent SQL injection

                connection.Open();
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    if (reader.Read()) // If a row is found
                    {
                        int id = reader.GetInt32(reader.GetOrdinal("Id")); // Get "id" column
                        string name = reader.GetString(reader.GetOrdinal("SimpleData")); // Get "name" column (example)½

                        Console.WriteLine($"ID: {id}, Name: {name}");
                        return Ok(name);
                    }
                    else
                    {
                        Console.WriteLine("No record found.");
                        return BadRequest("No record found");
                    }
                }
            }

        }

    }
}
