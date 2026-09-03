using HyperSpeed.Domain.Entities;
using HyperSpeed.Domain.interfaces;
using HyperSpeed.Infrastruture.Context;
using Microsoft.EntityFrameworkCore;
public class PedidoRepository : IPedidoRepository
{
    private readonly HyperSpeedDbContext _context;

    public PedidoRepository(HyperSpeedDbContext context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Pedido>> GetAllAsync()
    {
        return await _context.Pedidos
            .Include(p => p.ItemPedidos).ThenInclude(i => i.Produto).ToListAsync();
    }
    public async Task<Pedido?> GetByIdAsync(int id)
    {
        return await _context.Pedidos
            .Include(p => p.ItemPedidos).ThenInclude(i => i.Produto).FirstOrDefaultAsync(p => p.Id == id);
    }
    public async Task AddAsync(Pedido pedido)
    {
        await _context.Pedidos.AddAsync(pedido);

        await _context.SaveChangesAsync();
    }
    public async Task UpdateAsync(Pedido pedido)
    {
        _context.Pedidos.Update(pedido);

        await _context.SaveChangesAsync();
    }
    public async Task DeleteAsync(int id)
    {
        var pedido =
            await _context.Pedidos.FindAsync(id);

        if (pedido != null)
        {
            _context.Pedidos.Remove(pedido);

            await _context.SaveChangesAsync();
        }
    }
    public async Task<int> CountAsync()
    {
        return await _context.Pedidos.CountAsync();
    }
}
