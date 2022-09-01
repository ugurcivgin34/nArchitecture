﻿using Application.Features.Brands.Dtos;
using Application.Features.Brands.Rules;
using Application.Services.Repositories;
using AutoMapper;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Features.Brands.Commands.CreateBrand
{
    //Buraya bir komut ortaya atılıyor.Mediatr paterni kullanılarak bu commandi kim tüketiyorsa,hangi handler tüketiyorsa onun handler metodunu çalıştırıyor.
    public class CreateBrandCommand : IRequest<CreatedBrandDto>
    {
        public string Name { get; set; }


        //Bu requesti gerçekleştirecek commmand i veriyoruz.Sağa da dönüş tipimizi veriyoruz.
        public class CreatedBrandCommandHandler : IRequestHandler<CreateBrandCommand, CreatedBrandDto>
        {

            private readonly IBrandRepository _brandRepository;
            private readonly IMapper _mapper;
            private readonly BrandBusinessRules _brandBusinessRules;

            public CreatedBrandCommandHandler(IBrandRepository brandRepository, IMapper mapper, BrandBusinessRules brandBusinessRules)
            {
                _brandRepository = brandRepository;
                _mapper = mapper;
                _brandBusinessRules = brandBusinessRules;
            }

            public async Task<CreatedBrandDto> Handle(CreateBrandCommand request, CancellationToken cancellationToken)
            {
                await _brandBusinessRules.BrandNameCanNotBeDuplicatedWhenInserted(request.Name);

                Brand mappedBrand = _mapper.Map<Brand>(request); //api den gelen isteği commende çevirdik.Veritabanı entiti'sine çevirdik
                Brand createdBrand = await _brandRepository.AddAsync(mappedBrand);
                CreatedBrandDto createdBrandDto = _mapper.Map<CreatedBrandDto>(createdBrand);//Veritabanından gelen nesneyi  dto 'a çeviriyoruz

                //Mapperin yaptığı işlem aşağıdaki gibidir
                //CreatedBrandDto createdBrandDto1 = new CreatedBrandDto();
                //createdBrand.Id = mappedBrand.Id;
                //createdBrand.Name = mappedBrand.Name;

                return createdBrandDto;
            }
        }
    }
}
