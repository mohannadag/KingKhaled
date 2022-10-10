using API.Controllers.Common;
using API.Errors;
using API.ViewModels.Identity;
using API.ViewModels.Passport;
using AutoMapper;
using Core.Models;
using Data.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers.HR
{
    public class PassportController : MainController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PassportController> _logger;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public PassportController(IUnitOfWork unitOfWork, ILogger<PassportController> logger, IMapper mapper, LinkGenerator linkGenerator)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("GetById/{passportId:int}")]
        public async Task<ActionResult<PassportVM>> GetById(int passportId)
        {
            var result = await _unitOfWork.Passports.GetByIdAsync(passportId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Passport Found!"));
            }

            return _mapper.Map<PassportVM>(result);
        }

        [HttpGet("GetBy-PassportNumber/{passportNumber}")]
        public async Task<ActionResult<PassportVM>> GetByIdentityNumber(string passportNumber)
        {
            var result = await _unitOfWork.Passports.GetByNumberAsync(passportNumber);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Passport Found!"));
            }

            return _mapper.Map<PassportVM>(result);
        }

        [HttpGet("GetBy-EmployeeId/{employeeId:int}")]
        public async Task<ActionResult<PassportVM>> GetByEmployeeId(int employeeId)
        {
            var result = await _unitOfWork.Passports.GetByEmployeeIdAsync(employeeId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Passport Found!"));
            }

            return _mapper.Map<PassportVM>(result);
        }

        [HttpGet("GetBy-EmployeeNumber/{employeeNumber:int}")]
        public async Task<ActionResult<PassportVM>> GetByEmployeeNumber(int employeeNumber)
        {
            var result = await _unitOfWork.Passports.GetByEmployeeNumberAsync(employeeNumber);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Passport Found!"));
            }

            return _mapper.Map<PassportVM>(result);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<PassportVM[]>> GetAll()
        {
            var result = await _unitOfWork.Passports.GetAllAsync();
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Passport Found!"));
            }

            return _mapper.Map<PassportVM[]>(result);
        }

        [HttpGet("GetAllBy-DateExpired")]
        public async Task<ActionResult<PassportVM[]>> GetAllExpired()
        {
            var result = await _unitOfWork.Passports.GetAllExpiredAsync();
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Passport Found!"));
            }

            return _mapper.Map<PassportVM[]>(result);
        }

        [HttpPost]
        public async Task<ActionResult<PassportVM>> Post(CreatePassportVM createPassportVM)
        {
            var passport = _mapper.Map<Passport>(createPassportVM);

            await _unitOfWork.Passports.AddAsync(passport);

            if (await _unitOfWork.SaveAsync())
            {
                var location = _linkGenerator.GetPathByAction("GetById", "Passport", values: new { passportId = passport.Id });

                return Created(location, _mapper.Map<PassportVM>(passport));
            }

            return BadRequest(new ApiResponse(400, "Failed to Add Passport!"));
        }

        [HttpPut("{passportId:int}")]
        public async Task<ActionResult<PassportVM>> Put(int passportId, UpdatePassportVM updatePassportVM)
        {
            var passport = await _unitOfWork.Passports.GetByIdAsync(passportId);
            if (passport == null)
            {
                return BadRequest(new ApiResponse(400, "Passport Not Found!"));
            }

            _mapper.Map(updatePassportVM, passport);

            _unitOfWork.Passports.Update(passport);

            if (await _unitOfWork.SaveAsync())
            {
                return _mapper.Map<PassportVM>(passport);
            }

            return BadRequest(new ApiResponse(400, "Failed to Update Passport!"));
        }

        [HttpDelete("{passportId:int}")]
        public async Task<ActionResult> Delete(int passportId)
        {
            var passport = await _unitOfWork.Passports.GetByIdAsync(passportId);
            if (passport == null)
            {
                return BadRequest(new ApiResponse(400, "Passport Not Found!"));
            }

            _unitOfWork.Passports.Delete(passport);

            if (await _unitOfWork.SaveAsync())
            {
                return Ok("Deleted Successfully.");
            }

            return BadRequest(new ApiResponse(400, "Failed to Delete Passport!"));
        }
    }
}
