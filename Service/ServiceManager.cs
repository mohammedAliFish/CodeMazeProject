
using Contracts.Interface;
using Repository;
using Service.Contracts;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

using Entities.Models;

namespace Service
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<ICompanyService> _companyService;
        private readonly Lazy<IEmployeeService> _employeeService;
        private readonly Lazy<IAuthenticationService> _authenticationService;
        public ServiceManager(IRepositoryManager repositoryManager, UserManager<User> userManager, ILoggerManager logger, IMapper mapper, IEmployyLinks  employyLinks)
        { 
            _companyService = new Lazy<ICompanyService>(() => new CompanyService(repositoryManager, logger, mapper));
            _employeeService = new Lazy<IEmployeeService>(() => new EmployeeService(repositoryManager, logger, mapper, employyLinks));
            //_authenticationService = new Lazy<IAuthenticationService>(() =>
            //new IAuthenticationService(logger, mapper, userManager, configuration));
        }
        public ICompanyService CompanyService => _companyService.Value;
        public IEmployeeService EmployeeService => _employeeService.Value;
        public IAuthenticationService AuthenticationService => _authenticationService.Value;

    }
}
