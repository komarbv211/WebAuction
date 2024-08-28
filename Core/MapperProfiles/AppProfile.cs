using AutoMapper;
using Core.Dtos;
using Data.Entities;

namespace Core.MapperProfiles
{
    public class AppProfile : Profile
    {
        public AppProfile()
        {
            CreateMap<LotDto, Lot>().ForMember(x => x.Description, opt => opt.MapFrom(src => src.Description + "!"));
            CreateMap<Lot, LotDto>();
            CreateMap<Order, OrderDto>().ReverseMap();
            CreateMap<Bid, BidDto>().ReverseMap();
        }
    }
}
