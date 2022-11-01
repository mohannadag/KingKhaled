using API.Controllers.Common;
using API.Controllers.Requests;
using API.Errors;
using API.ViewModels.Requests;
using API.ViewModels.StaffPerformanceEvaluation;
using API.ViewModels.StaffShifts.WorkShift;
using AutoMapper;
using Core.Models.StaffPerformanceEvaluation;
using Core.Models.StaffShifts;
using Data.Repositories.IRepository.Evaluations;
using Data.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.StaffPerformanceEvaluation
{
 
    public class EvaluationController : MainController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EvaluationController> _logger;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public EvaluationController(IUnitOfWork unitOfWork, ILogger<EvaluationController> logger, IMapper mapper, LinkGenerator linkGenerator)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }
        [HttpPost]
        public async Task<ActionResult<EvaluationVM>> Post(EvaluationVM evaluationVM)
        {
            var evaluation = _mapper.Map<Evaluation>(evaluationVM);

            await _unitOfWork.Evaluation.AddAsync(evaluation);

            if (await _unitOfWork.SaveAsync())
            {
                var location = _linkGenerator.GetPathByAction("Post", "EvaluationController", values: new { Id = evaluation.Id });

                return Created(location, _mapper.Map<EvaluationVM>(evaluation));
            }

            return BadRequest(new ApiResponse(400, "Failed to Add Evaluation!"));
        }

        [HttpDelete("{evaluationID:int}")]
        public async Task<ActionResult> Delete(int evaluationID)
        {
            var evaluation = await _unitOfWork.Evaluation.GetByIdAsync(evaluationID);
            if (evaluation == null)
            {
                return BadRequest(new ApiResponse(400, "Evaluation Not Found!"));
            }

            _unitOfWork.Evaluation.Delete(evaluation);

            if (await _unitOfWork.SaveAsync())
            {
                return Ok("Deleted Successfully.");
            }

            return BadRequest(new ApiResponse(400, "Failed to Delete Evaluation!"));
        }
        [HttpGet("GetAll")]
        public async Task<ActionResult<EvaluationVM[]>> GetAll()
        {
            var result = await _unitOfWork.Evaluation.GetAllAsync();
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Shift  Found!"));
            }

            return _mapper.Map<EvaluationVM[]>(result);
        }
        [HttpGet("GetById/{id:int}")]
        public async Task<ActionResult<EvaluationVM>> GetById(int id)
        {
            var result = await _unitOfWork.Evaluation.GetByIdAsync(id);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Request Found!"));
            }

            return _mapper.Map<EvaluationVM>(result);
        }


        [HttpPut("{ID:int}")]
        public async Task<ActionResult<UpdateEvaluationVM>> Put(int ID, UpdateEvaluationVM evaluation)
        {
            var eva = await _unitOfWork.Evaluation.GetByIdAsync(ID);
            if (eva == null)
            {
                return BadRequest(new ApiResponse(400, "Evaluation Not Found!"));
            }

            var result = _mapper.Map(evaluation, eva);

            _unitOfWork.Evaluation.Update(result);

            if (await _unitOfWork.SaveAsync())
            {
                return _mapper.Map<UpdateEvaluationVM>(result);
            }

            return BadRequest(new ApiResponse(400, "Failed to Update Evaluation!"));
        }
    }
}
