using System.Collections.Generic;
using Store.Core.EntityLayer.HumanResources;

namespace Store.Core.DataLayer.Contracts
{
    public interface IHumanResourcesRepository
	{
		IEnumerable<Employee> GetEmployees();

		Employee GetEmployee(Employee entity);

		void AddEmployee(Employee entity);

		void UpdateEmployee(Employee changes);

		void DeleteEmployee(Employee entity);
	}
}
