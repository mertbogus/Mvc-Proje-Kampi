using BusinessLayer.Abatract;
using DataAccessLayer.EntityFramework;
using EntityLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        IAboutDal _AboutDal;

        public AboutManager(IAboutDal aboutDal)
        {
            _AboutDal = aboutDal;
        }

        public void AboutAddBL(About about)
        {
            _AboutDal.Insert(about);
        }

        public void AboutDeleteBL(About about)
        {
            _AboutDal.Delete(about);
        }

        public void AboutUpdateBL(About about)
        {
            _AboutDal.Update(about);
        }

        public List<About> GetAboutList()
        {
            return _AboutDal.List();
        }

        public About GetByID(int id)
        {
            return _AboutDal.Get(x=>x.AboutId==id);
        }
    }
}
