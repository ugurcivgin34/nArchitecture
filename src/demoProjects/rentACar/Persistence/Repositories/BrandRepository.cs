using Application.Services.Repositories;
using Core.Persistence.Repositories;
using Domain.Entities;
using Persistence.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.Repositories
{

    //Kulllanıcı markaya göre , renk e göre filtrelemeler yapabilir.Bunun kodları corePackages altında Dynamic kla
    //söründe bulunmaktadır.Aynı zamanada sayfalama için yapı da bulunmaktadır.Paging kısmında
    //Repositroies klasöründe hem asenkronlu hem asenkronsuz repositories de vardır
    public class BrandRepository : EfRepositoryBase<Brand, BaseDbContext>, IBrandRepository
    {
        public BrandRepository(BaseDbContext context) : base(context)
        {
        }
        
    }
}