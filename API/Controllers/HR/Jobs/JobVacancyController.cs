using API.Controllers.Common;
using API.Errors;
using API.ViewModels.JobGroup;
using AutoMapper;
using Core.Models.Jobs;
using Data.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers.HR.Jobs
{
    public class JobVacancyController : MainController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<JobVacancyController> _logger;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public JobVacancyController(IUnitOfWork unitOfWork, ILogger<JobVacancyController> logger, IMapper mapper, LinkGenerator linkGenerator)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("GetById/{jobVacancyId:int}")]
        public async Task<ActionResult<JobVacancyVM>> GetById(int jobVacancyId)
        {
            var result = await _unitOfWork.JobVacancy.GetByIdAsync(jobVacancyId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Job Vacancy Found!"));
            }

            return _mapper.Map<JobVacancyVM>(result);
        }

        [HttpGet("GetBy-VacantNumber/{vacantNumber:int}")]
        public async Task<ActionResult<JobVacancyVM>> GetByVacantNumber(int vacantNumber)
        {
            var result = await _unitOfWork.JobVacancy.GetByVacantNumberAsync(vacantNumber);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Job Vacancy Found!"));
            }

            return _mapper.Map<JobVacancyVM>(result);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<JobVacancyVM[]>> GetAll()
        {
            var result = await _unitOfWork.JobVacancy.GetAllAsync();
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Job Vacancy Found!"));
            }

            return _mapper.Map<JobVacancyVM[]>(result);
        }

        [HttpGet("GetAllBy-DepartmentId/{departmentId:int}")]
        public async Task<ActionResult<JobVacancyVM[]>> GetAllByDepartmentId(int departmentId)
        {
            var result = await _unitOfWork.JobVacancy.GetAllByDepartmentIdAsync(departmentId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Job Vacancy Found!"));
            }

            return _mapper.Map<JobVacancyVM[]>(result);
        }

        [HttpGet("GetAllBy-BranchId/{branchId:int}")]
        public async Task<ActionResult<JobVacancyVM[]>> GetAllByBranchId(int branchId)
        {
            var result = await _unitOfWork.JobVacancy.GetAllByBranchIdAsync(branchId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Job Vacancy Found!"));
            }

            return _mapper.Map<JobVacancyVM[]>(result);
        }

        [HttpPost]
        public async Task<ActionResult<JobVacancyVM>> Post(CreateJobVacancyVM createJobVacancyVM)
        {
            var jobVacancy = _mapper.Map<JobVacancy>(createJobVacancyVM);

            await _unitOfWork.JobVacancy.AddAsync(jobVacancy);

            if (await _unitOfWork.SaveAsync())
            {
                var location = _linkGenerator.GetPathByAction("GetById", "JobVacancy", values: new { jobVacancyId = jobVacancy.Id });

                return Created(location, _mapper.Map<JobVacancyVM>(jobVacancy));
            }

            return BadRequest(new ApiResponse(400, "Failed to Add JobVacancy!"));
        }

        [HttpPut("{jobVacancyId:int}")]
        public async Task<ActionResult<JobVacancyVM>> Put(int jobVacancyId, UpdateJobVacancyVM updateJobVacancyVM)
        {
            var jobVacancy = await _unitOfWork.JobVacancy.GetByIdAsync(jobVacancyId);
            if (jobVacancy == null)
            {
                return BadRequest(new ApiResponse(400, "JobVacancy Not Found!"));
            }

            _mapper.Map(updateJobVacancyVM, jobVacancy);

            _unitOfWork.JobVacancy.Update(jobVacancy);

            if (await _unitOfWork.SaveAsync())
            {
                return _mapper.Map<JobVacancyVM>(jobVacancy);
            }

            return BadRequest(new ApiResponse(400, "Failed to Update JobVacancy!"));
        }

        [HttpDelete("{jobVacancyId:int}")]
        public async Task<ActionResult> Delete(int jobVacancyId)
        {
            var jobVacancy = await _unitOfWork.JobVacancy.GetByIdAsync(jobVacancyId);
            if (jobVacancy == null)
            {
                return BadRequest(new ApiResponse(400, "JobVacancy Not Found!"));
            }

            _unitOfWork.JobVacancy.Delete(jobVacancy);

            if (await _unitOfWork.SaveAsync())
            {
                return Ok("Deleted Successfully.");
            }

            return BadRequest(new ApiResponse(400, "Failed to Delete JobVacancy!"));
        }
    }
}
