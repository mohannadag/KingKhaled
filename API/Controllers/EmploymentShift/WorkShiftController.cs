using API.Controllers.Common;
using API.Errors;
using API.ViewModels.EmployeeAccount;
using API.ViewModels.StaffShifts.WorkShift;
using AutoMapper;
using Core.Models.EmployeesInfo;
using Core.Models.StaffShifts;
using Data.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.EmploymentShift
{
  
    public class WorkShiftController : MainController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<WorkShiftController> _logger;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public WorkShiftController(IUnitOfWork unitOfWork, ILogger<WorkShiftController> logger, IMapper mapper, LinkGenerator linkGenerator)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<WorkShiftsVM[]>> GetAll()
        {
            var result = await _unitOfWork.WorkShifts.GetAllAsync();
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Shift  Found!"));
            }

            return _mapper.Map<WorkShiftsVM[]>(result);
        }
        [HttpGet("GetById/{workShiftID:int}")]
        public async Task<ActionResult<WorkShiftsVM[]>> GetById(int workShiftID)
        {
            var result = await _unitOfWork.WorkShifts.GetByIdAsync(workShiftID);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Shift  Found!"));
            }

            return _mapper.Map<WorkShiftsVM[]>(result);
        }
        [HttpPost]
        public async Task<ActionResult<WorkShiftsVM>> Post(WorkShiftsVM WorkShiftsVm)
        {
            var WorkShifts = _mapper.Map<WorkShifts>(WorkShiftsVm);

            await _unitOfWork.WorkShifts.AddAsync(WorkShifts);

            if (await _unitOfWork.SaveAsync())
            {
                var location = _linkGenerator.GetPathByAction("GetById", "WorkShiftController", values: new { Id = WorkShifts.Id });

                return Created(location, _mapper.Map<WorkShiftsVM>(WorkShiftsVm));
            }

            return BadRequest(new ApiResponse(400, "Failed to Add Employee Account!"));
        }

        [HttpPut("{WorkShifts:int}")]
        public async Task<ActionResult<UpdateWorkShiftVM>> Put(int ID, UpdateWorkShiftVM WorkShiftsVM)
        {
            var WorkShifts = await _unitOfWork.WorkShifts.GetByIdAsync(ID);
            if (WorkShifts == null)
            {
                return BadRequest(new ApiResponse(400, "Work Shifts Not Found!"));
            }

            var result = _mapper.Map(WorkShiftsVM, WorkShifts);

            _unitOfWork.WorkShifts.Update(result);

            if (await _unitOfWork.SaveAsync())
            {
                return _mapper.Map<UpdateWorkShiftVM>(result);
            }

            return BadRequest(new ApiResponse(400, "Failed to Update WorkShifts!"));
        }

        [HttpDelete("{employeeAccountId:int}")]
        public async Task<ActionResult> Delete(int employeeAccountId)
        {
            var employeeAccount = await _unitOfWork.WorkShifts.GetByIdAsync(employeeAccountId);
            if (employeeAccount == null)
            {
                return BadRequest(new ApiResponse(400, "WorkShifts Not Found!"));
            }

            _unitOfWork.WorkShifts.Delete(employeeAccount);

            if (await _unitOfWork.SaveAsync())
            {
                return Ok("Deleted Successfully.");
            }

            return BadRequest(new ApiResponse(400, "Failed to Delete WorkShifts!"));
        }
    }
   
}
