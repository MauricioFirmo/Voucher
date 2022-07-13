using Voucher.Application.DTO;
using Voucher.Application.ServiceStack.Interfaces;
using Voucher.Domain;
using Voucher.Repository.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Voucher.Application.ServiceStack.AppServices
{
    public class EmailAppService : IEmailAppService
    {
        private readonly EmailRepository _emailRepository;
        public EmailAppService(EmailRepository emailRepository)
        {
            _emailRepository = emailRepository;
        }

        public async Task<Result> Delete(long idEmail)
        {
            await _emailRepository.Delete(idEmail);
            return new Result
            {

            };
        }
        public async Task<IEnumerable<AccommodationEmailTemplate>> List()
        {
            return await _emailRepository.List();
        }

        public async Task<AccommodationEmailTemplate> List(int idEmail)
        {
            return await _emailRepository.List(idEmail);
        }

        public async Task<Result> Save(AccommodationEmailTemplate email)
        {

            await _emailRepository.Update(email);
            return new Result
            {

            };
        }

        public async Task<Result> Create(AccommodationEmailTemplate email)
        {
            await _emailRepository.Insert(email);
            return new Result
            {

            };
        }
    }
}
