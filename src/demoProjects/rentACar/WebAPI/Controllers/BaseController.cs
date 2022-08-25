using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebAPI.Controllers
{
    public class BaseController : ControllerBase
    {

        //Mediator varsa onu döndür yoksa git servislerden IMediatoru çöz onu bana ver şeklinde IoC ye söylüyoruz
        protected IMediator? Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>();
        private IMediator? _mediator;


    }
}
