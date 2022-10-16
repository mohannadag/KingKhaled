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
    public class JobSubGroupController : MainController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<JobSubGroupController> _logger;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public JobSubGroupController(IUnitOfWork unitOfWork, ILogger<JobSubGroupController> logger, IMapper mapper, LinkGenerator linkGenerator)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("GetById/{jobSubGroupId:int}")]
        public async Task<ActionResult<JobSubGroupVM>> GetById(int jobSubGroupId)
        {
            var result = await _unitOfWork.JobSubGroups.GetByIdAsync(jobSubGroupId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Job Sub Group Found!"));
            }

            return _mapper.Map<JobSubGroupVM>(result);
        }

        [HttpGet("GetBy-ArabicName/{arabicName}")]
        public async Task<ActionResult<JobSubGroupVM>> GetByArabicName(string arabicName)
        {
            var result = await _unitOfWork.JobSubGroups.GetByArabicNameAsync(arabicName);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Job Sub Group Found!"));
            }

            return _mapper.Map<JobSubGroupVM>(result);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<JobSubGroupVM[]>> GetAll()
        {
            var result = await _unitOfWork.JobSubGroups.GetAllAsync();
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Job Sub Group Found!"));
            }

            return _mapper.Map<JobSubGroupVM[]>(result);
        }

        [HttpGet("GetAllBy-JobGroupId/{jobGroupId:int}")]
        public async Task<ActionResult<JobSubGroupVM[]>> GetAllByJobGroupId(int jobGroupId)
        {
            var result = await _unitOfWork.JobSubGroups.GetAllByJobGroupIdAsync(jobGroupId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Job Sub Group Found!"));
            }

            return _mapper.Map<JobSubGroupVM[]>(result);
        }

        [HttpPost]
        public async Task<ActionResult<JobSubGroupVM>> Post(CreateJobSubGroupVM createJobSubGroupVM)
        {
            var jobSubGroup = _mapper.Map<JobSubGroup>(createJobSubGroupVM);

            await _unitOfWork.JobSubGroups.AddAsync(jobSubGroup);

            if (await _unitOfWork.SaveAsync())
            {
                var location = _linkGenerator.GetPathByAction("GetById", "JobSubGroup", values: new { jobSubGroupId = jobSubGroup.Id });

                return Created(location, _mapper.Map<JobSubGroupVM>(jobSubGroup));
            }

            return BadRequest(new ApiResponse(400, "Failed to Add JobSubGroup!"));
        }

        [HttpPut("{jobSubGroupId:int}")]
        public async Task<ActionResult<JobSubGroupVM>> Put(int jobSubGroupId, UpdateJobSubGroupVM updateJobSubGroupVM)
        {
            var jobSubGroup = await _unitOfWork.JobSubGroups.GetByIdAsync(jobSubGroupId);
            if (jobSubGroup == null)
            {
                return BadRequest(new ApiResponse(400, "JobSubGroup Not Found!"));
            }

            _mapper.Map(updateJobSubGroupVM, jobSubGroup);

            _unitOfWork.JobSubGroups.Update(jobSubGroup);

            if (await _unitOfWork.SaveAsync())
            {
                return _mapper.Map<JobSubGroupVM>(jobSubGroup);
            }

            return BadRequest(new ApiResponse(400, "Failed to Update JobSubGroup!"));
        }

        [HttpDelete("{jobSubGroupId:int}")]
        public async Task<ActionResult> Delete(int jobSubGroupId)
        {
            var jobSubGroup = await _unitOfWork.JobSubGroups.GetByIdAsync(jobSubGroupId);
            if (jobSubGroup == null)
            {
                return BadRequest(new ApiResponse(400, "JobSubGroup Not Found!"));
            }

            _unitOfWork.JobSubGroups.Delete(jobSubGroup);

            if (await _unitOfWork.SaveAsync())
            {
                return Ok("Deleted Successfully.");
            }

            return BadRequest(new ApiResponse(400, "Failed to Delete JobSubGroup!"));
        }
    }
}
