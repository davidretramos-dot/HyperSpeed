using hyperSpeed.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace hyperSpeed.Application.Interfaces
{
    public class ICategoriasService
    {
        Task<IEnumerable<CategoriasDTo>> GetAllAsync();
        Task<CategoriasDTo?> GetByIdAsync(int id);
        Task<CategoriasDTo> CreateAsync(CriaçãoCategoriasDTo dto);
        Task<CategoriasDTo?> UpdateAsync(int id, CategoriasDTo dto);
        Task<bool> DeleteAsync(int id);
        Task<int> CountAsync();
    }
}
