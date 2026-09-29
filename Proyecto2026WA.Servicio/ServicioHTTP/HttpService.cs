using System;
using System.Collections.Generic;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;

namespace Proyecto2026WA.Servicio.ServicioHTTP
{
    public class HttpService : IHttpService
    {
        private readonly HttpClient http;

        public HttpService(HttpClient http)
        {
            this.http = http;
        }

        public async Task<HttpResp<T?>> GetAsync<T>(string url)
        {
            try
            {
                var response = await http.GetAsync(url);
                if (!response.IsSuccessStatusCode)
                {
                    return new HttpResp<T?>(default, true, response, null);
                }

                var dato = await response.Content.ReadFromJsonAsync<T>();

                return new HttpResp<T?>(dato, false, response, null);

            }
            catch (Exception e)
            {
                return new HttpResp<T?>(default, true, null, e.Message);
            }

        }

        public async Task<HttpResp<TResp?>> PostAsync<T, TResp>(string url, T DTO)
        {
            try
            {
                var JsonEnviar = JsonSerializer.Serialize(DTO);
                var cuerpo = new StringContent(JsonEnviar, Encoding.UTF8, "application/json");

                var response = await http.PostAsync(url, cuerpo);
                if (!response.IsSuccessStatusCode)
                {
                    return new HttpResp<TResp?>(default, true, response, null);
                }
                else
                {
                    var dato = await response.Content.ReadFromJsonAsync<TResp>();
                    return new HttpResp<TResp?>(dato, false, response, null);
                }
            }
            catch (Exception e)
            {
                return new HttpResp<TResp?>(default, true, null, e.Message);
            }
        }

        public async Task<HttpResp<TResp?>> PutAsync<T, TResp>(string url, T DTO)
        {
            try
            {
                var JsonEnviar = JsonSerializer.Serialize(DTO);
                var cuerpo = new StringContent(JsonEnviar,
                                               Encoding.UTF8,
                                               "application/json");

                var response = await http.PutAsync(url, cuerpo);
                if (!response.IsSuccessStatusCode)
                {
                    return new HttpResp<TResp?>(default, true, response, null);
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var dato = DesSerializar<TResp>(content);

                    //var dato = await response.Content.ReadFromJsonAsync<TResp>();
                    return new HttpResp<TResp?>(dato, false, response, null);
                }
            }
            catch (Exception e)
            {
                return new HttpResp<TResp?>(default, true, null, e.Message);
                //+ " " + e.InnerException?.Message 
                //+ " " + e.StackTrace);
            }
        }

        public async Task<HttpResp<TResp?>> DeleteAsync<TResp>(string url)
        {
            try
            {
                var response = await http.DeleteAsync(url);
                if (!response.IsSuccessStatusCode)
                {
                    return new HttpResp<TResp?>(default, true, response, null);
                }
                else
                {
                    var content = await response.Content.ReadAsStringAsync();
                    var dato = DesSerializar<TResp>(content);
                    //var dato = await response.Content.ReadFromJsonAsync<TResp>();
                    return new HttpResp<TResp?>(dato, false, response, null);
                }
            }
            catch (Exception e)
            {
                return new HttpResp<TResp?>(default, true, null, e.Message);
            }
        }
        private T? DesSerializar<T>(string content)
        {
            return JsonSerializer.Deserialize<T>(content,
                                                new JsonSerializerOptions
                                                {
                                                    PropertyNameCaseInsensitive = true
                                                });
        }
    }
}
