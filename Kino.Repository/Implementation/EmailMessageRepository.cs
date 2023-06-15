using Kino.Domain.DomainModels;
using Kino.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Kino.Repository.Implementation
{
    public class EmailMessageRepository:IRepository<EmailMessage>
    {
        private readonly List<EmailMessage> _emails;
        public EmailMessageRepository()
        {
            _emails = new List<EmailMessage>();
        }

        public void Delete(EmailMessage entity)
        {
            _emails.Remove(entity);
        }

        public EmailMessage Get(Guid? id)
        {
            return _emails.FirstOrDefault(x => x.Id == id);
        }

        public IEnumerable<EmailMessage> GetAll()
        {
            return _emails;
        }

        public void Insert(EmailMessage entity)
        {
           _emails.Add(entity);
        }

        public void Remove(EmailMessage entity)
        {
            _emails.Remove(entity);
        }

        public void SaveChanges()
        {
            throw new NotImplementedException();
        }

        public void Update(EmailMessage entity)
        {
            var existingMessage = _emails.FirstOrDefault(e => e.Id == entity.Id);
            if (existingMessage != null)
            {
                existingMessage.Subject = entity.Subject;
                existingMessage.Body = entity.Body;
                existingMessage.MailTo = entity.MailTo;
                existingMessage.Status = entity.Status;
            }
        }
    }
}
