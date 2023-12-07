/* Este código estabelece o que é captado como entrada (request) 
à chamada de Cadastro de Usuário. */

namespace Controllers.Models
{
    public class CadastroUsuarioRequest
    {
        public string? Nome { get; set; }

        public string? Sobrenome { get; set; }

        public string? Email { get; set; }

        public string? Telefone { get; set; }

        public string? Senha { get; set; }

        public string? Genero { get; set; }

    }
}