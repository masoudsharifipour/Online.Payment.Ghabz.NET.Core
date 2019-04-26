using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Online.Payment.Ghabz.Repository.Models;
using Online.Payment.Ghabz.Repository.RepositoryGhabz;
using Online.Payment.Ghabz.Repository.Service.Dto;

namespace Online.Payment.Ghabz.Repository.Service.Imp
{
    public class GenerateGhabzService : IGenerateGhabzService
    {

        private readonly IRepository _repository;
        private readonly IMapper _mapper;

        public GenerateGhabzService(IRepository repository, IMapper mapper)
        {
            this._repository = repository;
            this._mapper = mapper;

        }

        public async Task<GenerateGhabzOutputDto> generateGhabz(GenerateGhabzInputDto generateGhabzInputDto)
        {
            try
            {
                var output = new GenerateGhabzOutputDto();
                int ShenaseGhabz = generateGhabzInputDto.ShenaseGhabz.Length;
                int ShenasePardakht = generateGhabzInputDto.ShenasePardakht.Length;

                if (ShenaseGhabz >= 6 && ShenaseGhabz <= 13)
                {
                    if (ShenasePardakht >= 6 && ShenasePardakht <= 13)
                    {
                        string s = generateGhabzInputDto.ShenaseGhabz;
                        string price = "";
                        for (int i = ShenaseGhabz; i >= 6; i--)
                        {

                            price += s[(ShenaseGhabz - i)].ToString();

                        }
                        output.Parvande = price;

                        char n;
                        n = s[ShenaseGhabz - 2];
                        switch (n)
                        {
                            case '1':
                                output.Type = "آب";
                                break;
                            case '2':
                                output.Type = "برق";
                                break;
                            case '3':
                                output.Type = "گاز";
                                break;
                            case '4':
                                output.Type = "تلفن ثابت";
                                break;
                            case '5':
                                output.Type = "تلفن همراه";
                                break;
                            case '6':
                                output.Type = "شهرداری";
                                break;
                            default:
                                output.Type = "نامعتبر";
                                break;
                        }


                        string m = generateGhabzInputDto.ShenasePardakht;
                        string amount = "";
                        for (int i = ShenasePardakht; i >= 6; i--)
                        {

                            amount += m[(ShenasePardakht - i)].ToString();

                        }
                        output.Price = amount + "000";

                        output.ShenaseGhabz = generateGhabzInputDto.ShenaseGhabz;
                        output.ShenasePardakht = generateGhabzInputDto.ShenasePardakht;

                        var result = this._mapper.Map<GhabzHistory>(output);
                        await this._repository.AddGhabz(result);
                        return output;

                    }
                    else
                    {
                        throw new Exception("اطلاعات وارد شده صحیح نیست");
                    }
                }
                else
                {
                    throw new Exception("اطلاعات وارد شده صحیح نیست");
                }
            }
            catch (Exception ex)
            {
                throw new Exception("خطایی رخ داده است", ex);
            }

        }

        public async Task<IQueryable<GhabzHistory>> GetGenerateGhabzHistory()
        {
            return this._repository.GetGhabzHistory();
        }

        public async Task<PaymentHistory> Payment(int id)
        {
            var ghabzHistory = this._repository.GetGhabzHistory().FirstOrDefault(x => x.Id == id);
            var input = new PaymentHistory
            {
                GhabzHistory = ghabzHistory,
                IsPayment = true,
                TrakingNumber = Guid.NewGuid().ToString("N"),
            };

            await this._repository.AddPayment(input);

            return input;
        }
    }
}
