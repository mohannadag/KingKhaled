using API.Controllers.Common;
using API.Errors;
using API.ViewModels.Contracts;
using API.ViewModels.Tickets;
using AutoMapper;
using Core.Models.EmployeesInfo;
using Data.UnitOfWorks;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers.HR.EmployeeInfo
{
    public class TicketsController : MainController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<TicketsController> _logger;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public TicketsController(IUnitOfWork unitOfWork, ILogger<TicketsController> logger, IMapper mapper, LinkGenerator linkGenerator)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }

        [HttpGet("GetById/{ticketId:int}")]
        public async Task<ActionResult<TicketVM>> GetById(int ticketId)
        {
            var result = await _unitOfWork.Tickets.GetByIdAsync(ticketId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Ticket Found!"));
            }

            return _mapper.Map<TicketVM>(result);
        }

        [HttpGet("GetBy-TicketNumber/{ticketNumber}")]
        public async Task<ActionResult<TicketVM>> GetByTicketNumber(string ticketNumber)
        {
            var result = await _unitOfWork.Tickets.GetByTicketNumberAsync(ticketNumber);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Ticket Found!"));
            }

            return _mapper.Map<TicketVM>(result);
        }

        [HttpGet("GetAll")]
        public async Task<ActionResult<TicketVM[]>> GetAll()
        {
            var result = await _unitOfWork.Tickets.GetAllAsync();
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Tickets Found!"));
            }

            return _mapper.Map<TicketVM[]>(result);
        }

        [HttpGet("GetAllBy-EmployeeId/{employeeId:int}")]
        public async Task<ActionResult<TicketVM[]>> GetAllByEmployeeId(int employeeId)
        {
            var result = await _unitOfWork.Tickets.GetAllByEmployeeIdAsync(employeeId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Tickets Found!"));
            }

            return _mapper.Map<TicketVM[]>(result);
        }

        [HttpGet("GetAllBy-ContractId/{contractId:int}")]
        public async Task<ActionResult<TicketVM[]>> GetAllByContractId(int contractId)
        {
            var result = await _unitOfWork.Tickets.GetAllByContractIdAsync(contractId);
            if (result == null)
            {
                return NotFound(new ApiResponse(404, "No Tickets Found!"));
            }

            return _mapper.Map<TicketVM[]>(result);
        }

        [HttpPost]
        public async Task<ActionResult<TicketVM>> Post(CreateTicketVM createTicketVM)
        {
            var ticket = _mapper.Map<Ticket>(createTicketVM);

            await _unitOfWork.Tickets.AddAsync(ticket);

            if (await _unitOfWork.SaveAsync())
            {
                var location = _linkGenerator.GetPathByAction("GetById", "Tickets", values: new { ticketId = ticket.Id });

                return Created(location, _mapper.Map<TicketVM>(ticket));
            }

            return BadRequest(new ApiResponse(400, "Failed to Add Ticket!"));
        }

        [HttpPut("{ticketId:int}")]
        public async Task<ActionResult<TicketVM>> Put(int ticketId, UpdateTicketVM updateTicketVM)
        {
            var ticket = await _unitOfWork.Tickets.GetByIdAsync(ticketId);
            if (ticket == null)
            {
                return BadRequest(new ApiResponse(400, "Ticket Not Found!"));
            }

            _mapper.Map(updateTicketVM, ticket);

            _unitOfWork.Tickets.Update(ticket);

            if (await _unitOfWork.SaveAsync())
            {
                return _mapper.Map<TicketVM>(ticket);
            }

            return BadRequest(new ApiResponse(400, "Failed to Update Ticket!"));
        }

        [HttpDelete("{ticketId:int}")]
        public async Task<ActionResult> Delete(int ticketId)
        {
            var ticket = await _unitOfWork.Tickets.GetByIdAsync(ticketId);
            if (ticket == null)
            {
                return BadRequest(new ApiResponse(400, "Ticket Not Found!"));
            }

            _unitOfWork.Tickets.Delete(ticket);

            if (await _unitOfWork.SaveAsync())
            {
                return Ok("Deleted Successfully.");
            }

            return BadRequest(new ApiResponse(400, "Failed to Delete Ticket!"));
        }
    }
}
