using API.Controllers.Common;
using API.Errors;
using API.ViewModels.Contracts;
using API.ViewModels.EntryCard;
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
    public class ContractsController : MainController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ContractsController> _logger;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public ContractsController(IUnitOfWork unitOfWork, ILogger<ContractsController> logger, IMapper mapper, LinkGenerator linkGenerator)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("GetById/{contractId:int}")]
        public async Task<ActionResult<ContractVM>> GetById(int contractId)
        {
            var result = await _unitOfWork.Contracts.GetByIdAsync(contractId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Contract Found!"));
            }

            return _mapper.Map<ContractVM>(result);
        }

        [HttpGet("GetBy-ContractNumber/{contractNumber}")]
        public async Task<ActionResult<ContractVM>> GetByContractNumber(string contractNumber)
        {
            var result = await _unitOfWork.Contracts.GetByContractNumberAsync(contractNumber);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Contract Found!"));
            }

            return _mapper.Map<ContractVM>(result);
        }

        [HttpGet("GetBy-EmployeeId/{employeeId:int}")]
        public async Task<ActionResult<ContractVM>> GetByEmployeeId(int employeeId)
        {
            var result = await _unitOfWork.Contracts.GetByEmployeeId(employeeId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Contract Found!"));
            }

            return _mapper.Map<ContractVM>(result);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<ContractVM[]>> GetAll()
        {
            var result = await _unitOfWork.Contracts.GetAllAsync();
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Contract Found!"));
            }

            return _mapper.Map<ContractVM[]>(result);
        }

        [HttpGet("GetAll-Expired")]
        public async Task<ActionResult<ContractVM[]>> GetAllExpired()
        {
            var result = await _unitOfWork.Contracts.GetAllExpiredAsync();
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Expired Contract Found!"));
            }

            return _mapper.Map<ContractVM[]>(result);
        }

        [HttpGet("GetAllBy-ContractTypeId/{contractTypeId:int}")]
        public async Task<ActionResult<ContractVM[]>> GetAllByContractTypeId(int contractTypeId)
        {
            var result = await _unitOfWork.Contracts.GetAllByContractTypeIdAsync(contractTypeId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Contract Found!"));
            }

            return _mapper.Map<ContractVM[]>(result);
        }

        [HttpPost]
        public async Task<ActionResult<ContractVM>> Post(CreateContractVM createContractVM)
        {
            var contract = _mapper.Map<Contract>(createContractVM);

            await _unitOfWork.Contracts.AddAsync(contract);

            if (await _unitOfWork.SaveAsync())
            {
                var location = _linkGenerator.GetPathByAction("GetById", "Contracts", values: new { contractId = contract.Id });

                return Created(location, _mapper.Map<ContractVM>(contract));
            }

            return BadRequest(new ApiResponse(400, "Failed to Add Contract!"));
        }

        [HttpPut("{contractId:int}")]
        public async Task<ActionResult<ContractVM>> Put(int contractId, UpdateContractVM updateContractVM)
        {
            var contract = await _unitOfWork.Contracts.GetByIdAsync(contractId);
            if (contract == null)
            {
                return BadRequest(new ApiResponse(400, "Contract Not Found!"));
            }

            _mapper.Map(updateContractVM, contract);

            _unitOfWork.Contracts.Update(contract);

            if (await _unitOfWork.SaveAsync())
            {
                return _mapper.Map<ContractVM>(contract);
            }

            return BadRequest(new ApiResponse(400, "Failed to Update Contract!"));
        }

        [HttpDelete("{contractId:int}")]
        public async Task<ActionResult> Delete(int contractId)
        {
            var contract = await _unitOfWork.Contracts.GetByIdAsync(contractId);
            if (contract == null)
            {
                return BadRequest(new ApiResponse(400, "Contract Not Found!"));
            }

            _unitOfWork.Contracts.Delete(contract);

            if (await _unitOfWork.SaveAsync())
            {
                return Ok("Deleted Successfully.");
            }

            return BadRequest(new ApiResponse(400, "Failed to Delete Contract!"));
        }
    }
}
