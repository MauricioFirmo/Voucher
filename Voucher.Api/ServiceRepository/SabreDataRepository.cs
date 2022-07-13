using Voucher.Api.Requests;
using Voucher.Api.ServiceRepository.DTO;
using Voucher.Api.ServiceRepository.Extensions;
using Voucher.Application.ServiceStack.Interfaces;
using Voucher.Domain;
using Voucher.Repository.Extensions;
using Microsoft.EntityFrameworkCore;
using SabreFlightDetailRQ;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Voucher.Api.ServiceRepository
{
    public class SabreDataRepository: ISabreDataRepository
    {
        private readonly IFlightAppService _flightRepo;
        private readonly IPassengerAppService _PassengerRepo;
        private readonly IRemarksSabreAppService _remakRepo;
        private readonly ISabreRepository _sabreRepository;
        private readonly VoucherContext _context;

        public SabreDataRepository(ISabreRepository sabreRepository, IRemarksSabreAppService appService, 
            VoucherContext context, IPassengerAppService PassengerRepo, IFlightAppService flightRepo)
        {
            _sabreRepository = sabreRepository;
            _remakRepo = appService;
            _context = context;
            _PassengerRepo = PassengerRepo;
            _flightRepo = flightRepo;
        }

        private const string SABRE_SERVICE_DOMAIN = "G3";
        private const string SABRE_SERVICE_USERNAME = "891001";
        private const string SABRE_SERVICE_PASSWORD = "GRUGRU20";

            public List<PassengerRemarks> GetPassengerList(string securityToken, string[] codeList, string strAirline,
                string strFilght, string departureDate, string strOrigin, bool hasFilter, string filterType, long idFlight)
            {
                var getList = new GetPassengerListRQDTO();
                var getData = _sabreRepository.GetPassengerListRQSAbre(securityToken, codeList, strAirline,
                    strFilght, departureDate, strOrigin, hasFilter, filterType);

                List<PassengerRemarks> passengersRemarks = new List<PassengerRemarks>();

                if (getData.Result.Status == SabreGetPassengerListRQ.ErrorOrSuccessCode.Success)
                {
                    getList = this.GetPassengerListData(getData, idFlight);
                    var passengerList = _PassengerRepo.GetList(idFlight);//Lista de passageiros do voo

                    foreach(var passenger in passengerList)
                    {
                    PassengerRemarks passengerRemark = new PassengerRemarks
                    {
                        PassengerId = passenger.Id,
                        FlightId = idFlight,
                        PassengeNumber = passenger.TicketNumber,
                        PNR = passenger.RecordLocator,
                        Emitido = "",
                        FlightNumber = strFilght,
                        Nome = passenger.FirstName + ' ' + passenger.LastName
                    };

                        var remarksList = _remakRepo.List(passenger.FlightId, passenger.Id);
                        foreach (var remark in remarksList)
                            {
                                passengerRemark.Remarks = passengerRemark.Remarks + '/' +remark.Remark;
                            }
                        passengersRemarks.Add(passengerRemark);
                    }
                return passengersRemarks;

                }
                else
                {
                    //getList.ErrorCode = -3;
                    //getList.ErrorMessage = Resource.Resource.ResourceManager.GetString("GetPassengerListRQSAbre", CultureInfo.GetCultureInfo("pt-br"));
                    //getList.Status = ResultBean.Error;
                    return null;
                }

            }

        public GetPassengerListRQDTO GetPassengerListData(SabreGetPassengerListRQ.GetPassengerListRS getPassengerList, long idFlight)
        {
            var getList = new GetPassengerListRQDTO();
            var PassengerInfo = new List<PassengerInfoList>();

            foreach (var item in getPassengerList.PassengerInfoList)
            {
                PassengerInfo.Add(new PassengerInfoList
                {

                    BoardingInfo = new BoardingInfoField
                    {
                        boardStatusField = item.Boarding_Info.BoardStatus,
                        boardStatusFieldSpecified = item.Boarding_Info.BoardStatusSpecified
                    },
                    NameDetails = new NameDetailsField
                    {
                        FirstNameField = item.Name_Details.FirstName,
                        LastNameField = item.Name_Details.LastName
                    },
                    CheckInInfo = new CheckInInfoField
                    {
                        checkInNumberField = item.CheckIn_Info.CheckInNumber.ToString(),
                        checkInStatusField = item.CheckIn_Info.CheckInStatus,
                        checkInNumberFieldSpecified = item.CheckIn_Info.CheckInNumberSpecified,
                        checkInStatusFieldSpecified = item.CheckIn_Info.CheckInStatusSpecified
                    },
                    PNRLocator = new PNRLocatorField
                    {
                        nameAssociationIDField = item.PNRLocator.nameAssociationID,
                        passengerIDField = item.PassengerID,
                        valueField = item.PNRLocator.Value
                    },
                });
                //insere caso o passageiro não esteja na tabela
                var pax = _PassengerRepo.GetPassengers(idFlight, item.PassengerID);
                if (pax==null)
                {
                    Passenger passenger = new Passenger();
                    passenger.DateOfBirth = default(DateTime);
                    passenger.FirstName = item.Name_Details.FirstName;
                    passenger.FlightId = idFlight;
                    passenger.Id = CreateMD5(item.Name_Details.FirstName + item.Name_Details.LastName + item.PNRLocator.Value);
                    passenger.LastName = item.Name_Details.LastName;
                    passenger.MiddleName = "";
                    passenger.RecordLocator = item.PNRLocator.Value.ToString();
                    passenger.TicketNumber = item.PassengerID;

                    _PassengerRepo.Insert(passenger);
                }
            }
            getList.PassengerInfo = PassengerInfo;
            getList.aircraftTypeField = getPassengerList.ItineraryInfo.Itinerary.AircraftType;
            getList.arrivalTimeField = getPassengerList.ItineraryInfo.DepartureArrival_Dates.ArrivalTime;
            getList.departureTimeField = getPassengerList.ItineraryInfo.DepartureArrival_Dates.DepartureTime;
            getList.destinationField = getPassengerList.ItineraryInfo.Itinerary.Destination;
            getList.estimated_ArrivalDateField = getPassengerList.ItineraryInfo.DepartureArrival_Dates.Estimated_ArrivalDate;
            getList.estimated_DepartureDateField = getPassengerList.ItineraryInfo.DepartureArrival_Dates.Estimated_DepartureDate;
            getList.originField = getPassengerList.ItineraryInfo.Itinerary.Origin;
            getList.scheduled_ArrivalDateField = getPassengerList.ItineraryInfo.DepartureArrival_Dates.Scheduled_ArrivalDate;
            getList.scheduled_DepartureDateField = getPassengerList.ItineraryInfo.DepartureArrival_Dates.Scheduled_DepartureDate;

            return getList;
        }

        public static string CreateMD5(string input)
        {
            // Use input string to calculate MD5 hash
            using (System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create())
            {
                byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(input);
                byte[] hashBytes = md5.ComputeHash(inputBytes);

                // Convert the byte array to hexadecimal string
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    sb.Append(hashBytes[i].ToString("X2"));
                }
                return sb.ToString();
            }
        }

        public GetFlightDetailSabreDTO GetFlightDetailSabre(GetFlightDetailSabreRequest request)
        {
            string sabre_domain = SABRE_SERVICE_DOMAIN;
            string sabre_username = SABRE_SERVICE_USERNAME;
            string sabre_password = SABRE_SERVICE_PASSWORD;

            string token = "";
            List<PassengerRemarks> listPassengerRemakrs = new List<PassengerRemarks>();
            var listDTO = new ACS_FlightDetailRSACS();
            var result = new GetFlightDetailSabreDTO();
            Flight Newflight = new Flight();
            string shareCode = "";
            try
            {
                var loginSabre = _sabreRepository.LoginSabre(sabre_domain, sabre_username, sabre_password);
                if (loginSabre == "" || loginSabre == null)
                {
                    throw new Exception("Erro ao fazer login no serviço Sabre.");
                }
                token = loginSabre;
                listDTO = _sabreRepository.GetFlightDetailSabre(token, request.Airline, request.Flight, request.Origin, request.DepartureDate, false);
                var listDTOShareCode = _sabreRepository.GetFlightDetailSabre(token, request.Airline, request.Flight, request.Origin, request.DepartureDate, true);
                
                if (listDTOShareCode.ItineraryResponseList != null)
                {
                    var ItinerayList = listDTOShareCode.ItineraryResponseList[0];
                    var FreeText = ItinerayList.FreeTextInfoList;

                    for (int i = 1; i <= (FreeText.Length - 1); i++)
                    {
                        var strText = FreeText[i].TextLine[1];
                        if (strText != null)
                        { shareCode = shareCode + '/' + (strText.ToString().Trim()); }
                    }

                    var intineraryInfo = listDTO.ItineraryResponseList[0];
                    if (intineraryInfo != null)
                    {
                        Flight flight = new Flight
                        {
                            ArrivalStation = "BSB",
                            STA = Convert.ToDateTime(intineraryInfo.ScheduledArrivalDate),
                            CarrierCode = "G3",
                            DepartureStation = intineraryInfo.Origin,
                            FlightNumber = intineraryInfo.Flight,
                            STD = Convert.ToDateTime(intineraryInfo.ScheduledDepartureDate),
                        };
                        Newflight = _flightRepo.GetListData(intineraryInfo.Flight, intineraryInfo.Origin, Convert.ToDateTime(intineraryInfo.ScheduledDepartureDate));
                        if (Newflight==null)
                        {
                            //cadastrando o voo no banco e obtendo o resultado caso não exista
                            Newflight = _flightRepo.Insert(flight).Result;
                        }
                    }
                    
                    listPassengerRemakrs = GetPassengerList(token, new string[2] { "ON", "XON" }, request.Airline, request.Flight, request.DepartureDate, request.Origin, true, "OR", Newflight.Id);
                }
                result.ShareCode = shareCode;
                result.ACS_FlightDetailRSACS = listDTO;
                result.PassengerList = listPassengerRemakrs;
            }
            catch (Exception ex)
            {
                //Logger.Error(ex, "GetPassegerData Error: " + ex.Message);
                _sabreRepository.LogOutSabre(token);
                throw;
            }
            _sabreRepository.LogOutSabre(token);
            return result;
            
        }


        public string GetPassengerListRQSAbre(GetPassengerListRQSAbreRequest request)
        {
            string sabre_domain = SABRE_SERVICE_DOMAIN;
            string sabre_username = SABRE_SERVICE_USERNAME;
            string sabre_password = SABRE_SERVICE_PASSWORD;

            var listDTO = new List<PassengerRemarks>();
            string token = "";
            try
            {
                var loginSabre = _sabreRepository.LoginSabre(sabre_domain, sabre_username, sabre_password);
                if (loginSabre == "" || loginSabre == null)
                {
                    throw new Exception("Erro ao fazer login no serviço Sabre.");
                }

                token = loginSabre;

                var teste = _sabreRepository.GetPassengerListRQSAbre(token, request.codeList, request.strAirline,
                request.strFilght, request.departureDate, request.strOrigin, request.hasFilter, request.filterType);
            }
            catch (System.Net.WebException we)
            {
                //Logger.Error(we, "Erro no GetPassengerListRQSAbre");
                //listDTO.ErrorCode = -1;
                //listDTO.Status = "ERROR";
                //listDTO.ErrorMessage = we.Message;
                Thread.Sleep(5000);
            }
            catch (TimeoutException te)
            {
                //Logger.Error(te, "Erro Timeout no GetPassengerListRQSAbre");
                //listDTO.ErrorCode = -1;
                //listDTO.Status = "ERROR";
                //listDTO.ErrorMessage = te.Message;
                Thread.Sleep(5000);
            }
            catch (Exception ex)
            {
                //Logger.Error(ex, "GetPassengerListRQSAbre Error: " + ex.Message);
                //listDTO.ErrorCode = -1;
                //listDTO.Status = "ERROR";
                //listDTO.ErrorMessage = ex.Message;
                throw ex;
            }
            _sabreRepository.LogOutSabre(token);
            return "Teste";
        }

        //-----------------------------------UPDATE SABRE--------------------------------------
        //Método secundário que chama a inserção na sabre e o banco para vários comentários
        //de exclusão ou inserção de uma só vez
        public ServiceResult UpdadeRemarksSabreRange<TypeOfVoucher>(List<TypeOfVoucher> VoucherList, bool isInsertion) where TypeOfVoucher : class
        {
            
            var voucherType = VoucherList[0].GetType();
            object voucherObj = VoucherList[0];


            string remark = "";
            if (isInsertion == true)
            { remark = "comentário de inserção"; }
            else
            { remark = "comentário de cancelamento"; }
            //Inserção de comntários na Sabre
            ServiceResult serviceResult = new ServiceResult();
            List<UpdateReserveSabreRequest> requestList = new List<UpdateReserveSabreRequest>();
            try
            {
                foreach (var item in VoucherList)
                {
                    var passenger = _PassengerRepo.Get(voucherType.GetProperty("PassengerId").GetValue(voucherObj, null).ToString());
                    UpdateReserveSabreRequest requestItem = new UpdateReserveSabreRequest
                    {
                        pnr = passenger.Result.RecordLocator,
                        comments = remark
                    };
                    requestList.Add(requestItem);
                }
                serviceResult = this.UpdateReserveService(requestList);
                
                //Inserção no banco de dados
                List<RemarksSabre> remarkList = new List<RemarksSabre>();
                foreach (var item in VoucherList)
                {
                    string userName = "";
                    if (Convert.ToBoolean(voucherType.GetProperty("IsActive").GetValue(voucherObj, null)) == true)
                    { userName = voucherType.GetProperty("CreatedBy").GetValue(voucherObj, null).ToString(); }
                    else
                    { userName = voucherType.GetProperty("CanceledBy").GetValue(voucherObj, null).ToString();  }
                    RemarksSabre remarkItem = new RemarksSabre
                    {
                        VoucherId = Convert.ToInt64(voucherType.GetProperty("Id").GetValue(voucherObj, null)),
                        dtInsert = DateTime.Now,
                        FlightId = Convert.ToInt64(voucherType.GetProperty("FlightId").GetValue(voucherObj, null)),
                        PassengerId = voucherType.GetProperty("PassengerId").GetValue(voucherObj, null).ToString(),
                        Username = userName,
                        Remark = remark
                    };
                    remarkList.Add(remarkItem);
                }
                _remakRepo.InsertRange(remarkList);
                serviceResult.resultDatabase = true;
                return serviceResult;
            }

            catch (Exception ex)
            {
                throw ex;
            }
        }

        public ServiceResult UpdateReserveService(List<UpdateReserveSabreRequest> requestList)
        {
            string sabre_domain = SABRE_SERVICE_DOMAIN;
            string sabre_username = SABRE_SERVICE_USERNAME;
            string sabre_password = SABRE_SERVICE_PASSWORD;
            string Pnr = "";

            ServiceResult result = new ServiceResult();
            result.resultSabre = false;

            var listDTO = new UpdateReservationSabre.UpdateReservationRS();
            var loginSabre = _sabreRepository.LoginSabre(sabre_domain, sabre_username, sabre_password);
            string token = loginSabre;

            if (loginSabre == "" || loginSabre == null)
            {
                throw new Exception("Erro ao fazer login no serviço Sabre.");
            }
            try
            {
                foreach (var request in requestList)
                {
                    Pnr = request.pnr;
                    listDTO = _sabreRepository.UpdateReserveSabre(token, request.pnr, request.comments);
                }
            }
            catch (Exception ex)
            {
                result.resultSabre = false;
                result.listError.Add("Erro ao inserir o comentário na Sabre " + Pnr);
                //Logger.Error(ex, "GetPassegerData Error: " + ex.Message);
                //throw;
            }
            _sabreRepository.LogOutSabre(token);
            if (result.listError == null) { result.resultSabre = true; }
            return result;
        }

        public UpdateReservationSabre.UpdateReservationRS UpdateReserveSabre(UpdateReserveSabreRequest request)
        {


            string sabre_domain = SABRE_SERVICE_DOMAIN;
            string sabre_username = SABRE_SERVICE_USERNAME;
            string sabre_password = SABRE_SERVICE_PASSWORD;

            string token = "";
            var listDTO = new UpdateReservationSabre.UpdateReservationRS();
            try
            {


                var loginSabre = _sabreRepository.LoginSabre(sabre_domain, sabre_username, sabre_password);
                if (loginSabre == "" || loginSabre == null)
                {
                    throw new Exception("Erro ao fazer login no serviço Sabre.");
                }
                token = loginSabre;
                listDTO = _sabreRepository.UpdateReserveSabre(token, request.pnr, request.comments);

            }
            catch (Exception ex)
            {
                //Logger.Error(ex, "GetPassegerData Error: " + ex.Message);
                throw;
            }
            _sabreRepository.LogOutSabre(token);
            return listDTO;
        }

    }
}
