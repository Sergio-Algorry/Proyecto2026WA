using Microsoft.AspNetCore.Mvc;

namespace Proyecto2026WA.Server.Controllers
{
    [ApiController]
    [Route("api/pais")]
    public class PaisController : ControllerBase
    {
        [HttpGet]
        public string Get()
        {
            return "Hola desde el controlador de País";
        }
    }
}
