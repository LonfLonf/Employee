using System;
using System.Data.SqlClient;

namespace CrudExample
{
    class Program
    {

        public static void Main(string[] args)
        {
            
            string connectionString = @"Data Source=LONFTONF;
                            Initial Catalog=CrudExample;
                            Trusted_Connection=Yes;";

            while (true)
            {
                Console.WriteLine("Choose An Operation:");
                Console.WriteLine("1. Create Employee");
                Console.WriteLine("2. Read Employees");
                Console.WriteLine("3. Update Employee");
                Console.WriteLine("4. Delete Employee");
                Console.WriteLine("5. Exit");
                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        Console.Write("Name: ");
                        string name = Console.ReadLine();
                        Console.Write("Position: ");
                        string position = Console.ReadLine();
                        Console.Write("Salary: ");
                        decimal salary = decimal.Parse(Console.ReadLine());
                        CreateEmployee(name, position, salary);
                        break;
                    case 2:
                        ReadEmployees();
                        break;
                    case 3:
                        Console.Write("Employee ID to update: ");
                        int updateId = int.Parse(Console.ReadLine());
                        Console.Write("Name: ");
                        string updateName = Console.ReadLine();
                        Console.Write("Position: ");
                        string updatePosition = Console.ReadLine();
                        Console.Write("Salary: ");
                        decimal updateSalary = decimal.Parse(Console.ReadLine());
                        UpdateEmployee(updateId, updateName, updatePosition, updateSalary);
                        break;
                    case 4:
                        Console.Write("Employee ID to delete: ");
                        int deleteId = int.Parse(Console.ReadLine());
                        DeleteEmployee(deleteId);
                        break;
                    case 5:
                        return;
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
                    using (SqlConnection connection = new SqlConnection(connectionString))
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
    }
}
