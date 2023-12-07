/* Este código estabelece o que será enviado como resposta (result) 
à chamada de Login. */

namespace Controllers.Models
{
    public class LoginResult : BaseResult
    {
        public Guid UsuarioGuid { get; set; }
    }
}