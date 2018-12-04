using System;
using System.Collections.Generic;
using System.Data.Common;
using Microsoft.Data.Sqlite;
using Microsoft.Extensions.Configuration;
using WebCore.Entities;
using WebCore.Models;

namespace WebCore.Repositories.Sqlite
{
    public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(IConfiguration configuration) : base(configuration)
        {
        }

        protected override string TableName => "Employees";

        protected override Employee Parser(DbDataReader reader)
        {
            var languageId = Convert.ToInt32(reader["LanguageId"]);
            var departmentId = Convert.ToInt32(reader["DepartmentId"]);

            return new Employee()
            {
                Id = Convert.ToInt32(reader["Id"]),
                Age = Convert.ToInt16(reader["Age"]),
                LastName = reader["LastName"].ToString(),
                FirstName = reader["FirstName"].ToString(),
                DepartmentId = departmentId,
                LanguageId = languageId,
            };
        }

        public override void Insert(Employee entity)
        {
            using (var connect = new SqliteConnection(ConnectionString))
            {
                connect.Open();

                var command = connect.CreateCommand();
                command.CommandText =
                    $"INSERT INTO {TableName} (Age, LastName, FirstName, DepartmentId, LanguageId) values(@Age, @LastName, @FirstName, @DepartmentId, @LanguageId)";
                command.Parameters.Add(new SqliteParameter("@Age", entity.Age));
                command.Parameters.Add(new SqliteParameter("@LastName", entity.LastName));
                command.Parameters.Add(new SqliteParameter("@FirstName", entity.FirstName));
                command.Parameters.Add(new SqliteParameter("@DepartmentId", entity.DepartmentId));
                command.Parameters.Add(new SqliteParameter("@LanguageId", entity.LanguageId));

                command.ExecuteNonQuery();
            }
        }

        public override void Update(Employee entity)
        {
            using (var connect = new SqliteConnection(ConnectionString))
            {
                connect.Open();

                var command = connect.CreateCommand();
                command.CommandText =
                    $"UPDATE {TableName} SET Age = @Age, LastName = @LastName, FIrstName = @FirstName, DepartmentId = @DepartmentId, LanguageId = @LanguageId WHERE Id = @Id";
                command.Parameters.Add(new SqliteParameter("@Age", entity.Age));
                command.Parameters.Add(new SqliteParameter("@LastName", entity.LastName));
                command.Parameters.Add(new SqliteParameter("@FirstName", entity.FirstName));
                command.Parameters.Add(new SqliteParameter("@DepartmentId", entity.DepartmentId));
                command.Parameters.Add(new SqliteParameter("@LanguageId", entity.LanguageId));
                command.Parameters.Add(new SqliteParameter("@Id", entity.Id));
                
                command.ExecuteNonQuery();
            }
        }

        public ICollection<Employee> Search(EmployeeSearch search)
        {
            if (string.IsNullOrEmpty(search.LikeFirstName))
            {
                return All();
            }

            using (var connect = new SqliteConnection(ConnectionString))
            {
                connect.Open();
                var command = connect.CreateCommand();
                command.CommandText = $"SELECT * FROM {TableName} WHERE FirstName LIKE @LikeFirstName ";
                command.Parameters.Add(new SqliteParameter("@LikeFirstName", search.LikeFirstName + "%"));

                return ExecuteRead(command);
            }
        }
    }
}