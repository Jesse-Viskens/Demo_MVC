using DemoMVC.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DemoMVC.Data
{
    public class VoertuigDbContext:DbContext
    {
        public VoertuigDbContext(DbContextOptions<VoertuigDbContext> options): base(options)
        {

        }
        public DbSet<AutoModel> Autos { get; set; }
        
    }
}
