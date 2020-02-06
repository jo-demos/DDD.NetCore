using DDD.NetCore.Application.DTO;
using DDD.NetCore.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DDD.NetCore.CervejaManager.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RevendedorController : ControllerBase
    {
        private readonly IRevendedorAppService _revendedorAppService;

        public RevendedorController(IRevendedorAppService revendedorAppService)
        {
            this._revendedorAppService = revendedorAppService;
        }
        // GET: api/Revendedor
        [HttpGet]
        public IEnumerable<RevendedorDTO> Get()
        {
            return _revendedorAppService.GetAll();
        }

        // GET: api/Revendedor/5
        [HttpGet("{id}")]
        public RevendedorDTO Get(int id)
        {
            return _revendedorAppService.GetById(id);
        }

        // POST: api/Revendedor
        [HttpPost]
        public void Post([FromBody] RevendedorDTO revendedor)
        {
            _revendedorAppService.Add(revendedor);
        }

        // PUT: api/Revendedor/5
        [HttpPut("{id}")]
        public void Put([FromBody] RevendedorDTO revendedor)
        {
            _revendedorAppService.Update(revendedor);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            _revendedorAppService.Remove(id);
        }
    }
}
