using API.Errors;
using API.ViewModels.Bank;
using API.ViewModels.JobGroup;
using AutoMapper;
using Core.Models;
using Data.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers.Common
{
    public class JobGroupController : MainController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<JobGroupController> _logger;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public JobGroupController(IUnitOfWork unitOfWork, ILogger<JobGroupController> logger, IMapper mapper, LinkGenerator linkGenerator)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("GetById/{jobGroupId:int}")]
        public async Task<ActionResult<JobGroupVM>> GetById(int jobGroupId)
        {
            var result = await _unitOfWork.JobGroups.GetByIdAsync(jobGroupId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Job Group Found!"));
            }

            return _mapper.Map<JobGroupVM>(result);
        }

        [HttpGet("GetBy-ArabicName/{arabicName}")]
        public async Task<ActionResult<JobGroupVM>> GetByArabicName(string arabicName)
        {
            var result = await _unitOfWork.JobGroups.GetByArabicNameAsync(arabicName);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Job Group Found!"));
            }

            return _mapper.Map<JobGroupVM>(result);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<JobGroupVM[]>> GetAll()
        {
            var result = await _unitOfWork.JobGroups.GetAllAsync();
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Job Group Found!"));
            }

            return _mapper.Map<JobGroupVM[]>(result);
        }

        [HttpPost]
        public async Task<ActionResult<JobGroupVM>> Post(CreateJobGroupVM createJobGroupVM)
        {
            var jobGroup = _mapper.Map<JobGroup>(createJobGroupVM);

            await _unitOfWork.JobGroups.AddAsync(jobGroup);

            if (await _unitOfWork.SaveAsync())
            {
                var location = _linkGenerator.GetPathByAction("GetById", "JobGroup", values: new { jobGroupId = jobGroup.Id });

                return Created(location, _mapper.Map<JobGroupVM>(jobGroup));
            }

            return BadRequest(new ApiResponse(400, "Failed to Add JobGroup!"));
        }

        [HttpPut("{jobGroupId:int}")]
        public async Task<ActionResult<JobGroupVM>> Put(int jobGroupId, UpdateJobGroupVM updateJobGroupVM)
        {
            var jobGroup = await _unitOfWork.JobGroups.GetByIdAsync(jobGroupId);
            if (jobGroup == null)
            {
                return BadRequest(new ApiResponse(400, "JobGroup Not Found!"));
            }

            _mapper.Map(updateJobGroupVM, jobGroup);

            _unitOfWork.JobGroups.Update(jobGroup);

            if (await _unitOfWork.SaveAsync())
            {
                return _mapper.Map<JobGroupVM>(jobGroup);
            }

            return BadRequest(new ApiResponse(400, "Failed to Update JobGroup!"));
        }

        [HttpDelete("{jobGroupId:int}")]
        public async Task<ActionResult> Delete(int jobGroupId)
        {
            var jobGroup = await _unitOfWork.JobGroups.GetByIdAsync(jobGroupId);
            if (jobGroup == null)
            {
                return BadRequest(new ApiResponse(400, "JobGroup Not Found!"));
            }

            _unitOfWork.JobGroups.Delete(jobGroup);

            if (await _unitOfWork.SaveAsync())
            {
                return Ok("Deleted Successfully.");
            }

            return BadRequest(new ApiResponse(400, "Failed to Delete JobGroup!"));
        }
    }
}
