using System;
using RefactoringTest.Enumerations;

namespace RefactoringTest.Entities
{
    /// <summary>
    /// Stores key information about a booking
    /// </summary>
    public class BookingInfo : BaseJourney
    {
        public int Id { get; private set; }
        public ReturnJourney ReturnJourney { get; private set; }
		public bool IsBookingConfirmationCreated { get; set; }

	    public BookingInfo(int id, ModeOfTransport modeOfTransport, DateTime dateOfTravel, ReturnJourney returnJourney) : base(modeOfTransport, dateOfTravel)
		    {
			    Id = id;
			    ReturnJourney = returnJourney;
		    }
    }
}