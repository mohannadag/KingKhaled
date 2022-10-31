using API.Controllers.Common;
using API.Errors;
using API.ViewModels.Contracts;
using API.ViewModels.Identity;
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
    public class IdentityTransactionController : MainController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<IdentityTransactionController> _logger;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public IdentityTransactionController(IUnitOfWork unitOfWork, ILogger<IdentityTransactionController> logger, IMapper mapper, LinkGenerator linkGenerator)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("GetById/{identityTransactionId:int}")]
        public async Task<ActionResult<IdentityTransactionVM>> GetById(int identityTransactionId)
        {
            var result = await _unitOfWork.IdentityTransactions.GetByIdAsync(identityTransactionId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Transaction Found!"));
            }

            return _mapper.Map<IdentityTransactionVM>(result);
        }

        [HttpGet("GetAllBy-EmployeeId/{employeeId:int}")]
        public async Task<ActionResult<IdentityTransactionVM[]>> GetAllByEmployeeId(int employeeId)
        {
            var result = await _unitOfWork.IdentityTransactions.GetAllByEmployeeIdAsync(employeeId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Transaction Found!"));
            }

            return _mapper.Map<IdentityTransactionVM[]>(result);
        }

        [HttpGet("GetAllBy-IdentityId/{identityId:int}")]
        public async Task<ActionResult<IdentityTransactionVM[]>> GetAllByIdentityId(int identityId)
        {
            var result = await _unitOfWork.IdentityTransactions.GetAllByIdentityIdAsync(identityId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Transaction Found!"));
            }

            return _mapper.Map<IdentityTransactionVM[]>(result);
        }

        [HttpGet("GetAllBy-IdentityNumber/{identityNumber}")]
        public async Task<ActionResult<IdentityTransactionVM[]>> GetAllByIdentityNumber(string identityNumber)
        {
            var result = await _unitOfWork.IdentityTransactions.GetAllByIdentityNumberAsync(identityNumber);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Transaction Found!"));
            }

            return _mapper.Map<IdentityTransactionVM[]>(result);
        }

        [HttpPost]
        public async Task<ActionResult<IdentityTransactionVM>> Post(CreateIdentityTransactionVM createIdentityTransactionVM)
        {
            var identity = await _unitOfWork.Identities.GetByIdAsync(createIdentityTransactionVM.IdentityId);
            if (identity == null)
            {
                return NotFound(new ApiResponse(404, "No Identity Found!"));
            }

            _mapper.Map(createIdentityTransactionVM, identity);

            identity.ModifiedBy = "CurrentUser";
            identity.LastModified = DateTime.Now;

            var identityTransaction = _mapper.Map<IdentityTransaction>(createIdentityTransactionVM);

            await _unitOfWork.IdentityTransactions.AddAsync(identityTransaction);

            if (await _unitOfWork.SaveAsync())
            {
                var location = _linkGenerator.GetPathByAction("GetById", "IdentityTransaction", values: new { identityTransactionId = identityTransaction.Id });

                return Created(location, _mapper.Map<IdentityTransactionVM>(identityTransaction));
            }

            return BadRequest(new ApiResponse(400, "Failed to Add Transaction!"));
        }
    }
}
