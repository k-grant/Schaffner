using Schaffner_Server.Common.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace Schaffner_Server.Common.Interfaces
{
    //This class is for mocking and testing!
    public interface IBusSystemDataSource
    {
        IEnumerable<IStop> Stops { get; }

        IEnumerable<IRoute> Routes { get; }
    }
}
