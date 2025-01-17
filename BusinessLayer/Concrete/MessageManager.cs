using BusinessLayer.Abatract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class MessageManager : IMessageService
    {
        IMessageDal _messageDal;

        public MessageManager(IMessageDal messageDal)
        {
            _messageDal = messageDal;
        }

        public void Add(Message message)
        {
            _messageDal.Insert(message);
        }

        public void Delete(Message message)
        {
            _messageDal.Delete(message);
        }

        public List<Message> GetAll(Expression<Func<Message, bool>> filter)
        {
            return _messageDal.List(filter);
        }

        public Message GetById(int id)
        {
            return _messageDal.Get(x => x.MessageId == id);
        }

        public List<Message> GetListInbox(string userEmail)
        {
           return  _messageDal.List(x=>x.ReceiverMail== userEmail);
        }

        public List<Message> GetListSendbox(string userEmail)
        {
            return _messageDal.List(x => x.SenderMail== userEmail);
        }


        public void Update(Message message)
        {
            _messageDal.Update(message);
        }


    }
}
