using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCuisine.Application.DTOs.Country
{
    public class CountryListDto
    {
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string FlagUrl { get; set; } = string.Empty;
    }
}
