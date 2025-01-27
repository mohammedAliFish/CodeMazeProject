
namespace Shared.DataTransferObjects
{
    public record class CompanyForUpdateDto(string CompanyName, string CompanyAddress, string Country, 
        IEnumerable<EmployeeForCreationDto> Employees);
}
