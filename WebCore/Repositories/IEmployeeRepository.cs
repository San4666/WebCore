using System.Collections.Generic;
using WebCore.Entities;
using WebCore.Models;

namespace WebCore.Repositories
{
    public interface IEmployeeRepository : IBaseRepository<Employee>
    {
        ICollection<Employee> Search(EmployeeSearch search);
    }
}