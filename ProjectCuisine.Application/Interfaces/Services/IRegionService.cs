using ProjectCuisine.Application.DTOs.Region;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCuisine.Application.Interfaces.Services
{
    public interface IRegionService
    {
        public Task<List<RegionListDto>> GetAllAsync();

        public Task<RegionPageDto> GetByIdAsync(int id);
    }
}
