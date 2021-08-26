using DemoMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DemoMVC.DAL.Data.Repositories.Auto
{
    public class AutoRepository : IAutoRepository
    {
        private readonly VoertuigDbContext _context;
        public AutoRepository(VoertuigDbContext context)
        {
            _context = context;
        }

        //public async Task AddAutoAsync(AutoModel auto)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<AutoModel> GetAllAutosAsync()
        //{
        //    return  _context.Autos;
        //}

        //public async Task<AutoModel> GetAutoByIDAsync(int Id)
        //{
        //    return await _context.Autos.FirstOrDefaultAsync(x => x.Id == Id);
        //}

        //public async Task SaveAsync()
        //{
        //    await _context.SaveChangesAsync();
        //}
        public AutoModel AddAuto(AutoModel auto)
        {
            try
            {
                _context.Autos.Add(auto);
            }
            catch (Exception)
            {

                throw;
            }
            Save();
            return GetAutoByID(auto.Id);
        }

        public IEnumerable<AutoModel> GetAllAutos()
        {
            return _context.Autos;
        }

        public AutoModel GetAutoByID(int Id)
        {
            return _context.Autos.FirstOrDefault(a => a.Id == Id);
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}
