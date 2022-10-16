using API.Errors;
using API.ViewModels.Bank;
using API.ViewModels.Nationality;
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
    public class BankController : MainController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<BankController> _logger;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public BankController(IUnitOfWork unitOfWork, ILogger<BankController> logger, IMapper mapper, LinkGenerator linkGenerator )
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("GetById/{bankId:int}")]
        public async Task<ActionResult<BankVM>> GetById(int bankId)
        {
            var result = await _unitOfWork.Banks.GetByIdAsync(bankId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Bank Found!"));
            }

            return _mapper.Map<BankVM>(result);
        }

        [HttpGet("GetBy-Code/{code}")]
        public async Task<ActionResult<BankVM>> GetByCode(string code)
        {
            var result = await _unitOfWork.Banks.GetByCodeAsync(code);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Bank Found!"));
            }

            return _mapper.Map<BankVM>(result);
        }

        [HttpGet("GetBy-ArabicName/{arabicName}")]
        public async Task<ActionResult<BankVM>> GetByArabicName(string arabicName)
        {
            var result = await _unitOfWork.Banks.GetByArabicNameAsync(arabicName);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Bank Found!"));
            }

            return _mapper.Map<BankVM>(result);
        }

        [HttpGet("GetBy-EnglishName/{englishName}")]
        public async Task<ActionResult<BankVM>> GetByEnglishName(string englishName)
        {
            var result = await _unitOfWork.Banks.GetByEnglishNameAsync(englishName);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Bank Found!"));
            }

            return _mapper.Map<BankVM>(result);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<BankVM[]>> GetAll()
        {
            var result = await _unitOfWork.Banks.GetAllAsync();
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Banks Found!"));
            }

            return _mapper.Map<BankVM[]>(result);
        }

        [HttpPost]
        public async Task<ActionResult<BankVM>> Post(CreateBankVM createBankVM)
        {
            var bank = _mapper.Map<Bank>(createBankVM);

            await _unitOfWork.Banks.AddAsync(bank);

            if (await _unitOfWork.SaveAsync())
            {
                var location = _linkGenerator.GetPathByAction("GetById", "Bank", values: new { bankId = bank.Id });

                return Created(location, _mapper.Map<BankVM>(bank));
            }

            return BadRequest(new ApiResponse(400, "Failed to Add Bank!"));
        }

        [HttpPut("{bankId:int}")]
        public async Task<ActionResult<BankVM>> Put(int bankId, UpdateBankVM updateBankVM)
        {
            var bank = await _unitOfWork.Banks.GetByIdAsync(bankId);
            if (bank == null)
            {
                return BadRequest(new ApiResponse(400, "Bank Not Found!"));
            }

            _mapper.Map(updateBankVM, bank);

            _unitOfWork.Banks.Update(bank);

            if (await _unitOfWork.SaveAsync())
            {
                return _mapper.Map<BankVM>(bank);
            }

            return BadRequest(new ApiResponse(400, "Failed to Update Bank!"));
        }

        [HttpDelete("{bankId:int}")]
        public async Task<ActionResult> Delete(int bankId)
        {
            var bank = await _unitOfWork.Banks.GetByIdAsync(bankId);
            if (bank == null)
            {
                return BadRequest(new ApiResponse(400, "Bank Not Found!"));
            }

            _unitOfWork.Banks.Delete(bank);

            if (await _unitOfWork.SaveAsync())
            {
                return Ok("Deleted Successfully.");
            }

            return BadRequest(new ApiResponse(400, "Failed to Delete Bank!"));
        }
    }
}
