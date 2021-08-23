using DemoMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DemoMVC.Data
{
    public class VoertuigDbContext:IdentityDbContext<Customer>
    {
        public VoertuigDbContext(DbContextOptions<VoertuigDbContext> options): base(options)
        {

        }
        public DbSet<AutoModel> Autos { get; set; }
        
    }
}
