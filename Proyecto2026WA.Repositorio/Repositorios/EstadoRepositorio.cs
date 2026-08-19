using Proyecto2026WA.BD.Datos;
using Proyecto2026WA.BD.Datos.Entity;
using Proyecto2026WA.Shared.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto2026WA.Repositorio.Repositorios
{
    public class EstadoRepositorio : Repositorio<Estado>, IEstadoRepositorio
    {
        private readonly AppDbContext context;

        public EstadoRepositorio(AppDbContext context) : base(context)
        {
            this.context = context;
        }
    }

}
