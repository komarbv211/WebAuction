using AutoMapper;
using WebAuction.Dtos;
using WebAuction.Entities;

namespace WebAuction.MapperProfiles
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<LotDto, Lot>().ReverseMap();
        }
    }
}
