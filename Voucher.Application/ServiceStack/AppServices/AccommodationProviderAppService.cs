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
    public class AccommodationProviderAppService : IAccommodationProviderAppService
    {
        private readonly AccommodationProviderRepository _accommodationProviderRepository;
        private readonly AccommodationProviderSpecialServiceRepository _accommodationProviderSpecialServiceRepository;
        private readonly SpecialServiceRepository _specialServiceRepository;
        private const string DISCRIMINATOR = "AccommodationProvider";

        public AccommodationProviderAppService(AccommodationProviderRepository accommodationProviderRepository, 
                                               AccommodationProviderSpecialServiceRepository accommodationProviderSpecialServiceRepository,
                                               SpecialServiceRepository specialServiceRepository)
        {
            _accommodationProviderRepository = accommodationProviderRepository;
            _accommodationProviderSpecialServiceRepository = accommodationProviderSpecialServiceRepository;
            _specialServiceRepository = specialServiceRepository;
        }

        public async Task<AccommodationProvider> Delete(long Id)
        {
            try
            {
                await _accommodationProviderRepository.Delete(Id);
                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AccommodationProviderReponse> Get(long Id)
        {
            try
            {
                AccommodationProviderReponse reponse = new AccommodationProviderReponse();
                AccommodationProvider accommodation = await _accommodationProviderRepository.Get(Id);
                IEnumerable<SpecialService> specialService = await _specialServiceRepository.GetList();

                reponse.AccommodationEmailTemplateId = accommodation.AccommodationEmailTemplateId;
                reponse.Active = accommodation.Active;
                reponse.Address = accommodation.Address;
                reponse.AirportIataCode = accommodation.AirportIataCode;
                reponse.CreatedBy = accommodation.CreatedBy;
                reponse.CreatedDate = accommodation.CreatedDate;
                reponse.Discriminator = accommodation.Discriminator;
                reponse.Distance = accommodation.Distance;
                reponse.Email = accommodation.Email;
                reponse.FreeText = accommodation.FreeText;
                reponse.Id = accommodation.Id;
                reponse.LastModifiedBy = accommodation.LastModifiedBy;
                reponse.LastModifiedDate = accommodation.LastModifiedDate;
                reponse.MaxPaxPerSharedRoom = accommodation.MaxPaxPerSharedRoom;
                reponse.MealPrice = accommodation.MealPrice;
                reponse.Name = accommodation.Name;
                reponse.Phone = accommodation.Phone;
                reponse.Priority = accommodation.Priority;
                reponse.SapCode = accommodation.SapCode;

                foreach (var item in specialService)
                {
                    AccommodationProviderSpecialService AccommodationProviderspecialservice = await _accommodationProviderSpecialServiceRepository.Get(Id, item.Id);
                    List<SpecialServiceResponse> specialsList = new List<SpecialServiceResponse>();

                    if (AccommodationProviderspecialservice != null)
                    {
                        if (Id == AccommodationProviderspecialservice.AccommodationProviderId &&
                            item.Id == AccommodationProviderspecialservice.SpecialServiceId)
                        {
                            SpecialServiceResponse special = new SpecialServiceResponse();

                            special.Id = AccommodationProviderspecialservice.SpecialService.Id;
                            special.Name = AccommodationProviderspecialservice.SpecialService.Name;

                            specialsList.Add(special);

                            reponse.SpecialServices = specialsList;
                        }
                    }
                }

                return reponse;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<IEnumerable<AccommodationProviderReponse>> GetList()
        {
            try
            {
                List<AccommodationProviderReponse> providerReponses = new List<AccommodationProviderReponse>();
                IEnumerable<AccommodationProvider> accommodationProviders = await _accommodationProviderRepository.GetList();
                IEnumerable<SpecialService> specialService = await _specialServiceRepository.GetList();

                foreach (AccommodationProvider itemAccommodationProvider in accommodationProviders)
                {
                    AccommodationProviderReponse Acsp = new AccommodationProviderReponse();

                    foreach (SpecialService itemSpecialService in specialService)
                    {
                        AccommodationProviderSpecialService AccommodationProviderspecialservice = await _accommodationProviderSpecialServiceRepository.Get(itemAccommodationProvider.Id, itemSpecialService.Id);
                        List<SpecialServiceResponse> specialsList = new List<SpecialServiceResponse>();


                        if (AccommodationProviderspecialservice != null)
                        {
                            if (itemAccommodationProvider.Id == AccommodationProviderspecialservice.AccommodationProviderId &&
                            itemSpecialService.Id == AccommodationProviderspecialservice.SpecialServiceId)
                            {
                                SpecialServiceResponse special = new SpecialServiceResponse();
                                
                                Acsp.AccommodationEmailTemplateId = itemAccommodationProvider.AccommodationEmailTemplateId;
                                Acsp.Active = itemAccommodationProvider.Active;
                                Acsp.Address = itemAccommodationProvider.Address;
                                Acsp.AirportIataCode = itemAccommodationProvider.AirportIataCode;
                                Acsp.CreatedBy = itemAccommodationProvider.CreatedBy;
                                Acsp.CreatedDate = itemAccommodationProvider.CreatedDate;
                                Acsp.Discriminator = itemAccommodationProvider.Discriminator;
                                Acsp.Distance = itemAccommodationProvider.Distance;
                                Acsp.Email = itemAccommodationProvider.Email;
                                Acsp.FreeText = itemAccommodationProvider.FreeText;
                                Acsp.Id = itemAccommodationProvider.Id;
                                Acsp.LastModifiedBy = itemAccommodationProvider.LastModifiedBy;
                                Acsp.LastModifiedDate = itemAccommodationProvider.LastModifiedDate;
                                Acsp.MaxPaxPerSharedRoom = itemAccommodationProvider.MaxPaxPerSharedRoom;
                                Acsp.MealPrice = itemAccommodationProvider.MealPrice;
                                Acsp.Name = itemAccommodationProvider.Name;
                                Acsp.Phone = itemAccommodationProvider.Phone;
                                Acsp.Priority = itemAccommodationProvider.Priority;
                                Acsp.SapCode = itemAccommodationProvider.SapCode;

                                special.Id = AccommodationProviderspecialservice.SpecialService.Id;
                                special.Name = AccommodationProviderspecialservice.SpecialService.Name;
                                specialsList.Add(special);
                                
                                Acsp.SpecialServices = specialsList;
                            }
                        }
                    }

                    providerReponses.Add(Acsp);
                }
                return providerReponses;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        public async Task<AccommodationProvider> Insert(AccommodationProviderRequest request)
        {
            try
            {
                AccommodationProvider entity = new AccommodationProvider
                {
                    Active = request.Active,
                    Address = request.Address,
                    AirportIataCode = request.AirportIataCode,
                    CreatedBy = request.CreatedBy,
                    CreatedDate = request.CreatedDate,
                    Distance = request.Distance,
                    Email = request.Email,
                    FreeText = request.FreeText,
                    Id = request.Id,
                    LastModifiedBy = request.LastModifiedBy,
                    LastModifiedDate = request.LastModifiedDate,
                    Name = request.Name,
                    Phone = request.Phone,
                    Priority = request.Priority,
                    AccommodationEmailTemplateId = request.AccommodationEmailTemplateId,
                    MaxPaxPerSharedRoom = request.MaxPaxPerSharedRoom,
                    MealPrice = request.MealPrice,
                    SapCode = request.SapCode,
                    Discriminator = DISCRIMINATOR
                };

                var accommodationId = await _accommodationProviderRepository.Insert(entity);

                foreach (var item in request.AccommodationProviderSpecialServices)
                {
                    AccommodationProviderSpecialService service = new AccommodationProviderSpecialService
                    {
                        AccommodationProviderId = accommodationId,
                        SpecialServiceId = item.SpecialServiceId
                    };

                    await _accommodationProviderSpecialServiceRepository.Insert(service);
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<AccommodationProvider> Update(AccommodationProviderRequest request)
        {
            try
            {
                AccommodationProvider entity = new AccommodationProvider
                {
                    Active = request.Active,
                    Address = request.Address,
                    AirportIataCode = request.AirportIataCode,
                    CreatedBy = request.CreatedBy,
                    CreatedDate = request.CreatedDate,
                    Distance = request.Distance,
                    Email = request.Email,
                    FreeText = request.FreeText,
                    Id = request.Id,
                    LastModifiedBy = request.LastModifiedBy,
                    LastModifiedDate = request.LastModifiedDate,
                    Name = request.Name,
                    Phone = request.Phone,
                    Priority = request.Priority,
                    AccommodationEmailTemplateId = request.AccommodationEmailTemplateId,
                    MaxPaxPerSharedRoom = request.MaxPaxPerSharedRoom,
                    MealPrice = request.MealPrice,
                    SapCode = request.SapCode,
                    Discriminator = DISCRIMINATOR
                    
                };

                var accommodationId =  await _accommodationProviderRepository.Update(entity);

                foreach (var item in request.AccommodationProviderSpecialServices)
                {
                    AccommodationProviderSpecialService service = new AccommodationProviderSpecialService
                    {
                        AccommodationProviderId = accommodationId,
                        SpecialServiceId = item.SpecialServiceId
                    };

                    await _accommodationProviderSpecialServiceRepository.Update(service);
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
