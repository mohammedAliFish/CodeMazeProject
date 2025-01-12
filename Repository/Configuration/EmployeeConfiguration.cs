using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class EmployeeConfiguration : IEntityTypeConfiguration<Employee> 
    {
        public void Configure(EntityTypeBuilder<Employee> builder) 
        {
            builder.HasData(
                new Employee
                {
                    EmployeeGuid = new Guid("80abbca8-664d-4b20-b5de-024705497d4a"),
                    EmployeeName = "Sam Raiden",
                    EmployeeAge = 26,
                    EmployeePosition = "Software developer",
                    CompanyGuid = new Guid("c9d4c053-49b0-4a8c-8e0d-3b5f5f6f6f9b")
                },
                new Employee
                {
                    EmployeeGuid = new Guid("86dba8c0-d178-41e7-938c-ed49778fb52a"),
                    EmployeeName = "Jana McLeaf",
                    EmployeeAge = 30,
                    EmployeePosition = "Software developer",
                    CompanyGuid = new Guid("c9d4c053-49b0-4a8c-8e0d-3b5f5f6f6f9b")
                },
                new Employee
                {
                    EmployeeGuid = new Guid("021ca3c1-0deb-4afd-ae94-2159a8479811"),
                    EmployeeName = "Kane Miller",
                    EmployeeAge = 35,
                    EmployeePosition = "Administrator",
                    CompanyGuid = new Guid("d8e506f1-1d3f-4b3f-8f0a-2f3f6f6f6f9b")
                }
            );
        }
    }
}
