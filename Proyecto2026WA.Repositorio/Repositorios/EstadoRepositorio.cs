using Proyecto2026WA.BD.Datos;
using Proyecto2026WA.BD.Datos.Entity;
using Proyecto2026WA.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace Proyecto2026WA.Repositorio.Repositorios
{
    public class EstadoRepositorio : Repositorio<Estado>, IEstadoRepositorio
    {
        private readonly AppDbContext context;

        public EstadoRepositorio(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<EstadoResumenDTO?> SelectByCodigo(string codigo)
        {
            var entidad = await context.Estados.Where(x => x.Codigo == codigo)
                .Select(e => new EstadoResumenDTO
                {
                    Codigo = e.Codigo,
                    Nombre = e.Nombre,
                    NombrePais = e.Pais.Nombre
                })
                .FirstOrDefaultAsync();
            return entidad;
        }

        public async Task<EstadoCompletoDTO?> SelectByIdCompleto(int id)
        {
            var entidad = await context.Estados
                .Include(p => p.Pais)
                .FirstOrDefaultAsync(x => x.Id == id);
            var DTO = new EstadoCompletoDTO();
            DTO.Id = entidad.Id;
            DTO.Codigo = entidad.Codigo;
            DTO.Nombre = entidad.Nombre;
            DTO.PaisId = entidad.PaisId;
            DTO.Pais= new PaisDTO 
                { 
                    Id = entidad.Pais.Id, 
                    Nombre = entidad.Pais.Nombre, 
                    Codigo = entidad.Pais.Codigo 
                };


            return DTO;
        }
    }
}
