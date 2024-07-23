using AutoMapper;
using Core.Dtos;
using Core.Interfaces;
using Data.Data;
using Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace Core.Services
{
    public class LotService : ILotService
    {
        private readonly AuctionDbContext _context;
        private readonly IMapper _mapper;

        public LotService(AuctionDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public List<LotDto> GetActiveLots()
        {
            var lots = _context.Lots
                .Include(x => x.Category)
                .Where(x => !x.Archived)
                .ToList();

            return _mapper.Map<List<LotDto>>(lots);
        }

        public List<LotDto> GetArchivedLots()
        {
            var lots = _context.Lots
                .Include(x => x.Category)
                .Where(x => x.Archived)
                .ToList();

            return _mapper.Map<List<LotDto>>(lots);
        }

        public LotDto GetLotById(int id)
        {
            var lot = _context.Lots.Find(id);
            return lot == null ? null : _mapper.Map<LotDto>(lot);
        }

        public void CreateLot(LotDto lotDto)
        {
            var lot = _mapper.Map<Lot>(lotDto);
            _context.Lots.Add(lot);
            _context.SaveChanges();
        }

        public void UpdateLot(LotDto lotDto)
        {
            var lot = _mapper.Map<Lot>(lotDto);
            _context.Lots.Update(lot);
            _context.SaveChanges();
        }

        public void ArchiveLot(int id)
        {
            var lot = _context.Lots.Find(id);
            if (lot != null)
            {
                lot.Archived = true;
                _context.SaveChanges();
            }
        }

        public void DeleteLot(int id)
        {
            var lot = _context.Lots.Find(id);
            if (lot != null)
            {
                _context.Lots.Remove(lot);
                _context.SaveChanges();
            }
        }

        public void RestoreLot(int id)
        {
            var lot = _context.Lots.Find(id);
            if (lot != null)
            {
                lot.Archived = false;
                _context.SaveChanges();
            }
        }
        public List<Category> GetCategories()
        {
            return _context.Categories.ToList();
        }
    }
}
