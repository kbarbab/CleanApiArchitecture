using Mine.Application.DTOs;

namespace Mine.Application.Services.Interfaces
{
    public interface IXMoveService
    {
        Task<ResponseDto<List<PositionInfoDto>>> GetPositionInfo(int position);
        Task<ResponseDto<XMoveResponse>> InsertNewPosition(int position, Guid xMinerId);
    }
}
