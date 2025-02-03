
using Contracts.Interface;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Shared.RequestFeatures;

namespace Repository
{
    public class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
        {
        }




        public async Task<PagedList<Employee>> GetEmployeesAsync(Guid companyId,EmployeeParameters employeeParameters, bool trackChanges)
        {
            var employees = await FindByCondition(e => e.CompanyGuid.Equals(companyId), trackChanges)
                .OrderBy(e => e.EmployeeName)
                .ToListAsync();

            return PagedList<Employee>
                .ToPagedList(employees, employeeParameters.PageNumber, employeeParameters.PageSize);
        }





        public async Task<Employee> GetEmployeeAsync(Guid companyId, Guid id, bool trackChanges) =>
        await FindByCondition(e => e.CompanyGuid.Equals(companyId) && e.EmployeeGuid.Equals(id), trackChanges)
        .SingleOrDefaultAsync();





        public Employee GetEmployee(Guid companyId, Guid id, bool trackChanges) =>
            FindByCondition(e => e.CompanyGuid.Equals(companyId) && e.EmployeeGuid.Equals(id), trackChanges).SingleOrDefault();






        public void CreateEmployeeForCompany(Guid companyGuid, Employee employee)
        {
            employee.CompanyGuid = companyGuid;
            Create(employee);
        }





        public IEnumerable<Employee> GetAllEmployees(bool trackChanges) =>
           FindAll(trackChanges).OrderBy(e => e.EmployeeName).ToList();
        public void DeleteEmployee(Employee employee) => Delete(employee);
    }
    
    
}
