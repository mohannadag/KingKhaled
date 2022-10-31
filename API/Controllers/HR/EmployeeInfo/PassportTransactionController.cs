using API.Controllers.Common;
using API.Errors;
using API.ViewModels.Contracts;
using API.ViewModels.Passport;
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
    public class PassportTransactionController : MainController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PassportTransactionController> _logger;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public PassportTransactionController(IUnitOfWork unitOfWork, ILogger<PassportTransactionController> logger, IMapper mapper, LinkGenerator linkGenerator)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("GetById/{passportTransactionId:int}")]
        public async Task<ActionResult<PassportTransactionVM>> GetById(int passportTransactionId)
        {
            var result = await _unitOfWork.PassportTransactions.GetByIdAsync(passportTransactionId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Transaction Found!"));
            }

            return _mapper.Map<PassportTransactionVM>(result);
        }

        [HttpGet("GetAllBy-EmployeeId/{employeeId:int}")]
        public async Task<ActionResult<PassportTransactionVM[]>> GetAllByEmployeeId(int employeeId)
        {
            var result = await _unitOfWork.PassportTransactions.GetAllByEmployeeIdAsync(employeeId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Transaction Found!"));
            }

            return _mapper.Map<PassportTransactionVM[]>(result);
        }

        [HttpGet("GetAllBy-PassportId/{passportId:int}")]
        public async Task<ActionResult<PassportTransactionVM[]>> GetAllByPassportId(int passportId)
        {
            var result = await _unitOfWork.PassportTransactions.GetAllByPassportIdAsync(passportId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Transaction Found!"));
            }

            return _mapper.Map<PassportTransactionVM[]>(result);
        }

        [HttpGet("GetAllBy-PassportNumber/{passportNumber}")]
        public async Task<ActionResult<PassportTransactionVM[]>> GetAllByPassportNumber(string passportNumber)
        {
            var result = await _unitOfWork.PassportTransactions.GetAllByPassportNumberAsync(passportNumber);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Transaction Found!"));
            }

            return _mapper.Map<PassportTransactionVM[]>(result);
        }

        [HttpPost]
        public async Task<ActionResult<PassportTransactionVM>> Post(CreatePassportTransactionVM createPassportTransactionVM)
        {
            var passport = await _unitOfWork.Passports.GetByIdAsync(createPassportTransactionVM.PassportId);
            if (passport == null)
            {
                return NotFound(new ApiResponse(404, "No Passport Found!"));
            }

            _mapper.Map(createPassportTransactionVM, passport);

            passport.ModifiedBy = "CurrentUser";
            passport.LastModified = DateTime.Now;

            var passportTransaction = _mapper.Map<PassportTransaction>(createPassportTransactionVM);

            await _unitOfWork.PassportTransactions.AddAsync(passportTransaction);

            if (await _unitOfWork.SaveAsync())
            {
                var location = _linkGenerator.GetPathByAction("GetById", "PassportTransaction", values: new { passportTransactionId = passportTransaction.Id });

                return Created(location, _mapper.Map<PassportTransactionVM>(passportTransaction));
            }

            return BadRequest(new ApiResponse(400, "Failed to Add Transaction!"));
        }
    }
}
