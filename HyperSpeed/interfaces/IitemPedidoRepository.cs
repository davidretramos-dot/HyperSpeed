using HyperSpeed.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HyperSpeed.Domain.interfaces
{
    public interface IitemPedidoRepository
    {
        Task<IEnumerable<ItemPedido>> GetAllAsync();

        Task<ItemPedido?> GetByIdAsync(int id);

        Task AddAsync(ItemPedido category);

        Task UpdateAsync(ItemPedido category);


        Task DeleteAsync(int id);

        Task<int> CountAsync();
    }
}
