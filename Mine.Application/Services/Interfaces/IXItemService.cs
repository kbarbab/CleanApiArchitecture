using Mine.Application.DTOs;

namespace Mine.Application.Contracts.Services.XMiner
{
    public interface IXItemService
    {
        Task<ResponseDto<InventoryGetResponseDto>> GetMinerInfo(Guid minerId);
        Task<ResponseDto<GetPotionsResponse>> GetItems(Guid minerId);
    }
}
