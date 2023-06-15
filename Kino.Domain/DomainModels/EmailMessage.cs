using System;
using System.Collections.Generic;
using System.Text;

namespace Kino.Domain.DomainModels
{
    public class EmailMessage:BaseEntity
    {
        public string MailTo { get; set; }
        public string Subject { get; set; }
        public string Body { get; set; }
        public Boolean Status { get; set; }
    }
}
