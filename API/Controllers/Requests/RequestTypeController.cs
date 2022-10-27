using API.Controllers.Common;
using AutoMapper;
using Data.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers.Requests
{
    public class RequestTypeController : MainController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<RequestTypeController> _logger;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public RequestTypeController(IUnitOfWork unitOfWork, ILogger<RequestTypeController> logger, IMapper mapper, LinkGenerator linkGenerator)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }


    }
}
