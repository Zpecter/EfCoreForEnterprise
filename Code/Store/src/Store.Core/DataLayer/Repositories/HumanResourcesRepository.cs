using System.Collections.Generic;
using System.Linq;
using Store.Core.DataLayer.Contracts;
using Store.Core.EntityLayer.HumanResources;

namespace Store.Core.DataLayer.Repositories
{
    public class HumanResourcesRepository : Repository, IHumanResourcesRepository
    {
        public HumanResourcesRepository(UserInfo userInfo, StoreDbContext dbContext)
            : base(userInfo, dbContext)
        {
        }

        public IEnumerable<Employee> GetEmployees()
        {
            return DbContext.Set<Employee>();
        }

        public Employee GetEmployee(Employee entity)
        {
            return DbContext.Set<Employee>().FirstOrDefault(item => item.EmployeeID == entity.EmployeeID);
        }

        public void AddEmployee(Employee entity)
        {
            DbContext.Set<Employee>().Add(entity);

            DbContext.SaveChanges();
        }

        public void UpdateEmployee(Employee changes)
        {
            var entity = GetEmployee(changes);

            if (entity != null)
            {
                entity.FirstName = changes.FirstName;
                entity.MiddleName = changes.MiddleName;
                entity.LastName = changes.LastName;
                entity.BirthDate = changes.BirthDate;

                DbContext.SaveChanges();
            }
        }

        public void DeleteEmployee(Employee entity)
        {
            DbContext.Set<Employee>().Remove(entity);

            DbContext.SaveChanges();
        }
    }
}
