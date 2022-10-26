using API.Controllers.Common;
using API.Errors;
using API.ViewModels.EntryCard;
using API.ViewModels.JobGroup;
using AutoMapper;
using Core.Models.EmployeesInfo;
using Core.Models.Jobs;
using Data.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers.HR.EmployeeInfo
{
    public class EntryCardController : MainController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EntryCardController> _logger;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public EntryCardController(IUnitOfWork unitOfWork, ILogger<EntryCardController> logger, IMapper mapper, LinkGenerator linkGenerator)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("GetById/{entryCardId:int}")]
        public async Task<ActionResult<EntryCardVM>> GetById(int entryCardId)
        {
            var result = await _unitOfWork.EntryCards.GetByIdAsync(entryCardId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No EntryCard Found!"));
            }

            return _mapper.Map<EntryCardVM>(result);
        }

        [HttpGet("GetBy-SecurityNumber/{SecurityNumber}")]
        public async Task<ActionResult<EntryCardVM>> GetBySecurityNumber(string SecurityNumber)
        {
            var result = await _unitOfWork.EntryCards.GetBySecurityNumberAsync(SecurityNumber);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No EntryCard Found!"));
            }

            return _mapper.Map<EntryCardVM>(result);
        }

        [HttpGet("GetBy-EmployeeId/{employeeId:int}")]
        public async Task<ActionResult<EntryCardVM>> GetByEmployeeId(int employeeId)
        {
            var result = await _unitOfWork.EntryCards.GetByEmployeeId(employeeId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No EntryCard Found!"));
            }

            return _mapper.Map<EntryCardVM>(result);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<EntryCardVM[]>> GetAll()
        {
            var result = await _unitOfWork.EntryCards.GetAllAsync();
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No EntryCard Found!"));
            }

            return _mapper.Map<EntryCardVM[]>(result);
        }

        public async Task<ActionResult<EntryCardVM>> Post(CreateEntryCardVM createEntryCardVM)
        {
            var entryCard = _mapper.Map<EntryCard>(createEntryCardVM);

            await _unitOfWork.EntryCards.AddAsync(entryCard);

            if (await _unitOfWork.SaveAsync())
            {
                var location = _linkGenerator.GetPathByAction("GetById", "EntryCard", values: new { entryCardId = entryCard.Id });

                return Created(location, _mapper.Map<EntryCardVM>(entryCard));
            }

            return BadRequest(new ApiResponse(400, "Failed to Add EntryCard!"));
        }

        [HttpPut("{entryCardId:int}")]
        public async Task<ActionResult<EntryCardVM>> Put(int entryCardId, UpdateEntryCardVM updateEntryCardVM)
        {
            var entryCard = await _unitOfWork.EntryCards.GetByIdAsync(entryCardId);
            if (entryCard == null)
            {
                return BadRequest(new ApiResponse(400, "EntryCard Not Found!"));
            }

            _mapper.Map(updateEntryCardVM, entryCard);

            _unitOfWork.EntryCards.Update(entryCard);

            if (await _unitOfWork.SaveAsync())
            {
                return _mapper.Map<EntryCardVM>(entryCard);
            }

            return BadRequest(new ApiResponse(400, "Failed to Update EntryCard!"));
        }

        [HttpDelete("{entryCardId:int}")]
        public async Task<ActionResult> Delete(int entryCardId)
        {
            var entryCard = await _unitOfWork.EntryCards.GetByIdAsync(entryCardId);
            if (entryCard == null)
            {
                return BadRequest(new ApiResponse(400, "EntryCard Not Found!"));
            }

            _unitOfWork.EntryCards.Delete(entryCard);

            if (await _unitOfWork.SaveAsync())
            {
                return Ok("Deleted Successfully.");
            }

            return BadRequest(new ApiResponse(400, "Failed to Delete EntryCard!"));
        }
    }
}
