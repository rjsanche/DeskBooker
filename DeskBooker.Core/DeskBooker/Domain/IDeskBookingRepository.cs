namespace DeskBooker.Core.DeskBooker.Domain
{
    public interface IDeskBookingRepository
    {
        void Save(DeskBooking deskBooking);
    }
}
