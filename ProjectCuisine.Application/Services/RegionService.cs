using ProjectCuisine.Application.DTOs.Region;
using ProjectCuisine.Application.Interfaces.Repositories;
using ProjectCuisine.Application.Interfaces.Services;
using ProjectCuisine.Application.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCuisine.Application.Services
{
    public class RegionService : IRegionService
    {
        private readonly IRegionRepository _repository;

        private readonly RegionMapper _mapper;

        public RegionService(IRegionRepository repository, RegionMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<List<RegionListDto>> GetAllAsync()
        {
            var regions = await _repository.GetAllAsync();
            return _mapper.ToListDtos(regions);
        }
        public async Task<RegionPageDto> GetByIdAsync(int id)
        {
            var region = await _repository.GetByIdAsync(id);
            return _mapper.ToPageDto(region);
        }

        public async Task<int> GetCountAsync()
        {
            return await _repository.GetCountAsync();
        }
    }
}
