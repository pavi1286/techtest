using System;
using RefactoringTest.Enumerations;

namespace RefactoringTest.Entities
{
	public class BaseJourney : IJourney
	{
		private bool _isFirstClass;

		public ModeOfTransport ModeOfTransport { get; private set; }
		public DateTime DateOfTravel { get; private set; }
		public bool IsReservationProcessed { get; set; }
		public bool IsReservationConfirmed { get; set; }

		public bool IsFirstClass
		{
			get { return _isFirstClass; }
			set { _isFirstClass = ModeOfTransport == ModeOfTransport.Train && value; }
		}

		protected BaseJourney(ModeOfTransport modeOfTransport, DateTime dateOfTravel)
		{
			ModeOfTransport = modeOfTransport;
			DateOfTravel = dateOfTravel;
		}
	}
}
