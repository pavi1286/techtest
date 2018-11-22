using System;
using RefactoringTest.Entities;

namespace RefactoringTest.ToRefactor
{
    public class BusReservationHandler : IReservationHandler
    {
        public void ReserveSeat(BookingInfo info)
        {
            string file = PDFBuilder.GenerateBusReservationPdf(info);
            Emailer.SendEmailWithAttachment(Config.EmailContact, file);
        }

        public void ReserveSeat(BookingInfo info, bool isOutwardJourney)
        {
            throw new NotImplementedException("Bus reservation handler does not support this overload of ReserveSeat");
        }

		public void ReserveReturnSeat(BookingInfo info)
        {
            string file = PDFBuilder.GenerateReturnBusReservationPdf(info);
            Emailer.SendEmailWithAttachment(Config.EmailContact, file);
        }
    }
}