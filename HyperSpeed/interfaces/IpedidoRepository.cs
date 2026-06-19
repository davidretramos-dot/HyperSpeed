using HyperSpeed.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HyperSpeed.Domain.interfaces
{
    public interface IpedidoRepository
    {
        Task<IEnumerable<Pedido>> GetAllAsync();

        Task<Pedido?> GetByIdAsync(int id);

        Task AddAsync(Pedido category);

        Task UpdateAsync(Pedido category);


        Task DeleteAsync(int id);

        Task<int> CountAsync();
    }
}
