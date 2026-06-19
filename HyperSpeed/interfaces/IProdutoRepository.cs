using HyperSpeed.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HyperSpeed.Domain.interfaces
{
    public interface IProdutoRepository
    {
        
         
        Task<IEnumerable<Produto>> GetAllAsync();

        Task<Produto?> GetByIdAsync(int id);

        Task AddAsync(Produto category);

        Task UpdateAsync(Produto category);


        Task DeleteAsync(int id);

        Task<int> CountAsync();
    }
}
