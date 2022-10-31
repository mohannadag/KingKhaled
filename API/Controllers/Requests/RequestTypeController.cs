using API.Controllers.Common;
using API.Errors;
using API.ViewModels.EntryCard;
using API.ViewModels.Requests;
using AutoMapper;
using Core.Models.EmployeesInfo;
using Core.Models.Requests;
using Data.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers.Requests
{
    public class RequestTypeController : MainController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<RequestTypeController> _logger;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public RequestTypeController(IUnitOfWork unitOfWork, ILogger<RequestTypeController> logger, IMapper mapper, LinkGenerator linkGenerator)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("GetById/{requestTypeId:int}")]
        public async Task<ActionResult<RequestTypeVM>> GetById(int requestTypeId)
        {
            var result = await _unitOfWork.RequestTypes.GetByIdAsync(requestTypeId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No RequestType Found!"));
            }

            return _mapper.Map<RequestTypeVM>(result);
        }

        [HttpGet("GetBy-Name/{Name}")]
        public async Task<ActionResult<RequestTypeVM>> GetByName(string Name)
        {
            var result = await _unitOfWork.RequestTypes.GetByNameAsync(Name);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No RequestType Found!"));
            }

            return _mapper.Map<RequestTypeVM>(result);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<RequestTypeVM[]>> GetAll()
        {
            var result = await _unitOfWork.RequestTypes.GetAllAsync();
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No RequestType Found!"));
            }

            return _mapper.Map<RequestTypeVM[]>(result);
        }

        [HttpPost]
        public async Task<ActionResult<RequestTypeVM>> Post(CreateRequestTypeVM createRequestTypeVM)
        {
            var requestType = _mapper.Map<RequestType>(createRequestTypeVM);

            await _unitOfWork.RequestTypes.AddAsync(requestType);

            if (await _unitOfWork.SaveAsync())
            {
                var location = _linkGenerator.GetPathByAction("GetById", "RequestType", values: new { requestTypeId = requestType.Id });

                return Created(location, _mapper.Map<RequestTypeVM>(requestType));
            }

            return BadRequest(new ApiResponse(400, "Failed to Add RequestType!"));
        }

        [HttpPut("{requestTypeId:int}")]
        public async Task<ActionResult<RequestTypeVM>> Put(int entryCardId, UpdateRequestTypeVM updateRequestTypeVM)
        {
            var requestType = await _unitOfWork.RequestTypes.GetByIdAsync(entryCardId);
            if (requestType == null)
            {
                return BadRequest(new ApiResponse(400, "RequestType Not Found!"));
            }

            _mapper.Map(updateRequestTypeVM, requestType);

            _unitOfWork.RequestTypes.Update(requestType);

            if (await _unitOfWork.SaveAsync())
            {
                return _mapper.Map<RequestTypeVM>(requestType);
            }

            return BadRequest(new ApiResponse(400, "Failed to Update RequestType!"));
        }

        [HttpDelete("{requestTypeId:int}")]
        public async Task<ActionResult> Delete(int requestTypeId)
        {
            var requestType = await _unitOfWork.RequestTypes.GetByIdAsync(requestTypeId);
            if (requestType == null)
            {
                return BadRequest(new ApiResponse(400, "RequestType Not Found!"));
            }

            _unitOfWork.RequestTypes.Delete(requestType);

            if (await _unitOfWork.SaveAsync())
            {
                return Ok("Deleted Successfully.");
            }

            return BadRequest(new ApiResponse(400, "Failed to Delete RequestTypes!"));
        }
    }
}
