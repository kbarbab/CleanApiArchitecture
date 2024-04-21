using Microsoft.EntityFrameworkCore;
using Mine.Application.DTOs;
using Mine.Domain.Entities.XMine;
using Mine.Domain.Enums;
using Mine.Infrastructure.Data;
using Mine.Infrastructure.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Mine.Application.Contracts.Persistence.XMiner
{
    public class XMinerRepository : AsyncRepository<XMinerEntity>, IXMinerRepository
    {
        private readonly MineDbContext _mineDbContext;


        public XMinerRepository(MineDbContext dbContext) : base(dbContext)
        {
            _mineDbContext = dbContext;
        }

        public XMineInfoDto GetXMinersWithPerks(Guid userId)
        {
            var result = _mineDbContext.XMiners
                .Where(m => m.UserId == userId)
                .Select(m => new
                {
                    Miner = m,
                    Perks = _mineDbContext.XPerks.Where(p => p.MinerId == m.Id).ToList()
                })
                .FirstOrDefault();


            if (result == null)
            {
                return null;
            }

            var mineInfoDto = new XMineInfoDto
            {
                coins = result.Miner.Coins,
                id = result.Miner.Id.ToString(),
                level = result.Miner.Level,
                maxStamina = result.Miner.MaxStamina,
                position = result.Miner.Position,
                speed = result.Miner.Speed,
                stamina = result.Miner.Stamina,
                strength = result.Miner.Strength,
                toolId = result.Miner.ToolId,
                type = (int)result.Miner.Type,
                xp = result.Miner.XP,
                bufs = result.Perks.Select(p => new Buf
                {
                    Expire = Convert.ToInt32((DateTime.UtcNow - p.Expire).TotalSeconds),
                    size = 0,
                    type = Enum.GetName(typeof(XItemType), p.Perk)
                }).ToList()
            };

            return mineInfoDto;
        }

    }
}
