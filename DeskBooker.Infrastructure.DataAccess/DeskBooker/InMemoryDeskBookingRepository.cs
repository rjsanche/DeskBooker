using DeskBooker.Core.DeskBooker.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DeskBooker.Infrastructure.DataAccess.DeskBooker
{
    public class InMemoryDeskBookingRepository : IDeskBookingRepository
    {
        private readonly List<DeskBooking> _deskBookingList;


        public InMemoryDeskBookingRepository()
        {
            _deskBookingList = new List<DeskBooking>();
        }

        public void Save(DeskBooking deskBooking)
        {
            _deskBookingList.Add(deskBooking);
        }
    }
}
