using Microsoft.EntityFrameworkCore;
using Mine.Application.DTOs;
using Mine.Domain.Entities.XMine;
using Mine.Domain.Enums;
using Mine.Infrastructure.Data;
using Mine.Infrastructure.Repositories;

namespace Mine.Application.Contracts.Persistence.XMiner
{
    public class XItemRepository: AsyncRepository<XItemEntity>, IXItemRepository
    {
        private readonly MineDbContext _mineDbContext;

        public XItemRepository(MineDbContext dbContext) : base(dbContext)
        {
            _mineDbContext = dbContext;
        }

        public async Task<InventoryGetResponseDto> GetInventory(Guid xMinerId)
        {
            var tools = await _mineDbContext.XTools
            .Where(t => t.MinerId == xMinerId)
            .ToListAsync();

            var items = await _mineDbContext.XItems
                .Where(i => i.MinerId == xMinerId)
                .ToListAsync();

            if (tools.Any() && items.Any()) {
                var result = new InventoryGetResponseDto
                {
                    tools = tools.Select(t => new Tool
                    {
                        id = t.Id.ToString(),
                        name = Enum.GetName(typeof(XToolType), t.Type),
                        type = (int)t.Type,
                        health = t.Health.ToString(),
                        hits = 10
                    }).ToList(),
                    items = items.Select(i => new Item
                    {
                        id = i.Id.ToString(),
                        name = Enum.GetName(typeof(XItemType), i.Type),
                        type = (int)i.Type,
                        count = i.Count.ToString()
                    }).ToList()
                };

                return result;
            }

            return null;
        }
    }


}
