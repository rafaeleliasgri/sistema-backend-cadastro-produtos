/* Este código estabelece o que será enviado como resposta (result) 
à chamada de Obter Usuário. */

namespace Controllers.Models
{
    public class ObterUsuarioResult : BaseResult
    {
        public string Nome { get; set; }
    }
}