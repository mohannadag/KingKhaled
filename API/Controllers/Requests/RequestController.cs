using API.Controllers.Common;
using API.Errors;
using API.ViewModels.EntryCard;
using API.ViewModels.Passport;
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
    public class RequestController : MainController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<RequestController> _logger;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public RequestController(IUnitOfWork unitOfWork, ILogger<RequestController> logger, IMapper mapper, LinkGenerator linkGenerator)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("GetById/{requestId:int}")]
        public async Task<ActionResult<RequestVM>> GetById(int requestId)
        {
            var result = await _unitOfWork.Requests.GetByIdAsync(requestId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Request Found!"));
            }

            return _mapper.Map<RequestVM>(result);
        }

        [HttpGet("GetBy-RequestNumber/{requestNumber}")]
        public async Task<ActionResult<RequestVM>> GetByRequestNumber(string requestNumber)
        {
            var result = await _unitOfWork.Requests.GetByNumberAsync(requestNumber);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Request Found!"));
            }

            return _mapper.Map<RequestVM>(result);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<RequestVM[]>> GetAll()
        {
            var result = await _unitOfWork.Requests.GetAllAsync();
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Request Found!"));
            }

            return _mapper.Map<RequestVM[]>(result);
        }

        [HttpGet("GetAllBy-RequestTypeId/{requestTypeId:int}")]
        public async Task<ActionResult<RequestVM[]>> GetAllByRequestTypeId(int employeeId)
        {
            var result = await _unitOfWork.Requests.GetAllByRequestTypeIdAsync(employeeId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Request Found!"));
            }

            return _mapper.Map<RequestVM[]>(result);
        }

        [HttpGet("GetAllBy-EmployeeId/{employeeId:int}")]
        public async Task<ActionResult<RequestVM[]>> GetAllByEmployeeId(int employeeId)
        {
            var result = await _unitOfWork.Requests.GetAllByEmployeeIdAsync(employeeId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Request Found!"));
            }

            return _mapper.Map<RequestVM[]>(result);
        }

        [HttpGet("GetAllBy-Status")]
        public async Task<ActionResult<RequestVM[]>> GetAllByStatus(bool? isApproved)
        {
            var result = await _unitOfWork.Requests.GetAllByStatusAsync(isApproved);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Request Found!"));
            }

            return _mapper.Map<RequestVM[]>(result);
        }

        [HttpPost]
        public async Task<ActionResult<RequestVM>> Post(CreateRequestVM createRequestVM)
        {
            var request = _mapper.Map<Request>(createRequestVM);

            await _unitOfWork.Requests.AddAsync(request);

            if (await _unitOfWork.SaveAsync())
            {
                var location = _linkGenerator.GetPathByAction("GetById", "Request", values: new { requestId = request.Id });

                return Created(location, _mapper.Map<RequestVM>(request));
            }

            return BadRequest(new ApiResponse(400, "Failed to Add Request!"));
        }

        [HttpPut("{requestId:int}")]
        public async Task<ActionResult<RequestVM>> Put(int requestId, UpdateRequestVM updateRequestVM)
        {
            var request = await _unitOfWork.Requests.GetByIdAsync(requestId);
            if (request == null)
            {
                return BadRequest(new ApiResponse(400, "EntryCard Not Found!"));
            }

            _mapper.Map(updateRequestVM, request);

            _unitOfWork.Requests.Update(request);

            if (await _unitOfWork.SaveAsync())
            {
                return _mapper.Map<RequestVM>(request);
            }

            return BadRequest(new ApiResponse(400, "Failed to Update Request!"));
        }

        [HttpDelete("{requestId:int}")]
        public async Task<ActionResult> Delete(int requestId)
        {
            var request = await _unitOfWork.Requests.GetByIdAsync(requestId);
            if (request == null)
            {
                return BadRequest(new ApiResponse(400, "Request Not Found!"));
            }

            _unitOfWork.Requests.Delete(request);

            if (await _unitOfWork.SaveAsync())
            {
                return Ok("Deleted Successfully.");
            }

            return BadRequest(new ApiResponse(400, "Failed to Delete Request!"));
        }
    }
}
