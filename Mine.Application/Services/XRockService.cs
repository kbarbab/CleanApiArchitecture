using Mine.Application.Contracts.Persistence.XMiner;
using Mine.Application.Contracts.Services.XMiner;
using Mine.Application.DTOs;
using Mine.Domain.Entities.XMine;

namespace Mine.Application.Services
{
    public class XRockService : IXRockService
    {
        private readonly IXRockRepository _xRockrRepo;

        public XRockService(IXRockRepository xRockrRepo)
        {
            _xRockrRepo = xRockrRepo;
        }

        public async Task<ResponseDto<PokeResponseDto>> InsertRock(int position, Guid xMinerId)
        {
            var obj = new XRockEntity
            {
                Coins = 100,
                Item = 1,
                MinerId = xMinerId,
                Position = position,
                Tool = 5
            };

            var response = await _xRockrRepo.AddAsync(obj);

            if (response != null)
            {
                var item = new PokeResponseDto
                {
                    coins = response.Coins,
                    potion = response.Position,
                    tool = response.Tool
                };

                return new ResponseDto<PokeResponseDto>
                {
                    data = item,
                    errors = new(),
                    message = "Rock mined successfully!",
                    success = true
                };
            }

            return new ResponseDto<PokeResponseDto>
            {
                data = null,
                errors = new(),
                message = "Failed to mine rock",
                success = false
            }; 


        }
    }
}
