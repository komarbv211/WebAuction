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
        private readonly IFilesService _filesService;

        public LotService(AuctionDbContext context, IMapper mapper, IFilesService filesService)
        {
            _context = context;
            _mapper = mapper;
            _filesService = filesService;
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
            var lot = _context.Lots
                .Include(l => l.Category) 
                .FirstOrDefault(l => l.Id == id);

            return lot == null ? null : _mapper.Map<LotDto>(lot);
        }

        public async Task CreateLot(LotDto lotDto)
        {
            var lot = _mapper.Map<Lot>(lotDto);

            if (lotDto.Image != null)
            {
                lot.ImageUrl = await _filesService.SaveLotImage(lotDto.Image);
            }

            _context.Lots.Add(lot);
            await _context.SaveChangesAsync(); 
        }


        public async Task UpdateLot(LotDto model)
        {

            if (model.Image != null)
            {
                model.ImageUrl = await _filesService.EditLotImage(model.ImageUrl, model.Image);
            }

            _context.Lots.Update(_mapper.Map<Lot>(model));
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

        public async Task DeleteLot(int id)
        {
            var lot = _context.Lots.Find(id);
            if (lot != null)
            {
                if (lot.ImageUrl != null)
                    await _filesService.DeleteLotImage(lot.ImageUrl);
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
