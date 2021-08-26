using DemoMVC.Models;
using System.Collections.Generic;

namespace DemoMVC.BLL.Services.Auto
{
    public interface IAutoService
    {
        List<AutoModel> GetAllAutos();
        AutoModel GetAutoByID(int Id);
        AutoModel AddAuto(AutoModel auto);
    }
}
