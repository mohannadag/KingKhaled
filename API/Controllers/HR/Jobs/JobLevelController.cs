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
    public class JobLevelController : MainController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<JobLevelController> _logger;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public JobLevelController(IUnitOfWork unitOfWork, ILogger<JobLevelController> logger, IMapper mapper, LinkGenerator linkGenerator)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("GetById/{jobLevelId:int}")]
        public async Task<ActionResult<JobLevelVM>> GetById(int jobLevelId)
        {
            var result = await _unitOfWork.JobLevels.GetByIdAsync(jobLevelId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No JobLevel Found!"));
            }

            return _mapper.Map<JobLevelVM>(result);
        }

        [HttpGet("GetBy-Name/{name}")]
        public async Task<ActionResult<JobLevelVM>> GetByArabicName(string name)
        {
            var result = await _unitOfWork.JobLevels.GetByNameAsync(name);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No JobLevel Found!"));
            }

            return _mapper.Map<JobLevelVM>(result);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<JobLevelVM[]>> GetAll()
        {
            var result = await _unitOfWork.JobLevels.GetAllAsync();
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No JobLevel Found!"));
            }

            return _mapper.Map<JobLevelVM[]>(result);
        }

        [HttpPost]
        public async Task<ActionResult<JobLevelVM>> Post(CreateJobLevelVM createJobLevelVM)
        {
            var jobLevel = _mapper.Map<JobLevel>(createJobLevelVM);

            await _unitOfWork.JobLevels.AddAsync(jobLevel);

            if (await _unitOfWork.SaveAsync())
            {
                var location = _linkGenerator.GetPathByAction("GetById", "JobLevel", values: new { jobLevelId = jobLevel.Id });

                return Created(location, _mapper.Map<JobLevelVM>(jobLevel));
            }

            return BadRequest(new ApiResponse(400, "Failed to Add JobLevel!"));
        }

        [HttpPut("{jobLevelId:int}")]
        public async Task<ActionResult<JobLevelVM>> Put(int jobLevelId, UpdateJobVisaVM updateJobVisaVM)
        {
            var jobLevel = await _unitOfWork.JobLevels.GetByIdAsync(jobLevelId);
            if (jobLevel == null)
            {
                return BadRequest(new ApiResponse(400, "JobLevel Not Found!"));
            }

            _mapper.Map(updateJobVisaVM, jobLevel);

            _unitOfWork.JobLevels.Update(jobLevel);

            if (await _unitOfWork.SaveAsync())
            {
                return _mapper.Map<JobLevelVM>(jobLevel);
            }

            return BadRequest(new ApiResponse(400, "Failed to Update JobLevel!"));
        }

        [HttpDelete("{jobLevelId:int}")]
        public async Task<ActionResult> Delete(int jobLevelId)
        {
            var jobLevel = await _unitOfWork.JobLevels.GetByIdAsync(jobLevelId);
            if (jobLevel == null)
            {
                return BadRequest(new ApiResponse(400, "JobLevel Not Found!"));
            }

            _unitOfWork.JobLevels.Delete(jobLevel);

            if (await _unitOfWork.SaveAsync())
            {
                return Ok("Deleted Successfully.");
            }

            return BadRequest(new ApiResponse(400, "Failed to Delete JobLevel!"));
        }
    }
}
