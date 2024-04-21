using Mine.Application.DTOs;

namespace Mine.Application.Contracts.Services.XMiner
{
    public interface IXRockService
    {
        Task<ResponseDto<PokeResponseDto>> InsertRock(int position, Guid xMinerId);
    }
}
