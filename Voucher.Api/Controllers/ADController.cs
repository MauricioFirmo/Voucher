﻿using Voucher.Api.Requests;
using Voucher.Api.ServiceRepository;
using Voucher.Api.ServiceRepository.DTO;
using Voucher.Api.ServiceRepository.Extensions;
using Voucher.Application.ServiceStack.AppServices;
using Voucher.Application.ServiceStack.Interfaces;
using Voucher.Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SabreFlightDetailRQ;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UpdateReservationSabre;

namespace Voucher.Api.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ADController : ControllerBase
    {
        private readonly IADAppService _adAppService;
        private readonly ILogger<ADController> _logger;
        public ADController(IADAppService adAppService, ILogger<ADController> logger)
        {
            _adAppService = adAppService;
            _logger = logger;
        }

        [HttpPost]
        public Task<ADAuthentication> GetADProfile(string username, string password)
        {
            try
            {
                return _adAppService.GetADAuthentication(username, password);
            }
            catch(Exception ex)
            {
                _logger.LogError(ex,"Failed to authenticate");
                throw;
            }
        }
    }
}
