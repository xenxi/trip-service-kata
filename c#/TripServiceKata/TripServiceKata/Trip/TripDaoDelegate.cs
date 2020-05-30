using System.Collections.Generic;

namespace TripServiceKata.Trip
{
    public class TripDaoDelegate : ITripDaoDelegate
    {
        public TripDaoDelegate()
        {
        }

        public List<Trip> FindTripsByUser(User.User user)
        {
            return TripDAO.FindTripsByUser(user);
        }
    }
}