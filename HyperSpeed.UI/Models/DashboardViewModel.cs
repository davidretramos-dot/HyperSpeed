using hyperSpeed.Application.DTOs;

namespace HyperSpeed.UI.Models
{
    public class DashboardViewModel
    {
        public int TotalProdutos { get; set; }
        public int TotalCategorias { get; set; }
        public IEnumerable<ProdutoDTo> RecentProdutos { get; set; } = new List<ProdutoDTo>();
    }
}
