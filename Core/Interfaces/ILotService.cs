using Core.Dtos;
using Data.Entities;

namespace Core.Interfaces
{
    public interface ILotService
    {
        List<LotDto> GetActiveLots();
        List<LotDto> GetArchivedLots();
        LotDto GetLotById(int id);
        Task CreateLot(LotDto lotDto);
        Task UpdateLot(LotDto lotDto);
        void ArchiveLot(int id);
        Task DeleteLot(int id);
        void RestoreLot(int id);
        public List<Category> GetCategories();
    }
}
