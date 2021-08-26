using DemoMVC.DAL.Data.Repositories.Auto;
using DemoMVC.Models;
using System.Collections.Generic;
using System.Linq;

namespace DemoMVC.BLL.Services.Auto
{
    public class AutoService : IAutoService
    {
        private readonly IAutoRepository _autoRepository;
        public AutoService(IAutoRepository autoRepository)
        {
            _autoRepository = autoRepository;
        }

        public AutoModel AddAuto(AutoModel auto)
        {
            var autoToCheck=  _autoRepository.AddAuto(auto);
            return _autoRepository.GetAutoByID(autoToCheck.Id);
        }

        public List<AutoModel> GetAllAutos()
        {
            return _autoRepository.GetAllAutos().ToList();
        }

        public AutoModel GetAutoByID(int Id)
        {
            return _autoRepository.GetAutoByID(Id);
        }
    }
}
