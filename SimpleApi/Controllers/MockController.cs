using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace SimpleApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MockController : ControllerBase
    {
        private string connectionString = "Data Source=localhost;Initial Catalog=SimpleDatabase;User ID=sa;Password=********;Connect Timeout=30;Encrypt=True;Trust Server Certificate=True;Application Intent=ReadWrite;Multi Subnet Failover=False";
        [HttpGet]
        public IActionResult Get()
        {
            //string query = "SELECT TOP 1 * FROM SimpleTable ORDER BY id"; // Modify table and column names
            //using (SqlConnection connection = new SqlConnection(connectionString))
            //{
            //    SqlCommand command = new SqlCommand(query, connection);
            //    connection.Open();

            //    using (SqlDataReader reader = command.ExecuteReader())
            //    {
            //        if (reader.Read()) // Reads the first row
            //        {
            //            return Ok(reader["Column2"]);
            //        }
            //        else
            //        {
            //            Console.WriteLine("No data found.");
            //        }
            //    }
            //}

            return Ok("Hello World");
        }

    }
}
