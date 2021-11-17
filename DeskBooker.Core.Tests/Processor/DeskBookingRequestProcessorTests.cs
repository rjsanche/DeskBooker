using DeskBooker.Core.Domain;
using DeskBooker.Core.Interface;
using Moq;
using System;
using Xunit;

namespace DeskBooker.Core.Processor
{
    public class DeskBookingRequestProcessorTests
    {
        private readonly DeskBookingRequestProcessor _processor;

        private readonly DeskBookingRequest _request;
        private readonly Mock<IDeskBookingRepository> _deskBookingRepositoryMock;

        public DeskBookingRequestProcessorTests()
        {            
            _request = new DeskBookingRequest
            {
                FirstName = "Raúl",
                LastName = "Jiménez",
                Email = "rjsanche@gmail.com",
                Date = new DateTime(2021, 11, 17),
            };

            _deskBookingRepositoryMock  = new Mock<IDeskBookingRepository>();
            _processor = new DeskBookingRequestProcessor(_deskBookingRepositoryMock.Object);
        }

        [Fact]
        public void ShouldReturnDeskBookingResultWithRequestValues()
        {
            //act
            DeskBookingResult result = _processor.BookDesk(_request);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(_request.FirstName, result.FirstName);
            Assert.Equal(_request.LastName, result.LastName);
            Assert.Equal(_request.Email, result.Email);
            Assert.Equal(_request.Date, result.Date);
        }

        [Fact]
        public void ShouldThrowExceptionIfRequestIsNull()
        {
            var exception = Assert.Throws<ArgumentNullException>(() => _processor.BookDesk(null));

            Assert.Equal("request", exception.ParamName);
        }

        [Fact]
        public void ShouldSaveDeskBooking()
        {
            //arrange
            DeskBooking savedDeskBooking = null;
            _deskBookingRepositoryMock.Setup(x => x.Save(It.IsAny<DeskBooking>()))
                .Callback<DeskBooking>(deskBooking =>
                {
                    savedDeskBooking = deskBooking;
                });

            //act
            _processor.BookDesk(_request);

            _deskBookingRepositoryMock.Verify(x => x.Save(It.IsAny<DeskBooking>()), Times.Once);

            //Assert
            Assert.NotNull(savedDeskBooking);
            Assert.Equal(_request.FirstName, savedDeskBooking.FirstName);
            Assert.Equal(_request.LastName, savedDeskBooking.LastName);
            Assert.Equal(_request.Email, savedDeskBooking.Email);
            Assert.Equal(_request.Date, savedDeskBooking.Date);

        }

    }
}
