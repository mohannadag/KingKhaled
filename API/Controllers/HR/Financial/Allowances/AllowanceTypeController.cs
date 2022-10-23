using API.Controllers.Common;
using API.Errors;
using API.ViewModels.Allowance;
using API.ViewModels.Bank;
using AutoMapper;
using Core.Models.Allowance;
using Core.Models.General;
using Data.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers.HR.Financial.Allowances
{
    public class AllowanceTypeController : MainController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<AllowanceTypeController> _logger;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public AllowanceTypeController(IUnitOfWork unitOfWork, ILogger<AllowanceTypeController> logger, IMapper mapper, LinkGenerator linkGenerator)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("GetById/{allowanceTypeId:int}")]
        public async Task<ActionResult<AllowanceTypeVM>> GetById(int allowanceTypeId)
        {
            var result = await _unitOfWork.AllowanceTypes.GetByIdAsync(allowanceTypeId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No AllowanceType Found!"));
            }

            return _mapper.Map<AllowanceTypeVM>(result);
        }

        [HttpGet("GetBy-ArabicName/{arabicName}")]
        public async Task<ActionResult<AllowanceTypeVM>> GetByArabicName(string arabicName)
        {
            var result = await _unitOfWork.AllowanceTypes.GetByArabicNameAsync(arabicName);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No AllowanceType Found!"));
            }

            return _mapper.Map<AllowanceTypeVM>(result);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<AllowanceTypeVM[]>> GetAll()
        {
            var result = await _unitOfWork.AllowanceTypes.GetAllAsync();
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No AllowanceType Found!"));
            }

            return _mapper.Map<AllowanceTypeVM[]>(result);
        }

        [HttpPost]
        public async Task<ActionResult<AllowanceTypeVM>> Post(CreateAllowanceTypeVM createAllowanceTypeVM)
        {
            var allowanceType = _mapper.Map<AllowanceType>(createAllowanceTypeVM);

            await _unitOfWork.AllowanceTypes.AddAsync(allowanceType);

            if (await _unitOfWork.SaveAsync())
            {
                var location = _linkGenerator.GetPathByAction("GetById", "AllowanceType", values: new { allowanceTypeId = allowanceType.Id });

                return Created(location, _mapper.Map<AllowanceTypeVM>(allowanceType));
            }

            return BadRequest(new ApiResponse(400, "Failed to Add AllowanceType!"));
        }

        [HttpPut("{allowanceTypeId:int}")]
        public async Task<ActionResult<AllowanceTypeVM>> Put(int allowanceTypeId, UpdateAllowanceTypeVM updateAllowanceTypeVM)
        {
            var allowanceType = await _unitOfWork.AllowanceTypes.GetByIdAsync(allowanceTypeId);
            if (allowanceType == null)
            {
                return BadRequest(new ApiResponse(400, "AllowanceType Not Found!"));
            }

            _mapper.Map(updateAllowanceTypeVM, allowanceType);

            _unitOfWork.AllowanceTypes.Update(allowanceType);

            if (await _unitOfWork.SaveAsync())
            {
                return _mapper.Map<AllowanceTypeVM>(allowanceType);
            }

            return BadRequest(new ApiResponse(400, "Failed to Update AllowanceType!"));
        }

        [HttpDelete("{allowanceTypeId:int}")]
        public async Task<ActionResult> Delete(int allowanceTypeId)
        {
            var allowanceType = await _unitOfWork.AllowanceTypes.GetByIdAsync(allowanceTypeId);
            if (allowanceType == null)
            {
                return BadRequest(new ApiResponse(400, "AllowanceType Not Found!"));
            }

            _unitOfWork.AllowanceTypes.Delete(allowanceType);

            if (await _unitOfWork.SaveAsync())
            {
                return Ok("Deleted Successfully.");
            }

            return BadRequest(new ApiResponse(400, "Failed to Delete AllowanceType!"));
        }
    }
}
