using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto2026WA.BD.Datos;
using Proyecto2026WA.BD.Datos.Entity;

namespace Proyecto2026WA.Server.Controllers
{
    [ApiController]
    [Route("api/estado")]
    public class EstadoController : ControllerBase
    {
        private readonly AppDbContext context;

        public EstadoController(AppDbContext context)
        {
            this.context = context;
        }

        [HttpGet] //api/estado
        public async Task<ActionResult<List<Estado>>> Get()
        {
            var lista = await context.Set<Estado>().ToListAsync();
            if (lista == null)
            {
                return NotFound("No se encontro elementos de la lista, VERIFICAR.");
            }
            else if (lista.Count == 0)
            {
                return Ok("Lista sin registros.");
            }

            return Ok(lista);
        }

    }
}
