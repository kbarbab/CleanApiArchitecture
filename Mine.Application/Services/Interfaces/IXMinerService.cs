using Mine.Application.DTOs;
using Mine.Domain.Entities.XMine;
using System.Linq.Expressions;

namespace Mine.Application.Contracts.Services.XMiner
{
    public interface IXMinerService
    {
        Task<ResponseDto<XMineInfoDto>> GetMinerInfo(Guid userId);
        Task<ResponseDto<XMinerEntity>> GetSingleRecord(Expression<Func<XMinerEntity, bool>> predicate);
    }
}
