using API.Controllers.Common;
using API.Errors;
using API.ViewModels.StaffPerformanceEvaluation;
using AutoMapper;
using Core.Models.StaffPerformanceEvaluation;
using Data.UnitOfWorks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.StaffPerformanceEvaluation
{
 
    public class EmploymentPerformanceEvaluationController : MainController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EmploymentPerformanceEvaluationController> _logger;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public EmploymentPerformanceEvaluationController(IUnitOfWork unitOfWork, ILogger<EmploymentPerformanceEvaluationController> logger, IMapper mapper, LinkGenerator linkGenerator)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }
        [HttpPost]
        public async Task<ActionResult<EmploymentPerformanceEvaluationVM>> Post(EmploymentPerformanceEvaluationVM evaluationVM)
        {
            var evaluation = _mapper.Map<EmploymentPerformanceEvaluation>(evaluationVM);
            List<EmployeePerfomanc> employeePerfomancs = new List<EmployeePerfomanc>();
            foreach (var item in evaluationVM.EvaluationsID)
            {
                EmployeePerfomanc emp = new EmployeePerfomanc();
                emp.StaffPerformanceEvaluationID = evaluationVM.Id;
                emp.EvaluationId = item;
                employeePerfomancs.Add(emp);
            }
            await _unitOfWork.EmploymentPerformanceEvaluation.AddAsync(evaluation, employeePerfomancs);

            if (await _unitOfWork.SaveAsync())
            {
                var location = _linkGenerator.GetPathByAction("Post", "EvaluationController", values: new { Id = evaluation.Id });

                return Created(location, _mapper.Map<EmploymentPerformanceEvaluationVM>(evaluation));
            }

            return BadRequest(new ApiResponse(400, "Failed to Add Evaluation!"));
        }

        [HttpDelete("{evaluationID:int}")]
        public async Task<ActionResult> Delete(int evaluationID)
        {
            var evaluation = await _unitOfWork.EmploymentPerformanceEvaluation.GetByIdAsync(evaluationID);
            if (evaluation == null)
            {
                return BadRequest(new ApiResponse(400, "EmploymentPerformanceEvaluation Not Found!"));
            }

            _unitOfWork.EmploymentPerformanceEvaluation.Delete(evaluation);

            if (await _unitOfWork.SaveAsync())
            {
                return Ok("Deleted Successfully.");
            }

            return BadRequest(new ApiResponse(400, "Failed to Delete EmploymentPerformanceEvaluation!"));
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<EmploymentPerformanceEvaluationVM[]>> GetAll()
        {
            var result = await _unitOfWork.EmploymentPerformanceEvaluation.GetAllAsync();
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No UpdateEmploymentPerformanceEvaluation  Found!"));
            }

            return _mapper.Map<EmploymentPerformanceEvaluationVM[]>(result);
        }
        [HttpGet("GetById/{id:int}")]
        public async Task<ActionResult<EmploymentPerformanceEvaluationVM>> GetById(int id)
        {
            var result = await _unitOfWork.EmploymentPerformanceEvaluation.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Request Found!"));
            }

            return _mapper.Map<EmploymentPerformanceEvaluationVM>(result);
        }


        [HttpPut("{ID:int}")]
        public async Task<ActionResult<UpdateEmploymentPerformanceEvaluationVM>> Put(int ID, UpdateEmploymentPerformanceEvaluationVM evaluation)
        {
            var eva = await _unitOfWork.Evaluation.GetByIdAsync(ID);
            if (eva == null)
            {
                return BadRequest(new ApiResponse(400, "UpdateEmploymentPerformanceEvaluation Not Found!"));
            }

            var result = _mapper.Map(evaluation, eva);

            _unitOfWork.Evaluation.Update(result);

            if (await _unitOfWork.SaveAsync())
            {
                return _mapper.Map<UpdateEmploymentPerformanceEvaluationVM>(result);
            }

            return BadRequest(new ApiResponse(400, "Failed to Update UpdateEmploymentPerformanceEvaluation!"));
        }
    }
}
