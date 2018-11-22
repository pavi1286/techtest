using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using RefactoringTest.ToRefactor;

namespace RefactoringUnitTests
{
	[TestClass]
	public class RefactoringUnitTests
	{
		[TestMethod]
		public void BookingServiceSucceedsForBookingId1()
		{
			// Arrange
			var bookingService = new BookingService();
			var mockDataService = new MockDataService();

			// Act
			bookingService.ProcessPendingBookings(mockDataService);
			var bookingId1 = bookingService.Bookings.FirstOrDefault(bi => bi.Id == 1);

			// Assert
			Assert.IsNotNull(bookingId1);
			Assert.IsTrue(bookingId1.IsReservationProcessed);
			Assert.IsTrue(bookingId1.IsReservationConfirmed);
			Assert.IsTrue(bookingId1.ReturnJourney.IsReservationProcessed);
			Assert.IsTrue(bookingId1.ReturnJourney.IsReservationConfirmed);
			Assert.IsTrue(bookingId1.IsBookingConfirmationCreated);
		}

		[TestMethod]
		public void BookingServiceSucceedsForBookingId2()
		{
			// Arrange
			var bookingService = new BookingService();
			var mockDataService = new MockDataService();

			// Act
			bookingService.ProcessPendingBookings(mockDataService);
			var bookingId2 = bookingService.Bookings.FirstOrDefault(bi => bi.Id == 2);

			// Assert
			Assert.IsNotNull(bookingId2);
			Assert.IsTrue(bookingId2.IsFirstClass);
			Assert.IsTrue(bookingId2.IsReservationProcessed);
			Assert.IsTrue(bookingId2.IsReservationConfirmed);
			Assert.IsTrue(bookingId2.ReturnJourney.IsFirstClass);
			Assert.IsTrue(bookingId2.ReturnJourney.IsReservationProcessed);
			Assert.IsTrue(bookingId2.ReturnJourney.IsReservationConfirmed);
			Assert.IsFalse(bookingId2.IsBookingConfirmationCreated);
		}

		[TestMethod]
		public void BookingServiceSucceedsForBookingId3()
		{
			// Arrange
			var bookingService = new BookingService();
			var mockDataService = new MockDataService();

			// Act
			bookingService.ProcessPendingBookings(mockDataService);
			var bookingId3 = bookingService.Bookings.FirstOrDefault(bi => bi.Id == 3);

			// Assert
			Assert.IsNotNull(bookingId3);
			Assert.IsTrue(bookingId3.IsReservationProcessed);
			Assert.IsTrue(bookingId3.IsReservationConfirmed);
			Assert.IsFalse(bookingId3.ReturnJourney.IsReservationProcessed);
			Assert.IsFalse(bookingId3.ReturnJourney.IsReservationConfirmed);
			Assert.IsFalse(bookingId3.IsBookingConfirmationCreated);
		}

		[TestMethod]
		public void BookingServiceSucceedsForBookingId4()
		{
			// Arrange
			var bookingService = new BookingService();
			var mockDataService = new MockDataService();

			// Act
			bookingService.ProcessPendingBookings(mockDataService);
			var bookingId4 = bookingService.Bookings.FirstOrDefault(bi => bi.Id == 4);

			// Assert
			Assert.IsNotNull(bookingId4);
			Assert.IsTrue(bookingId4.IsReservationProcessed);
			Assert.IsTrue(bookingId4.IsReservationConfirmed);
			Assert.IsTrue(bookingId4.ReturnJourney.IsFirstClass);
			Assert.IsTrue(bookingId4.ReturnJourney.IsReservationProcessed);
			Assert.IsTrue(bookingId4.ReturnJourney.IsReservationConfirmed);
			Assert.IsTrue(bookingId4.IsBookingConfirmationCreated);
		}
	}
}
