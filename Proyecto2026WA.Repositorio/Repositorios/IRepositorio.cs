namespace Proyecto2026WA.Repositorio.Repositorios
{
    public interface IRepositorio<E> where E : class
    {
        Task<List<E>> Select();
    }
}