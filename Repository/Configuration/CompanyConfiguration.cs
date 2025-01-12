

using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class CompanyConfiguration : IEntityTypeConfiguration<Company>
    {
        public void Configure(EntityTypeBuilder<Company> builder)
        {
            builder.HasData
            (
                new Company
                {
                    CompanyGuid = new Guid("c9d4c053-49b0-4a8c-8e0d-3b5f5f6f6f9b"),
                    CompanyName = "IT Solutions Ltd",
                    CompanyAddress = "583 Wall Dr. Gwynn Oak, MD 21207",
                    Country = "United States"
                },
                new Company
                {
                    CompanyGuid = new Guid("d8e506f1-1d3f-4b3f-8f0a-2f3f6f6f6f9b"),
                    CompanyName = "Admin Solutions Ltd",
                    CompanyAddress = "312 Forest Avenue, BF 923",
                    Country = "United States"
                }
            );
        }
    }
}
