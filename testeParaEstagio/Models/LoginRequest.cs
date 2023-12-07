/* Este código estabelece o que é captado como entrada (request) 
à chamada de Login. */

namespace Controllers.Models
{
    public class LoginRequest
    {
        public string? Email { get; set; }

        public string? Senha { get; set; }
    }
}