using API.Controllers.Common;
using API.Errors;
using API.ViewModels.Employee;
using API.ViewModels.Nationality;
using AutoMapper;
using Core.Enums;
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
    public class EmployeeController : MainController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EmployeeController> _logger;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public EmployeeController(IUnitOfWork unitOfWork, ILogger<EmployeeController> logger, IMapper mapper, LinkGenerator linkGenerator)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("GetById/{employeeId:int}")]
        public async Task<ActionResult<EmployeeVM>> GetById(int employeeId)
        {
            var result = await _unitOfWork.Employees.GetByIdAsync(employeeId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Employee Found!"));
            }

            return _mapper.Map<EmployeeVM>(result);
        }

        [HttpGet("GetBy-EmployeeNumber/{employeeNumber:int}")]
        public async Task<ActionResult<EmployeeVM>> GetByEmployeeNumber(int employeeNumber)
        {
            var result = await _unitOfWork.Employees.GetByEmployeeNumberAsync(employeeNumber);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Employee Found!"));
            }

            return _mapper.Map<EmployeeVM>(result);
        }

        [HttpGet("GetBy-GeneralNumber/{generalNumber}")]
        public async Task<ActionResult<EmployeeVM>> GetByGeneralNumber(string generalNumber)
        {
            var result = await _unitOfWork.Employees.GetByGeneralNumberAsync(generalNumber);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Employee Found!"));
            }

            return _mapper.Map<EmployeeVM>(result);
        }

        [HttpGet("GetBy-ArabicName/{arabicName}")]
        public async Task<ActionResult<EmployeeVM>> GetByArabicName(string arabicName)
        {
            var result = await _unitOfWork.Employees.GetByArabicNameAsync(arabicName);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Employee Found!"));
            }

            return _mapper.Map<EmployeeVM>(result);
        }

        [HttpGet("GetBy-EnglishName/{englishName}")]
        public async Task<ActionResult<EmployeeVM>> GetByEnglishName(string englishName)
        {
            var result = await _unitOfWork.Employees.GetByEnglishNameAsync(englishName);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Employee Found!"));
            }

            return _mapper.Map<EmployeeVM>(result);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<EmployeeVM[]>> GetAll()
        {
            var result = await _unitOfWork.Employees.GetAllAsync();
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Employees Found!"));
            }

            return _mapper.Map<EmployeeVM[]>(result);
        }

        [HttpGet("GetAllBy-Gender")]
        public async Task<ActionResult<EmployeeVM[]>> GetAllByGender(Gender gender = Gender.Male)
        {
            var result = await _unitOfWork.Employees.GetAllByGenderAsync(gender.ToString());
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Employees Found!"));
            }

            return _mapper.Map<EmployeeVM[]>(result);
        }

        [HttpGet("GetAllBy-Religion")]
        public async Task<ActionResult<EmployeeVM[]>> GetAllByReligion(Religion religion = Religion.Islam)
        {
            var result = await _unitOfWork.Employees.GetAllByReligionAsync(religion.ToString());
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Employees Found!"));
            }

            return _mapper.Map<EmployeeVM[]>(result);
        }

        [HttpGet("GetAllBy-MarritalStatus")]
        public async Task<ActionResult<EmployeeVM[]>> GetAllByMarritalStatus(MaritalStatus maritalStatus = MaritalStatus.Married)
        {
            var result = await _unitOfWork.Employees.GetAllByMarritalStatusAsync(maritalStatus.ToString());
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Employees Found!"));
            }

            return _mapper.Map<EmployeeVM[]>(result);
        }

        [HttpGet("GetAllBy-GradeId/{gradeId:int}")]
        public async Task<ActionResult<EmployeeVM[]>> GetAllByGradeId(int gradeId)
        {
            var result = await _unitOfWork.Employees.GetAllByGradeIdAsync(gradeId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Employees Found!"));
            }

            return _mapper.Map<EmployeeVM[]>(result);
        }

        [HttpGet("GetAllBy-LevelId/{levelId:int}")]
        public async Task<ActionResult<EmployeeVM[]>> GetAllByLevelId(int levelId)
        {
            var result = await _unitOfWork.Employees.GetAllByLevelIdAsync(levelId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Employees Found!"));
            }

            return _mapper.Map<EmployeeVM[]>(result);
        }

        [HttpGet("GetAllBy-GradeId-and-LevelId/{gradeId:int}/{levelId:int}")]
        public async Task<ActionResult<EmployeeVM[]>> GetAllByGradeIdAndLevelId(int gradeId, int levelId)
        {
            var result = await _unitOfWork.Employees.GetAllByGradeIdAndLevelIdAsync(gradeId, levelId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Employees Found!"));
            }

            return _mapper.Map<EmployeeVM[]>(result);
        }

        [HttpGet("GetAllBy-BranchId/{branchId:int}")]
        public async Task<ActionResult<EmployeeVM[]>> GetAllByBranchId(int branchId)
        {
            var result = await _unitOfWork.Employees.GetAllByBranchIdAsync(branchId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Employees Found!"));
            }

            return _mapper.Map<EmployeeVM[]>(result);
        }

        [HttpGet("GetAllBy-JobId/{jobId:int}")]
        public async Task<ActionResult<EmployeeVM[]>> GetAllByJobId(int jobId)
        {
            var result = await _unitOfWork.Employees.GetAllByJobIdAsync(jobId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Employees Found!"));
            }

            return _mapper.Map<EmployeeVM[]>(result);
        }

        [HttpGet("GetAllBy-NationalityId/{nationalityId:int}")]
        public async Task<ActionResult<EmployeeVM[]>> GetAllByNationalityId(int nationalityId)
        {
            var result = await _unitOfWork.Employees.GetAllByNationalityIdAsync(nationalityId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Employees Found!"));
            }

            return _mapper.Map<EmployeeVM[]>(result);
        }

        [HttpGet("GetAllBy-QualificationId/{qualificationId:int}")]
        public async Task<ActionResult<EmployeeVM[]>> GetAllByQualificationId(int qualificationId)
        {
            var result = await _unitOfWork.Employees.GetAllByQualificationIdAsync(qualificationId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Employees Found!"));
            }

            return _mapper.Map<EmployeeVM[]>(result);
        }

        [HttpPost]
        public async Task<ActionResult<EmployeeVM>> Post(CreateEmployeeVM createEmployeeVM)
        {
            var employee = _mapper.Map<Employee>(createEmployeeVM);

            await _unitOfWork.Employees.AddAsync(employee);

            if (await _unitOfWork.SaveAsync())
            {
                var location = _linkGenerator.GetPathByAction("GetById", "Employee", values: new { employeeId = employee.Id });

                return Created(location, _mapper.Map<EmployeeVM>(employee));
            }

            return BadRequest(new ApiResponse(400, "Failed to Add Employee!"));
        }

        [HttpPut("{employeeId:int}")]
        public async Task<ActionResult<EmployeeVM>> Put(int employeeId, UpdateEmployeeVM updateEmployeeVM)
        {
            var employee = await _unitOfWork.Employees.GetByIdAsync(employeeId);
            if (employee == null)
            {
                return BadRequest(new ApiResponse(400, "Employee Not Found!"));
            }

            _mapper.Map(updateEmployeeVM, employee);

            _unitOfWork.Employees.Update(employee);

            if (await _unitOfWork.SaveAsync())
            {
                return _mapper.Map<EmployeeVM>(employee);
            }

            return BadRequest(new ApiResponse(400, "Failed to Update Employee!"));
        }

        [HttpDelete("{employeeId:int}")]
        public async Task<ActionResult> Delete(int employeeId)
        {
            var employee = await _unitOfWork.Employees.GetByIdAsync(employeeId);
            if (employee == null)
            {
                return BadRequest(new ApiResponse(400, "Employee Not Found!"));
            }

            _unitOfWork.Employees.Delete(employee);

            if (await _unitOfWork.SaveAsync())
            {
                return Ok("Deleted Successfully.");
            }

            return BadRequest(new ApiResponse(400, "Failed to Delete Employee!"));
        }
    }
}
