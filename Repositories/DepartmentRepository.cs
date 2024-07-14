using Npgsql;
using PhoneDirectory.Models;

namespace PhoneDirectory.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly string _connectionString;

        public DepartmentRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        public async Task<IEnumerable<Department>> GetDepartmentsAsync()
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new NpgsqlCommand("SELECT id, name, parent_id FROM departments", connection))
                {
                    var departments = new List<Department>();
                    var reader = await command.ExecuteReaderAsync();
                    while (await reader.ReadAsync())
                    {
                        departments.Add(new Department
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            ParentId = reader.IsDBNull(2) ? (int?)null : reader.GetInt32(2)
                        });
                    }
                    return departments;
                }
            }
        }

        public async Task<Department> GetDepartmentByIdAsync(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new NpgsqlCommand("SELECT id, name, parent_id FROM departments WHERE id = @id", connection))
                {
                    command.Parameters.AddWithValue("id", id);
                    var reader = await command.ExecuteReaderAsync();
                    if (await reader.ReadAsync())
                    {
                        return new Department
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            ParentId = reader.IsDBNull(2) ? (int?)null : reader.GetInt32(2)
                        };
                    }
                    return null;
                }
            }
        }

        public async Task AddDepartmentAsync(Department department)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new NpgsqlCommand("INSERT INTO departments (name, parent_id) VALUES (@name, @parentId)", connection))
                {
                    command.Parameters.AddWithValue("name", department.Name);
                    command.Parameters.AddWithValue("parentId", department.ParentId ?? (object)DBNull.Value);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task UpdateDepartmentAsync(int id, Department department)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new NpgsqlCommand("UPDATE departments SET name = @name, parent_id = @parentId WHERE id = @id", connection))
                {
                    command.Parameters.AddWithValue("id", id);
                    command.Parameters.AddWithValue("name", department.Name);
                    command.Parameters.AddWithValue("parentId", department.ParentId ?? (object)DBNull.Value);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task DeleteDepartmentAsync(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                await connection.OpenAsync();
                using (var command = new NpgsqlCommand("DELETE FROM departments WHERE id = @id", connection))
                {
                    command.Parameters.AddWithValue("id", id);
                    await command.ExecuteNonQueryAsync();
                }
            }
        }

        public async Task<IEnumerable<Department>> GetSubDepartmentsAsync(int id)
        {
            using (var connection = new NpgsqlConnection(_connectionString))
            {
                var departments = new List<Department>();
                var command = new NpgsqlCommand("SELECT * FROM Departments WHERE parent_id = @id", connection);
                command.Parameters.AddWithValue("id", id);

                await connection.OpenAsync();
                var reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    departments.Add(new Department()
                    {
                        Id = reader.GetInt32(0),
                        Name = reader.GetString(1),
                        ParentId = reader.IsDBNull(2) ? (int?)null : reader.GetInt32(2)
                    });
                }
                await connection.CloseAsync();

                return departments;
            }
        }
    }
}
