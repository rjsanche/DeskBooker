using System;
using System.Collections.Generic;

namespace DeskBooker.Core.DeskBooker.Domain
{
    public interface IDeskRepository
    {
        IEnumerable<Desk> GetAvailableDesks(DateTime date);
    }
}
