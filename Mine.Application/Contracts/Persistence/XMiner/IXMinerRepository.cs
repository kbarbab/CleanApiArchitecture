using Mine.Application.DTOs;
using Mine.Domain.Entities.XMine;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mine.Application.Contracts.Persistence.XMiner
{
    public interface IXMinerRepository : IAsyncRepository<XMinerEntity>
    {
        XMineInfoDto GetXMinersWithPerks(Guid userId);
    }
}
