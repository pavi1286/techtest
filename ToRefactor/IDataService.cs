using System.Collections.Generic;
using RefactoringTest.Entities;

namespace RefactoringTest
{
    public interface IDataService
    {
        List<BookingInfo> GetPendingBookings();
		void ConfirmSeatReservation(IJourney journey, int bookingId);
    }
}