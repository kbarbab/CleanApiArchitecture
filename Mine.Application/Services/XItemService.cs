using Mine.Application.Contracts.Persistence.XMiner;
using Mine.Application.Contracts.Services.XMiner;
using Mine.Application.DTOs;
using Mine.Domain.Enums;

namespace Mine.Application.Services
{
    public class XItemService : IXItemService
    {
        private readonly IXItemRepository _xItemRepo;

        public XItemService(IXItemRepository xItemRepo)
        {
            _xItemRepo = xItemRepo;
        }

        public async Task<ResponseDto<GetPotionsResponse>> GetItems(Guid minerId)
        {
            var response = _xItemRepo.QueryInContext(x => x.MinerId == minerId).ToList();

            if (response != null)
            {
                var obj = new GetPotionsResponse()
                {
                    potions = response.Select(x => new Potion
                    {
                        cost = x.Count,
                        expire = "600", //Count not find it anywhere
                        id = x.Id.ToString(),
                        name = Enum.GetName(typeof(XItemType), x.Type)
                    }).ToList()
                };

                return new ResponseDto<GetPotionsResponse>
                {
                    data = obj,
                    errors = new(),
                    message = string.Empty,
                    success = true
                };
            }

            return new ResponseDto<GetPotionsResponse>
            {
                data = null,
                errors = new(),
                message = "No potions found!",
                success = false
            };
        }
    
        public async Task<ResponseDto<InventoryGetResponseDto>> GetMinerInfo(Guid minerId)
        {
            var response = await _xItemRepo.GetInventory(minerId);

            if (response != null)
            {
                return new ResponseDto<InventoryGetResponseDto>
                {
                    data = response,
                    errors = new(),
                    message = string.Empty,
                    success = true
                };
            }

            return new ResponseDto<InventoryGetResponseDto>
            {
                data = null,
                errors = new(),
                message = "No records found",
                success = false
            };
        }
    }
}
