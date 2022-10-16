using API.Errors;
using API.ViewModels.Department;
using API.ViewModels.JobGroup;
using AutoMapper;
using Core.Models.General;
using Data.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers.Common
{
    public class DepartmentController : MainController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<DepartmentController> _logger;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public DepartmentController(IUnitOfWork unitOfWork, ILogger<DepartmentController> logger, IMapper mapper, LinkGenerator linkGenerator)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("GetById/{departmentId:int}")]
        public async Task<ActionResult<DepartmentVM>> GetById(int departmentId)
        {
            var result = await _unitOfWork.Departments.GetByIdAsync(departmentId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Department Found!"));
            }

            return _mapper.Map<DepartmentVM>(result);
        }

        [HttpGet("GetBy-ArabicName/{arabicName}")]
        public async Task<ActionResult<DepartmentVM>> GetByArabicName(string arabicName)
        {
            var result = await _unitOfWork.Departments.GetByArabicNameAsync(arabicName);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Department Found!"));
            }

            return _mapper.Map<DepartmentVM>(result);
        }

        [HttpGet("GetBy-EnglishName/{englishName}")]
        public async Task<ActionResult<DepartmentVM>> GetByEnglishName(string englishName)
        {
            var result = await _unitOfWork.Departments.GetByEnglishNameAsync(englishName);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Department Found!"));
            }

            return _mapper.Map<DepartmentVM>(result);
        }

        [HttpGet("GetBy-ShortArName/{shortArName}")]
        public async Task<ActionResult<DepartmentVM>> GetByShortArabicName(string shortArName)
        {
            var result = await _unitOfWork.Departments.GetByShortArNameAsync(shortArName);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Department Found!"));
            }

            return _mapper.Map<DepartmentVM>(result);
        }

        [HttpGet("GetBy-ShortEnName/{shortEnName}")]
        public async Task<ActionResult<DepartmentVM>> GetByShortEnglishName(string shortEnName)
        {
            var result = await _unitOfWork.Departments.GetByShortEnNameAsync(shortEnName);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Department Found!"));
            }

            return _mapper.Map<DepartmentVM>(result);
        }


        [HttpGet("GetAll")]
        public async Task<ActionResult<DepartmentVM[]>> GetAll()
        {
            var result = await _unitOfWork.Departments.GetAllAsync();
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Departments Found!"));
            }

            return _mapper.Map<DepartmentVM[]>(result);
        }

        [HttpPost]
        public async Task<ActionResult<DepartmentVM>> Post(CreateDepartmentVM createDepartmentVM)
        {
            var department = _mapper.Map<Department>(createDepartmentVM);

            await _unitOfWork.Departments.AddAsync(department);

            if (await _unitOfWork.SaveAsync())
            {
                var location = _linkGenerator.GetPathByAction("GetById", "Department", values: new { departmentId = department.Id });

                return Created(location, _mapper.Map<DepartmentVM>(department));
            }

            return BadRequest(new ApiResponse(400, "Failed to Add Departments!"));
        }

        [HttpPut("{departmentId:int}")]
        public async Task<ActionResult<DepartmentVM>> Put(int departmentId, UpdateDepartmentVM updateDepartmentVM)
        {
            var department = await _unitOfWork.Departments.GetByIdAsync(departmentId);
            if (department == null)
            {
                return BadRequest(new ApiResponse(400, "Department Not Found!"));
            }

            _mapper.Map(updateDepartmentVM, department);

            _unitOfWork.Departments.Update(department);

            if (await _unitOfWork.SaveAsync())
            {
                return _mapper.Map<DepartmentVM>(department);
            }

            return BadRequest(new ApiResponse(400, "Failed to Update Department!"));
        }

        [HttpDelete("{departmentId:int}")]
        public async Task<ActionResult> Delete(int departmentId)
        {
            var department = await _unitOfWork.Departments.GetByIdAsync(departmentId);
            if (department == null)
            {
                return BadRequest(new ApiResponse(400, "Department Not Found!"));
            }

            _unitOfWork.Departments.Delete(department);

            if (await _unitOfWork.SaveAsync())
            {
                return Ok("Deleted Successfully.");
            }

            return BadRequest(new ApiResponse(400, "Failed to Delete Department!"));
        }
    }
}
