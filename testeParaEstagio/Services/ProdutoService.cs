/* Este código executa validações, chamadas ao ProdutoRepositorio,
retorna resultados ao ProdutoController para operações de  
cadastro de produto. */

using Controllers.Entities;
using Controllers.Models;
using Controllers.Repositories;

namespace Controllers.Services
{
    public class ProdutoService
    {
        private string _connectionString;
        public ProdutoService(string connectionString)
        {
            _connectionString = connectionString;
        }
        public CadastroProdutoResult CadastroProduto(string NomeProduto, string CodigoProduto, string PrecoProduto,
 string quantidadeEstoque)
        {
            var result = new CadastroProdutoResult();
            var repositorio = new ProdutoRepository(_connectionString);
            var produto = repositorio.ObterProdutoPorCodigo(CodigoProduto);

            if (produto != null)
            {
                // o produto já existe;
                result.Sucesso = false;
                result.Mensagem = $"Produto já existe no sistema";
            }
            else
            {
                // o produto não existe;
                var user = new Produto
                {
                    NomeProduto = NomeProduto,
                    CodigoProduto = CodigoProduto,
                    PrecoProduto = PrecoProduto,
                    QuantidadeEstoque = quantidadeEstoque,
                    ProdutoGuid = Guid.NewGuid()
                };

                var affectedRows = repositorio.InserirProduto(user);

                if (affectedRows > 0)
                {
                    result.Sucesso = true;
                    result.ProdutoGuid = user.ProdutoGuid;
                    result.Mensagem = $"Produto cadastrado com Sucesso!";
                }
                else
                {
                    result.Sucesso = false;
                    result.Mensagem = $"Não foi possível inserir o produto.";
                }
            }

            return result;
        }
    }
}