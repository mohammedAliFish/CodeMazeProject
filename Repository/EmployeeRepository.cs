
using Contracts.Interface;
using Entities.Models;

namespace Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }

        public IEnumerable<Employee> GetEmployees(Guid companyId, bool trackChanges) =>
            FindByCondition(e => e.CompanyGuid.Equals(companyId), trackChanges).OrderBy(e => e.EmployeeName).ToList();

        public Employee GetEmployee(Guid companyId, Guid id, bool trackChanges) =>
            FindByCondition(e => e.CompanyGuid.Equals(companyId) && e.EmployeeGuid.Equals(id), trackChanges).SingleOrDefault();

        public void CreateEmployeeForCompany(Guid companyGuid, Employee employee)
        {
            employee.CompanyGuid = companyGuid;
            Create(employee);
        }

        public void DeleteEmployee(Employee employee) => Delete(employee);
    }
    
    
}
