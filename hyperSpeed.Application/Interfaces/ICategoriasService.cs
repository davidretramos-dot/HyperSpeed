using hyperSpeed.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace hyperSpeed.Application.Interfaces
{
    public interface ICategoriasService
    {
        Task<IEnumerable<CategoriasDTo>> GetAllAsync();
        Task<CategoriasDTo?> GetByIdAsync(int id);
        Task<CategoriasDTo> CreateAsync(CriacaoCategoriaDTo dto);
        Task<CategoriasDTo?> UpdateAsync(int id, AtualizacaoCategoriaDTo dto);
        Task<bool> DeleteAsync(int id);
        Task<int> CountAsync();
    }

    
}
