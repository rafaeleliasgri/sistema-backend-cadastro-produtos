/* Este código estabelece o que será enviado como resposta (result) 
à chamada de Cadastro de Produto. */

namespace Controllers.Models
{
    public class CadastroProdutoResult : BaseResult
    {
        public Guid ProdutoGuid { get; set; }
    }
}