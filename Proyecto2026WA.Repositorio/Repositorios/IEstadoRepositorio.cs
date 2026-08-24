using Proyecto2026WA.BD.Datos.Entity;
using Proyecto2026WA.Shared.DTO;

namespace Proyecto2026WA.Repositorio.Repositorios
{
    public interface IEstadoRepositorio : IRepositorio<Estado>
    {
        Task<EstadoResumenDTO?> SelectByCodigo(string codigo);
        Task<EstadoCompletoDTO?> SelectByIdCompleto(int id);
    }
}