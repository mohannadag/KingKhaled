using API.Controllers.Common;
using API.Errors;
using API.ViewModels.Employee;
using API.ViewModels.EmployeeAccount;
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
    public class EmployeeAccountsController : MainController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EmployeeAccountsController> _logger;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public EmployeeAccountsController(IUnitOfWork unitOfWork, ILogger<EmployeeAccountsController> logger, IMapper mapper, LinkGenerator linkGenerator)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("GetById/{employeeAccountId:int}")]
        public async Task<ActionResult<EmployeeAccountVM>> GetById(int employeeAccountId)
        {
            var result = await _unitOfWork.EmployeeAccounts.GetByIdAsync(employeeAccountId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Employee Account Found!"));
            }

            return _mapper.Map<EmployeeAccountVM>(result);
        }

        [HttpGet("GetBy-IBAN/{iban}")]
        public async Task<ActionResult<EmployeeAccountVM>> GetByIBAN(string iban)
        {
            var result = await _unitOfWork.EmployeeAccounts.GetByIBANAsync(iban);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Employee Account Found!"));
            }

            return _mapper.Map<EmployeeAccountVM>(result);
        }

        [HttpGet("GetBy-AccountNumber/{accountNumber}")]
        public async Task<ActionResult<EmployeeAccountVM>> GetByAccountNumber(string accountNumber)
        {
            var result = await _unitOfWork.EmployeeAccounts.GetByNumberAsync(accountNumber);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Employee Account Found!"));
            }

            return _mapper.Map<EmployeeAccountVM>(result);
        }

        [HttpGet("GetAllBy-BankID/{bankId:int}")]
        public async Task<ActionResult<EmployeeAccountVM[]>> GetAllByBankId(int bankId)
        {
            var result = await _unitOfWork.EmployeeAccounts.GetAllByBankIdAsync(bankId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Employees Account Found!"));
            }

            return _mapper.Map<EmployeeAccountVM[]>(result);
        }

        [HttpGet("GetAllBy-EmployeeId/{employeeId:int}")]
        public async Task<ActionResult<EmployeeAccountVM[]>> GetAllByEmployeeId(int employeeId)
        {
            var result = await _unitOfWork.EmployeeAccounts.GetAllByEmployeeIdAsync(employeeId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Employees Account Found!"));
            }

            return _mapper.Map<EmployeeAccountVM[]>(result);
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeAccountVM>> Post(CreateEmployeeAccountVM createEmployeeAccountVM)
        {
            var employeeAccount = _mapper.Map<EmployeeAccount>(createEmployeeAccountVM);

            await _unitOfWork.EmployeeAccounts.AddAsync(employeeAccount);

            if (await _unitOfWork.SaveAsync())
            {
                var location = _linkGenerator.GetPathByAction("GetById", "EmployeeAccounts", values: new { employeeAccountId = employeeAccount.Id });

                return Created(location, _mapper.Map<EmployeeAccountVM>(employeeAccount));
            }

            return BadRequest(new ApiResponse(400, "Failed to Add Employee Account!"));
        }

        [HttpPut("{employeeAccountId:int}")]
        public async Task<ActionResult<EmployeeAccountVM>> Put(int employeeAccountId, UpdateEmployeeAccountVM updateEmployeeAccountVM)
        {
            var employeeAccount = await _unitOfWork.EmployeeAccounts.GetByIdAsync(employeeAccountId);
            if (employeeAccount == null)
            {
                return BadRequest(new ApiResponse(400, "Employee Account Not Found!"));
            }

            _mapper.Map(updateEmployeeAccountVM, employeeAccount);

            _unitOfWork.EmployeeAccounts.Update(employeeAccount);

            if (await _unitOfWork.SaveAsync())
            {
                return _mapper.Map<EmployeeAccountVM>(employeeAccount);
            }

            return BadRequest(new ApiResponse(400, "Failed to Update Employee!"));
        }

        [HttpDelete("{employeeAccountId:int}")]
        public async Task<ActionResult> Delete(int employeeAccountId)
        {
            var employeeAccount = await _unitOfWork.EmployeeAccounts.GetByIdAsync(employeeAccountId);
            if (employeeAccount == null)
            {
                return BadRequest(new ApiResponse(400, "Employee Account Not Found!"));
            }

            _unitOfWork.EmployeeAccounts.Delete(employeeAccount);

            if (await _unitOfWork.SaveAsync())
            {
                return Ok("Deleted Successfully.");
            }

            return BadRequest(new ApiResponse(400, "Failed to Delete Employee Account!"));
        }
    }
}
