using Microsoft.EntityFrameworkCore;
using Mine.Application.DTOs;
using Mine.Domain.Entities.XMine;
using Mine.Domain.Enums;
using Mine.Infrastructure.Data;
using Mine.Infrastructure.Repositories;

namespace Mine.Application.Contracts.Persistence.XMiner
{
    public class XMoveRepository: AsyncRepository<XMoveEntity>, IXMoveRepository
    {
        private readonly MineDbContext _mineDbContext;

        public XMoveRepository(MineDbContext dbContext) : base(dbContext)
        {
            _mineDbContext = dbContext;
        }

        public List<PositionInfoDto> GetPositionInfo(int position)
        {
            var bankInfo = GetStaticBanks(); //Getting static banks as of now

            var result = from mo in _mineDbContext.XMoves
                         join m in _mineDbContext.XMiners on mo.MinerId equals m.Id
                         join u in _mineDbContext.Users on m.UserId equals u.Id
                         join i in _mineDbContext.XItems on m.Id equals i.MinerId
                         join r in _mineDbContext.XRocks on (int)i.Type equals r.Item
                         where m.Position == position
                         group new { mo, m, u, r } by new { m.Position, r.Item } into g
                         select new PositionInfoDto
                         {
                             players = g.Select(x => new Player
                             {
                                 destination = x.mo.Destination,
                                 location = x.m.Position,
                                 speed = x.mo.Speed,
                                 username = x.u.Username
                             }).ToList(),
                             rocks = g.Select(x => new Rock
                             {
                                 id = x.r.Id.ToString(),
                                 location = x.r.Position,
                                 type = x.r.Item
                             }).ToList(),
                             banks = bankInfo
                         };

            return result.Any() ? result.ToList() : null;
        }


        private static List<Bank> GetStaticBanks()
        {
            return new List<Bank>
            {
                new Bank
                {
                    id =  "00000000-0000-0000-0000-000000000000",
                    location = 550
                },
                new Bank
                {
                    id =  "00000000-0000-0000-0000-000000000000",
                    location = 500
                },
                new Bank
                {
                    id =  "00000000-0000-0000-0000-000000000000",
                    location = 600
                },
            };
        }


    }


}
