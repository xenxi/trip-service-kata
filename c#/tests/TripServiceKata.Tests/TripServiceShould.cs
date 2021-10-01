using System;
using FluentAssertions;
using NSubstitute;
using TripServiceKata.Exception;
using TripServiceKata.Service;
using Xunit;

namespace TripServiceKata.Tests
{
    public class TripServiceShould
    {
        [Fact]
        public void throw_user_not_logged_in_exception() {
            IUserSession userSession = Substitute.For<IUserSession>();
            var service = new TripService(userSession);

            Action action = () => service.GetTripsByUser(null);

            action.Should().Throw<UserNotLoggedInException>();
        }
    }

}
