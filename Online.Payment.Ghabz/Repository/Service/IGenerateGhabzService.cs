using Online.Payment.Ghabz.Repository.Models;
using Online.Payment.Ghabz.Repository.Service.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Online.Payment.Ghabz.Repository.Service
{
    public interface IGenerateGhabzService
    {
        Task<GenerateGhabzOutputDto> generateGhabz(GenerateGhabzInputDto generateGhabzInputDto);
        Task<IQueryable<GhabzHistory>> GetGenerateGhabzHistory();
        Task<PaymentHistory> Payment(int id);
    }
}
