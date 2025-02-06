
using Entities.Models;
using Microsoft.AspNetCore.Http;
using Shared.DataTransferObjects;

namespace Contracts.Interface
{
    public interface IEmployyLinks
    {
        LinkResponse TryGenerateLinks(IEnumerable<EmployeeDto> employeesDto,
    string fields, Guid companyId, HttpContext httpContext);
    }
}
