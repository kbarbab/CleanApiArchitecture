using Mine.Application.Contracts.Persistence.XMiner;
using Mine.Application.Contracts.Services.XMiner;
using Mine.Application.DTOs;
using Mine.Domain.Entities.XMine;
using System.Linq.Expressions;

namespace Mine.Application.Services
{
    public class XMinerService : IXMinerService
    {
        private readonly IXMinerRepository _xMinerRepo;

        public XMinerService(IXMinerRepository xMinerRepo)
        {
            _xMinerRepo = xMinerRepo;
        }

        public async Task<ResponseDto<XMineInfoDto>> GetMinerInfo(Guid userId)
        {
            var response =   _xMinerRepo.GetXMinersWithPerks(userId);

            if(response != null)
            {
                return new ResponseDto<XMineInfoDto> { 
                data = response,
                errors = new(),
                message = string.Empty,
                success = true
                };
            }

            return new ResponseDto<XMineInfoDto>
            {
                data = null,
                errors = new(),
                message = "No records found",
                success = false
            };
        }

        public async Task<ResponseDto<XMinerEntity>> GetSingleRecord(Expression<Func<XMinerEntity, bool>> predicate)
        {
            var response = await _xMinerRepo.GetSingleWhereAsync(predicate);

            if (response != null)
            {
                return new ResponseDto<XMinerEntity>
                {
                    data = response,
                    errors = new(),
                    message = "Miner records found",
                    success = false
                };
            }
            else
            {
                return new ResponseDto<XMinerEntity>
                {
                    data = null,
                    errors = new(),
                    message = "No records found",
                    success = false
                };
            }
        }
    }
}
