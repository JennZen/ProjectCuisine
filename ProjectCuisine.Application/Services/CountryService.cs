using ProjectCuisine.Application.DTOs.Country;
using ProjectCuisine.Application.Interfaces.Repositories;
using ProjectCuisine.Application.Interfaces.Services;
using ProjectCuisine.Application.Mapping;
using ProjectCuisine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCuisine.Application.Services
{
    public class CountryService : ICountryService
    {
        private readonly ICountryRepository _repository;

        private readonly CountryMapper _mapper;

        public CountryService(ICountryRepository repository, CountryMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<CountryPageDto?> GetByIdAsync(int id)
        {
            var country = await _repository.GetByIdAsync(id);
            return _mapper.ToPageDto(country);
        }

        public async Task<List<CountryListDto>> GetAllAsync()
        {
            var countries = await _repository.GetAllAsync();
            return _mapper.ToListDtos(countries);
        }

        public async Task<List<CountryListDto>> GetAllByRegionAsync(int regionId)
        {
            var countries = await _repository.GetAllByRegionAsync(regionId);
            return _mapper.ToListDtos(countries);
        }
    }
}
