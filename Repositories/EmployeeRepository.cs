using Npgsql;
using PhoneDirectory.Models;

namespace PhoneDirectory.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly NpgsqlConnection _connection;

        public EmployeeRepository(NpgsqlConnection connection)
        {
            _connection = connection;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            var employees = new List<Employee>();
            var command = new NpgsqlCommand("SELECT * FROM Employees", _connection);

            await _connection.OpenAsync();
            var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                employees.Add(new Employee
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Position = reader.GetString(2),
                    PhoneNumber = reader.GetString(3),
                    DepartmentId = reader.GetInt32(4)
                });
            }
            await _connection.CloseAsync();

            return employees;
        }

        public async Task<Employee> GetEmployeeByIdAsync(int id)
        {
            var command = new NpgsqlCommand("SELECT * FROM Employees WHERE Id = @id", _connection);
            command.Parameters.AddWithValue("id", id);

            await _connection.OpenAsync();
            var reader = await command.ExecuteReaderAsync();
            Employee employee = null;
            if (await reader.ReadAsync())
            {
                employee = new Employee
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Position = reader.GetString(2),
                    PhoneNumber = reader.GetString(3),
                    DepartmentId = reader.GetInt32(4)
                };
            }
            await _connection.CloseAsync();

            return employee;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesByDepartmentAsync(int departmentId)
        {
            var employees = new List<Employee>();
            var command = new NpgsqlCommand("SELECT * FROM Employees WHERE department_id = @departmentId", _connection);
            command.Parameters.AddWithValue("departmentId", departmentId);

            await _connection.OpenAsync();
            var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                employees.Add(new Employee
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Position = reader.GetString(2),
                    PhoneNumber = reader.GetString(3),
                    DepartmentId = reader.GetInt32(4)
                });
            }
            await _connection.CloseAsync();

            return employees;
        }

        public async Task<IEnumerable<Employee>> SearchEmployeesAsync(string searchText)
        {
            var employees = new List<Employee>();
            var command = new NpgsqlCommand("SELECT * FROM Employees WHERE Name ILIKE @searchText OR Position ILIKE @searchText OR phone_number ILIKE @searchText", _connection);
            command.Parameters.AddWithValue("searchText", "%" + searchText + "%");

            await _connection.OpenAsync();
            var reader = await command.ExecuteReaderAsync();
            while (await reader.ReadAsync())
            {
                employees.Add(new Employee
                {
                    Id = reader.GetInt32(0),
                    Name = reader.GetString(1),
                    Position = reader.GetString(2),
                    PhoneNumber = reader.GetString(3),
                    DepartmentId = reader.GetInt32(4)
                });
            }
            await _connection.CloseAsync();

            return employees;
        }

        public async Task AddEmployeeAsync(Employee employee)
        {
            var command = new NpgsqlCommand("INSERT INTO Employees (Name, Position, phone_number, department_id) VALUES (@name, @position, @phoneNumber, @departmentId)", _connection);
            command.Parameters.AddWithValue("name", employee.Name);
            command.Parameters.AddWithValue("position", employee.Position);
            command.Parameters.AddWithValue("phoneNumber", employee.PhoneNumber);
            command.Parameters.AddWithValue("departmentId", employee.DepartmentId);

            await _connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
            await _connection.CloseAsync();
        }

        public async Task UpdateEmployeeAsync(int id, Employee employee)
        {
            var command = new NpgsqlCommand("UPDATE Employees SET Name = @name, Position = @position, phone_number = @phoneNumber, department_id = @departmentId WHERE Id = @id", _connection);
            command.Parameters.AddWithValue("id", id);
            command.Parameters.AddWithValue("name", employee.Name);
            command.Parameters.AddWithValue("position", employee.Position);
            command.Parameters.AddWithValue("phoneNumber", employee.PhoneNumber);
            command.Parameters.AddWithValue("departmentId", employee.DepartmentId);

            await _connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
            await _connection.CloseAsync();
        }

        public async Task DeleteEmployeeAsync(int id)
        {
            var command = new NpgsqlCommand("DELETE FROM Employees WHERE Id = @id", _connection);
            command.Parameters.AddWithValue("id", id);

            await _connection.OpenAsync();
            await command.ExecuteNonQueryAsync();
            await _connection.CloseAsync();
        }
    }

}
