using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Online.Payment.Ghabz.Repository.Models;
using Online.Payment.Ghabz.Repository.Service;
using Online.Payment.Ghabz.Repository.Service.Dto;

namespace Online.Payment.Ghabz.Controllers
{
    [Route("OnlinePayment/Ghabz/")]
    [AllowAnonymous]
    public class PaymentController : Controller
    {
        public readonly IGenerateGhabzService _generateGhabzService;
        public readonly IMapper _mapper;

        public PaymentController(IGenerateGhabzService generateGhabzService, IMapper mapper)
        {
            this._generateGhabzService = generateGhabzService;
            this._mapper = mapper;
        }


        [HttpGet]
        [Route("GenerateGhabz")]
        public async Task<GenerateGhabzOutputDto> GenerateGhabz(GenerateGhabzInputDto generateGhabzInputDto)
        {
            return await this._generateGhabzService.generateGhabz(generateGhabzInputDto);
        }

        [HttpGet]
        [Route("GenerateGhabzHistory")]
        public async Task<IQueryable<GhabzHistory>> GenerateGhabzHistory()
        {
           return await this._generateGhabzService.GetGenerateGhabzHistory();

        }

        [HttpPost]
        [Route("payment")]
        public async Task<PaymentHistory> Payment(int Id)
        {
            return await this._generateGhabzService.Payment(Id);
        }

    }
}