using DemoMVC.DAL.Data;
using DemoMVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace DemoMVC.Data
{
    public class DbInitializer
    {
        public static void Seed(VoertuigDbContext context)
        {
            context.Database.EnsureCreated();

            if (context.Autos.Any())
            {
                return;
            }
            var AutoList = new List<AutoModel>()
            {
                new AutoModel {KilometerStand=12000,Merk="Skoda",Type="Octavia"},
                new AutoModel {KilometerStand=12345,Merk="Volkswagen",Type="Golf"},
                new AutoModel {KilometerStand=45000,Merk="Tesla",Type="Model T"}
            };
            foreach(var auto in AutoList)
            {
                context.Autos.Add(auto);
            }
            context.SaveChanges();

        }
    }
}
