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

        public List<RegionListDto> GetAll()
        {
            var regions = _repository.GetAll();
            return _mapper.ToListDtos(regions);
        }
        public RegionPageDto GetById(int id)
        {
            var region = _repository.GetById(id);
            return _mapper.ToPageDto(region);
        }
    }
}
