namespace HyperSpeed.Domain.Entities
{
    public enum StatusPedido
    {
        Pendente = 1,
        Pago = 2,
        EmPreparacao = 3,
        Enviado = 4,
        Entregue = 5,
        Cancelado = 6
    }
    public class Pedido
    {
        public int Id { get; set; }
        public DateTime DataPedido { get; set; } = DateTime.Now;

        public StatusPedido Status { get; set; } = StatusPedido.Pendente;

        public decimal ValorTotal { get; set; }
        public ICollection<ItemPedido> ItemPedidos { get; set; } = new List<ItemPedido>();

        public ICollection<Pagamento> Pagamentos { get; set; } = new List<Pagamento>();
    }
}
