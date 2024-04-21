using Microsoft.EntityFrameworkCore;
using Mine.Domain.Entities.XMine;
using Mine.Infrastructure.Data;
using Mine.Infrastructure.Repositories;

namespace Mine.Application.Contracts.Persistence.XMiner
{
    public class XRockRepository: AsyncRepository<XRockEntity>, IXRockRepository
    {
        private readonly MineDbContext _mineDbContext;

        public XRockRepository(MineDbContext dbContext) : base(dbContext)
        {
            _mineDbContext = dbContext;
        }
    }
}
