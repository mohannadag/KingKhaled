using API.Controllers.Common;
using API.Errors;
using API.ViewModels.Branch;
using API.ViewModels.JobGroup;
using API.ViewModels.Salary;
using AutoMapper;
using Core.Models.Financial;
using Data.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers.HR.Financial.InitialSalary
{
    public class SalaryController : MainController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<SalaryController> _logger;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public SalaryController(IUnitOfWork unitOfWork, ILogger<SalaryController> logger, IMapper mapper, LinkGenerator linkGenerator)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("GetById/{salaryId:int}")]
        public async Task<ActionResult<SalaryVM>> GetById(int salaryId)
        {
            var result = await _unitOfWork.Salaries.GetByIdAsync(salaryId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Basic Salary Found!"));
            }

            return _mapper.Map<SalaryVM>(result);
        }

        [HttpGet("GetBy-GradeId-and-LevelId/{gradeId:int}/{levelId:int}")]
        public async Task<ActionResult<SalaryVM>> GetByGradeIdAndLevelId(int gradeId, int levelId)
        {
            var result = await _unitOfWork.Salaries.GetByGradeIdAndLevelIdAsync(gradeId, levelId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Basic Salary Found!"));
            }

            return _mapper.Map<SalaryVM>(result);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<SalaryVM[]>> GetAll()
        {
            var result = await _unitOfWork.Salaries.GetAllAsync();
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Basic Salary Found!"));
            }

            return _mapper.Map<SalaryVM[]>(result);
        }

        [HttpGet("GetAllBy-GradeId/{gradeId:int}")]
        public async Task<ActionResult<SalaryVM[]>> GetAllByGradeId(int gradeId)
        {
            var result = await _unitOfWork.Salaries.GetAllByGradeIdAsync(gradeId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Basic Salaries Found for this Grade!"));
            }

            return _mapper.Map<SalaryVM[]>(result);
        }

        [HttpGet("GetAllBy-LevelId/{levelId:int}")]
        public async Task<ActionResult<SalaryVM[]>> GetAllByLevelId(int levelId)
        {
            var result = await _unitOfWork.Salaries.GetAllByLevelIdAsync(levelId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Basic Salaries Found for this Level!"));
            }

            return _mapper.Map<SalaryVM[]>(result);
        }

        [HttpPost]
        public async Task<ActionResult<SalaryVM>> Post(CreateSalaryVM createSalaryVM)
        {
            var salary = _mapper.Map<Salary>(createSalaryVM);

            await _unitOfWork.Salaries.AddAsync(salary);

            if (await _unitOfWork.SaveAsync())
            {
                var location = _linkGenerator.GetPathByAction("GetById", "Salary", values: new { salaryId = salary.Id });

                return Created(location, _mapper.Map<SalaryVM>(salary));
            }

            return BadRequest(new ApiResponse(400, "Failed to Add Basic Salary!"));
        }

        [HttpPut("{salaryId:int}")]
        public async Task<ActionResult<SalaryVM>> Put(int salaryId, UpdateSalaryVM updateSalaryVM)
        {
            var salary = await _unitOfWork.Salaries.GetByIdAsync(salaryId);
            if (salary == null)
            {
                return BadRequest(new ApiResponse(400, "Basic Salary Not Found!"));
            }

            _mapper.Map(updateSalaryVM, salary);

            _unitOfWork.Salaries.Update(salary);

            if (await _unitOfWork.SaveAsync())
            {
                return _mapper.Map<SalaryVM>(salary);
            }

            return BadRequest(new ApiResponse(400, "Failed to Update Basic Salary!"));
        }

        [HttpDelete("{salaryId:int}")]
        public async Task<ActionResult> Delete(int salaryId)
        {
            var salary = await _unitOfWork.Salaries.GetByIdAsync(salaryId);
            if (salary == null)
            {
                return BadRequest(new ApiResponse(400, "Basic Salary Not Found!"));
            }

            _unitOfWork.Salaries.Delete(salary);

            if (await _unitOfWork.SaveAsync())
            {
                return Ok("Deleted Successfully.");
            }

            return BadRequest(new ApiResponse(400, "Failed to Delete Basic Salary!"));
        }
    }
}
