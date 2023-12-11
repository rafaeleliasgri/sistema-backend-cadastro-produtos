/* Este código é um controlador de recebimento de mensagem em formato
JSON e envio de resposta também em formato JSON (CadastroProduto. 
Após as validações executadas, envolvem-se os modelos Request e Result
respectivos. Então o código PrdutoService é acionado. Este, por sua vez,
aciona o código ProdutoRepository. Este, após as tratativas, 
retorna resultado para o UsuarioService que, por sua vez, 
retorna resultado para este código, que retorna resposta (Result respectiva).*/


using Controllers.Models;
using Controllers.Services;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Controllers;

[ApiController]
[Route("api/ProdutoController")]
public class ProdutoController : ControllerBase
{
    private IConfiguration _configuration;

    public ProdutoController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost]
    [Route("CadastroProduto")]
    public CadastroProdutoResult CadastroProduto(CadastroProdutoRequest request)
    {
        var result = new CadastroProdutoResult();

        if (request == null ||
        string.IsNullOrEmpty(request.NomeProduto) ||
        string.IsNullOrEmpty(request.CodigoProduto) ||
        string.IsNullOrEmpty(request.PrecoProduto) ||
        string.IsNullOrEmpty(request.QuantidadeEstoque))
        {
            result.Mensagem = $"Todos os campos são obrigatórios";
        }
        else
        {
            var connectionString = _configuration.GetConnectionString("testeParaEstagioDb");
            var produtoService = new ProdutoService(connectionString);

            result = produtoService.CadastroProduto
            (request.NomeProduto,
             request.CodigoProduto,
             request.PrecoProduto,
             request.QuantidadeEstoque);
        }

        return result;
    }
}

