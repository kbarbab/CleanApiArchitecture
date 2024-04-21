using Microsoft.EntityFrameworkCore;
using Mine.Domain.Entities.XMine;
using Mine.Infrastructure.Repositories;

namespace Mine.Application.Contracts.Persistence.XMiner
{
    public class XItemRepository: AsyncRepository<XItemEntity>, IXItemRepository
    {
        public XItemRepository(DbContext dbContext) : base(dbContext)
        {
        }
    }


}
