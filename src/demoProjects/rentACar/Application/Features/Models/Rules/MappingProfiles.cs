using Application.Features.Models.Dtos;
using Application.Features.Models.Models;
using AutoMapper;
using Core.Persistence.Paging;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Models.Rules
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Model, ModelListDto>().ForMember(c => c.BrandName, opt => opt.MapFrom(c => c.Brand.Name)).ReverseMap();//BrandName Modelin içinde tanımlı olmadığı için brand dan çekmemiz gerektiği için bu şekilde yaptık
            CreateMap<IPaginate<Model>, ModelListModel>().ReverseMap();
        }
    }
}
