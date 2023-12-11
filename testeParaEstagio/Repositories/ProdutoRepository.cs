/* Este código executa inserções de novo Produto na
tabela MySQL-Server. Também obtém da tabela produto por código.
Retorna resultados ao ProdutoService. */

using Controllers.Entities;
using MySql.Data.MySqlClient;

namespace Controllers.Repositories
{
    public class ProdutoRepository
    {
        private string _connectionString;

        public ProdutoRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public int InserirProduto(Produto produto)
        {
            var cnn = new MySqlConnection(_connectionString);
            var cmd = new MySqlCommand
            {
                Connection = cnn,
                CommandText = @"INSERT INTO produto
                (nomeProduto, codigoProduto, precoProduto, quantidadeEstoque, produtoGuid)
                VALUES
                (@nomeProduto, @codigoProduto, @precoProduto, @quantidadeEstoque, @produtoGuid)"
            };
            cmd.Parameters.AddWithValue("nomeProduto", produto.NomeProduto);
            cmd.Parameters.AddWithValue("codigoProduto", produto.CodigoProduto);
            cmd.Parameters.AddWithValue("precoProduto", produto.PrecoProduto);
            cmd.Parameters.AddWithValue("quantidadeEstoque", produto.QuantidadeEstoque);
            cmd.Parameters.AddWithValue("produtoGuid", produto.ProdutoGuid);

            cnn.Open();

            var affectedRows = cmd.ExecuteNonQuery();

            cnn.Close();

            return affectedRows;
        }

        public Produto ObterProdutoPorCodigo(string CodigoProduto)
        {
            Produto produto = null;

            MySqlConnection cnn = new(_connectionString);

            MySqlCommand cmd = new()
            {
                Connection = cnn,

                CommandText = "SELECT * FROM produto WHERE codigoProduto = @codigoProduto"
            };

            cmd.Parameters.AddWithValue("codigoProduto", CodigoProduto);

            cnn.Open();

            var reader = cmd.ExecuteReader();

            if (reader.Read())
            {
                produto = new Produto
                {
                    NomeProduto = reader["nomeProduto"].ToString(),
                    CodigoProduto = reader["codigoProduto"].ToString(),
                    PrecoProduto = reader["precoProduto"].ToString(),
                    QuantidadeEstoque = reader["quantidadeEstoque"].ToString(),
                    ProdutoGuid = new Guid(reader["produtoGuid"].ToString())
                };
            }

            return produto;
        }
    }
}