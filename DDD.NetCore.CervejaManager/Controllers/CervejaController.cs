using DDD.NetCore.Application.DTO;
using DDD.NetCore.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DDD.NetCore.CervejaManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CervejaController : ControllerBase
    {
        private readonly ICervejaAppService _cervejaAppService;

        public CervejaController(ICervejaAppService cervejaAppService)
        {
            this._cervejaAppService = cervejaAppService;
        }
        // GET: api/Cerveja
        [HttpGet]
        public IEnumerable<CervejaDTO> Get()
        {
            return _cervejaAppService.GetAll();
        }

        // GET: api/Cerveja/5
        [HttpGet("{id}")]
        public CervejaDTO Get(int id)
        {
            return _cervejaAppService.GetById(id);
        }

        // POST: api/Cerveja
        [HttpPost]
        public void Post([FromBody] CervejaDTO cerveja)
        {
            _cervejaAppService.Add(cerveja);
        }

        // PUT: api/Cerveja/5
        [HttpPut("{id}")]
        public void Put([FromBody] CervejaDTO cerveja)
        {
            _cervejaAppService.Update(cerveja);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _cervejaAppService.Remove(id);
        }
    }
}
