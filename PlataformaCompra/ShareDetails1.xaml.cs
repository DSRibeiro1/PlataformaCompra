using Dominio.Entidades; // Importa o namespace das entidades de domínio
using Newtonsoft.Json; // Importa o namespace para trabalhar com JSON

namespace PlataformaCompra// Define o namespace do aplicativo


{
    // Definição da classe ShareDetails que herda de ContentPage
    public partial class ShareDetails1 : ContentPage
    {
        // Declaração de variáveis privadas
        private string _shareSymbol; // Armazena o símbolo da ação

        private readonly BaseClient _client = new BaseClient(); // Instância de um cliente para interação com a API

        // Construtor da classe ShareDetails
        public ShareDetails1(string shareSymbol)
        {
            InitializeComponent(); // Inicializa os componentes visuais da página (deve vir primeiro)

            _shareSymbol = shareSymbol; // Atribui o símbolo da ação fornecido ao campo privado _shareSymbol

            ShowShareDetails(_shareSymbol); // Chama o método para exibir os detalhes da ação
        }

        // Método assíncrono para exibir os detalhes da ação
        public async Task ShowShareDetails(string shareSymbol)
        {
            try
            {
                // Faz uma solicitação assíncrona à API para obter os detalhes da ação
                HttpResponseMessage respostaAPI = await _client.GetShare(shareSymbol);

                string conteudo = await respostaAPI.Content.ReadAsStringAsync();

                // Desserializa o conteúdo JSON recebido em um objeto do tipo Acao
                Acao acao = JsonConvert.DeserializeObject<Acao>(conteudo);


                // Atualiza a UI na thread principal com os detalhes da ação
                MainThread.BeginInvokeOnMainThread(() =>
                {

                    Logotipo.Source = acao.Logourl; // Define a fonte da imagem do logotipo da ação

                    Dados.Text = $"{acao.ShortName} Valor: {acao.RegularMarketPrice}"; // Define o texto exibido com os detalhes da ação
                });
            }
            catch (Exception ex)
            {

                // Trata exceções (por exemplo, exibindo uma mensagem de erro para o usuário)
                MainThread.BeginInvokeOnMainThread(() =>
                {
                    // Atualiza a UI para refletir o erro (por exemplo, exibindo uma mensagem de erro na tela)
                });
            }
        }
    }
}
