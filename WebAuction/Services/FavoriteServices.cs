using AutoMapper;
using Core.Dtos;
using Data.Data;
using Microsoft.EntityFrameworkCore;
using WebAuction.Extensions;

namespace WebAuction.Services
{
    public class FavoriteServices
    {
        private readonly HttpContext httpContext;
        private readonly IMapper mapper;
        private readonly AuctionDbContext context;
        public FavoriteServices(IHttpContextAccessor contextAccessor, IMapper mapper, AuctionDbContext context)
        {
            httpContext = contextAccessor.HttpContext!;
            this.mapper = mapper;
            this.context = context;
        }

        public int GetCount()
        {
            var ids = httpContext.Session.Get<List<int>>("favorite_items");

            if (ids == null) return 0;

            return ids.Distinct().Count();
        }
        public List<LotDto> GetLots()
        {
            var ids = httpContext.Session.Get<List<int>>("favorite_items") ?? new();

            var lots = context.Lots.Include(x => x.Category).Where(x => ids.Contains(x.Id)).ToList();

            return mapper.Map<List<LotDto>>(lots);
        }

        public void AddItem(int id)
        {
            var ids = httpContext.Session.Get<List<int>>("favorite_items");

            if (ids == null) ids = new();

            ids.Add(id);

            httpContext.Session.Set("favorite_items", ids);
        }

        public void RemoveItem(int id)
        {
            var ids = httpContext.Session.Get<List<int>>("favorite_items");

            if (ids == null || !ids.Contains(id)) return; // throw exception

            ids.Remove(id);

            httpContext.Session.Set("favorite_items", ids);
        }
    }
}
