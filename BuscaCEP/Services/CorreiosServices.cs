using BuscaCEP.Models;
using Newtonsoft.Json;

namespace BuscaCEP.Services
{
    public class CorreiosServices
    {
        //Crio uma propriedade e faço uma injeção, porém tenho que trazer a invejão de independência
        private readonly HttpClient _httpClient; 
        

        public CorreiosServices(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        //Recebo o CEP se for válido
        public async Task<Endereco> BuscarEnderecoPorCep(string cep)
        {
            //Inicio a tentativa 
            try
            {
                //URI da API MONTADA
                var response = await _httpClient.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
                //Executa o HTTP CLIENT e me tras o resultado
                var json = await response.Content.ReadAsStringAsync();
                //Variavel JSON > do que 20
                if (json.Length > 20)
                    //Deserealiza o objeto JSON e joga dentro do endereço
                    return JsonConvert.DeserializeObject<Endereco>(json);
                else
                    return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
