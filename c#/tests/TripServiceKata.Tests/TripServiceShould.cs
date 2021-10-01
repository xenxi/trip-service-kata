using System;
using FluentAssertions;
using NSubstitute;
using TripServiceKata.Exception;
using TripServiceKata.Service;
using Xunit;

namespace TripServiceKata.Tests {
    public class TripServiceShould {
        private readonly IUserSession _userSession;
        private readonly TripService _service;

        public TripServiceShould() {
            _userSession = Substitute.For<IUserSession>();
            _service = new TripService(_userSession);
        }

        [Fact]
        public void throw_user_not_logged_in_exception() {
            Action action = () => _service.GetTripsByUser(null);

            action.Should().Throw<UserNotLoggedInException>();
        }
    }
}