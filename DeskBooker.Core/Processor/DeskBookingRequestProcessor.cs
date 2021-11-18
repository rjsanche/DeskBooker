using DeskBooker.Core.Domain;
using DeskBooker.Core.Interface;
using System;
using System.Collections.Generic;
using System.Linq;

namespace DeskBooker.Core.Processor
{
    public class DeskBookingRequestProcessor
    {
        private readonly IDeskBookingRepository _deskBookingRepository;
        private readonly IDeskRepository _deskRepository;

        public DeskBookingRequestProcessor(IDeskBookingRepository deskBookingRepository, IDeskRepository deskRepository)
        {
            _deskBookingRepository = deskBookingRepository;
            _deskRepository = deskRepository;
        }

        public DeskBookingResult BookDesk(DeskBookingRequest request)
        {
            if (request == null)
            {
                throw new ArgumentNullException(nameof(request));
            }
            IEnumerable<Desk> availableDesks = _deskRepository.GetAvailableDesks(request.Date);
            if (availableDesks.Any())
            {
                Desk availableDesk = availableDesks.First();
                DeskBooking newDeskBooking = Create<DeskBooking>(request);
                newDeskBooking.DeskId = availableDesk.Id;
                _deskBookingRepository.Save(newDeskBooking);
            }

            return Create<DeskBookingResult>(request);

        }

        private static T Create<T>(DeskBookingRequest request) where T: DeskBookingBase, new()
        {
            return new T()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                Email = request.Email,
                Date = request.Date,
            };
        }
    }
}