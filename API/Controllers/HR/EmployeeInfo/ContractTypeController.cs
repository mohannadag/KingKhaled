using API.Controllers.Common;
using API.Errors;
using API.ViewModels.Contracts;
using AutoMapper;
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
    public class ContractTypeController : MainController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ContractTypeController> _logger;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public ContractTypeController(IUnitOfWork unitOfWork, ILogger<ContractTypeController> logger, IMapper mapper, LinkGenerator linkGenerator)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("GetById/{contractTypeId:int}")]
        public async Task<ActionResult<ContractTypeVM>> GetById(int contractTypeId)
        {
            var result = await _unitOfWork.ContractTypes.GetByIdAsync(contractTypeId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No ContractType Found!"));
            }

            return _mapper.Map<ContractTypeVM>(result);
        }

        [HttpGet("GetBy-ArabicName/{arabicName}")]
        public async Task<ActionResult<ContractTypeVM>> GetByArabicName(string arabicName)
        {
            var result = await _unitOfWork.ContractTypes.GetByArabicNameAsync(arabicName);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No ContractType Found!"));
            }

            return _mapper.Map<ContractTypeVM>(result);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ContractTypeVM[]>> GetAll()
        {
            var result = await _unitOfWork.ContractTypes.GetAllAsync();
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No ContractType Found!"));
            }

            return _mapper.Map<ContractTypeVM[]>(result);
        }

        [HttpPost]
        public async Task<ActionResult<ContractTypeVM>> Post(CreateContractTypeVM createContractTypeVM)
        {
            var contractType = _mapper.Map<ContractType>(createContractTypeVM);

            await _unitOfWork.ContractTypes.AddAsync(contractType);

            if (await _unitOfWork.SaveAsync())
            {
                var location = _linkGenerator.GetPathByAction("GetById", "ContractType", values: new { contractTypeId = contractType.Id });

                return Created(location, _mapper.Map<ContractTypeVM>(contractType));
            }

            return BadRequest(new ApiResponse(400, "Failed to Add ContractType!"));
        }

        [HttpPut("{contractTypeId:int}")]
        public async Task<ActionResult<ContractTypeVM>> Put(int contractTypeId, UpdateContractTypeVM updateContractTypeVM)
        {
            var contractType = await _unitOfWork.ContractTypes.GetByIdAsync(contractTypeId);
            if (contractType == null)
            {
                return BadRequest(new ApiResponse(400, "ContractType Not Found!"));
            }

            _mapper.Map(updateContractTypeVM, contractType);

            _unitOfWork.ContractTypes.Update(contractType);

            if (await _unitOfWork.SaveAsync())
            {
                return _mapper.Map<ContractTypeVM>(contractType);
            }

            return BadRequest(new ApiResponse(400, "Failed to Update ContractType!"));
        }

        [HttpDelete("{contractTypeId:int}")]
        public async Task<ActionResult> Delete(int contractTypeId)
        {
            var contractType = await _unitOfWork.ContractTypes.GetByIdAsync(contractTypeId);
            if (contractType == null)
            {
                return BadRequest(new ApiResponse(400, "ContractType Not Found!"));
            }

            _unitOfWork.ContractTypes.Delete(contractType);

            if (await _unitOfWork.SaveAsync())
            {
                return Ok("Deleted Successfully.");
            }

            return BadRequest(new ApiResponse(400, "Failed to Delete ContractType!"));
        }
    }
}
