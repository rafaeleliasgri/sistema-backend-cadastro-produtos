/* Este código executa validações, chamadas ao UsuarioRepository,
ao EmailSender e retorna resultados ao UsuarioController para operações de Login,  
cadastro de usuário, esqueceu senha, e obter usuário. */

using Controllers.Common;
using Controllers.Entities;
using Controllers.Models;
using Controllers.Repositories;

namespace Controllers.Services
{
    public class UsuarioService
    {
        private string _connectionString;
        public UsuarioService(string connectionString)
        {
            _connectionString = connectionString;
        }
        public LoginResult Login(string email, string senha)
        {
            var result = new LoginResult();

            var usuarioExistente = new UsuarioRepository(_connectionString).ObterUsuarioPorEmail(email);

            if (usuarioExistente == null)
            {
                result.Sucesso = false;
                result.Mensagem = $"Usuário ou senha Inválidos.";
            }
            else
            {
                //o usuário existe
                if (usuarioExistente.Senha == senha)
                {
                    // a senha é válida;
                    result.Sucesso = true;
                    result.UsuarioGuid = usuarioExistente.UsuarioGuid;
                    result.Mensagem = $"Você Logou!";
                }
                else
                {
                    // a senha é inválida;
                    result.Sucesso = false;
                    result.Mensagem = $"Usuário ou senha Inválidos";
                }
            }

            return result;
        }

        public CadastroUsuarioResult CadastroUsuario(string nome, string sobrenome, string telefone,
         string email, string genero, string senha)
        {
            var result = new CadastroUsuarioResult();

            var repositorio = new UsuarioRepository(_connectionString);

            var usuario = repositorio.ObterUsuarioPorEmail(email);

            if (usuario != null)
            {
                // o usuário já existe;
                result.Sucesso = false;
                result.Mensagem = $"Usuário já existe no sistema";
            }
            else
            {
                // o usuário não existe;
                var user = new Usuario
                {
                    Nome = nome,
                    Sobrenome = sobrenome,
                    Telefone = telefone,
                    Email = email,
                    Genero = genero,
                    Senha = senha,
                    UsuarioGuid = Guid.NewGuid()
                };

                var affectedRows = repositorio.InserirUsuario(user);

                if (affectedRows > 0)
                {
                    result.Sucesso = true;
                    result.UsuarioGuid = user.UsuarioGuid;
                    result.Mensagem = $"Usuário cadastrado com Sucesso!";
                }
                else
                {
                    result.Sucesso = false;
                    result.Mensagem = $"Não foi possível inserir o usuário.";
                }
            }

            return result;
        }

        public EsqueceuSenhaResult Esqueceusenha(string email)
        {
            var result = new EsqueceuSenhaResult();
            var usuarioExistente = new UsuarioRepository(_connectionString).ObterUsuarioPorEmail(email);

            if (usuarioExistente == null)
            {
                result.Sucesso = false;
                result.Mensagem = $"Usuário não existe.";
            }
            else
            {
                var assunto = $"Programação do Zero - Recuperação de Senha";
                var corpo = $"Sua senha de acesso é: {usuarioExistente.Senha}";
                var emailSender = new EmailSender();

                emailSender.EnviarEmail(assunto, corpo, usuarioExistente.Email);

                result.Sucesso = true;
            }

            return result;
        }

        public Usuario ObterUsuario(Guid usuarioGuid)
        {
            var usuario = new UsuarioRepository(_connectionString).ObterUsuarioPorGuid(usuarioGuid);

            return usuario;
        }
    }
}