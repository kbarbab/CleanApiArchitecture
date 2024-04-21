using Mine.Application.DTOs;
using Mine.Domain.Entities.XMine;

namespace Mine.Application.Contracts.Persistence.XMiner
{
    public interface IXMoveRepository : IAsyncRepository<XMoveEntity>
    {
        List<PositionInfoDto> GetPositionInfo(int positiond);
    }
}
