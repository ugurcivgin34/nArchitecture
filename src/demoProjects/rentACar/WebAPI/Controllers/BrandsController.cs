using Application.Features.Brands.Commands.CreateBrand;
using Application.Features.Brands.Dtos;
using Application.Features.Brands.Models;
using Application.Features.Brands.Queries.GetByIdBrand;
using Application.Features.Brands.Queries.GetListBrand;
using Core.Application.Requests;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BrandsController : BaseController
    {
        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateBrandCommand createBrandCommand) //FromBody post operasyonlarında body den okuduğumuz için
        {
            CreatedBrandDto result = await Mediator.Send(createBrandCommand);
            return Created("", result); //Bu dataya ulaşmak için adresi "" yerine istek adresini yani linkini yazarak da verebiliriz.Boş da verebiliriz.
        }

        [HttpGet]
        public async Task<IActionResult> GetList([FromQuery] PageRequest pageRequest) //FromQuery Get yani query opereasyonlarında okuduğumuz için
        {
            GetListBrandQuery getListBrandQuery = new() { PageRequest = pageRequest };
            BrandListModel result = await Mediator.Send(getListBrandQuery);
            return Ok(result);
        }

        [HttpGet("{Id}")] //Property deki id neyse o şekilde olması lazım
        public async Task<IActionResult> GetById([FromRoute] GetByIdBrandQuery getByIdBrandQuery) //FromQuery Get yani query opereasyonlarında okuduğumuz için
        {
            BrandGetByIdDto brandGetByIdDto = await Mediator.Send(getByIdBrandQuery);
            return Ok(brandGetByIdDto);
        }
    }
}
