using System.Collections.Generic;

namespace TripServiceKata.Trip
{
    public interface ITripDaoDelegate
    {
        List<Trip> FindTripsByUser(User.User user);
    }
}