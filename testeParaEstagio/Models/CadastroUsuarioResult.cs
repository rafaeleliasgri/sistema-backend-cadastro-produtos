/* Este código estabelece o que será enviado como resposta (result) 
à chamada de Cadastro de Usuário. */

namespace Controllers.Models
{
    public class CadastroUsuarioResult : BaseResult
    {
        public Guid UsuarioGuid { get; set; }
    }
}