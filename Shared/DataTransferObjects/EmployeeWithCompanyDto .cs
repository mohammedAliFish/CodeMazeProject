
namespace Shared.DataTransferObjects
{
    public record EmployeeWithCompanyDto
    {
        public Guid EmployeeGuid { get; init; }
        public string EmployeeName { get; init; }
        public int EmployeeAge { get; init; }
        public string EmployeePosition { get; init; }
        public string CompanyName { get; init; }
    }
}
