using System;
using RefactoringTest.Entities;

namespace RefactoringTest.ToRefactor
{
    public class TrainReservationHandler : IReservationHandler
    {
        public void ReserveSeat(BookingInfo info)
        {
            throw new NotImplementedException("Train reservations do not support this overload of ReserveSeat");
        }

		public void ReserveSeat(BookingInfo info, bool isOutwardJourney)
        {
			TrainReservationGenerator.GenerateTrainReservationFile(info, isOutwardJourney);
        }
    }
}