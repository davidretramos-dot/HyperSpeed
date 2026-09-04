namespace HyperSpeed.Domain.Entities
{
    public class ItemPedido
    {
        public int Id { get; set; }

        public int Quantidade { get; set; }

        public decimal PrecoUni { get; set; }

        public decimal SubTotal { get; set; }


        // Chave estrangeira do Pedido
        public int PedidoId { get; set; }


        // Chave estrangeira do Produto
        public int ProdutoId { get; set; }


        public virtual Pedido Pedido { get; set; } = null!;

        public virtual Produto Produto { get; set; } = null!;
    }
}