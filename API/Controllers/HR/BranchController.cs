using API.Controllers.Common;
using API.Errors;
using API.ViewModels.Branch;
using API.ViewModels.Department;
using AutoMapper;
using Core.Models;
using Data.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers.HR
{
    public class BranchController : MainController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<BranchController> _logger;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public BranchController(IUnitOfWork unitOfWork, ILogger<BranchController> logger, IMapper mapper, LinkGenerator linkGenerator)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("GetById/{branchId:int}")]
        public async Task<ActionResult<BranchVM>> GetById(int branchId)
        {
            var result = await _unitOfWork.Branches.GetByIdAsync(branchId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Branch Found!"));
            }

            return _mapper.Map<BranchVM>(result);
        }

        [HttpGet("GetBy-ArabicName/{arabicName}")]
        public async Task<ActionResult<BranchVM>> GetByArabicName(string arabicName)
        {
            var result = await _unitOfWork.Branches.GetByArabicNameAsync(arabicName);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Branch Found!"));
            }

            return _mapper.Map<BranchVM>(result);
        }

        [HttpGet("GetBy-EnglishName/{englishName}")]
        public async Task<ActionResult<BranchVM>> GetByEnglishName(string englishName)
        {
            var result = await _unitOfWork.Branches.GetByEnglishNameAsync(englishName);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Branch Found!"));
            }

            return _mapper.Map<BranchVM>(result);
        }

        [HttpGet("GetBy-ShortArName/{shortArName}")]
        public async Task<ActionResult<BranchVM>> GetByShortArabicName(string shortArName)
        {
            var result = await _unitOfWork.Departments.GetByShortArNameAsync(shortArName);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Branch Found!"));
            }

            return _mapper.Map<BranchVM>(result);
        }

        [HttpGet("GetBy-ShortEnName/{shortEnName}")]
        public async Task<ActionResult<BranchVM>> GetByShortEnglishName(string shortEnName)
        {
            var result = await _unitOfWork.Branches.GetByShortEnNameAsync(shortEnName);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Branch Found!"));
            }

            return _mapper.Map<BranchVM>(result);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<BranchVM[]>> GetAll()
        {
            var result = await _unitOfWork.Branches.GetAllAsync();
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Branch Found!"));
            }

            return _mapper.Map<BranchVM[]>(result);
        }

        [HttpPost]
        public async Task<ActionResult<BranchVM>> Post(CreateBranchVM createBranchVM)
        {
            var branch = _mapper.Map<Branch>(createBranchVM);

            await _unitOfWork.Branches.AddAsync(branch);

            if (await _unitOfWork.SaveAsync())
            {
                var location = _linkGenerator.GetPathByAction("GetById", "Branch", values: new { branchId = branch.Id });

                return Created(location, _mapper.Map<BranchVM>(branch));
            }

            return BadRequest(new ApiResponse(400, "Failed to Add Branch!"));
        }

        [HttpPut("{branchId:int}")]
        public async Task<ActionResult<BranchVM>> Put(int branchId, UpdateBranchVM updateBranchVM)
        {
            var branch = await _unitOfWork.Branches.GetByIdAsync(branchId);
            if (branch == null)
            {
                return BadRequest(new ApiResponse(400, "Branch Not Found!"));
            }

            _mapper.Map(updateBranchVM, branch);

            _unitOfWork.Branches.Update(branch);

            if (await _unitOfWork.SaveAsync())
            {
                return _mapper.Map<BranchVM>(branch);
            }

            return BadRequest(new ApiResponse(400, "Failed to Update Branch!"));
        }

        [HttpDelete("{branchId:int}")]
        public async Task<ActionResult> Delete(int branchId)
        {
            var branch = await _unitOfWork.Branches.GetByIdAsync(branchId);
            if (branch == null)
            {
                return BadRequest(new ApiResponse(400, "Branch Not Found!"));
            }

            _unitOfWork.Branches.Delete(branch);

            if (await _unitOfWork.SaveAsync())
            {
                return Ok("Deleted Successfully.");
            }

            return BadRequest(new ApiResponse(400, "Failed to Delete Branch!"));
        }
    }
}
