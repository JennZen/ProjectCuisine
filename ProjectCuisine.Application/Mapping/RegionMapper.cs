using ProjectCuisine.Application.DTOs.Region;
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
    public partial class RegionMapper
    {
        public partial RegionPageDto ToPageDto(Region region);

        public partial RegionListDto ToListDto(Region region);

        public partial List<RegionListDto> ToListDtos(List<Region> regions);
    }
}
