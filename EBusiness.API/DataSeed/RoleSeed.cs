using EBusiness.API.Server.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EBusiness.API.DataSeed;

public class RoleSeed : IEntityTypeConfiguration<IdentityRole>
{
    public void Configure(EntityTypeBuilder<IdentityRole> builder)
    {
        builder.HasData(
            new IdentityRole { Id = "d6s9043f-3924-4589-05fq-1i94ed3ddc31", Name = "Admin", NormalizedName = "ADMIN" },
            new IdentityRole { Id = "d6s9043f-3924-4589-05fq-1i94ed3ddc32", Name = "User", NormalizedName = "USER" },
            new IdentityRole { Id = "d6s9043f-3924-4589-05fq-1i94ed3dd3f3", Name = "Manager", NormalizedName = "MANAGER"},
            new IdentityRole { Id = "d6s9043f-3924-4589-05fq-1i94ed3dc3f4", Name = "SuperAdmin", NormalizedName = "SUPERADMIN" },
            new IdentityRole { Id = "d6s9043f-3924-4589-05fq-1i94d3ddc3f5", Name = "Cashier", NormalizedName = "CASHIER" }

        );
    }
}
