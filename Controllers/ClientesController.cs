using Microsoft.AspNetCore.Mvc;
using NuGet.Packaging.Core;
using PruebaTecnica.Models;
using PruebaTecnica.Repositorios;
using PruebaTecnica.Repositorys;
using PruebaTecnica.ValueObjects;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace PruebaTecnica.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientesController : ControllerBase
    {

        private readonly ClienteRepository _repoCliente;
        private readonly CuentaRepository _repoCuenta;

        public ClientesController(ClienteRepository repoCliente, CuentaRepository repoCuenta)
        {
            _repoCliente = repoCliente;
            _repoCuenta = repoCuenta;
        }

        // POST api/<ClientesController>
        [HttpPost]
        [Route("{cliente}/cuentas")]
        public async Task<ClientesResponse> Post([FromBody]ClientesRequest value)
        {
            var cliente = await _repoCliente.ObtenerClientePorIdAsync(1);
            return new ClientesResponse();
        }

    }
}
