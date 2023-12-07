/* Este código estabelece o que é captado como entrada (request) 
à chamada de Cadastro de Produto. */

namespace Controllers.Models
{
    public class CadastroProdutoRequest
    {
        public string? NomeProduto { get; set; }

        public string? CodigoProduto { get; set; }

        public string? PrecoProduto { get; set; }

        public string? QuantidadeEstoque { get; set; }

    }
}