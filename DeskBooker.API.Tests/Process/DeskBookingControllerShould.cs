using DeskBooker.API.Controllers;
using DeskBooker.Core.DeskBooker.Application;
using DeskBooker.Core.DeskBooker.Domain;
using Moq;
using Xunit;

namespace DeskBooker.API.Tests.Process
{
    public class DeskBookingControllerShould
    {
        
        [Theory]
        [InlineData(1, true)]
        [InlineData(0, false)]
        public void ShouldCallBookDeskMethodOfProcessor(
            int expectedBookDeskCalls, bool isModelValid)
        {
            //arrange
            DeskBookingRequest request = new DeskBookingRequest();
            var deskBookingRequestProcessorMock = new Mock<IDeskBookingRequestProcessor>();
            DeskBookingProcessController controller = new DeskBookingProcessController(deskBookingRequestProcessorMock.Object);

            if(!isModelValid)
            {
                controller.ModelState.AddModelError("JustAKey", "AnErrorMessage");
            }
            //act
            controller.Post(request);

            //assert
            deskBookingRequestProcessorMock.Verify(x => x.BookDesk(It.IsAny<DeskBookingRequest>()), 
                Times.Exactly(expectedBookDeskCalls));



        }
    }
}

