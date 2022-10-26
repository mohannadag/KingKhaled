using API.Errors;
using API.ViewModels.Bank;
using API.ViewModels.EmploymentApplications;
using AutoMapper;
using Core.Models.EmploymentApplications;
using Core.Models.General;
using Data.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers.Common
{
    public class EmploymentApplicationsController : MainController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<EmploymentApplications> _logger;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;
        public EmploymentApplicationsController(IUnitOfWork unitOfWork, ILogger<EmploymentApplications> logger, IMapper mapper, LinkGenerator linkGenerator)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }
        [HttpGet("GetById/{ApplicationsId:int}")]
        public async Task<ActionResult<EmploymentApplicationsVM>> GetById(int ApplicationsId)
        {
            var result = await _unitOfWork.EmploymentApplications.GetByIdAsync(ApplicationsId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No EmploymentApplications Found!"));
            }

            return _mapper.Map<EmploymentApplicationsVM>(result);
        }

     

        [HttpGet("GetBy-ArabicName/{arabicName}")]
        public async Task<ActionResult<EmploymentApplicationsVM>> GetByArabicName(string arabicName)
        {
            var result = await _unitOfWork.EmploymentApplications.GetByArabicNameAsync(arabicName);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No EmploymentApplications Found!"));
            }

            return _mapper.Map<EmploymentApplicationsVM>(result);
        }

        [HttpGet("GetBy-EnglishName/{englishName}")]
        public async Task<ActionResult<EmploymentApplicationsVM>> GetByEnglishName(string englishName)
        {
            var result = await _unitOfWork.EmploymentApplications.GetByEnglishNameAsync(englishName);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No EmploymentApplications Found!"));
            }

            return _mapper.Map<EmploymentApplicationsVM>(result);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<EmploymentApplicationsVM[]>> GetAll()
        {
            var result = await _unitOfWork.EmploymentApplications.GetAllAsync();
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Banks Found!"));
            }

            return _mapper.Map<EmploymentApplicationsVM[]>(result);
        }

        [HttpPost]
        public async Task<ActionResult<EmploymentApplicationsVM>> Post(EmploymentApplicationsVM createEmploymentApplicationsVMM)
        {
            var createEmploymentApplicationsV = _mapper.Map<EmploymentApplications>(createEmploymentApplicationsVMM);

            await _unitOfWork.EmploymentApplications.AddAsync(createEmploymentApplicationsV);

            if (await _unitOfWork.SaveAsync())
            {
                var location = _linkGenerator.GetPathByAction("GetById", "Bank", values: new { Id = createEmploymentApplicationsV.Id });

                return Created(location, _mapper.Map<EmploymentApplicationsVM>(createEmploymentApplicationsV));
            }

            return BadRequest(new ApiResponse(400, "Failed to Add Bank!"));
        }

        [HttpPut("{EmploymentApplicationsID:int}")]
        public async Task<ActionResult<EmploymentApplicationsVM>> Put(int Id, UpdateBankVM updateBankVM)
        {
            var EmploymentApplications = await _unitOfWork.EmploymentApplications.GetByIdAsync(Id);
            if (EmploymentApplications == null)
            {
                return BadRequest(new ApiResponse(400, "Bank Not Found!"));
            }

            _mapper.Map(updateBankVM, EmploymentApplications);

            _unitOfWork.EmploymentApplications.Update(EmploymentApplications);

            if (await _unitOfWork.SaveAsync())
            {
                return _mapper.Map<EmploymentApplicationsVM>(EmploymentApplications);
            }

            return BadRequest(new ApiResponse(400, "Failed to Update Bank!"));
        }

        [HttpDelete("{bankId:int}")]
        public async Task<ActionResult> Delete(int bankId)
        {
            var bank = await _unitOfWork.EmploymentApplications.GetByIdAsync(bankId);
            if (bank == null)
            {
                return BadRequest(new ApiResponse(400, "Bank Not Found!"));
            }

            _unitOfWork.EmploymentApplications.Delete(bank);

            if (await _unitOfWork.SaveAsync())
            {
                return Ok("Deleted Successfully.");
            }

            return BadRequest(new ApiResponse(400, "Failed to Delete Bank!"));
        }
    }
}
