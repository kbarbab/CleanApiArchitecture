using Mine.Application.DTOs;
using Mine.Domain.Entities.XMine;
namespace Mine.Application.Contracts.Persistence.XMiner
{
    public interface IXItemRepository : IAsyncRepository<XItemEntity>
    {
        Task<InventoryGetResponseDto> GetInventory(Guid xMinerId);
    }
}
