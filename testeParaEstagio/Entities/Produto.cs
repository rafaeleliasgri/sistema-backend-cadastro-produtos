/* Este código define a entidade Produto. */

namespace Controllers.Entities
{
    public class Produto
    {
        public int Id { get; set; }

        public Guid ProdutoGuid { get; set; }

        public string? NomeProduto { get; set; }

        public string? CodigoProduto { get; set; }

        public string? PrecoProduto { get; set; }

        public string? QuantidadeEstoque { get; set; }

    }
}