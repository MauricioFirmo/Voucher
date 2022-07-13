using SabreFlightDetailRQ;
using SabreGetPassengerListRQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Voucher.Api.ServiceRepository.Extensions
{
    public interface ISabreRepository
    {
        string LoginSabre(string domain, string username, string password);
        string LogOutSabre(string securityToken);
        ACS_FlightDetailRSACS GetFlightDetailSabre(string token, string Airline, string Flight, string Origin, string DepartureDate, bool shareCode);
        GetPassengerListRS GetPassengerListRQSAbre(string securityToken, string[] codeList, string strAirline,
                                                  string strFilght, string departureDate, string strOrigin, bool hasFilter, string filterType);
        UpdateReservationSabre.UpdateReservationRS UpdateReserveSabre(string token, string pnr, string comments);
    }
}
