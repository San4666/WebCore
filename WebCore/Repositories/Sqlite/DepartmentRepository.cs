using System;
using System.Data.Common;
using Microsoft.Extensions.Configuration;
using WebCore.Entities;

namespace WebCore.Repositories.Sqlite
{
    public class DepartmentRepository : BaseRepository<Department>, IDepartmentRepository
    {
        protected override string TableName => "Departments";

        public DepartmentRepository(IConfiguration configuration) : base(configuration)
        {
        }

        public override void Insert(Department entity)
        {
            throw new NotImplementedException();
        }

        public override void Update(Department entity)
        {
            throw new NotImplementedException();
        }

        protected override Department Parser(DbDataReader reader)
        {
            return new Department()
            {
                Id = Convert.ToInt32(reader["Id"]),
                Name = reader["Name"].ToString()
            };
        }
    }
}