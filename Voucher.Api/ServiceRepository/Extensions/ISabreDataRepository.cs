using Voucher.Api.Requests;
using Voucher.Api.ServiceRepository.DTO;
using Voucher.Domain;
using Voucher.Repository.Extensions;
using SabreFlightDetailRQ;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Voucher.Api.ServiceRepository.Extensions
{
    public interface ISabreDataRepository
    {

        //List<PassengerRemarks> GetPassengerListRQSAbre(GetPassengerListRQSAbreRequest request);
        List<PassengerRemarks> GetPassengerList(string securityToken, string[] codeList, string strAirline,
        string strFilght, string departureDate, string strOrigin, bool hasFilter, string filterType, long idFlight);
        GetPassengerListRQDTO GetPassengerListData(SabreGetPassengerListRQ.GetPassengerListRS getPassengerList, long idFlight);
        UpdateReservationSabre.UpdateReservationRS UpdateReserveSabre(UpdateReserveSabreRequest request);
        GetFlightDetailSabreDTO GetFlightDetailSabre(GetFlightDetailSabreRequest request);
        string GetPassengerListRQSAbre(GetPassengerListRQSAbreRequest request);
        ServiceResult UpdadeRemarksSabreRange<TypeOfVoucher>(List<TypeOfVoucher> VoucherList, bool isInsertion) where TypeOfVoucher : class;

    }
}
