using Core.Dtos;
using Data.Entities;

namespace Core.Interfaces
{
    public interface ILotService
    {
        List<LotDto> GetActiveLots();
        List<LotDto> GetArchivedLots();
        LotDto GetLotById(int id);
        void CreateLot(LotDto lotDto);
        void UpdateLot(LotDto lotDto);
        void ArchiveLot(int id);
        void DeleteLot(int id);
        void RestoreLot(int id);
        public List<Category> GetCategories();
    }
}
