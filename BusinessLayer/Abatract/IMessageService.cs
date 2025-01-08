using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abatract
{
    public  interface IMessageService
    {
        List<Message> GetListInbox(string userEmail);
        List<Message> GetListSendbox(string userEmail);
        Message GetById(int id);
        void Add(Message message);
        void Update(Message message);
        void Delete(Message message);
        List<Message> GetAll(Expression<Func<Message, bool>> filter);
    }
}
