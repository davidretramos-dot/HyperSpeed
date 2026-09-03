namespace HyperSpeed.Domain.Entities
{
    public class ItemPedido
    {
        public int Id { get; set; }
        public int Quantidade { get; set; }
        public decimal PrecoUni { get; set; }
        public decimal SubTotal { get; set; }
        public int IdPedido { get; set; }
        public int IdProduto { get; set; }
        public virtual Pedido Pedido { get; set; } = null!;

        public virtual Produto Produto { get; set; } = null!;
    }
}
