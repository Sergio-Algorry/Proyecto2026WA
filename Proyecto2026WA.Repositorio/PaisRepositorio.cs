using Microsoft.Identity.Client;
using Proyecto2026WA.BD.Datos;
using Proyecto2026WA.BD.Datos.Entity;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace Proyecto2026WA.Repositorio
{
    public class PaisRepositorio : Repositorio<Pais>, IPaisRepositorio
    {
        public PaisRepositorio(AppDbContext context) : base(context)
        {
    
        }
    }
}
