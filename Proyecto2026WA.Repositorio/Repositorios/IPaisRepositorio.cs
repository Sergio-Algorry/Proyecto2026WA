using Proyecto2026WA.BD.Datos.Entity;
using Proyecto2026WA.Shared.DTO;

namespace Proyecto2026WA.Repositorio.Repositorios
{
    public interface IPaisRepositorio : IRepositorio<Pais>
    {
        Task<List<PaisListadoDTO>> ListaPais();
    }
}