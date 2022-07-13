using Voucher.Application.DTO;
using Voucher.Application.ServiceStack.Interfaces;
using Voucher.Domain;
using Voucher.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Voucher.Application.ServiceStack.AppServices
{
    public class ReportVoucherAppService : IReportVoucherAppService
    {
        private readonly AccommodationVoucherRepository _accommodationVoucherRepository;
        private readonly AccommodationProviderRepository _accommodationProviderRepository;
        private readonly TransportVoucherRepository _transportVoucherRepository;
        private readonly TransportProviderRepository _transportProviderRepository;
        private readonly FoodVoucherRepository _foodVoucherRepository;
        private readonly FoodProviderRepository _foodProviderRepository;
        private readonly PassengerRepository _passengerRepository;
        private readonly FlightRepository _flightRepository;
        private decimal TotalHotels;
        private decimal TotalFood;
        private decimal TotalTransport;
        private decimal GrandTotal;
        
        public ReportVoucherAppService(AccommodationVoucherRepository accommodationVoucherRepository,
                                       AccommodationProviderRepository accommodationProviderRepository,
                                       TransportVoucherRepository transportVoucherRepository,
                                       TransportProviderRepository transportProviderRepository,
                                       FoodVoucherRepository foodVoucherRepository,
                                       FoodProviderRepository foodProviderRepository,
                                       PassengerRepository passengerRepository,
                                       FlightRepository flightRepository)
        {
            _accommodationVoucherRepository = accommodationVoucherRepository;
            _accommodationProviderRepository = accommodationProviderRepository;
            _transportVoucherRepository = transportVoucherRepository;
            _transportProviderRepository = transportProviderRepository;
            _foodVoucherRepository = foodVoucherRepository;
            _foodProviderRepository = foodProviderRepository;
            _passengerRepository = passengerRepository;
            _flightRepository = flightRepository;
        }

        public async Task<IEnumerable<ReportVoucherResponse>> GetListReport(ReportVoucherRequest request)
        {
            try
            {
                List<ReportVoucherResponse> responses = new List<ReportVoucherResponse>();
                IEnumerable<Flight> flights = await GetFlights(request.Flight, request.FirstPeriod, request.FinalPeriod);

                foreach (var flight in flights)
                {
                    IEnumerable<Passenger> passengers = await GetPassengerByFlight(flight.Id);

                    foreach (var passenger in passengers)
                    {
                        IEnumerable<FoodVoucher> foodVouchers = await _foodVoucherRepository.GetListByReport(passenger.Id, passenger.FlightId, request.FirstPeriod, request.FinalPeriod);

                        foreach (var foodVoucher in foodVouchers)
                        {
                            FoodProvider foodProvider = await GetFoodProvider(foodVoucher.ServiceProviderId);

                            if (foodProvider.AirportIataCode == request.AirportIataCode)
                            {
                                ReportVoucherResponse reportFood = await AddReponseFood(foodProvider, flight, request, passenger, foodVoucher);
                                if (reportFood != null)
                                {
                                    responses.Add(reportFood);
                                }
                            }
                        }

                        IEnumerable<AccommodationVoucher> accommodationVouchers = await _accommodationVoucherRepository.GetListByReport(passenger.Id, passenger.FlightId, request.FirstPeriod, request.FinalPeriod);

                        foreach (var accommodationVoucher in accommodationVouchers)
                        {
                            AccommodationProvider accommodationProvider = await GetAccommodationProvider(accommodationVoucher.ServiceProviderId);

                            if (accommodationProvider.AirportIataCode == request.AirportIataCode)
                            {
                                ReportVoucherResponse reportAccommodation = await AddReponseAccommodation(accommodationProvider, flight, request, passenger, accommodationVoucher);
                                if (reportAccommodation != null)
                                {
                                    responses.Add(reportAccommodation);
                                }
                            }
                        }

                        IEnumerable<TransportVoucher> TransportVouchers = await _transportVoucherRepository.GetListByReport(passenger.Id, passenger.FlightId, request.FirstPeriod, request.FinalPeriod);

                        foreach (var transportVoucher in TransportVouchers)
                        {
                            TransportProvider transportProvider = await GetTransportProvider(transportVoucher.ServiceProviderId);

                            if (transportProvider.AirportIataCode == request.AirportIataCode)
                            {
                                ReportVoucherResponse reportTransport = await AddReponseTransport(transportProvider, flight, request, passenger, transportVoucher);
                                if (reportTransport != null)
                                {
                                    responses.Add(reportTransport);
                                }
                            }
                        }
                    }
                }
                return responses.Select(r =>
                                            {
                                                r.TotalHotels = TotalHotels;
                                                r.TotalFood = TotalFood;
                                                r.TotalTransport = TotalTransport;
                                                r.GrandTotal = TotalHotels + TotalFood + TotalTransport;
                                                return r;
                                            });
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<IEnumerable<Flight>> GetFlights(string Flight, DateTime FirstDate, DateTime LastDate)
        {
            try
            {
                return await _flightRepository.GetFlightPerPeriod(Flight, FirstDate, LastDate);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<IEnumerable<Passenger>> GetPassengerByFlight(long FlightId)
        {
            try
            {
                return await _passengerRepository.GetPassengerByFlight(FlightId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<FoodProvider> GetFoodProvider(long ServiceProviderId)
        {
            try
            {
                return await _foodProviderRepository.Get(ServiceProviderId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<AccommodationProvider> GetAccommodationProvider(long ServiceProviderId)
        {
            try
            {
                return await _accommodationProviderRepository.Get(ServiceProviderId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<TransportProvider> GetTransportProvider(long ServiceProviderId)
        {
            try
            {
                return await _transportProviderRepository.Get(ServiceProviderId);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<ReportVoucherResponse> AddReponseFood(FoodProvider foodProvider, Flight flight, ReportVoucherRequest request, Passenger passenger, FoodVoucher foodVoucher)
        {
            try
            {
                ReportVoucherResponse reportFood = new ReportVoucherResponse();

                reportFood.AirportIataCode = foodProvider.AirportIataCode;
                reportFood.Destino = flight.ArrivalStation;
                reportFood.FlightNumber = flight.FlightNumber;
                reportFood.VoucherId = foodVoucher.Id;
                reportFood.Satus = foodVoucher.Status;
                reportFood.CanceledDate = foodVoucher.CanceledDate;
                reportFood.Discriminator = foodVoucher.Discriminator;
                reportFood.Price = foodProvider.Price;
                reportFood.Name = foodProvider.Name;
                reportFood.RecordLocator = passenger.RecordLocator;
                reportFood.PassengerName = passenger.FirstName + " " + passenger.MiddleName + " " + passenger.LastName;
                TotalFood = TotalFood + foodProvider.Price;

                if (request.Status == StatusType.issued)
                {
                    if (foodVoucher.Status == StatusType.issued)
                    {
                        return await Task.FromResult(reportFood);
                    }
                }
                
                if (request.Status == StatusType.canceled)
                {
                    if (foodVoucher.Status == StatusType.canceled)
                    {
                        return await Task.FromResult(reportFood);
                    }
                }

                if (request.Status == StatusType.all)
                {
                    return await Task.FromResult(reportFood);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<ReportVoucherResponse> AddReponseAccommodation(AccommodationProvider accommodationProvider, Flight flight, ReportVoucherRequest request, Passenger passenger, AccommodationVoucher accommodationVoucher)
        {
            try
            {
                ReportVoucherResponse reportAccommodation = new ReportVoucherResponse();

                reportAccommodation.AirportIataCode = accommodationProvider.AirportIataCode;
                reportAccommodation.Destino = flight.ArrivalStation;
                reportAccommodation.FlightNumber = flight.FlightNumber;
                reportAccommodation.VoucherId = accommodationVoucher.Id;
                reportAccommodation.Satus = accommodationVoucher.Status;
                reportAccommodation.CanceledDate = accommodationVoucher.CanceledDate;
                reportAccommodation.Discriminator = accommodationVoucher.Discriminator;
                reportAccommodation.Price = accommodationProvider.MealPrice;
                reportAccommodation.Name = accommodationProvider.Name;
                reportAccommodation.RecordLocator = passenger.RecordLocator;
                reportAccommodation.PassengerName = passenger.FirstName + " " + passenger.MiddleName + " " + passenger.LastName;
                TotalHotels = TotalHotels + accommodationProvider.MealPrice;

                if (request.Status == StatusType.issued)
                {
                    if (accommodationVoucher.Status == StatusType.issued)
                    {
                        return await Task.FromResult(reportAccommodation);
                    }
                }

                if (request.Status == StatusType.canceled)
                {
                    if (accommodationVoucher.Status == StatusType.canceled)
                    {
                        return await Task.FromResult(reportAccommodation);
                    }
                }

                if (request.Status == StatusType.all)
                {
                    return await Task.FromResult(reportAccommodation);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private async Task<ReportVoucherResponse> AddReponseTransport(TransportProvider transportProvider, Flight flight, ReportVoucherRequest request, Passenger passenger, TransportVoucher transportVoucher)
        {
            try
            {
                ReportVoucherResponse reportTransport = new ReportVoucherResponse();

                reportTransport.AirportIataCode = transportProvider.AirportIataCode;
                reportTransport.Destino = flight.ArrivalStation;
                reportTransport.FlightNumber = flight.FlightNumber;
                reportTransport.VoucherId = transportVoucher.Id;
                reportTransport.Satus = transportVoucher.Status;
                reportTransport.CanceledDate = transportVoucher.CanceledDate;
                reportTransport.Discriminator = transportVoucher.Discriminator;
                reportTransport.Price = transportProvider.Price;
                reportTransport.Name = transportProvider.Name;
                reportTransport.RecordLocator = passenger.RecordLocator;
                reportTransport.PassengerName = passenger.FirstName + " " + passenger.MiddleName + " " + passenger.LastName;
                TotalTransport = TotalTransport + transportProvider.Price;

                if (request.Status == StatusType.issued)
                {
                    if (transportVoucher.Status == StatusType.issued)
                    {
                        return await Task.FromResult(reportTransport);
                    }
                }

                if (request.Status == StatusType.canceled)
                {
                    if (transportVoucher.Status == StatusType.canceled)
                    {
                        return await Task.FromResult(reportTransport);
                    }
                }

                if (request.Status == StatusType.all)
                {
                    return await Task.FromResult(reportTransport);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
