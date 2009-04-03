using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeTracker.Services.Contracts
{
    public class Activity
    {
        public Guid Id { get; set; }
        public string Description { get; set; }
        public string Color { get; set; }
    }
}
