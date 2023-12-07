/* Este código estabelece o que é captado como entrada (request) 
à chamada de Esqueceu Senha. */

namespace Controllers.Models
{
    public class EsqueceuSenhaRequest
    {
        public string? Email { get; set; }
    }
}