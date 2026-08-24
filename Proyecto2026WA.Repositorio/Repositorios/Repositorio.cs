using Proyecto2026WA.BD.Datos;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Proyecto2026WA.Shared.DTO;

namespace Proyecto2026WA.Repositorio.Repositorios
{
    public class Repositorio<E> : IRepositorio<E> where E : class, IEntityBase
    {
        private readonly AppDbContext context;

        public Repositorio(AppDbContext context)
        {
            this.context = context;
        }

        //existe
        public async Task<bool> Existe(E entity)
        {
            try
            {
                return await context.Set<E>().AnyAsync(e => e == entity);
            }
            catch (Exception e)
            {
                throw;
            }
        }

        //select
        public async Task<List<E>> Select()
        {
            return await context.Set<E>().ToListAsync();
        }

        public async Task<E?> SelectById(int id)
        {
            return await context.Set<E>().FirstOrDefaultAsync(e => e.Id == id);
        }

        //insert
        public async Task<E> Insert(E entity)
        {
            try
            {
                await context.Set<E>().AddAsync(entity);
                await context.SaveChangesAsync();
                return entity;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        //update
        public async Task<bool> Update(E entity)
        {
            try
            {
                bool existe = await context.Set<E>().AnyAsync(e => e == entity);
                if (!existe)
                {
                    return false;
                }
                else
                {
                    context.Set<E>().Update(entity);
                    await context.SaveChangesAsync();
                }
                return true;
            }
            catch (Exception e)
            {
                throw;
            }
        }

        //delete
        public async Task<bool> Delete(int id)
        {
            var entidad = await context.Set<E>().FirstOrDefaultAsync(x => x.Id == id);
            if (entidad == null)
            {
                return false;
            }
            context.Set<E>().Remove(entidad);
            await context.SaveChangesAsync();
            return true;
        }

        public Task<EstadoResumenDTO?> SelectByCodigo(string codigo)
        {
            throw new NotImplementedException();
        }
    }
}
