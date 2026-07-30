using ProjectCuisine.Application.DTOs.Country;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCuisine.Application.Interfaces.Services
{
    public interface ICountryService
    {
        public CountryPageDto GetById(int id);

        public List<CountryListDto> GetAll();

        public Task<List<CountryListDto>> GetAllByRegionAsync(int regionId);
    }
}
