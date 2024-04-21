using Mine.Application.Contracts.Persistence.XMiner;
using Mine.Application.Contracts.Services.XMiner;
using Mine.Application.DTOs;
using Mine.Domain.Enums;

namespace Mine.Application.Services
{
    public class XToolService : IXToolService
    {
        private readonly IXToolRepository _xToolRepository;

        public XToolService(IXToolRepository xToolRepository)
        {
            _xToolRepository = xToolRepository;
        }

        public async Task<ResponseDto<GetToolsResponseDto>> GetTools(Guid xMinerId)
        {
            var tools = _xToolRepository.QueryInContext(x => x.MinerId == xMinerId).ToList();

            if (tools != null && tools.Any())
            {
                var obj = new GetToolsResponseDto()
                {
                    tools = tools.Select(t => new Tools
                    {
                        id = t.Id.ToString(),
                        name = Enum.GetName(typeof(XToolType), t.Type),
                        cost = 0, //Cannot find it anywhere
                        hits = 0, //Cannot find it anywhere
                        strength = "0" //Cannot find it anywhere
                    }).ToList()
                };

                return new ResponseDto<GetToolsResponseDto>
                {
                    data = obj,
                    errors = new(),
                    message = string.Empty,
                    success = true
                };
            }

            return new ResponseDto<GetToolsResponseDto>
            {
                data = null,
                errors = new(),
                message = "No tools found!",
                success = false
            };
        }
    }
}
