using Microsoft.AspNetCore.Mvc;
using Mine.Application.Contracts.Authorization;
using Mine.Application.Contracts.Services.XMiner;
using Mine.Application.DTOs;
using Mine.Application.Services.Interfaces;

namespace Mine.API.Controllers
{
    [ApiController]
    [Route("xmine")]
    public class MineController : ControllerBase
    {
        private readonly IXMinerService _xMinerService;
        private readonly IXMoveService _xMoveService;
        private readonly IUserAccessor _userAccessor;
        private ResponseDto<string> _exeptionResponse = new ResponseDto<string>();

        public MineController(IXMinerService XMinerService, IUserAccessor userAccessor, IXMoveService xMoveService)
        {
            _xMinerService = XMinerService;
            _userAccessor = userAccessor;
            _xMoveService = xMoveService;
        }

        [HttpGet("miner")]
        public async Task<IActionResult> GetMiner()
        {
            try
            {
                var minerResponse = await _xMinerService.GetMinerInfo(_userAccessor.UserId);
                return Ok(minerResponse);
            }
            catch(Exception ex)
            {
                _exeptionResponse.errors.Add(ex.Message);
                _exeptionResponse.success = false;
                _exeptionResponse.message = ex.Message;
                return Ok(_exeptionResponse);
            }
        }

        [HttpGet("map/{playerlocation}")]
        public async Task<IActionResult> GetMap(int playerlocation)
        {
            try
            {
                var positionInfo = await _xMoveService.GetPositionInfo(playerlocation);
                return Ok(positionInfo);
            }
            catch(Exception ex)
            {
                _exeptionResponse.errors.Add(ex.Message);
                _exeptionResponse.success = false;
                _exeptionResponse.message = ex.Message;
                return Ok(_exeptionResponse);
            };
        }

        [HttpPost("move/{position}")]
        public async Task<IActionResult> Move(int position)
        {
            try
            {
                var xminerResponse = await _xMinerService.GetSingleRecord(x => x.UserId == _userAccessor.UserId);

                if (xminerResponse != null)
                {
                    var moveResponse = await _xMoveService.InsertNewPosition(position, xminerResponse.data.Id);

                    return Ok(moveResponse);
                }
                else
                {
                    return Ok(xminerResponse);
                }
            }
            catch (Exception ex)
            {
                _exeptionResponse.errors.Add(ex.Message);
                _exeptionResponse.success = false;
                _exeptionResponse.message = ex.Message;
                return Ok(_exeptionResponse);
            }
        }
    }
}
