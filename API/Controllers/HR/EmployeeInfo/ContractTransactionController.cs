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
    public class ContractTransactionController : MainController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ContractTransactionController> _logger;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public ContractTransactionController(IUnitOfWork unitOfWork, ILogger<ContractTransactionController> logger, IMapper mapper, LinkGenerator linkGenerator)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("GetById/{contractTransactionId:int}")]
        public async Task<ActionResult<ContractTransactionVM>> GetById(int contractTransactionId)
        {
            var result = await _unitOfWork.ContractTransactions.GetByIdAsync(contractTransactionId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Transaction Found!"));
            }

            return _mapper.Map<ContractTransactionVM>(result);
        }

        [HttpGet("GetAllBy-EmployeeId/{employeeId:int}")]
        public async Task<ActionResult<ContractTransactionVM[]>> GetAllByEmployeeId(int employeeId)
        {
            var result = await _unitOfWork.ContractTransactions.GetAllByEmployeeIdAsync(employeeId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Transaction Found!"));
            }

            return _mapper.Map<ContractTransactionVM[]>(result);
        }

        [HttpGet("GetAllBy-ContractId/{contractId:int}")]
        public async Task<ActionResult<ContractTransactionVM[]>> GetAllByContractId(int contractId)
        {
            var result = await _unitOfWork.ContractTransactions.GetAllByContractIdAsync(contractId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Transaction Found!"));
            }

            return _mapper.Map<ContractTransactionVM[]>(result);
        }

        [HttpGet("GetAllBy-ContractNumber/{contractNumber}")]
        public async Task<ActionResult<ContractTransactionVM[]>> GetAllByContractNumber(string contractNumber)
        {
            var result = await _unitOfWork.ContractTransactions.GetAllByContractNumberAsync(contractNumber);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Transaction Found!"));
            }

            return _mapper.Map<ContractTransactionVM[]>(result);
        }

        [HttpPost]
        public async Task<ActionResult<ContractTransactionVM>> Post(CreateContractTransactionVM createContractTransactionVM)
        {
            var contract = await _unitOfWork.Contracts.GetByIdAsync(createContractTransactionVM.ContractId);
            if (contract == null)
            {
                return NotFound(new ApiResponse(404, "No Contract Found!"));
            }

            _mapper.Map(createContractTransactionVM, contract);
            
            contract.ModifiedBy = "CurrentUser";
            contract.LastModified = DateTime.Now;

            var contractTransaction = _mapper.Map<ContractTransaction>(createContractTransactionVM);

            await _unitOfWork.ContractTransactions.AddAsync(contractTransaction);

            if (await _unitOfWork.SaveAsync())
            {
                var location = _linkGenerator.GetPathByAction("GetById", "ContractTransaction", values: new { contractTransactionId = contractTransaction.Id });

                return Created(location, _mapper.Map<ContractTransactionVM>(contractTransaction));
            }

            return BadRequest(new ApiResponse(400, "Failed to Add Transaction!"));
        }
    }
}
