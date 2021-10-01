using System.Collections.Generic;
using TripServiceKata.Entity;
using TripServiceKata.Exception;
using TripServiceKata.Service;

namespace TripServiceKata
{
    public class TripService
    {
        private readonly IUserSession _userSession;
        private readonly ITripDAO _tripDao;
        private static readonly List<Trip> NO_TRIPS = new List<Trip>();

        public TripService(IUserSession userSession, ITripDAO tripDao) {
            _userSession = userSession;
            _tripDao = tripDao;
        }

        public List<Trip> GetTripsByUser(User user)
        {
            var loggedUser = GetLoggedUser();

            return user.IsFriend(loggedUser) 
                ? _tripDao.FindTripsByUser(user) 
                : NO_TRIPS;
        }

        private User GetLoggedUser() {
            var loggedUser = _userSession.GetLoggedUser();
            ThrowExceptionIfUserNotLogged(loggedUser);
            return loggedUser;
        }

        private static void ThrowExceptionIfUserNotLogged(User loggedUser) {
            if (loggedUser == null) throw new UserNotLoggedInException();
        }
    }
}