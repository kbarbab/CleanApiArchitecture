using Mine.Application.Contracts.Persistence.XMiner;
using Mine.Application.DTOs;
using Mine.Application.Services.Interfaces;
using Mine.Domain.Entities.XMine;

namespace Mine.Application.Services
{
    public class XMoveService : IXMoveService
    {
        private readonly IXMoveRepository _xMoveRepo;

        public XMoveService(IXMoveRepository xMoveRepo)
        {
            _xMoveRepo = xMoveRepo;
        }

        public async Task<ResponseDto<List<PositionInfoDto>>> GetPositionInfo(int position)
        {
            var response = _xMoveRepo.GetPositionInfo(position);

            if (response != null)
            {
                return new ResponseDto<List<PositionInfoDto>>
                {
                    data = response,
                    errors = new(),
                    message = string.Empty,
                    success = true
                };
            }

            return new ResponseDto<List<PositionInfoDto>>
            {
                data = null,
                errors = new(),
                message = "No records found",
                success = false
            };
        }

        public async Task<ResponseDto<XMoveResponse>> InsertNewPosition(int position, Guid xMinerId)
        {
            var existingXMoveResponse = await _xMoveRepo.GetLastWhereAsync(x => x.MinerId == xMinerId, y => y.RowVersion);

            var insertObj = new XMoveEntity
            {
                MinerId = xMinerId
            };

            if(existingXMoveResponse != null)
            {
                insertObj.Start = existingXMoveResponse.Destination;
                insertObj.Destination = existingXMoveResponse.Destination + position;
                insertObj.Speed = existingXMoveResponse.Speed;
            }
            else
            {
                insertObj.Start = 0;
                insertObj.Destination =  position;
                insertObj.Speed = 5.6;
            }

            var response = await _xMoveRepo.AddAsync(insertObj);

            if (response != null)
            {
                var obj = new XMoveResponse
                {
                    destination = response.Destination,
                    speed = response.Speed,
                    starting = response.Start
                };
                return new ResponseDto<XMoveResponse>
                {
                    data = obj,
                    errors = new(),
                    message = "Started moving",
                    success = true
                };
            }

            return new ResponseDto<XMoveResponse>
            {
                data = null,
                errors = new(),
                message = "Failed to move",
                success = false
            };
        }
    }
}
