using DemoMVC.Models;
using System.Collections.Generic;

namespace DemoMVC.DAL.Data.Repositories.Auto
{
    public interface IAutoRepository
    {
        IEnumerable<AutoModel> GetAllAutos();
        AutoModel GetAutoByID(int Id);
        AutoModel AddAuto(AutoModel auto);
        void Save();
    }
}
