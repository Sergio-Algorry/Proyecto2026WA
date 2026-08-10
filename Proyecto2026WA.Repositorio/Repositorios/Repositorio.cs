using Proyecto2026WA.BD.Datos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Proyecto2026WA.Repositorio.Repositorios
{
    public class Repositorio<E> : IRepositorio<E> where E : class
    {
        private readonly AppDbContext context;

        public Repositorio(AppDbContext context)
        {
            this.context = context;
        }
        //existe

        //select
        public async Task<List<E>> Select()
        {
            return await context.Set<E>().ToListAsync();
        }
        //insert
        //update
        //delete
    }
}
