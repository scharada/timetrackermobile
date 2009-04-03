using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TimeTracker.Services.Contracts
{
    public class Task
    {
        public Guid Id { get; set; }
        public Guid ActivityId { get; set; }
        public DateTime DatetimeFrom { get; set; }
        public DateTime DatetimeTo { get; set; }
        public int Diff { get; set; }
        public Activity activity { get; set; }
    }
}
