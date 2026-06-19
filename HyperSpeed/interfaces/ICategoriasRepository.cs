using HyperSpeed.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace HyperSpeed.Domain.interfaces
{
  public interface ICategoriaRepository
        {
         
            Task<IEnumerable<Categorias>> GetAllAsync();

            Task<Categorias?> GetByIdAsync(int id);

            Task AddAsync(Categorias category);

            Task UpdateAsync(Categorias category);


            Task DeleteAsync(int id);

            Task<int> CountAsync();
        }
    
}
