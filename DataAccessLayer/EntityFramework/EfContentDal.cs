using DataAccessLayer.Concrete.Repositories;
using EntityLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfContentDal : GenericRepository<Content>, IContentDal
    {
    }
}
