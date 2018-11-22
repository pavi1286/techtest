using System;
using RefactoringTest.Enumerations;

namespace RefactoringTest.Entities
{
    public class ReturnJourney : BaseJourney
    {
	    public bool IsOpenEnded
	    {
		    get { return (ModeOfTransport == ModeOfTransport.Tram); }
	    }

		public ReturnJourney(ModeOfTransport modeOfTransport, DateTime dateOfTravel) : base(modeOfTransport, dateOfTravel)
	    {
	    }
    }
}