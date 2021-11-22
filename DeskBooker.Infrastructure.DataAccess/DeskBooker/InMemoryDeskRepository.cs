using DeskBooker.Core.DeskBooker.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskBooker.Infrastructure.DataAccess.DeskBooker
{
    public class InMemoryDeskRepository : IDeskRepository
    {       

        private readonly Dictionary<DateTime, List<Desk>> _availableDesks;

        public InMemoryDeskRepository()
        {
            _availableDesks = new Dictionary<DateTime, List<Desk>> ();          

        }

        private List<Desk> CreateDesksForDay()
        {
            List<Desk> availableDesksPerDay = new List<Desk>();
            for (int i = 1; i < 100; i++)
            {
                availableDesksPerDay.Add(new Desk() { Id = i });
            }
            return availableDesksPerDay;
        }

        public IEnumerable<Desk> GetAvailableDesks(DateTime date)
        {
            if(!_availableDesks.ContainsKey(date))
            {
                _availableDesks.Add(date, CreateDesksForDay());
            }

            return _availableDesks[date].Select(x => x);

        }


    }
}
