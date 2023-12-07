/* Este código cria uma base para evitar repetição de código nos
códigos modelos CadastroProdutoResult, CadastroUsuarioResult, EsqueceuSenhaResult
LoginResult e ObterUsuarioResult */

namespace Controllers.Models
{
    public class BaseResult
    {
        public bool Sucesso { get; set; }

        public string? Mensagem { get; set; }

    }
}