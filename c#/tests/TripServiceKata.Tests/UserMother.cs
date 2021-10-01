using System.Collections.Generic;
using TripServiceKata.Entity;

namespace TripServiceKata.Tests {
    public class UserMother {
        public static User Create(List<User> friends = null) {
            var user = new User();
            friends ??= new List<User>();

            friends.ForEach(friend => user.AddFriend(friend));

            return user;
        }
        public static (User user, User userFriend) CreateWithOneFriend() {

            var userFriend = Create();
            var user = Create(new List<User>{userFriend});

            user.AddFriend(userFriend);

            return (user, userFriend);
        }
    }
}