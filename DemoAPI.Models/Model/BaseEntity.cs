﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DemoAPI.Core.Models
{
    public abstract class BaseEntity
    {
        public string Id { get; set; }
        public DateTime CreatedDateTime { get; set; }

        public BaseEntity()
        {
            this.Id = Guid.NewGuid().ToString();
            this.CreatedDateTime = DateTime.Now;
        }
    }
}
