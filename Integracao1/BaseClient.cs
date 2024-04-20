
namespace PlataformaCompra
{
    // All the code in this file is included in all platforms.
    public class BaseClient
    {
        // Instância estática e somente leitura de HttpClient para fazer requisições HTTP
        static readonly HttpClient _client = new HttpClient();

        // URL base da API
        string _baseUrl = "https://jq8d6sq2-7029.brs.devtunnels.ms/";

        // Método para obter informações sobre uma ação
        public async Task<HttpResponseMessage> GetShare(string shareSymbol)
        {
            // Concatenação da URL base com o endpoint para recuperar informações da ação
            string end = _baseUrl + "Share/" + shareSymbol;

            // Enviando uma requisição GET para o endpoint da API
            var response = await _client.GetAsync(end);

            // Verificando se a resposta é bem-sucedida
            if (!response.IsSuccessStatusCode)
            {
                // Se a resposta não for bem-sucedida, lança uma exceção com uma mensagem de erro
                throw new Exception("Erro ao buscar informações da ação");
            }

            // Retorna a resposta se for bem-sucedida
            return response;
        }
    }
}
