using API.Errors;
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
    public class LevelController : MainController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<LevelController> _logger;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public LevelController(IUnitOfWork unitOfWork, ILogger<LevelController> logger, IMapper mapper, LinkGenerator linkGenerator)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("GetById/{levelId:int}")]
        public async Task<ActionResult<LevelVM>> GetById(int levelId)
        {
            var result = await _unitOfWork.Levels.GetByIdAsync(levelId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Level Found!"));
            }

            return _mapper.Map<LevelVM>(result);
        }

        [HttpGet("GetBy-Name/{name}")]
        public async Task<ActionResult<LevelVM>> GetByArabicName(string name)
        {
            var result = await _unitOfWork.Levels.GetByArabicNameAsync(name);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Level Found!"));
            }

            return _mapper.Map<LevelVM>(result);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<LevelVM[]>> GetAll()
        {
            var result = await _unitOfWork.Levels.GetAllAsync();
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Level Found!"));
            }

            return _mapper.Map<LevelVM[]>(result);
        }

        [HttpPost]
        public async Task<ActionResult<LevelVM>> Post(CreateLevelVM createLevelVM)
        {
            var level = _mapper.Map<Level>(createLevelVM);

            await _unitOfWork.Levels.AddAsync(level);

            if (await _unitOfWork.SaveAsync())
            {
                var location = _linkGenerator.GetPathByAction("GetById", "Level", values: new { levelId = level.Id });

                return Created(location, _mapper.Map<LevelVM>(level));
            }

            return BadRequest(new ApiResponse(400, "Failed to Add Level!"));
        }

        [HttpPut("{levelId:int}")]
        public async Task<ActionResult<LevelVM>> Put(int levelId, UpdateLevelVM updateLevelVM)
        {
            var level = await _unitOfWork.Levels.GetByIdAsync(levelId);
            if (level == null)
            {
                return BadRequest(new ApiResponse(400, "Level Not Found!"));
            }

            _mapper.Map(updateLevelVM, level);

            _unitOfWork.Levels.Update(level);

            if (await _unitOfWork.SaveAsync())
            {
                return _mapper.Map<LevelVM>(level);
            }

            return BadRequest(new ApiResponse(400, "Failed to Update Level!"));
        }

        [HttpDelete("{levelId:int}")]
        public async Task<ActionResult> Delete(int levelId)
        {
            var level = await _unitOfWork.Levels.GetByIdAsync(levelId);
            if (level == null)
            {
                return BadRequest(new ApiResponse(400, "Level Not Found!"));
            }

            _unitOfWork.Levels.Delete(level);

            if (await _unitOfWork.SaveAsync())
            {
                return Ok("Deleted Successfully.");
            }

            return BadRequest(new ApiResponse(400, "Failed to Delete Level!"));
        }
    }
}
