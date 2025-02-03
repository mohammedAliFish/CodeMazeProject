
using Entities.Models;
using Shared.RequestFeatures;
namespace Contracts.Interface
{
    public interface IEmployeeRepository
    {
        Task<PagedList<Employee>> GetEmployeesAsync(Guid companyId,
    EmployeeParameters employeeParameters, bool trackChanges);
        Employee GetEmployee(Guid companyId, Guid id, bool trackChanges);
        Task<Employee> GetEmployeeAsync(Guid companyId, Guid id, bool trackChanges);
        void CreateEmployeeForCompany(Guid companyId, Employee employee);

        IEnumerable<Employee> GetAllEmployees(bool trackChanges);
        void DeleteEmployee(Employee employee);
    }
}
