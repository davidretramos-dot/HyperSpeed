using hyperSpeed.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace hyperSpeed.Application.Interfaces
{
    public interface IProdutoService
    {
         Task<IEnumerable<ProdutoDTo>> GetAllAsync();
        Task<ProdutoDTo?> GetByIdAsync(int id);
        Task<IEnumerable<ProdutoDTo>> GetFeaturedAsync();
        Task<IEnumerable<ProdutoDTo>> GetByCategoryAsync(int categoriasId);
        Task<ProdutoDTo> CreateAsync(CriacaoProdutoDTo dto);
        Task<ProdutoDTo?> UpdateAsync(int id, AutualizacaoProdutoDTo dto);
        Task<bool> DeleteAsync(int id);
        Task<int> CountAsync();
        Task CreateAsync(CriacaoCategoriaDTo dto);

    }
}

