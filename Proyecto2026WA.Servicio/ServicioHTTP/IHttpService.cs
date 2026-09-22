namespace Proyecto2026WA.Servicio.ServicioHTTP
{
    public interface IHttpService
    {
        Task<HttpResp<T>> GetAsync<T>(string url);
    }
}