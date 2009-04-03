using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace TimeTracker
{
    class ElapsedStatus
    {
        // This method is called by the timer delegate.
        public void Check(Object stateInfo)
        {
            AutoResetEvent autoEvent = (AutoResetEvent)stateInfo;

            autoEvent.Set();
        }
    }
}
