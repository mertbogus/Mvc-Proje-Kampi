using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abatract
{
    public interface IAboutService
    {
        List<About> GetAboutList();

        void AboutAddBL(About about);

        About GetByID(int id);

        void AboutDeleteBL(About about);

        void AboutUpdateBL(About about);
    }
}
