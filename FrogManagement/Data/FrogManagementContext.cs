using FrogManagement.Data;
using FrogManagement.Data.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace FrogManagement.Data
{
    public class FrogManagementContext(DbContextOptions<FrogManagementContext> options) : IdentityDbContext<FrogManagementUser>(options)
    {
        public DbSet<Frog> Frogs { get; set; }

    }
}
