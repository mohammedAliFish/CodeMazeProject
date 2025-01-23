﻿
using AutoMapper;
using Contracts.Interface;
using Entities.Exceptions;
using Repository;
using Service.Contracts;
using Shared.DataTransferObjects;
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

        public IEnumerable<EmployeeDto> GetEmployees(Guid companyId, bool trackChanges)
        {
            var company = _repository.Company.GetCompany(companyId, trackChanges);

            if (company is null)
                throw new CompanyNotFoundException(companyId);

            var employeesFromDb = _repository.Employee.GetEmployees(companyId, trackChanges);
            var employeesDto = _mapper.Map<IEnumerable<EmployeeDto>>(employeesFromDb);
            return employeesDto;
        }

        public EmployeeDto GetEmployee(Guid companyId, Guid id, bool trackChanges)
        {
            
            ValidateCompanyExists(companyId, trackChanges);

          
            var employeeDb = _repository.Employee.GetEmployee(companyId, id, trackChanges)
                ?? throw new EmployeeNotFoundException(id);

           
            return _mapper.Map<EmployeeDto>(employeeDb);
        }

        private void ValidateCompanyExists(Guid companyId, bool trackChanges)
        {
            var companyExists = _repository.Company.GetCompany(companyId, trackChanges) != null;
            if (!companyExists)
                throw new CompanyNotFoundException(companyId);
        }

    }
}
