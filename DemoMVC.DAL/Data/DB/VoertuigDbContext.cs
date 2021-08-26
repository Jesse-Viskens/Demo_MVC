using DemoMVC.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace DemoMVC.DAL.Data
{
    public class VoertuigDbContext:IdentityDbContext<IdentityUser>
    {
        public VoertuigDbContext(DbContextOptions<VoertuigDbContext> options): base(options)
        {

        }
        public DbSet<AutoModel> Autos { get; set; }
        
    }
}
