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
        public Task<CountryPageDto?> GetByIdAsync(int id);

        public Task<List<CountryListDto>> GetAllAsync();

        public Task<List<CountryListDto>> GetAllByRegionAsync(int regionId);
    }
}
