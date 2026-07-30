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
        public List<RegionListDto> GetAll();

        public RegionPageDto GetById(int id);
    }
}
