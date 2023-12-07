/* Este código é um controlador de recebimento de mensagem em formato
JSON e envio de resposta também em formato JSON (login, cadastroUsuário 
CadastroProduto, esqueceuSenha, obterUsuario). Após as validações 
executadas, envolvem-se os modelos Request e Result respectivos.
Então o código UsuarioService é acionado. Este, por sua vez,
aciona o código UsuárioRepositorio. Este, após as tratativas, 
retorna resultado para o UsuarioService que, por sua vez, 
retorna resultado para este código, que retorna resposta (Result respectiva).*/


using Controllers.Models;
using Controllers.Services;
using Microsoft.AspNetCore.Mvc;

namespace TodoApi.Controllers;

[ApiController]
[Route("api/UsuarioController")]
public class UsuarioController : ControllerBase
{
    private IConfiguration _configuration;

    public UsuarioController(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    [HttpPost]
    [Route("Login")]
    public LoginResult Login(LoginRequest request)
    {

        var result = new LoginResult();

        if (request == null)
        {
            result.Sucesso = false;
            result.Mensagem = $"Parâmetro request veio nulo.";
        }
        else if (request.Email == "")
        {
            result.Sucesso = false;
            result.Mensagem = $"E-mail Obrigatório";
        }
        else if (request.Senha == "")
        {
            result.Sucesso = false;
            result.Mensagem = $"Senha obrigatória";
        }
        else
        {
            var connectionString = _configuration.GetConnectionString("testeParaEstagioDb");

            var usuarioService = new UsuarioService(connectionString);

            result = usuarioService.Login(request.Email, request.Senha);
        }

        return result;
    }

    [HttpPost]
    [Route("CadastroUsuario")]
    public CadastroUsuarioResult CadastroUsuario(CadastroUsuarioRequest request)
    {
        var result = new CadastroUsuarioResult();

        if (request == null ||
        string.IsNullOrEmpty(request.Nome) ||
        string.IsNullOrEmpty(request.Sobrenome) ||
        string.IsNullOrEmpty(request.Telefone) ||
        string.IsNullOrEmpty(request.Genero) ||
        string.IsNullOrEmpty(request.Email) ||
        string.IsNullOrEmpty(request.Senha))
        {
            result.Mensagem = $"Todos os campos são obrigatórios";
        }
        else
        {
            var connectionString = _configuration.GetConnectionString("testeParaEstagioDb");

            var usuarioService = new UsuarioService(connectionString);

            result = usuarioService.CadastroUsuario
            (request.Nome,
             request.Sobrenome,
             request.Telefone,
             request.Email,
             request.Genero, request.Senha);
        }

        return result;
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
            var usuarioService = new UsuarioService(connectionString);

            result = usuarioService.CadastroProduto
            (request.NomeProduto,
             request.CodigoProduto,
             request.PrecoProduto,
             request.QuantidadeEstoque);
        }

        return result;
    }

    [HttpPost]
    [Route("EsqueceuSenha")]
    public EsqueceuSenhaResult EsqueceuSenha(EsqueceuSenhaRequest request)
    {
        var result = new EsqueceuSenhaResult();

        if (request == null ||
        string.IsNullOrEmpty(request.Email))
        {
            result.Mensagem = $"E-mail obrigatório";

            return result;
        }

        var connectionString = _configuration.GetConnectionString("testeParaEstagioDb");

        result = new UsuarioService(connectionString).Esqueceusenha(request.Email);

        return result;
    }


    [HttpGet]
    [Route("obterusuario")]
    public ObterUsuarioResult ObterUsuario(Guid usuarioGuid)
    {
        var result = new ObterUsuarioResult();

        if (usuarioGuid == null)
        {
            result.Mensagem = $"Guid vazio!";
        }
        else
        {
            var connectionString = _configuration.GetConnectionString("testeParaEstagioDb");

            var usuario = new UsuarioService(connectionString).ObterUsuario(usuarioGuid);

            if (usuario == null)
            {
                result.Mensagem = $"Usuário não existe!";
            }
            else
            {
                result.Sucesso = true;
                result.Nome = usuario.Nome;
                result.Mensagem = $"Usuário {usuario.Nome} encontrado com Sucesso!";
            }
        }

        return result;
    }

}

