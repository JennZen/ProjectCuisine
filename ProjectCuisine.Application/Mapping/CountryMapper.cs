using ProjectCuisine.Application.DTOs.Country;
using ProjectCuisine.Domain.Entities;
using Riok.Mapperly.Abstractions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCuisine.Application.Mapping
{
    [Mapper]
    public partial class CountryMapper
    {
        public partial CountryPageDto ToPageDto(Country country);

        public partial CountryListDto ToListDto(Country country);

        public partial List<CountryListDto> ToListDtos(List<Country> countries);
    }
}
