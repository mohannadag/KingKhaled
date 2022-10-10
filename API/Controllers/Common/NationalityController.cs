using API.Errors;
using API.ViewModels.Nationality;
using AutoMapper;
using Core.Models;
using Data.UnitOfWorks;
using FluentValidation;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers.Common
{
    public class NationalityController : MainController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<NationalityController> _logger;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public NationalityController(IUnitOfWork unitOfWork, ILogger<NationalityController> logger, IMapper mapper, 
                                     LinkGenerator linkGenerator)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("GetBy-Id/{nationalityId:int}")]
        public async Task<ActionResult<NationalityVM>> GetById(int nationalityId)
        {
            var result = await _unitOfWork.Nationalities.GetByIdAsync(nationalityId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Nationality Found!"));
            }

            return _mapper.Map<NationalityVM>(result);
        }

        [HttpGet("GetBy-ArabicName/{arabicName}")]
        public async Task<ActionResult<NationalityVM>> GetByArabicName(string arabicName)
        {
            var result = await _unitOfWork.Nationalities.GetByArNameAsync(arabicName);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Nationality Found!"));
            }

            return _mapper.Map<NationalityVM>(result);
        }

        [HttpGet("GetBy-EnglishName/{englishName}")]
        public async Task<ActionResult<NationalityVM>> GetByEnglishName(string englishName)
        {
            var result = await _unitOfWork.Nationalities.GetByEnNameAsync(englishName);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Nationality Found!"));
            }

            return _mapper.Map<NationalityVM>(result);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<NationalityVM[]>> GetAll()
        {
            var result = await _unitOfWork.Nationalities.GetAllAsync();
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Nationality Found!"));
            }

            return _mapper.Map<NationalityVM[]>(result);
        }
        
        [HttpPost]
        public async Task<ActionResult<NationalityVM>> Post(CreateNationalityVM createNationalityVM)
        {
            var nationality = _mapper.Map<Nationality>(createNationalityVM);

            await _unitOfWork.Nationalities.AddAsync(nationality);

            if (await _unitOfWork.SaveAsync())
            {
                var location = _linkGenerator.GetPathByAction("GetBy-Id", "Nationality", values: new { nationalityId = nationality.Id });

                return Created(location, _mapper.Map<NationalityVM>(nationality));
            }

            return BadRequest(new ApiResponse(400, "Failed to Add Nationality!"));
        }

        [HttpPut("{nationalityId:int}")]
        public async Task<ActionResult<NationalityVM>> Put(int nationalityId, UpdateNationalityVM updateNationalityVM)
        {
            var nationality = await _unitOfWork.Nationalities.GetByIdAsync(nationalityId);
            if (nationality == null)
            {
                return BadRequest(new ApiResponse(400, "Nationality Not Found!"));
            }

            _mapper.Map(updateNationalityVM, nationality);

            _unitOfWork.Nationalities.Update(nationality);

            if (await _unitOfWork.SaveAsync())
            {
                return _mapper.Map<NationalityVM>(nationality);
            }

            return BadRequest(new ApiResponse(400, "Failed to Update Nationality!"));
        }

        [HttpDelete("{nationalityId:int}")]
        public async Task<ActionResult> Delete(int nationalityId)
        {
            var nationality = await _unitOfWork.Nationalities.GetByIdAsync(nationalityId);
            if (nationality == null)
            {
                return BadRequest(new ApiResponse(400, "Nationality Not Found!"));
            }

            _unitOfWork.Nationalities.Delete(nationality);

            if (await _unitOfWork.SaveAsync())
            {
                return Ok("Deleted Successfully.");
            }

            return BadRequest(new ApiResponse(400, "Failed to Delete Nationality!"));
        }
    }
}
