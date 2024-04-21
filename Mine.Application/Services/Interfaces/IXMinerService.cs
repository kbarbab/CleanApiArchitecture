using Mine.Application.DTOs;
using Mine.Domain.Entities.XMine;
using Mine.Domain.Enums;
using System.Linq.Expressions;

namespace Mine.Application.Contracts.Services.XMiner
{
    public interface IXMinerService
    {
        Task<ResponseDto<XMineInfoDto>> GetMinerInfo(Guid userId);
        Task<ResponseDto<GetMinersResponseDto>> GetMiners();
        Task<ResponseDto<XMinerEntity>> GetSingleRecord(Expression<Func<XMinerEntity, bool>> predicate);
        Task<ResponseDto<UpgradeMinerTypeResponseDto>> UpdateMinerType(XMinerType minerType, Guid id);
    }
}
