namespace HyperSpeed.Domain.Entities
{
    public class Favorito
    {
        public int Id { get; set; }

        public string UserId { get; set; } = null!;

        public int ProdutoId { get; set; }

        public virtual Produto Produto { get; set; } = null!;
    }
}