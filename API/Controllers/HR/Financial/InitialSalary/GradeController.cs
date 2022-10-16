using API.Controllers.Common;
using API.Errors;
using API.ViewModels.Bank;
using API.ViewModels.JobGroup;
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
    public class GradeController : MainController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<GradeController> _logger;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public GradeController(IUnitOfWork unitOfWork, ILogger<GradeController> logger, IMapper mapper, LinkGenerator linkGenerator)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("GetById/{gradeId:int}")]
        public async Task<ActionResult<GradeVM>> GetById(int gradeId)
        {
            var result = await _unitOfWork.Grades.GetByIdAsync(gradeId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Grade Found!"));
            }

            return _mapper.Map<GradeVM>(result);
        }

        [HttpGet("GetBy-Name/{name}")]
        public async Task<ActionResult<GradeVM>> GetByArabicName(string name)
        {
            var result = await _unitOfWork.Grades.GetByArabicNameAsync(name);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Grade Found!"));
            }

            return _mapper.Map<GradeVM>(result);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<GradeVM[]>> GetAll()
        {
            var result = await _unitOfWork.Grades.GetAllAsync();
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Grade Found!"));
            }

            return _mapper.Map<GradeVM[]>(result);
        }

        [HttpPost]
        public async Task<ActionResult<GradeVM>> Post(CreateGradeVM createGradeVM)
        {
            var grade = _mapper.Map<Grade>(createGradeVM);

            await _unitOfWork.Grades.AddAsync(grade);

            if (await _unitOfWork.SaveAsync())
            {
                var location = _linkGenerator.GetPathByAction("GetById", "Grade", values: new { gradeId = grade.Id });

                return Created(location, _mapper.Map<GradeVM>(grade));
            }

            return BadRequest(new ApiResponse(400, "Failed to Add Grade!"));
        }

        [HttpPut("{gradeId:int}")]
        public async Task<ActionResult<GradeVM>> Put(int gradeId, UpdateGradeVM updateGradeVM)
        {
            var grade = await _unitOfWork.Grades.GetByIdAsync(gradeId);
            if (grade == null)
            {
                return BadRequest(new ApiResponse(400, "Grade Not Found!"));
            }

            _mapper.Map(updateGradeVM, grade);

            _unitOfWork.Grades.Update(grade);

            if (await _unitOfWork.SaveAsync())
            {
                return _mapper.Map<GradeVM>(grade);
            }

            return BadRequest(new ApiResponse(400, "Failed to Update Grade!"));
        }

        [HttpDelete("{gradeId:int}")]
        public async Task<ActionResult> Delete(int gradeId)
        {
            var grade = await _unitOfWork.Grades.GetByIdAsync(gradeId);
            if (grade == null)
            {
                return BadRequest(new ApiResponse(400, "Grade Not Found!"));
            }

            _unitOfWork.Grades.Delete(grade);

            if (await _unitOfWork.SaveAsync())
            {
                return Ok("Deleted Successfully.");
            }

            return BadRequest(new ApiResponse(400, "Failed to Delete Grade!"));
        }
    }
}
