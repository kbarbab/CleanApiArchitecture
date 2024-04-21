using Mine.Application.DTOs;

namespace Mine.Application.Contracts.Services.XMiner
{
    public interface IXToolService
    {
        Task<ResponseDto<GetToolsResponseDto>> GetTools(Guid xMinerId);
    }
}
