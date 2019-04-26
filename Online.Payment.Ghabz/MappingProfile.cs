using AutoMapper;
using Online.Payment.Ghabz.Repository.Models;
using Online.Payment.Ghabz.Repository.Service.Dto;
using System.Linq;

namespace Online.Payment.Ghabz
{
    internal class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<GenerateGhabzOutputDto, GhabzHistory>();

            CreateMap<IQueryable<GenerateGhabzOutputDto>, GhabzHistory>();
        }
    }
}