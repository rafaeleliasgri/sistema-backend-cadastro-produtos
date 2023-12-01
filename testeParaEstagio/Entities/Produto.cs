namespace Controllers.Entities
{
    public class Produto
    {
        public int Id { get; set; }

        public Guid ProdGuid { get; set; }

        public string? NomeProd { get; set; }

        public string? CodProd { get; set; }

        public string? PrecProd { get; set; }

        public string? QuantEstoque { get; set; }

    }
}