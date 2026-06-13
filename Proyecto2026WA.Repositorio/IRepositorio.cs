namespace Proyecto2026WA.Repositorio
{
    public interface IRepositorio<E>
    {
        Task<List<E>> Select();
    }
}