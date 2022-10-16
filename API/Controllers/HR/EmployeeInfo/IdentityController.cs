using API.Controllers.Common;
using API.Errors;
using API.ViewModels.Employee;
using API.ViewModels.Identity;
using API.ViewModels.Nationality;
using AutoMapper;
using Core.Enums;
using Core.Models.EmployeesInfo;
using Data.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers.HR.EmployeeInfo
{
    public class IdentityController : MainController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<IdentityController> _logger;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public IdentityController(IUnitOfWork unitOfWork, ILogger<IdentityController> logger, IMapper mapper, LinkGenerator linkGenerator)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("GetById/{identityId:int}")]
        public async Task<ActionResult<IdentityVM>> GetById(int identityId)
        {
            var result = await _unitOfWork.Identities.GetByIdAsync(identityId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Identity Found!"));
            }

            return _mapper.Map<IdentityVM>(result);
        }

        [HttpGet("GetBy-IdentityNumber/{identityNumber}")]
        public async Task<ActionResult<IdentityVM>> GetByIdentityNumber(string identityNumber)
        {
            var result = await _unitOfWork.Identities.GetByNumberAsync(identityNumber);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Identity Found!"));
            }

            return _mapper.Map<IdentityVM>(result);
        }

        [HttpGet("GetBy-EmployeeId/{employeeId:int}")]
        public async Task<ActionResult<IdentityVM>> GetByEmployeeId(int employeeId)
        {
            var result = await _unitOfWork.Identities.GetByEmployeeIdAsync(employeeId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Identity Found!"));
            }

            return _mapper.Map<IdentityVM>(result);
        }

        [HttpGet("GetBy-EmployeeNumber/{employeeNumber:int}")]
        public async Task<ActionResult<IdentityVM>> GetByEmployeeNumber(int employeeNumber)
        {
            var result = await _unitOfWork.Identities.GetByEmployeeNumberAsync(employeeNumber);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Identity Found!"));
            }

            return _mapper.Map<IdentityVM>(result);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<IdentityVM[]>> GetAll()
        {
            var result = await _unitOfWork.Identities.GetAllAsync();
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Identity Found!"));
            }

            return _mapper.Map<IdentityVM[]>(result);
        }

        [HttpGet("GetAllBy-DateExpired")]
        public async Task<ActionResult<IdentityVM[]>> GetAllExpired()
        {
            var result = await _unitOfWork.Identities.GetAllExpiredAsync();
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Identity Found!"));
            }

            return _mapper.Map<IdentityVM[]>(result);
        }

        [HttpGet("GetAllBy-IdentityType")]
        public async Task<ActionResult<IdentityVM[]>> GetAllByIdentityType(IdentityType identityType = IdentityType.Iqama)
        {
            var result = await _unitOfWork.Identities.GetAllByTypeAsync(identityType.ToString());
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Identity Found!"));
            }

            return _mapper.Map<IdentityVM[]>(result);
        }

        [HttpPost]
        public async Task<ActionResult<IdentityVM>> Post(CreateIdentityVM createIdentityVM)
        {
            var identity = _mapper.Map<Identity>(createIdentityVM);

            await _unitOfWork.Identities.AddAsync(identity);

            if (await _unitOfWork.SaveAsync())
            {
                var location = _linkGenerator.GetPathByAction("GetById", "Identity", values: new { identityId = identity.Id });

                return Created(location, _mapper.Map<IdentityVM>(identity));
            }

            return BadRequest(new ApiResponse(400, "Failed to Add Identity!"));
        }

        [HttpPut("{identityId:int}")]
        public async Task<ActionResult<IdentityVM>> Put(int identityId, UpdateIdentityVM updateIdentityVM)
        {
            var identity = await _unitOfWork.Nationalities.GetByIdAsync(identityId);
            if (identity == null)
            {
                return BadRequest(new ApiResponse(400, "Identity Not Found!"));
            }

            _mapper.Map(updateIdentityVM, identity);

            _unitOfWork.Nationalities.Update(identity);

            if (await _unitOfWork.SaveAsync())
            {
                return _mapper.Map<IdentityVM>(identity);
            }

            return BadRequest(new ApiResponse(400, "Failed to Update Identity!"));
        }

        [HttpDelete("{identityId:int}")]
        public async Task<ActionResult> Delete(int identityId)
        {
            var identity = await _unitOfWork.Identities.GetByIdAsync(identityId);
            if (identity == null)
            {
                return BadRequest(new ApiResponse(400, "Identity Not Found!"));
            }

            _unitOfWork.Identities.Delete(identity);

            if (await _unitOfWork.SaveAsync())
            {
                return Ok("Deleted Successfully.");
            }

            return BadRequest(new ApiResponse(400, "Failed to Delete Identity!"));
        }
    }
}
