using Mine.Domain.Entities.XMine;
using Mine.Infrastructure.Data;
using Mine.Infrastructure.Repositories;

namespace Mine.Application.Contracts.Persistence.XMiner
{
    public class XToolRepository : AsyncRepository<XToolEntity>,  IXToolRepository
    {
        private readonly MineDbContext _mineDbContext;

        public XToolRepository(MineDbContext dbContext) : base(dbContext)
        {
            _mineDbContext = dbContext;
        }
    }
}
