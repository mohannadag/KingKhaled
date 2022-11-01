using API.Controllers.Common;
using API.Errors;
using API.ViewModels.StaffShifts.EmploymentShifts;
using API.ViewModels.StaffShifts.WorkShift;
using AutoMapper;
using Core.Models.StaffShifts;
using Data.Repositories.IRepository.IStaffShifts;
using Data.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.EmploymentShift
{
  
    public class EmploymentShiftController : MainController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EmploymentShiftController> _logger;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public EmploymentShiftController(IUnitOfWork unitOfWork, ILogger<EmploymentShiftController> logger, IMapper mapper, LinkGenerator linkGenerator)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<EmploymentShiftsVM[]>> GetAll()
        {
            var result = await _unitOfWork.EmpShifts.GetAllAsync();
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Shift  Found!"));
            }

            return _mapper.Map<EmploymentShiftsVM[]>(result);
        }
        [HttpGet("GetAllShiftForoneEmploymentByIDAsync/{EmploymentID:int}")]
        public async Task<ActionResult<EmploymentShiftsVM[]>> GetAllShiftForoneEmploymentByIDAsync(int EmploymentID)
        {
            var result = await _unitOfWork.EmpShifts.GetAllShiftForoneEmploymentByIDAsync(EmploymentID);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Shift  Found!"));
            }

            return _mapper.Map<EmploymentShiftsVM[]>(result);
        }
        [HttpGet("GetById/{workShiftID:int}")]
        public async Task<ActionResult<EmploymentShiftsVM[]>> GetById(int workShiftID)
        {
            var result = await _unitOfWork.EmpShifts.GetByIdAsync(workShiftID);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Shift  Found!"));
            }

            return _mapper.Map<EmploymentShiftsVM[]>(result);
        }
        [HttpPost]
        public async Task<ActionResult<EmploymentShiftsVM>> Post(EmploymentShiftsVM EmploymentShiftsVM)
        {
            var empshift = _mapper.Map<EmployeeShifts>(EmploymentShiftsVM);

            await _unitOfWork.EmpShifts.AddAsync(empshift);

            if (await _unitOfWork.SaveAsync())
            {
                var location = _linkGenerator.GetPathByAction("GetById", "WorkShiftController", values: new { Id = empshift.Id });

                return Created(location, _mapper.Map<EmploymentShiftsVM>(empshift));
            }

            return BadRequest(new ApiResponse(400, "Failed to Add Employee Shift!"));
        }
        [HttpPost("PostAddList")]
        public async Task<ActionResult<EmploymentShiftsVM[]>> PostAddList(EmploymentShiftsVM[] EmploymentShiftsVM)
        {
            var empshift = _mapper.Map<EmployeeShifts[]>(EmploymentShiftsVM);

            await _unitOfWork.EmpShifts.AddListAsync(empshift);

            if (await _unitOfWork.SaveAsync())
            {
                var location = _linkGenerator.GetPathByAction("PostAddListAsync", "EmploymentShiftsVM");

                return Created(location, _mapper.Map<EmploymentShiftsVM[]>(empshift));
            }

            return BadRequest(new ApiResponse(400, "Failed to Add Employee Shift!"));
        }

        [HttpPut("{ID:int}")]
        public async Task<ActionResult<UpdateEmploymentShiftsVM>> Put(int ID, UpdateEmploymentShiftsVM UpdateEmploymentShiftsVM)
        {
            var empshift = await _unitOfWork.EmpShifts.GetByIdAsync(ID);
            if (empshift == null)
            {
                return BadRequest(new ApiResponse(400, "Employee Shift Not Found!"));
            }

            var result = _mapper.Map(UpdateEmploymentShiftsVM, empshift);

            _unitOfWork.EmpShifts.Update(result);

            if (await _unitOfWork.SaveAsync())
            {
                return _mapper.Map<UpdateEmploymentShiftsVM>(result);
            }

            return BadRequest(new ApiResponse(400, "Failed to Update Employee Shift!"));
        }

        [HttpDelete("{EmpShiftsID:int}")]
        public async Task<ActionResult> Delete(int EmpShiftsID)
        {
            var EmpShifts = await _unitOfWork.EmpShifts.GetByIdAsync(EmpShiftsID);
            if (EmpShifts == null)
            {
                return BadRequest(new ApiResponse(400, "WorkShifts Not Found!"));
            }

            _unitOfWork.EmpShifts.Delete(EmpShifts);

            if (await _unitOfWork.SaveAsync())
            {
                return Ok("Deleted Successfully.");
            }

            return BadRequest(new ApiResponse(400, "Failed to Delete WorkShifts!"));
        }
    }
}
