using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging.Core;
using PruebaTecnica.Models;
using PruebaTecnica.ValueObjects;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {
      
        // POST api/<ClientesController>
        [HttpPost]
        public async Task<ClientesResponse> Post([FromBody]ClientesRequest value)
        {
            return new ClientesResponse();
        }

    }
}
