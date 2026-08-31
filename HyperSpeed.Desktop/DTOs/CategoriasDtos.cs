using System;
using System.Collections.Generic;
using System.Text;

namespace HyperSpeed.Desktop.DTOs
{
    public class CategoriaResponseDtos
    {
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int GameCount { get; set; }
    }

    public class CreateCategoriaDto
    {
        public string Name { get; set; } = string.Empty;
    }

    public class UpdateCategoriaDto
    {
        public string Name { get; set; } = string.Empty;
    }
}
