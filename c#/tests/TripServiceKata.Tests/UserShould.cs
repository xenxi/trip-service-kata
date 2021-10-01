using FluentAssertions;
using Xunit;

namespace TripServiceKata.Tests
{
    public  class UserShould
    {
        [Fact]
        public void add_a_friend() {
            var aGivenUser = UserMother.Create();
            var aGivenFriend = UserMother.Create();

            aGivenUser.AddFriend(aGivenFriend);

            aGivenUser.GetFriends().Should().Contain(aGivenFriend);
        }
    }
}
