using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abatract
{
    public interface IContactService
    {
        List<Contact> GetContactList();

        void ContactAddBL(Contact contact);

        Contact GetByID(int id);

        void ContactDeleteBL(Contact contact);

        void ContactUpdateBL(Contact contact);
    }
}
