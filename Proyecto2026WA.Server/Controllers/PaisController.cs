using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto2026WA.BD.Datos;
using Proyecto2026WA.BD.Datos.Entity;
using Proyecto2026WA.Shared.DTO;

namespace Proyecto2026WA.Server.Controllers
{
    [ApiController]
    [Route("api/pais")]
    public class PaisController : ControllerBase
    {
        private readonly AppDbContext context;

        public PaisController(AppDbContext context)
        {
            this.context = context;
        }

        //[HttpGet] // api/pais
        //public string Get()
        //{
        //    return "Hola desde el controlador de País";
        //}

        [HttpGet] //api/pais
        public async Task<ActionResult<List<Pais>>> Get()
        {
            var lista = await context.Paises.ToListAsync();
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

        [HttpGet("listapais")] //api/pais/listapais
        public async Task<ActionResult<List<PaisListadoDTO>>> ListaPais()
        {
            var lista = await context.Paises
                        .Select(p => new PaisListadoDTO
                        {
                            Id = p.Id,
                            DatosPais = $"{p.Codigo} - {p.Nombre}"
                        })
                        .ToListAsync();

            if (lista == null)
            {
                return NotFound("No se encontro elementos de la lista, VERIFICAR.");
            }
            else if (lista.Count == 0)
            {
                return NotFound("Lista sin registros.");
            }

            return Ok(lista);
        }

        [HttpGet("{id:int}")]  //api/Pais/5
        public async Task<ActionResult<PaisDTO>> GetById(int id)
        {
            var entidad = await context.Paises.FirstOrDefaultAsync(x => x.Id == id);
            if (entidad is null)
            {
                return NotFound($"No existe el registro con id: {id}.");
            }
            PaisDTO DTO = new PaisDTO();
            DTO.Id = entidad.Id;
            DTO.Codigo = entidad.Codigo;
            DTO.Nombre = entidad.Nombre;

            return Ok(DTO);
        }

        [HttpPost] //api/pais
        public async Task<ActionResult<int>> Post(PaisDTO paisDTO)
        {
            Pais entidad = new Pais();
            entidad.Codigo = paisDTO.Codigo;
            entidad.Nombre = paisDTO.Nombre;
            context.Paises.Add(entidad);
            await context.SaveChangesAsync();
            return Ok(entidad.Id);
        }

        [HttpPut("{id:int}")] //api/pais/5
        public async Task<ActionResult<bool>> Put(int id, PaisDTO paisDTO)
        {
            if (id != paisDTO.Id)
            {
                return BadRequest("Datos incorrectos, no se actualizó.");
            }
            var entidad = await context.Paises.FirstOrDefaultAsync(x => x.Id == id);
            if (entidad is null)
            {
                return NotFound($"No existe el registro con id: {id}.");
            }
            entidad.Codigo = paisDTO.Codigo;
            entidad.Nombre = paisDTO.Nombre;
            await context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id:int}")] //api/pais/5
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var entidad = await context.Paises.FirstOrDefaultAsync(x => x.Id == id);
            if (entidad is null)
            {
                return NotFound($"No existe el registro con id: {id}.");
            }
            context.Paises.Remove(entidad);
            await context.SaveChangesAsync();
            return Ok();
        }
    }
}
