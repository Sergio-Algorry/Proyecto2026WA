using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Proyecto2026WA.BD.Datos;
using Proyecto2026WA.BD.Datos.Entity;
using Proyecto2026WA.Repositorio.Repositorios;
using Proyecto2026WA.Shared.DTO;

namespace Proyecto2026WA.Server.Controllers
{
    [ApiController]
    [Route("api/estado")]
    public class EstadoController : ControllerBase
    {
        private readonly IEstadoRepositorio repositorio;

        public EstadoController(IEstadoRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        [HttpGet] //api/estado
        public async Task<ActionResult<List<Estado>>> Get()
        {
            var lista = await repositorio.Select();
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

        [HttpGet("{id:int}")]  //api/Estado/5
        public async Task<ActionResult<EstadoDTO>> GetById(int id)
        {
            var entidad = await repositorio.SelectById(id);
            if (entidad is null)
            {
                return NotFound($"No existe el registro con id: {id}.");
            }
            EstadoDTO DTO = new EstadoDTO();
            DTO.Id = entidad.Id;
            DTO.PaisId = entidad.PaisId;
            DTO.Nombre = entidad.Nombre;

            return Ok(DTO);
        }

        [HttpPost] //api/estado
        public async Task<ActionResult<int>> Post(EstadoDTO DTO)
        {
            Estado entidad = new Estado();
            entidad.PaisId = DTO.PaisId;
            entidad.Nombre = DTO.Nombre;

            await repositorio.Insert(entidad);

            return Ok(entidad.Id);
        }

        [HttpPut("{id:int}")] //api/estado/5
        public async Task<ActionResult<bool>> Put(int id, EstadoDTO DTO)
        {
            if (id != DTO.Id)
            {
                return BadRequest("Datos incorrectos, no se actualizó.");
            }
            var entidad = new Estado();
            entidad.Id = DTO.Id;
            entidad.PaisId = DTO.PaisId;
            entidad.Nombre = DTO.Nombre;
            var resultado = await repositorio.Update(entidad);

            return Ok(resultado);
        }

        [HttpDelete("{id:int}")] //api/estado/5
        public async Task<ActionResult<bool>> Delete(int id)
        {
            var resultado = await repositorio.Delete(id);
            if (!resultado)
            {
                return NotFound($"No existe el registro con id: {id}.");
            }

            return Ok(true);
        }

    }
}
