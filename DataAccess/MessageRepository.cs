using System;
using System.Collections.Generic;
using System.Linq;
using DomainModel.Models;

namespace DataAccess
{
    public class MessageRepository : Interfaces.IMessageRepository
    {
        private ZilatanBotContext db = new ZilatanBotContext();
        public int Add(Message Current)
        {
            db.Messages.Add(Current);
            db.SaveChanges();
            return Current.Id;
        }

        public int Count()
        {
            return db.Messages.ToList().Count();
        }

        public int Count(Message sm)
        {
            return db.Messages.Where(x => x.Id == sm.Id).Count();
        }

        public bool Delete(int ID)
        {
            db.Messages.Remove(db.Messages.SingleOrDefault(x => x.Id == ID));
            db.SaveChanges();
            return true;
        }

        public bool DeleteRange(List<int> IDS)
        {
            var q = from item in db.Messages where IDS.Contains(item.Id) select item;
            db.Messages.RemoveRange(q);
            db.SaveChanges();
            return true;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }

        public bool Edit(Message Current)
        {
            db.Messages.Attach(Current);
            db.Entry<Message>(Current).State = System.Data.Entity.EntityState.Modified;
            db.SaveChanges();
            return true;
        }

        public Message Get(int ID)
        {
            var q = from item in db.Messages where item.Id == ID select item;
            return q.SingleOrDefault();

            var s = db.Messages.SingleOrDefault(x => x.Id == ID);
        }

        public List<Message> GetAll()
        {
            return db.Messages.ToList();
        }

        public Message GetByMessageID(int MessageID)
        {
            return db.Messages.Where(x => x.message_Id == MessageID).FirstOrDefault();
        }

        public List<Message> GetSeachResult(Message sm, out int RecordCount)
        {
            throw new NotImplementedException();
        }

        public List<Message> Search(Message sm, out int RecordCount)
        {
            var q = from item in db.Messages where item.from_username == sm.from_username select item;
            RecordCount = q.Count();
            return q.ToList();
        }

        
    }
}
