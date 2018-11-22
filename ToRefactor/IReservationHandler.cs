

using RefactoringTest.Entities;

namespace RefactoringTest.ToRefactor
{
    public interface IReservationHandler
    {
        void ReserveSeat(BookingInfo info);
        void ReserveSeat(BookingInfo info, bool isOutwardJourney);
    }
}