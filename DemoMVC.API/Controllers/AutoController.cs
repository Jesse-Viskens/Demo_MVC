using DemoMVC.BLL.Services.Auto;
using DemoMVC.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace DemoMVC.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AutoController : ControllerBase
    {
        private readonly IAutoService _autoService;
        public AutoController(IAutoService autoService)
        {
            _autoService = autoService;
        }
        // GET: api/<AutoController>
   
        [HttpGet]
        public List<AutoModel> Get()
        {
            try
            {
                return _autoService.GetAllAutos();
            }
            catch (Exception e)
            {
                var error = e.Message;
                //logger.log(error);
                NotFound();
                throw;
            }
        }

        // GET api/<AutoController>/5
        [HttpGet("{id}")]
        public AutoModel Get(int id)
        {
            return _autoService.GetAutoByID(id);
        }

        // POST api/<AutoController>
        [HttpPost]
        public AutoModel Post([FromBody] AutoModel auto)
        {
           return _autoService.AddAuto(auto);
        }

        // PUT api/<AutoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<AutoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
