﻿using AutoMapper;
using Data.UnitOfWorks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace API.Controllers.Common
{
    public class JobSubGroupController : MainController
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<JobSubGroupController> _logger;
        private readonly IMapper _mapper;
        private readonly LinkGenerator _linkGenerator;

        public JobSubGroupController(IUnitOfWork unitOfWork, ILogger<JobSubGroupController> logger, IMapper mapper, LinkGenerator linkGenerator)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;
            _linkGenerator = linkGenerator;
        }
    }
}
