using Proyecto2026WA.BD.Datos;
using Proyecto2026WA.BD.Datos.Entity;
using Proyecto2026WA.Shared.DTO;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto2026WA.Repositorio.Repositorios
{
    public class PEPE : Repositorio<Pais>, IPaisRepositorio
    {
        private readonly AppDbContext context;

        public PEPE(AppDbContext context) : base(context)
        {
            this.context = context;
        }

        public async Task<List<PaisListadoDTO>> ListaPais()
        {
            var lista = await
            context.Paises
                        .Select(p => new PaisListadoDTO
                        {
                            Id = p.Id,
                            DatosPais = $"{p.Codigo} - {p.Nombre}"
                        })
                        .ToListAsync();
            return lista;
        }
    }
}
