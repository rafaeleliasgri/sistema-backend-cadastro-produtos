/* Este código executa inserções de novo Usuário na
tabela MySQL-Server. Também obtém da tabela: usuário por email e
por Guid. Retorna resultados ao UsuarioService. */

using Controllers.Entities;
using MySql.Data.MySqlClient;

namespace Controllers.Repositories
{
    public class UsuarioRepository
    {
        private string _connectionString;

        public UsuarioRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int InserirUsuario(Usuario usuario)
        {
            var cnn = new MySqlConnection(_connectionString);
            var cmd = new MySqlCommand
            {
                Connection = cnn,

                CommandText = @"INSERT INTO usuario
                (nome, sobrenome, telefone, email, genero, senha, usuarioGuid)
                VALUES
                (@nome, @sobrenome, @telefone, @email, @genero, @senha, @usuarioGuid)"
            };

            cmd.Parameters.AddWithValue("nome", usuario.Nome);
            cmd.Parameters.AddWithValue("sobrenome", usuario.Sobrenome);
            cmd.Parameters.AddWithValue("telefone", usuario.Telefone);
            cmd.Parameters.AddWithValue("email", usuario.Email);
            cmd.Parameters.AddWithValue("genero", usuario.Genero);
            cmd.Parameters.AddWithValue("senha", usuario.Senha);
            cmd.Parameters.AddWithValue("usuarioGuid", usuario.UsuarioGuid);

            cnn.Open();

            var affectedRows = cmd.ExecuteNonQuery();

            cnn.Close();

            return affectedRows;
        }

        public Usuario ObterUsuarioPorEmail(string email)
        {
            Usuario usuario = null;

            MySqlConnection cnn = new(_connectionString);

            MySqlCommand cmd = new()
            {
                Connection = cnn,

                CommandText = "SELECT * FROM usuario WHERE email= @email"
            };

            cmd.Parameters.AddWithValue("email", email);

            cnn.Open();

            var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                usuario = new Usuario
                {
                    Nome = reader["nome"].ToString(),
                    Sobrenome = reader["sobrenome"].ToString(),
                    Telefone = reader["telefone"].ToString(),
                    Email = reader["email"].ToString(),
                    Genero = reader["genero"].ToString(),
                    Senha = reader["senha"].ToString(),
                    UsuarioGuid = new Guid(reader["usuarioGuid"].ToString())
                };
            }

            return usuario;
        }

        public Usuario ObterUsuarioPorGuid(Guid usuarioGuid)
        {
            Usuario usuario = null;

            var cnn = new MySqlConnection(_connectionString);
            var cmd = new MySqlCommand
            {
                Connection = cnn,

                CommandText = "SELECT * FROM usuario WHERE usuarioGuid = @usuarioGuid"
            };

            cmd.Parameters.AddWithValue("usuarioGuid", usuarioGuid);

            cnn.Open();

            var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                usuario = new Usuario
                {
                    Nome = reader["nome"].ToString(),
                    Sobrenome = reader["sobrenome"].ToString(),
                    Telefone = reader["telefone"].ToString(),
                    Email = reader["email"].ToString(),
                    Genero = reader["genero"].ToString(),
                    Senha = reader["senha"].ToString(),
                    UsuarioGuid = new Guid(reader["usuarioGuid"].ToString())
                };
            }

            cnn.Close();

            return usuario;
        }
    }
}