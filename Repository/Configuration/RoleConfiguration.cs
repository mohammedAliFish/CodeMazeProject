

using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Repository.Configuration
{
    public class RoleConfiguration : IEntityTypeConfiguration<IdentityRole>
    {
        public void Configure(EntityTypeBuilder<IdentityRole> builder)
        {
            builder.HasData(
                new IdentityRole 
            {
                    Id = "1f03d8e4-432c-4e72-a1a6-ff1c678b9b72",
                    Name = "Manager",
                NormalizedName = "MANAGER" 
            }, 
            new IdentityRole 
            {
                Id = "2a5b0f91-67a7-44a1-b94f-89d2c12e3c65",
                Name = "Administrator",
                NormalizedName = "ADMINISTRATOR" 
            });
        }
        }
}
