using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using System.Threading.Tasks;
using Voucher.Api.ServiceRepository.Extensions;
using SabreFlightDetailRQ;
using SabreGetPassengerListRQ;

namespace Voucher.Api.ServiceRepository
{
    public class SabreRepository: ISabreRepository
    {

        private const string CONVERSATION_ID = "ECOMPONENT";
        private const string SERVICE_SESSIONCREATE = "SessionCreateRQ";
        private const string SERVICE_SESSIONCLOSE = "SessionCloseRQ";
        private const string SERVICE_GETPASSEGERDATA = "GetPassengerDataRQ";
        private const string ACTION_SESSIONCREATE = "SessionCreateRQ";
        private const string ACTION_SESSIONCLOSE = "SessionCloseRQ";
        private const string ACTION_GETPASSEGERDATA = "GetPassengerDataRQ";
        private const string MENSAGEM_LOGOUT_SUCESS = "Logout Sabre Sucess";


        public string LoginSabre(string domain, string username, string password)
        {

            System.Net.ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;
            SabreSessionCreate.SessionCreatePortTypeClient client = new SabreSessionCreate.SessionCreatePortTypeClient();

            try
            {
                SabreSessionCreate.MessageHeader header = new SabreSessionCreate.MessageHeader();
                SabreSessionCreate.From from = new SabreSessionCreate.From();
                SabreSessionCreate.To to = new SabreSessionCreate.To();
                List<SabreSessionCreate.PartyId> partyId = new List<SabreSessionCreate.PartyId>();
                SabreSessionCreate.Security security = new SabreSessionCreate.Security();
                SabreSessionCreate.SessionCreateRQ sessionCreate = new SabreSessionCreate.SessionCreateRQ();
                SabreSessionCreate.SecurityUsernameToken usernameToken = new SabreSessionCreate.SecurityUsernameToken();

                partyId.Add(new SabreSessionCreate.PartyId());

                from.PartyId = partyId.ToArray();
                to.PartyId = partyId.ToArray();
                header.From = from;
                header.To = to;
                header.CPAId = domain;

                usernameToken.Username = username;
                usernameToken.Password = password;
                usernameToken.Organization = domain;
                usernameToken.Domain = domain;

                security.UsernameToken = usernameToken;

                SabreSessionCreate.Service service = new SabreSessionCreate.Service();
                service.Value = SERVICE_SESSIONCREATE;

                header.ConversationId = CONVERSATION_ID;
                header.Service = service;
                header.Action = ACTION_SESSIONCREATE;

                client.OpenAsync();
                client.SessionCreateRQ(ref header, ref security, sessionCreate);
                return security.BinarySecurityToken.Value;
            }
            catch (System.Net.WebException we)
            {
                //Logger.Error(we, "Erro Timeout no login no Sabre Tentativa ");
                Thread.Sleep(5000);
                client.CloseAsync();
            }
            catch (TimeoutException te)
            {
                //Logger.Error(te, "Erro Timeout no login no Sabre Tentativa ");
                Thread.Sleep(5000);
                client.CloseAsync();
            }
            catch (Exception ex)
            {
                //Logger.Error(ex, "LoginSabre Error: " + ex.Message);
                client.CloseAsync();
                throw;
            }
            client.CloseAsync();
            throw new TimeoutException("Erro Timeout no LoginSabre na Sabre");
        }

        public string LogOutSabre(string securityToken)
        {
            SabreSessionClose.SessionClosePortTypeClient client = new SabreSessionClose.SessionClosePortTypeClient();

            try
            {
                SabreSessionClose.MessageHeader header = new SabreSessionClose.MessageHeader();
                SabreSessionClose.Security security = new SabreSessionClose.Security();
                SabreSessionClose.SessionCloseRQ sessionCreate = new SabreSessionClose.SessionCloseRQ();
                SabreSessionClose.Service service = new SabreSessionClose.Service();
                SabreSessionClose.From from = new SabreSessionClose.From();
                SabreSessionClose.To to = new SabreSessionClose.To();
                List<SabreSessionClose.PartyId> fromPartyId = new List<SabreSessionClose.PartyId>();
                List<SabreSessionClose.PartyId> toPartyId = new List<SabreSessionClose.PartyId>();

                service.Value = SERVICE_SESSIONCLOSE;

                SabreSessionClose.PartyId clientpartyId = new SabreSessionClose.PartyId();
                clientpartyId.Value = "WebServiceClient";

                SabreSessionClose.PartyId supplierPartyId = new SabreSessionClose.PartyId();
                supplierPartyId.Value = "WebServiceSupplier";

                fromPartyId.Add(clientpartyId);
                toPartyId.Add(supplierPartyId);

                from.PartyId = fromPartyId.ToArray();
                to.PartyId = toPartyId.ToArray();
                header.From = from;
                header.To = to;

                header.ConversationId = CONVERSATION_ID;
                header.Service = service;
                header.Action = ACTION_SESSIONCLOSE;

                security.BinarySecurityToken = securityToken;

                client.OpenAsync();
                var result = client.SessionCloseRQ(ref header, ref security, sessionCreate);
                return MENSAGEM_LOGOUT_SUCESS;
            }
            catch (System.Net.WebException we)
            {
                //Logger.Error(we, "Erro Timeout no login no Sabre Tentativa ");
                Thread.Sleep(5000);
                client.CloseAsync();
            }
            catch (TimeoutException te)
            {
                //Logger.Error(te, "Erro Timeout no login no Sabre Tentativa ");
                Thread.Sleep(5000);
                client.CloseAsync();
            }
            catch (Exception ex)
            {
                //Logger.Error(ex, "LoginSabre Error: " + ex.Message);
                client.CloseAsync();
                throw;
            }
            client.CloseAsync();
            throw new TimeoutException("Erro Timeout no LogOutSabre na Sabre");
        }

        public ACS_FlightDetailRSACS GetFlightDetailSabre(string token, string Airline, string Flight, string Origin, string DepartureDate, bool shareCode)
        {
            SabreFlightDetailRQ.ACS_FlightDetailPortTypeClient client = new SabreFlightDetailRQ.ACS_FlightDetailPortTypeClient();
            try
            {

                SabreFlightDetailRQ.DisplayACS display = new SabreFlightDetailRQ.DisplayACS();
                SabreFlightDetailRQ.MessageHeader header = new SabreFlightDetailRQ.MessageHeader();
                SabreFlightDetailRQ.Security security = new SabreFlightDetailRQ.Security();
                SabreFlightDetailRQ.Service service = new SabreFlightDetailRQ.Service();
                SabreFlightDetailRQ.From from = new SabreFlightDetailRQ.From();
                SabreFlightDetailRQ.To to = new SabreFlightDetailRQ.To();
                SabreFlightDetailRQ.MessageData messageData = new SabreFlightDetailRQ.MessageData();
                List<SabreFlightDetailRQ.PartyId> fromPartyId = new List<SabreFlightDetailRQ.PartyId>();
                List<SabreFlightDetailRQ.PartyId> toPartyId = new List<SabreFlightDetailRQ.PartyId>();

                SabreFlightDetailRQ.PartyId clientpartyId = new SabreFlightDetailRQ.PartyId();
                clientpartyId.Value = "Voejunto_HOM";

                SabreFlightDetailRQ.PartyId supplierPartyId = new SabreFlightDetailRQ.PartyId();
                supplierPartyId.Value = "SWS_CERT";

                fromPartyId.Add(clientpartyId);
                toPartyId.Add(supplierPartyId);

                from.PartyId = fromPartyId.ToArray();
                to.PartyId = toPartyId.ToArray();
                header.From = from;
                header.To = to;

                service.Value = "ACS_FlightDetailRQ";
                messageData.MessageId = "17867654537556";
                messageData.Timestamp = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss");

                header.CPAId = "G3";
                header.MessageData = messageData;
                header.ConversationId = "Voejunto_HOM";
                header.Service = service;
                header.Action = "ACS_FlightDetailRQ";

                security.BinarySecurityToken = token;
                
                ACS_FlightDetailRQACS request = new ACS_FlightDetailRQACS();
                ACS_FlightDetailRQACSFlightInfo FlightInfo = new ACS_FlightDetailRQACSFlightInfo();


                FlightInfo.Airline = Airline;
                FlightInfo.Flight = Flight;
                FlightInfo.Origin = Origin;
                FlightInfo.DepartureDate = DepartureDate;
              
                request.FlightInfo = FlightInfo;
                display.Type = DisplayACSType.R;

                if(shareCode == true) { request.Item = display; }

                client.OpenAsync();
                var result = client.ACS_FlightDetailRQ(ref header, ref security, request);
                client.CloseAsync();
                return result;
            }
            catch (System.Net.WebException we)
            {
                //Logger.Error(we, "Erro ao acessar GetReservationSabre");
                Thread.Sleep(5000);
                client.CloseAsync();
            }
            catch (TimeoutException te)
            {
                //Logger.Error(te, "Erro Timeout no GetReservationSabre");
                Thread.Sleep(5000);
                client.CloseAsync();
            }
            catch (Exception ex)
            {
                //Logger.Error(ex, "GetReservationSabre Error: " + ex.Message);
                client.CloseAsync();
                throw;
            }
            client.CloseAsync();
            throw new TimeoutException("Erro Timeout no GetReservationSabre na Sabre");
        }

        public GetPassengerListRS GetPassengerListRQSAbre(string securityToken, string[] codeList, string strAirline,
                                                  string strFilght, string departureDate, string strOrigin, bool hasFilter, string filterType)
        {
            GetPassengerListPortTypeClient client = new GetPassengerListPortTypeClient();
            try
            {
                SabreGetPassengerListRQ.MessageHeader header = new SabreGetPassengerListRQ.MessageHeader();
                SabreGetPassengerListRQ.Security security = new SabreGetPassengerListRQ.Security();
                List<SabreGetPassengerListRQ.PartyId> fromPartyId = new List<SabreGetPassengerListRQ.PartyId>();
                List<SabreGetPassengerListRQ.PartyId> toPartyId = new List<SabreGetPassengerListRQ.PartyId>();
                SabreGetPassengerListRQ.Service service = new SabreGetPassengerListRQ.Service();
                SabreGetPassengerListRQ.From from = new SabreGetPassengerListRQ.From();
                SabreGetPassengerListRQ.To to = new SabreGetPassengerListRQ.To();
                SabreGetPassengerListRQ.MessageData messageData = new SabreGetPassengerListRQ.MessageData();
                SabreGetPassengerListRQ.PartyId clientpartyId = new SabreGetPassengerListRQ.PartyId();
                SabreGetPassengerListRQ.PartyId supplierPartyId = new SabreGetPassengerListRQ.PartyId();
                SabreGetPassengerListRQ.DisplayCodeRequest displayCodeReq = new SabreGetPassengerListRQ.DisplayCodeRequest();
                SabreGetPassengerListRQ.DisplayCodes displayCode = new SabreGetPassengerListRQ.DisplayCodes();

                //from
                clientpartyId.Value = "Voejunto_HOM";
                fromPartyId.Add(clientpartyId);
                from.PartyId = fromPartyId.ToArray();
                header.From = from;
                ////to
                supplierPartyId.Value = "SWS_CERT";
                toPartyId.Add(supplierPartyId);
                to.PartyId = toPartyId.ToArray();
                header.To = to;

                header.CPAId = "G3";
                header.ConversationId = "Voejunto_HOM";
                messageData.Timestamp = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"); //"2020-12-18T14:06:11"
                header.MessageData = messageData;
                security.BinarySecurityToken = securityToken;
                header.Action = "GetPassengerListRQ";
                service.type = "string";
                header.Service = service;
                GetPassengerListRQ listRq = new GetPassengerListRQ();
                SabreGetPassengerListRQ.ItineraryRequest itinerary = new SabreGetPassengerListRQ.ItineraryRequest();

                //string[] codeList = new string[20];--
                //codeList[0] = "ON";--
                //codeList[1] = "XON";--

                itinerary.Airline = strAirline;
                itinerary.Flight = strFilght;
                itinerary.DepartureDate = departureDate;
                itinerary.Origin = strOrigin;
                listRq.Itinerary = itinerary;
                displayCode.conditionSpecified = hasFilter;

                if (hasFilter == true)
                {
                    switch (filterType)
                    {
                        case "OR":
                            displayCode.condition = AndOr.OR; //filterType;
                            break;
                        case "AND":
                            displayCode.condition = AndOr.AND; //filterType;
                            break;
                            //default:
                    }
                }

                displayCode.DisplayCode = codeList;
                displayCodeReq.DisplayCodes = displayCode;
                listRq.Item = displayCodeReq;
                listRq.messageID = "17867654537556";
                listRq.serviceOption = ServiceOptionType.Stateless;
                listRq.version = "4.0.0";

                client.OpenAsync();
                GetPassengerListRS result = new GetPassengerListRS();
                result = client.GetPassengerListRQ(ref header, ref security, listRq);
                client.CloseAsync();

                return result;
            }

            catch (System.Net.WebException we)
            {
                //Logger.Error(we, "Erro Timeout no GetPassengerListRQ ");
                Thread.Sleep(5000);
                client.CloseAsync();
            }
            catch (TimeoutException te)
            {
                //Logger.Error(te, "Erro Timeout no GetPassengerListRQ Tentativa ");
                Thread.Sleep(5000);
                client.CloseAsync();
            }
            catch (Exception ex)
            {
                //Logger.Error(ex, "GetPassengerListRQ Error: " + ex.Message);
                client.CloseAsync();
                throw;
            }
            client.CloseAsync();
            throw new TimeoutException("Erro Timeout no GetPassengerListRQ na Sabre");
        }

        //-------------------------------------------REMARKS-----------------------------------
        public UpdateReservationSabre.UpdateReservationRS UpdateReserveSabre(string token, string pnr, string comments)
        {
            UpdateReservationSabre.UpdateReservationPortTypeClient client = new UpdateReservationSabre.UpdateReservationPortTypeClient();

            try
            {
                UpdateReservationSabre.MessageHeader header = new UpdateReservationSabre.MessageHeader();
                UpdateReservationSabre.Security security = new UpdateReservationSabre.Security();
                UpdateReservationSabre.Service service = new UpdateReservationSabre.Service();
                UpdateReservationSabre.From from = new UpdateReservationSabre.From();
                UpdateReservationSabre.To to = new UpdateReservationSabre.To();
                UpdateReservationSabre.MessageData messageData = new UpdateReservationSabre.MessageData();
                List<UpdateReservationSabre.PartyId> fromPartyId = new List<UpdateReservationSabre.PartyId>();
                List<UpdateReservationSabre.PartyId> toPartyId = new List<UpdateReservationSabre.PartyId>();

                UpdateReservationSabre.PartyId clientpartyId = new UpdateReservationSabre.PartyId();
                clientpartyId.Value = "Voejunto_HOM";

                UpdateReservationSabre.PartyId supplierPartyId = new UpdateReservationSabre.PartyId();
                supplierPartyId.Value = "SWS_CERT";

                fromPartyId.Add(clientpartyId);
                toPartyId.Add(supplierPartyId);

                from.PartyId = fromPartyId.ToArray();
                to.PartyId = toPartyId.ToArray();
                header.From = from;
                header.To = to;

                service.Value = "UpdateReservationRQ";
                messageData.MessageId = "17867654537556";
                messageData.Timestamp = DateTime.Now.ToString("yyyy-MM-ddTHH:mm:ss"); //"2020-12-18T14:06:11"

                header.CPAId = "G3";
                header.MessageData = messageData;
                header.ConversationId = "Voejunto_HOM";
                header.Service = service;
                header.Action = "UpdateReservationRQ";
                security.BinarySecurityToken = token;

                UpdateReservationSabre.UpdateReservationRQ request = new UpdateReservationSabre.UpdateReservationRQ();
                UpdateReservationSabre.ReservationUpdateListType reserveList = new UpdateReservationSabre.ReservationUpdateListType();
                UpdateReservationSabre.LocatorWithPartitionType locatorType = new UpdateReservationSabre.LocatorWithPartitionType();
                UpdateReservationSabre.ReservationUpdateItemType reserveItem = new UpdateReservationSabre.ReservationUpdateItemType();
                UpdateReservationSabre.RemarkUpdatePNRB remarkUpdate = new UpdateReservationSabre.RemarkUpdatePNRB();

                locatorType.Value = pnr;
                reserveList.Locator = locatorType;
                remarkUpdate.id = "1";
                remarkUpdate.type = UpdateReservationSabre.RemarkTypePNRB.HS;
                remarkUpdate.op = UpdateReservationSabre.OperationTypePNRB.C;

                UpdateReservationSabre.ReservationUpdateItemType[] reserveItemList = new UpdateReservationSabre.ReservationUpdateItemType[10];
                UpdateReservationSabre.RemarkUpdatePNRB[] remarkUpdateList = new UpdateReservationSabre.RemarkUpdatePNRB[10];

                remarkUpdate.RemarkText = comments;
                remarkUpdateList[0] = remarkUpdate;

                reserveItemList[0] = reserveItem;
                reserveItem.RemarkUpdate = remarkUpdateList;//ReservationUpdateItem
                reserveList.ReservationUpdateItem = reserveItemList;//ReservationUpdateList

                UpdateReservationSabre.ReturnOptions returnOptions = new UpdateReservationSabre.ReturnOptions();
                UpdateReservationSabre.RequestType requestType = new UpdateReservationSabre.RequestType();

                returnOptions.IncludeUpdateDetails = true;
                returnOptions.RetrievePNR = true;
                requestType.Value = UpdateReservationSabre.RequestEnumerationType.Stateless;

                request.ReturnOptions = returnOptions;
                request.RequestType = requestType;

                request.Version = "1.19.0";
                request.ReservationUpdateList = reserveList;
                client.OpenAsync();

                var result = client.UpdateReservationOperation(ref header, ref security, request);
                client.CloseAsync();
                return result;

            }
            catch (System.Net.WebException we)
            {
                //Logger.Error(we, "Erro Timeout no UpdateReservationRS");
                Thread.Sleep(5000);
                client.CloseAsync();
            }
            catch (TimeoutException te)
            {
                //Logger.Error(te, "Erro Timeout no UpdateReservationRS");
                Thread.Sleep(5000);
                client.CloseAsync();
            }
            catch (Exception ex)
            {
                //Logger.Error(ex, "UpdateReservationRS Error: " + ex.Message);
                client.CloseAsync();
                throw;
            }
            client.CloseAsync();
            throw new TimeoutException("Erro Timeout no UpdateReservationRS na Sabre");
        }

    }
}
