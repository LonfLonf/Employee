using System;
using System.Data.SqlClient;

namespace CrudExample
{
    class Program
    {
        string connectionString = "Server=LONFTONF;Database=CrudExample;User Id=LONFTONF;Password=;";

        public static void Main(string[] args)
        {

        }

        void CreateEmployee(string name, string position, decimal salary)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "INSERT INTO Employees (Name, Position, Salary) VALUES (@Name, @Position, @Salary)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Position", position);
                command.Parameters.AddWithValue("@Salary", salary);

                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Employee Created Successfully!");
            }
        }

        void ReadEmployees()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Employees";
                SqlCommand command = new SqlCommand(query, connection);

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    Console.WriteLine($"Id: {reader["Id"]}, Name: {reader["Name"]}, Position: {reader["Position"]}, Salary: {reader["Salary"]}");
                }
            }
        }

        void UpdateEmployee(int id, string name, string position, decimal salary)
        {
            using(SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "UPDATE Employees SET Name = @Name, Position = @Position, Salary = @Salary WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);
                command.Parameters.AddWithValue("@Name", name);
                command.Parameters.AddWithValue("@Position", position);
                command.Parameters.AddWithValue("@Salary", salary);

                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Employee updated successfully!");
            }
        }

        void DeleteEmployee(int id)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "DELETE FROM Employees WHERE Id = @Id";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Id", id);

                connection.Open();
                command.ExecuteNonQuery();
                Console.WriteLine("Employee deleted Successfully!");
            }
        }
    }
}