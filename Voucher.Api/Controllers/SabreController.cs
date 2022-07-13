using Voucher.Api.Requests;
using Voucher.Api.ServiceRepository;
using Voucher.Api.ServiceRepository.DTO;
using Voucher.Api.ServiceRepository.Extensions;
using Voucher.Application.ServiceStack.Interfaces;
using Voucher.Domain;
using Microsoft.AspNetCore.Mvc;
using SabreFlightDetailRQ;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UpdateReservationSabre;

namespace Gol.Voucher.Api.Controllers
{
    [Produces("application/json")]
    [Consumes("application/json")]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SabreController : ControllerBase
    {
        private readonly ISabreDataRepository _sabreDataRepository;
        public SabreController(ISabreDataRepository sabreDataRepository)
        {
            _sabreDataRepository = sabreDataRepository;
        }

        [HttpPost]
        public ActionResult<string> GetPassengerList(GetPassengerListRQSAbreRequest request)
        {
            
            _sabreDataRepository.GetPassengerListRQSAbre(request);
            return "Teste";
        }

        [HttpPost]
        public ActionResult<GetFlightDetailSabreDTO> GetFlightDetailSabre(GetFlightDetailSabreRequest request)
        {
            return _sabreDataRepository.GetFlightDetailSabre(request);
        }

        [HttpPost]
        public ActionResult<UpdateReservationRS> UpdateReserveSabre(UpdateReserveSabreRequest request)
        //public ActionResult<string> UpdateReserveSabre(UpdateReserveSabreRequest request)
        {
            return _sabreDataRepository.UpdateReserveSabre(request);
        }

        [HttpPost]
        public ActionResult<ServiceResult> UpdateRemarksRange(List<RemarksSabre> request)
        //public ActionResult<string> UpdateReserveSabre(UpdateReserveSabreRequest request)
        {
            return null;
            //return _sabreDataRepository.UpdateRange(request);
        }

    }
}
