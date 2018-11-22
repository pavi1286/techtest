using System;
using System.Collections.Generic;
using RefactoringTest;
using RefactoringTest.Entities;
using RefactoringTest.Enumerations;

namespace RefactoringUnitTests
{
    public class MockDataService : IDataService
    {
        public List<BookingInfo> GetPendingBookings()
        {
            //implementation to return bookings
            return new List<BookingInfo>
                       {
                           new BookingInfo(1, ModeOfTransport.Bus, new DateTime(2015, 05, 20, 11, 0, 0), new ReturnJourney(ModeOfTransport.Bus, new DateTime(2015, 05, 23, 17, 30, 0))),
                           new BookingInfo(2, ModeOfTransport.Train, new DateTime(2015, 05, 29, 6, 50, 0), new ReturnJourney(ModeOfTransport.Train, new DateTime(2015, 06, 10, 13, 00, 0))),
                           new BookingInfo(3, ModeOfTransport.Tram, new DateTime(2015, 06, 01, 14, 30, 0), new ReturnJourney(ModeOfTransport.Tram, new DateTime(2015, 06, 01, 21, 20, 0))),
                           new BookingInfo(4, ModeOfTransport.Bus, new DateTime(2015, 07, 15, 9, 0, 0), new ReturnJourney(ModeOfTransport.Train, new DateTime(2015, 07, 16, 12, 0, 0)))
                       };
        }

		public void ConfirmSeatReservation(IJourney journey, int bookingId)
        {
			Console.WriteLine("{0} {1} Seat Reservation Confirmed for Booking {2}", (journey is ReturnJourney) ? "Return" : "Outward", Enum.GetName(typeof(ModeOfTransport), journey.ModeOfTransport), bookingId);
        }
    }
}