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

        public TripService(IUserSession userSession, ITripDAO tripDao) {
            _userSession = userSession;
            _tripDao = tripDao;
        }

        public List<Trip> GetTripsByUser(User user)
        {
            var loggedUser = GetLoggedUser();

            var tripList = new List<Trip>();
            var isFriend = IsFriend(user, loggedUser);

            if (isFriend)
            {
                tripList = _tripDao.FindTripsByUser(user);
            }

            return tripList;

        }

        private static bool IsFriend(User user, User loggedUser) {
            var isFriend = false;

            foreach (var friend in user.GetFriends()) {
                if (friend.Equals(loggedUser)) {
                    isFriend = true;
                    break;
                }
            }

            return isFriend;
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