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

        public CountryPageDto GetById(int id)
        {
            var country = _repository.GetById(id);
            return _mapper.ToPageDto(country);
        }

        public List<CountryListDto> GetAll()
        {
            var countries = _repository.GetAll();
            return _mapper.ToListDtos(countries);
        }

        public async Task<List<CountryListDto>> GetAllByRegionAsync(int regionId)
        {
            var countries = await _repository.GetAllByRegionAsync(regionId);
            return _mapper.ToListDtos(countries);
        }
    }
}
