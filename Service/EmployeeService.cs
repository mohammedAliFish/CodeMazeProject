
using AutoMapper;
using Contracts.Interface;
using Entities.Exceptions;
using Entities.Models;
using Repository;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;
namespace Service
{
    internal sealed class EmployeeService : IEmployeeService
    {
        private readonly IRepositoryManager _repository;
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        public EmployeeService(IRepositoryManager repository, ILoggerManager logger , IMapper mapper)
        {
            _repository = repository;
            _logger = logger;
            _mapper = mapper;
        }

        public async Task<(IEnumerable<EmployeeDto> employees, MetaData metaData)> GetEmployeesAsync
          (Guid companyId, EmployeeParameters employeeParameters, bool trackChanges)
        {
            await CheckIfCompanyExists(companyId, trackChanges);

            var employeesWithMetaData = await _repository.Employee
                .GetEmployeesAsync(companyId, employeeParameters, trackChanges);
            var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employeesWithMetaData);

            return (employees: employeesDto, metaData: employeesWithMetaData.MetaData);
        }
        public async Task<EmployeeDto> GetEmployeeAsync(Guid companyId, Guid id, bool trackChanges)
        {
            await CheckIfCompanyExists(companyId, trackChanges);

            var employeeDb = await GetEmployeeForCompanyAndCheckIfItExists(companyId, id, trackChanges);

            var employee = _mapper.Map<EmployeeDto>(employeeDb);
            return employee;
        }
        private async Task<Employee> GetEmployeeForCompanyAndCheckIfItExists
        (Guid companyId, Guid id, bool trackChanges)
        {
            var employeeDb = await _repository.Employee.GetEmployeeAsync(companyId, id, trackChanges);
            if (employeeDb is null)
                throw new EmployeeNotFoundException(id);

            return employeeDb;
        }
        private async Task CheckIfCompanyExists(Guid companyId, bool trackChanges)
	{
		var company = await _repository.Company.GetCompanyAsync(companyId, trackChanges);
		if (company is null)
			throw new CompanyNotFoundException(companyId);
	}
        public EmployeeDto GetEmployee(Guid companyId, Guid id, bool trackChanges)
        {
            
            ValidateCompanyExists(companyId, trackChanges);

          
            var employeeDb = _repository.Employee.GetEmployee(companyId, id, trackChanges)
                ?? throw new EmployeeNotFoundException(id);

           
            return _mapper.Map<EmployeeDto>(employeeDb);
        }
        public IEnumerable<Employee> GetAllEmployees(bool trackChanges)
        {
           
            return _repository.Employee.GetAllEmployees(trackChanges);
        }

        private void ValidateCompanyExists(Guid companyId, bool trackChanges)
        {
            var companyExists = _repository.Company.GetCompanyAsync(companyId, trackChanges) != null;
            if (!companyExists)
                throw new CompanyNotFoundException(companyId);
        }

        public EmployeeDto CreateEmployeeForCompany(Guid companyId, EmployeeForCreationDto employeeForCreation, bool trackChanges)
        {
            var company = _repository.Company.GetCompanyAsync(companyId, trackChanges);
            if (company is null)
                throw new CompanyNotFoundException(companyId);

            var employeeEntity = _mapper.Map<Employee>(employeeForCreation);
          
            _repository.Employee.CreateEmployeeForCompany(companyId, employeeEntity);
            _repository.SaveAsync();

            var employeeToReturn = _mapper.Map<EmployeeDto>(employeeEntity);

            return employeeToReturn;
        }
        public void DeleteEmployeeForCompany(Guid companyId, Guid id, bool trackChanges)
        {
            var company = _repository.Company.GetCompanyAsync(companyId, trackChanges);
            if (company is null)
                throw new CompanyNotFoundException(companyId);

            var employeeForCompany = _repository.Employee.GetEmployee(companyId, id, trackChanges);
            if (employeeForCompany is null)
                throw new EmployeeNotFoundException(id);

            _repository.Employee.DeleteEmployee(employeeForCompany);
            _repository.SaveAsync();
        }
        public IEnumerable<EmployeeWithCompanyDto> GetAllEmployeesWithCompanyNames(bool trackChanges)
        {
            
            var employeesFromDb = _repository.Employee.GetAllEmployees(trackChanges);

            
            var employeesWithCompanyDto = employeesFromDb.Select(e =>
            {
                var company = _repository.Company.GetCompanyAsync(e.CompanyGuid, trackChanges);
                return new EmployeeWithCompanyDto
                {
                    EmployeeGuid = e.EmployeeGuid,
                    EmployeeName = e.EmployeeName,
                    EmployeeAge = e.EmployeeAge,
                    EmployeePosition = e.EmployeePosition,
                   // CompanyName = company?. ?? "Company Not Found"
                };
            });

            return employeesWithCompanyDto;
        }

        public void UpdateEmployeeForCompany(Guid companyId, Guid id, EmployeeForUpdateDto employeeForUpdate, bool compTrackChanges, bool empTrackChanges) 
        { 
            var company = _repository.Company.GetCompanyAsync(companyId, compTrackChanges);
            if (company is null) throw new CompanyNotFoundException(companyId); 
            var employeeEntity = _repository.Employee.GetEmployee(companyId, id, empTrackChanges);
            if (employeeEntity is null) throw new EmployeeNotFoundException(id); 
            _mapper.Map(employeeForUpdate, employeeEntity); _repository.SaveAsync(); 
        }

    }
}
