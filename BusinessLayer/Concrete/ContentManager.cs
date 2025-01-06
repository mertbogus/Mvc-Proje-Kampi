using BusinessLayer.Abatract;
using EntityLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class ContentManager : IContentService
    {
        IContentDal _contentDal;

        public ContentManager(IContentDal contentDal)
        {
            _contentDal = contentDal;
        }

        public void ContentAddBL(Content content)
        {
            _contentDal.Insert(content);
        }

        public void ContentDeleteBL(Content content)
        {
           _contentDal.Delete(content);
        }

        public void ContentUpdateBL(Content content)
        {
            _contentDal.Update(content);
        }

        public Content GetByID(int id)
        {
            return _contentDal.Get(x=>x.ContentId==id);
        }

        public List<Content> GetContentList()
        {
            return _contentDal.List();
        }

        public List<Content> GetListByHeadingID(int id)
        {
            return _contentDal.List(x=>x.ContentId==id);
        }
    }
}
