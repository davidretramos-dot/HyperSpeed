using HyperSpeed.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HyperSpeed.Domain.interfaces
{
    public interface IEntregaRepository
    {
        Task<IEnumerable<Entrega>> GetAllAsync();

        Task<Entrega?> GetByIdAsync(int id);

        Task AddAsync(Entrega category);

        Task UpdateAsync(Entrega category);


        Task DeleteAsync(int id);

        Task<int> CountAsync();
    }
}
