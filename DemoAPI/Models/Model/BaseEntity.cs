using System;
using System.Collections.Generic;
using System.Text;

namespace DemoAPI.Models
{
    public abstract class BaseEntity
    {
        public string Id { get; set; }
        public DateTimeOffset CreatedDateTime;

        public BaseEntity()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedDateTime = DateTimeOffset.Now;
        }
    }
}
