using Xunit;

namespace TripServiceKata.Tests
{
    public class TripServiceShould
    {
        [Fact]
        public void fail() {
            var service = new TripService();

            service.GetTripsByUser(null);

            Assert.True(false);
        }
    }
}
