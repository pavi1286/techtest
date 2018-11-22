using System;
using RefactoringTest.Entities;
using RefactoringTest.Enumerations;

namespace RefactoringTest.ToRefactor

{
    public class ReservationHandlerFactory
    {
        private readonly IDataService _dataService;

        public ReservationHandlerFactory(IDataService dataService)
        {
            _dataService = dataService;
        }

        public void ReserveSeat(BookingInfo bookingInfo)
        {
            System.Console.WriteLine("Reserve {0} Seat for Booking {1}", Enum.GetName(typeof(ModeOfTransport), bookingInfo.ModeOfTransport), bookingInfo.Id);
	        bookingInfo.IsReservationProcessed = true;

            switch (bookingInfo.ModeOfTransport)
            {
                case ModeOfTransport.Bus:
                    ReserveBusSeat(bookingInfo);
                    break;

				case ModeOfTransport.Train:
					ApplyAutomaticTrainUpgrade(bookingInfo, bookingInfo.Id);
                    ReserveTrainSeat(bookingInfo, true);
                    break;

                case ModeOfTransport.Tram:
                    ReserveTramSeat(bookingInfo);
                    break;

                default:
                    break;
            }

            ReserveReturnSeat(bookingInfo);
            if (bookingInfo.ModeOfTransport == ModeOfTransport.Bus)
            {
                generateBookingConfirmation(bookingInfo);
            }
            System.Console.WriteLine();
        }

        private void ReserveReturnSeat(BookingInfo bookingInfo)
        {
            if (bookingInfo.ReturnJourney == null) return;

            ReturnJourney returnJourney = bookingInfo.ReturnJourney;

            switch (returnJourney.ModeOfTransport)
            {
                case ModeOfTransport.Bus:
					System.Console.WriteLine("Reserve Return Bus Seat for Booking {0}", bookingInfo.Id);
		            bookingInfo.ReturnJourney.IsReservationProcessed = true;
                    ReserveReturnBusSeat(bookingInfo);
                    break;

                case ModeOfTransport.Train:
					System.Console.WriteLine("Reserve Return Train Seat for Booking {0}", bookingInfo.Id);
					bookingInfo.ReturnJourney.IsReservationProcessed = true;
		            ApplyAutomaticTrainUpgrade(bookingInfo.ReturnJourney, bookingInfo.Id);
                    ReserveTrainSeat(bookingInfo, false);
                    break;

                case ModeOfTransport.Tram:
                    // Nothing to do - assuming user realises tram tickets have open-ended returns
                    break;
            }
        }

        private void ReserveBusSeat(BookingInfo info)
        {
            var busHandler = new BusReservationHandler();
            busHandler.ReserveSeat(info);
            reservationCompleted(info, info.Id);
        }

        private void ReserveReturnBusSeat(BookingInfo info)
        {
            var busHandler = new BusReservationHandler();
            busHandler.ReserveReturnSeat(info);
			reservationCompleted(info.ReturnJourney, info.Id);
        }

        private void ReserveTrainSeat(BookingInfo info, bool isOutwardJourney)
        {
            var onlineHandler = new TrainReservationHandler();
			onlineHandler.ReserveSeat(info, isOutwardJourney);
			reservationCompleted((isOutwardJourney) ? (IJourney)info : info.ReturnJourney, info.Id);
        }
        
        private void ReserveTramSeat(BookingInfo info)
        {
            reservationCompleted(info, info.Id);
        }

		private void ApplyAutomaticTrainUpgrade(BaseJourney journey, int bookingId)
		{
			System.Console.WriteLine("Apply Automatic First Class Upgrade to {0} Journey for Booking {1}", (journey is ReturnJourney) ? "Return" : "Outward" , bookingId);
			journey.IsFirstClass = true;
		}

        private void generateBookingConfirmation(BookingInfo info)
        {
			System.Console.WriteLine("Generate Bus Confirmation for Booking {0}", info.Id);
	        info.IsBookingConfirmationCreated = true;

            // Call the conversion method and get back the path to the converted PDF document
			var fileName = PDFBuilder.GenerateBusConfirmationPdf(info);
            Emailer.SendEmailWithAttachment(Config.EmailContact, fileName);
        }

        private void reservationCompleted(IJourney journey, int bookingId)
        {
	        journey.IsReservationConfirmed = true;
            _dataService.ConfirmSeatReservation(journey, bookingId);
        }
    }
}