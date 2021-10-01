using System;
using System.Collections.Generic;
using FluentAssertions;
using NSubstitute;
using TripServiceKata.Entity;
using TripServiceKata.Exception;
using TripServiceKata.Service;
using Xunit;

namespace TripServiceKata.Tests {
    public class TripServiceShould {
        private readonly IUserSession _userSession;
        private readonly TripService _service;
        private readonly ITripDAO _tripDao;

        public TripServiceShould() {
            _userSession = Substitute.For<IUserSession>();
            _tripDao = Substitute.For<ITripDAO>();
            _service = new TripService(_userSession, _tripDao);
        }

        [Fact]
        public void throw_user_not_logged_in_exception() {
            Action action = () => _service.GetTripsByUser(null);

            action.Should().Throw<UserNotLoggedInException>();
        }

        [Fact]
        public void trips_be_empty()
        {
            var aGivenUser = new User();
            _userSession.GetLoggedUser().Returns(aGivenUser);

          var trips =  _service.GetTripsByUser(aGivenUser);

          trips.Should().BeEmpty();
        }

        [Fact]
        public void found_trips()
        {
            var aGivenLoggedUser = new User();
            var aGivenUser = new User();
            aGivenUser.AddFriend(aGivenLoggedUser);
            _userSession.GetLoggedUser().Returns(aGivenLoggedUser);
            List<Trip> aExpectedListOfTrip = new List<Trip>();
            _tripDao.FindTripsByUser(aGivenUser).Returns(aExpectedListOfTrip);

            var trips =  _service.GetTripsByUser(aGivenUser);

            trips.Should().BeSameAs(aExpectedListOfTrip);
        }
    }
}