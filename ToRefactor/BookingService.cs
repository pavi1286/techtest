using System;
using System.Collections.Generic;
using RefactoringTest.Entities;

namespace RefactoringTest.ToRefactor
{
    public class BookingService
    {
	    public List<BookingInfo> Bookings; 

        public void ProcessPendingBookings(IDataService dataService)
        {
            try
            {
                Bookings = dataService.GetPendingBookings();
                
                var reservationHandlerFactory = new ReservationHandlerFactory(dataService);
                
                foreach (var info in Bookings)
                {
                    reservationHandlerFactory.ReserveSeat(info);
                }
            }
            catch (Exception exPendingBookings)
            {
                Logger.Log(exPendingBookings.Message);
            }
        }
    }
}
