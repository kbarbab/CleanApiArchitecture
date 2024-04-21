using Microsoft.AspNetCore.Mvc;
using Mine.Application.Contracts.Authorization;
using Mine.Application.Contracts.Services.XMiner;
using Mine.Application.DTOs;
using Mine.Application.Services.Interfaces;
using Mine.Domain.Enums;

namespace Mine.API.Controllers
{
    [ApiController]
    [Route("xmine")]
    public class MineController : ControllerBase
    {
        private readonly IXMinerService _xMinerService;
        private readonly IXMoveService _xMoveService;
        private readonly IXRockService _xRockService;
        private readonly IXItemService _xItemService;
        private readonly IXToolService _xToolService;
        private readonly IUserAccessor _userAccessor;
        private ResponseDto<string> _exeptionResponse = new ResponseDto<string>();

        public MineController(IXMinerService XMinerService, IUserAccessor userAccessor, IXMoveService xMoveService, IXRockService xRockService, IXItemService xItemService, IXToolService xToolService)
        {
            _xMinerService = XMinerService;
            _userAccessor = userAccessor;
            _xMoveService = xMoveService;
            _xRockService = xRockService;
            _xItemService = xItemService;
            _xToolService = xToolService;
            _exeptionResponse.errors = new();
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

        [HttpPost("poke/{position}")]
        public async Task<IActionResult> Poke(int position)
        {
            try
            {
                var xminerResponse = await _xMinerService.GetSingleRecord(x => x.UserId == _userAccessor.UserId);

                if (xminerResponse != null)
                {
                    var pokeResponse = await _xRockService.InsertRock(position, xminerResponse.data.Id);

                    return Ok(pokeResponse);
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

        [HttpGet("inventory")]
        public async Task<IActionResult> Inventory()
        {
            try
            {
                var xminerResponse = await _xMinerService.GetSingleRecord(x => x.UserId == _userAccessor.UserId);

                if (xminerResponse != null)
                {
                    var pokeResponse = await _xItemService.GetMinerInfo(xminerResponse.data.Id);

                    return Ok(pokeResponse);
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

        [HttpPost("iventory/use/{id}")]
        public async Task<IActionResult> UseInventory(Guid id)
        {
            var resp = new ResponseDto<string>
            { 
                data = string.Empty,
                errors = new(),
                message = "Started moving!",
                success = true
            };

            return Ok(resp);
        }

        [HttpPost("iventory/equip/{id}")]
        public async Task<IActionResult> EquipInventory(Guid id)
        {
            var resp = new ResponseDto<string>
            {
                data = string.Empty,
                errors = new(),
                message = "Started moving!",
                success = true
            };

            return Ok(resp);
        }

        [HttpPost("upgrade/{minertype}")]
        public async Task<IActionResult> UpgradeMiner(XMinerType minertype)
        {
            try
            {
                var xminerResponse = await _xMinerService.GetSingleRecord(x => x.UserId == _userAccessor.UserId);

                if (xminerResponse != null)
                {
                    var updateResponse = await _xMinerService.UpdateMinerType(minertype, xminerResponse.data.Id);

                    return Ok(updateResponse);
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

        [HttpGet("tools")]
        public async Task<IActionResult> GetTools()
        {
            try
            {
                var xminerResponse = await _xMinerService.GetSingleRecord(x => x.UserId == _userAccessor.UserId);

                if (xminerResponse != null)
                {
                    var pokeResponse = await _xToolService.GetTools(xminerResponse.data.Id);

                    return Ok(pokeResponse);
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

        [HttpGet("potions")]
        public async Task<IActionResult> Potions()
        {
            try
            {
                var xminerResponse = await _xMinerService.GetSingleRecord(x => x.UserId == _userAccessor.UserId);

                if (xminerResponse != null)
                {
                    var pokeResponse = await _xItemService.GetItems(xminerResponse.data.Id);

                    return Ok(pokeResponse);
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

        [HttpGet("miners")]
        public async Task<IActionResult> Miners()
        {
            try
            {
                var pokeResponse = await _xMinerService.GetMiners();

                return Ok(pokeResponse);
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
