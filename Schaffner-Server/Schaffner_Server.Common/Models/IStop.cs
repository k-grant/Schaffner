using System;
using System.Collections.Generic;
using System.Text;

namespace Schaffner_Server.Common.Models
{
    public interface IStop
    {
        int Id { get; }

        string Name { get; }
    }
}
