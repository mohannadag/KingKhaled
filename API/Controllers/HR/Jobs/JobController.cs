using API.Controllers.Common;
using API.Errors;
using API.ViewModels.JobGroup;
using API.ViewModels.Nationality;
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
    public class JobController : MainController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<JobController> _logger;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public JobController(IUnitOfWork unitOfWork, ILogger<JobController> logger, IMapper mapper, LinkGenerator linkGenerator)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("GetById/{jobId:int}")]
        public async Task<ActionResult<JobVM>> GetById(int jobId)
        {
            var result = await _unitOfWork.Jobs.GetByIdAsync(jobId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Jobs Found!"));
            }

            return _mapper.Map<JobVM>(result);
        }

        [HttpGet("GetBy-Code/{code}")]
        public async Task<ActionResult<JobVM>> GetByCode(string code)
        {
            var result = await _unitOfWork.Jobs.GetByCodeAsync(code);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Job Found!"));
            }

            return _mapper.Map<JobVM>(result);
        }

        [HttpGet("GetBy-ArabicName/{arabicName}")]
        public async Task<ActionResult<JobVM>> GetByArabicName(string arabicName)
        {
            var result = await _unitOfWork.Jobs.GetByArabicNameAsync(arabicName);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Job Found!"));
            }

            return _mapper.Map<JobVM>(result);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<JobVM[]>> GetAll()
        {
            var result = await _unitOfWork.Jobs.GetAllAsync();
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Jobs Found!"));
            }

            return _mapper.Map<JobVM[]>(result);
        }

        [HttpGet("GetAllBy-JobGroupId/{jobGroupId:int}")]
        public async Task<ActionResult<JobVM[]>> GetAllByJobGroupId(int jobGroupId)
        {
            var result = await _unitOfWork.Jobs.GetAllByJobGroupIdAsync(jobGroupId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Job Found!"));
            }

            return _mapper.Map<JobVM[]>(result);
        }

        [HttpGet("GetAllBy-JobSubGroupId/{jobSubGroupId:int}")]
        public async Task<ActionResult<JobVM[]>> GetAllByJobSubGroupId(int jobSubGroupId)
        {
            var result = await _unitOfWork.Jobs.GetAllByJobSubGroupIdAsync(jobSubGroupId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Job Found!"));
            }

            return _mapper.Map<JobVM[]>(result);
        }

        [HttpGet("GetAllBy-MinGradeId/{minGradeId:int}")]
        public async Task<ActionResult<JobVM[]>> GetAllByMinGradeId(int minGradeId)
        {
            var result = await _unitOfWork.Jobs.GetAllByMinGradeIdAsync(minGradeId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Job Found!"));
            }

            return _mapper.Map<JobVM[]>(result);
        }

        [HttpGet("GetAllBy-MaxGradeId/{maxGradeId:int}")]
        public async Task<ActionResult<JobVM[]>> GetAllByMaxGradeId(int maxGradeId)
        {
            var result = await _unitOfWork.Jobs.GetAllByMaxGradeIdAsync(maxGradeId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Job Found!"));
            }

            return _mapper.Map<JobVM[]>(result);
        }

        [HttpGet("GetAllBy-WorkNatureAllowance")]
        public async Task<ActionResult<JobVM[]>> GetAllByMaxGradeId(bool? haveWorkNatureAllowance)
        {
            var result = await _unitOfWork.Jobs.GetAllByWorkNatureAllowanceAsync(haveWorkNatureAllowance);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Job Found!"));
            }

            return _mapper.Map<JobVM[]>(result);
        }

        [HttpPost]
        public async Task<ActionResult<JobVM>> Post(CreateJobVM createJobVM)
        {
            var job = _mapper.Map<Job>(createJobVM);

            await _unitOfWork.Jobs.AddAsync(job);

            if (await _unitOfWork.SaveAsync())
            {
                var location = _linkGenerator.GetPathByAction("GetById", "Job", values: new { jobId = job.Id });

                return Created(location, _mapper.Map<JobVM>(job));
            }

            return BadRequest(new ApiResponse(400, "Failed to Add Job!"));
        }

        [HttpPut("{jobId:int}")]
        public async Task<ActionResult<JobVM>> Put(int jobId, UpdateJobVM updateJobVM)
        {
            var job = await _unitOfWork.Jobs.GetByIdAsync(jobId);
            if (job == null)
            {
                return BadRequest(new ApiResponse(400, "Job Not Found!"));
            }

            _mapper.Map(updateJobVM, job);

            //await _unitOfWork.Jobs.UpdateJobGradesAsync(job);

            await _unitOfWork.Jobs.UpdateAsync(job);

            if (await _unitOfWork.SaveAsync())
            {
                return _mapper.Map<JobVM>(job);
            }

            return BadRequest(new ApiResponse(400, "Failed to Update Job!"));
        }

        [HttpDelete("{jobId:int}")]
        public async Task<ActionResult> Delete(int jobId)
        {
            var job = await _unitOfWork.Jobs.GetByIdAsync(jobId);
            if (job == null)
            {
                return BadRequest(new ApiResponse(400, "Job Not Found!"));
            }

            _unitOfWork.Jobs.Delete(job);

            if (await _unitOfWork.SaveAsync())
            {
                return Ok("Deleted Successfully.");
            }

            return BadRequest(new ApiResponse(400, "Failed to Delete Job!"));
        }
    }
}
