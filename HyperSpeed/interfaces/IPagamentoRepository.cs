using HyperSpeed.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HyperSpeed.Domain.interfaces
{
    public interface IPagamentoRepository
    {
        Task<IEnumerable<Pagamento>> GetAllAsync();

        Task<Pagamento?> GetByIdAsync(int id);

        Task AddAsync(Pagamento category);

        Task UpdateAsync(Pagamento category);


        Task DeleteAsync(int id);

        Task<int> CountAsync();
    }
}
