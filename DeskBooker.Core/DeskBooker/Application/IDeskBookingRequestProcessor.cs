using DeskBooker.Core.DeskBooker.Domain;

namespace DeskBooker.Core.DeskBooker.Application
{
    public interface IDeskBookingRequestProcessor
    {
        DeskBookingResult BookDesk(DeskBookingRequest request);
    }
}