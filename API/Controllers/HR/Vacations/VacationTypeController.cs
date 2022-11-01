using API.Controllers.Common;
using API.Errors;
using API.ViewModels.Contracts;
using API.ViewModels.Vacations;
using AutoMapper;
using Core.Models.EmployeesInfo;
using Core.Models.Vacations;
using Data.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers.HR.Vacations
{
    public class VacationTypeController : MainController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<VacationTypeController> _logger;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public VacationTypeController(IUnitOfWork unitOfWork, ILogger<VacationTypeController> logger, IMapper mapper, LinkGenerator linkGenerator)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("GetById/{vacationTypeId:int}")]
        public async Task<ActionResult<VacationTypeVM>> GetById(int vacationTypeId)
        {
            var result = await _unitOfWork.VacationTypes.GetByIdAsync(vacationTypeId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No VacationType Found!"));
            }

            return _mapper.Map<VacationTypeVM>(result);
        }

        [HttpGet("GetBy-ArabicName/{arabicName}")]
        public async Task<ActionResult<VacationTypeVM>> GetByArabicName(string arabicName)
        {
            var result = await _unitOfWork.VacationTypes.GetByArabicNameAsync(arabicName);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No VacationType Found!"));
            }

            return _mapper.Map<VacationTypeVM>(result);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<VacationTypeVM[]>> GetAll()
        {
            var result = await _unitOfWork.VacationTypes.GetAllAsync();
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No VacationType Found!"));
            }

            return _mapper.Map<VacationTypeVM[]>(result);
        }

        [HttpPost]
        public async Task<ActionResult<VacationTypeVM>> Post(CreateVacationTypeVM createVacationTypeVM)
        {
            var vacationType = _mapper.Map<VacationType>(createVacationTypeVM);

            await _unitOfWork.VacationTypes.AddAsync(vacationType);

            if (await _unitOfWork.SaveAsync())
            {
                var location = _linkGenerator.GetPathByAction("GetById", "VacationType", values: new { vacationTypeId = vacationType.Id });

                return Created(location, _mapper.Map<VacationTypeVM>(vacationType));
            }

            return BadRequest(new ApiResponse(400, "Failed to Add VacationType!"));
        }

        [HttpPut("{vacationTypeId:int}")]
        public async Task<ActionResult<VacationTypeVM>> Put(int vacationTypeId, UpdateVacationTypeVM updateVacationTypeVM)
        {
            var vacationType = await _unitOfWork.VacationTypes.GetByIdAsync(vacationTypeId);
            if (vacationType == null)
            {
                return BadRequest(new ApiResponse(400, "VacationType Not Found!"));
            }

            _mapper.Map(updateVacationTypeVM, vacationType);

            _unitOfWork.VacationTypes.Update(vacationType);

            if (await _unitOfWork.SaveAsync())
            {
                return _mapper.Map<VacationTypeVM>(vacationType);
            }

            return BadRequest(new ApiResponse(400, "Failed to Update VacationType!"));
        }

        [HttpDelete("{vacationTypeId:int}")]
        public async Task<ActionResult> Delete(int vacationTypeId)
        {
            var vacationType = await _unitOfWork.VacationTypes.GetByIdAsync(vacationTypeId);
            if (vacationType == null)
            {
                return BadRequest(new ApiResponse(400, "VacationType Not Found!"));
            }

            _unitOfWork.VacationTypes.Delete(vacationType);

            if (await _unitOfWork.SaveAsync())
            {
                return Ok("Deleted Successfully.");
            }

            return BadRequest(new ApiResponse(400, "Failed to Delete VacationType!"));
        }
    }
}
