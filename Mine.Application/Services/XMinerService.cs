using Mine.Application.Contracts.Persistence.XMiner;
using Mine.Application.Contracts.Services.XMiner;
using Mine.Application.DTOs;
using Mine.Domain.Entities.XMine;
using Mine.Domain.Enums;
using System;
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

        public async Task<ResponseDto<GetMinersResponseDto>> GetMiners()
        {
            var response = await _xMinerRepo.ListAllAsync();

            if (response != null && response.Any())
            {
                var obj = new GetMinersResponseDto()
                {
                    miners = response.Select(x => new Miner
                    {
                        cost = x.Coins,
                        description = "Some desc", //Could not find it
                        name = Enum.GetName(typeof(XMinerType), x.Type),
                        speed = x.Speed.ToString(),
                        id = x.Id.ToString(),
                        stamina = x.Stamina.ToString(),
                        strength = x.Strength.ToString(),
                    }).ToList()
                };

                return new ResponseDto<GetMinersResponseDto>
                {
                    data = obj,
                    errors = new(),
                    message = "Miner records found",
                    success = true
                };
            }
            else
            {
                return new ResponseDto<GetMinersResponseDto>
                {
                    data = null,
                    errors = new(),
                    message = "No records found",
                    success = false
                };
            }
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
                    success = true
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

        public async Task<ResponseDto<UpgradeMinerTypeResponseDto>> UpdateMinerType(XMinerType minerType, Guid id)
        {
            var existingMiner = await _xMinerRepo.GetSingleWhereAsync(x => x.Id == id);

            if (existingMiner != null)
            {
                existingMiner.Type = minerType;

                await _xMinerRepo.UpdateAsync(existingMiner);

                var obj = new UpgradeMinerTypeResponseDto
                {
                    id =existingMiner.Id.ToString(),
                    coins = existingMiner.Coins,
                    level = existingMiner.Level,
                    maxStamina = existingMiner.MaxStamina,
                    position = existingMiner.Position,
                    speed = existingMiner.Speed,
                    stamina = existingMiner.Stamina,
                    strength = existingMiner.Strength,
                    type = (int)existingMiner.Type,
                    xp = existingMiner.XP,
                    toolId = existingMiner.ToolId.ToString()
                };
                return new ResponseDto<UpgradeMinerTypeResponseDto>
                {
                    data = obj,
                    errors = new(),
                    message = "Miner Upgraded successfully!",
                    success = true
                };
            }
            else
            {
                return new ResponseDto<UpgradeMinerTypeResponseDto>
                {
                    data = null,
                    errors = new(),
                    message = "Miner not found!",
                    success = false
                };
            }
        }
    }
}
