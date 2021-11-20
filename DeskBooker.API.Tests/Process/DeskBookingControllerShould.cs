using DeskBooker.API.Controllers;
using DeskBooker.Core.Domain;
using DeskBooker.Core.Processor;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DeskBooker.API.Tests.Process
{
    public class DeskBookingControllerShould
    {
        [Fact]
        public void ShouldCallBookDeskMethodOfProcessor()
        {
            //arrange
            DeskBookingRequest request = new DeskBookingRequest();
            var deskBookingRequestProcessorMock = new Mock<IDeskBookingRequestProcessor>();
            DeskBookingProcessController controller = new DeskBookingProcessController(deskBookingRequestProcessorMock.Object);
            
            //act
            controller.Post(request);

            //assert
            deskBookingRequestProcessorMock.Verify(x => x.BookDesk(It.IsAny<DeskBookingRequest>()), Times.Once);


            //DeskBookingResult result = processor.BookDesk(request);
            //Assert.NotNull(result);
            //Assert.Equal(request.FirstName, result.FirstName);
            //Assert.Equal(request.LastName, result.LastName);
            //Assert.Equal(request.Email, result.Email);
            //Assert.Equal(request.Date, result.Date);



        }
    }
}

