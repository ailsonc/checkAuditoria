using System;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using CheckTesteAuditoria.Model.Response;
using CheckTesteAuditoria.Model.Request;
using DllCheckTesteAuditorialog;

namespace CheckTesteAuditoria.Services
{
    class HistoricoService
    {
        public static async Task<bool> SetHistoricoAuditoria(HistoricoRequest historicoRequest)
        {
            try
            {
                HistoricoResponse historicoResponse;

                using (HttpClient httpClient = new HttpClient())
                {
                    string jsonContent = JsonConvert.SerializeObject(historicoRequest);
                    HttpContent content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await httpClient.PostAsync($"{Constantes.URLPROD}api/historico/auditoria", content);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        historicoResponse = JsonConvert.DeserializeObject<HistoricoResponse>(responseContent);
                        return historicoResponse.message.Equals("success") ? true : false; ;
                    }
                    else
                    {
                        Log.LogError($"Erro na requisição: {response.StatusCode}");
                        throw new InvalidOperationException($"Erro na requisição: {response.StatusCode}");
                    }
                }
            }
            catch (Exception e)
            {
                Log.LogError($"Message :{e.Message} ");
                throw new InvalidOperationException(e.Message);
            }
        }

        public static async Task<bool> SetHistoricoMacAddress(HistoricoMacAddressRequest historicoMacAddressRequest)
        {
            try
            {
                GenericResponse genericResponse;

                using (HttpClient httpClient = new HttpClient())
                {
                    string jsonContent = JsonConvert.SerializeObject(historicoMacAddressRequest);
                    HttpContent content = new StringContent(jsonContent, System.Text.Encoding.UTF8, "application/json");
                    HttpResponseMessage response = await httpClient.PostAsync($"{Constantes.URLPROD}api/historico/macaddress", content);

                    if (response.IsSuccessStatusCode)
                    {
                        string responseContent = await response.Content.ReadAsStringAsync();
                        genericResponse = JsonConvert.DeserializeObject<GenericResponse>(responseContent);
                        return genericResponse.message.Equals("success") ? true : false; ;
                    }
                    else
                    {
                        Log.LogError($"Erro na requisição: {response.StatusCode}");
                        throw new InvalidOperationException($"Erro na requisição: {response.StatusCode}");
                    }
                }
            }
            catch (Exception e)
            {
                Log.LogError($"Message :{e.Message} ");
                throw new InvalidOperationException(e.Message);
            }
        }
    }
}
