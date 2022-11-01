using API.Controllers.Common;
using API.Errors;
using API.ViewModels.JobGroup;
using API.ViewModels.Qualification;
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
    public class JobVisaController : MainController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<JobVisaController> _logger;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public JobVisaController(IUnitOfWork unitOfWork, ILogger<JobVisaController> logger, IMapper mapper, LinkGenerator linkGenerator)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("GetById/{jobVisaId:int}")]
        public async Task<ActionResult<JobVisaVM>> GetById(int jobVisaId)
        {
            var result = await _unitOfWork.JobVisa.GetByIdAsync(jobVisaId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No JobVisa Found!"));
            }

            return _mapper.Map<JobVisaVM>(result);
        }

        [HttpGet("GetBy-Name/{name}")]
        public async Task<ActionResult<JobVisaVM>> GetByArabicName(string name)
        {
            var result = await _unitOfWork.JobVisa.GetByNameAsync(name);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No JobVisa Found!"));
            }

            return _mapper.Map<JobVisaVM>(result);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<JobVisaVM[]>> GetAll()
        {
            var result = await _unitOfWork.JobVisa.GetAllAsync();
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No JobVisa Found!"));
            }

            return _mapper.Map<JobVisaVM[]>(result);
        }

        [HttpPost]
        public async Task<ActionResult<JobVisaVM>> Post(CreateJobVisaVM createJobVisaVM)
        {
            var jobVisa = _mapper.Map<JobVisa>(createJobVisaVM);

            await _unitOfWork.JobVisa.AddAsync(jobVisa);

            if (await _unitOfWork.SaveAsync())
            {
                var location = _linkGenerator.GetPathByAction("GetById", "JobVisa", values: new { jobVisaId = jobVisa.Id });

                return Created(location, _mapper.Map<JobVisaVM>(jobVisa));
            }

            return BadRequest(new ApiResponse(400, "Failed to Add JobVisa!"));
        }

        [HttpPut("{jobVisaId:int}")]
        public async Task<ActionResult<JobVisaVM>> Put(int jobVisaId, UpdateJobVisaVM updateJobVisaVM)
        {
            var jobVisa = await _unitOfWork.JobVisa.GetByIdAsync(jobVisaId);
            if (jobVisa == null)
            {
                return BadRequest(new ApiResponse(400, "JobVisa Not Found!"));
            }

            _mapper.Map(updateJobVisaVM, jobVisa);

            _unitOfWork.JobVisa.Update(jobVisa);

            if (await _unitOfWork.SaveAsync())
            {
                return _mapper.Map<JobVisaVM>(jobVisa);
            }

            return BadRequest(new ApiResponse(400, "Failed to Update JobVisa!"));
        }

        [HttpDelete("{jobVisaId:int}")]
        public async Task<ActionResult> Delete(int jobVisaId)
        {
            var jobVisa = await _unitOfWork.JobVisa.GetByIdAsync(jobVisaId);
            if (jobVisa == null)
            {
                return BadRequest(new ApiResponse(400, "JobVisa Not Found!"));
            }

            _unitOfWork.JobVisa.Delete(jobVisa);

            if (await _unitOfWork.SaveAsync())
            {
                return Ok("Deleted Successfully.");
            }

            return BadRequest(new ApiResponse(400, "Failed to Delete JobVisa!"));
        }
    }
}
