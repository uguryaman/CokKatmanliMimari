using EntityLayer.Concreate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract
{
    public interface IMessageService
    {
        List<Message> GEtlistInbox();
        List<Message> GEtlistSendbox();
        void MessageAdd(Message message);
        void MessageDelete(Message message);
        void MessageUpdate(Message message);
        Message GetById(int id);
        List<Message> GetListByID(int id);
    }
}
