using System;
using RefactoringTest.Enumerations;

namespace RefactoringTest.Entities
{
	public interface IJourney
	{
		ModeOfTransport ModeOfTransport { get; }
		DateTime DateOfTravel { get; }
		bool IsReservationProcessed { get; set; }
		bool IsReservationConfirmed { get; set; }
		bool IsFirstClass { get; set; }
	}
}
