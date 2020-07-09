using System;
using System.Collections.Generic;
using System.Text;

namespace BackendArchitecture.Entities
{
    public class Link : EntityBase
    {
        public Guid UserId { get; set; }

        public string Uri { get; set; }

        public ICollection<Tag> Tags { get; set; }
    }
}
