using BusinessLayer.Abatract;

using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using DataAccessLayer.Abstract;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EntityLayer.Abstract;

namespace BusinessLayer.Concrete
{
    public class WriterManager : IWriterService
    {
        IWriterDal _writerDal;

        public WriterManager(IWriterDal writerDal)
        {
            _writerDal = writerDal;
        }

        public Writer GetById(int id)
        {
            return _writerDal.Get(x=>x.WriterId==id);
        }

        public List<Writer> GetListBL()
        {
            return _writerDal.List();
        }

        public void WriterAddBL(Writer writer)
        {
            _writerDal.Insert(writer);
        }

        public void WriterDeleteBL(Writer writer)
        {
            _writerDal.Delete(writer);
        }

        public void WriterUpdateBL(Writer writer)
        {
            _writerDal.Update(writer);
        }
    }
}
