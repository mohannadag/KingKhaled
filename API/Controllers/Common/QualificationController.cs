using API.Errors;
using API.ViewModels.JobGroup;
using API.ViewModels.Qualification;
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
    public class QualificationController : MainController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<QualificationController> _logger;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public QualificationController(IUnitOfWork unitOfWork, ILogger<QualificationController> logger, IMapper mapper, LinkGenerator linkGenerator)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("GetById/{qualificationId:int}")]
        public async Task<ActionResult<QualificationVM>> GetById(int qualificationId)
        {
            var result = await _unitOfWork.Qualifications.GetByIdAsync(qualificationId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Qualification Found!"));
            }

            return _mapper.Map<QualificationVM>(result);
        }

        [HttpGet("GetBy-Name/{name}")]
        public async Task<ActionResult<QualificationVM>> GetByArabicName(string name)
        {
            var result = await _unitOfWork.Qualifications.GetByNameAsync(name);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Qualification Found!"));
            }

            return _mapper.Map<QualificationVM>(result);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<QualificationVM[]>> GetAll()
        {
            var result = await _unitOfWork.Qualifications.GetAllAsync();
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Qualification Found!"));
            }

            return _mapper.Map<QualificationVM[]>(result);
        }

        [HttpPost]
        public async Task<ActionResult<QualificationVM>> Post(CreateQualificationVM createQualificationVM)
        {
            var qualification = _mapper.Map<Qualification>(createQualificationVM);

            await _unitOfWork.Qualifications.AddAsync(qualification);

            if (await _unitOfWork.SaveAsync())
            {
                var location = _linkGenerator.GetPathByAction("GetById", "Qualification", values: new { qualificationId = qualification.Id });

                return Created(location, _mapper.Map<QualificationVM>(qualification));
            }

            return BadRequest(new ApiResponse(400, "Failed to Add Qualification!"));
        }

        [HttpPut("{qualificationId:int}")]
        public async Task<ActionResult<QualificationVM>> Put(int qualificationId, UpdateQualificationVM updateQualificationVM)
        {
            var qualification = await _unitOfWork.Qualifications.GetByIdAsync(qualificationId);
            if (qualification == null)
            {
                return BadRequest(new ApiResponse(400, "Qualification Not Found!"));
            }

            _mapper.Map(updateQualificationVM, qualification);

            _unitOfWork.Qualifications.Update(qualification);

            if (await _unitOfWork.SaveAsync())
            {
                return _mapper.Map<QualificationVM>(qualification);
            }

            return BadRequest(new ApiResponse(400, "Failed to Update QualificationVM!"));
        }
    }
}
