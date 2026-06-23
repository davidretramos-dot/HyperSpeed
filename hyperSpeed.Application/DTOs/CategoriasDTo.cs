using System;
using System.Collections.Generic;
using System.Text;

namespace hyperSpeed.Application.DTOs
{
    public class CategoriasDTo
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        
    }

    public class CriacaoCategoriaDTo
    {
        public string Nome { get; set; } = string.Empty;
    }

    public class AtualizacaoCategoriaDTo
    {
        public string Nome { get; set; } = string.Empty;
    }    
}
