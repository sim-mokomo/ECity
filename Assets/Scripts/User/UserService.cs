namespace MokomoGames.Users
{
    public class UserService
    {
        public static User CreateRecoveriedStaminaUserByYukichi(User user)
        {
            var data = user.toData();
            data.Stamina += user.MaxFuel;
            data.Yukichi--;
            return new User(data, user.MaxFuel, user.NeedNextRankExp);
        }

        public static User CreateRecoveriedStaminaUserByTime(User user, uint recoveriedDiff)
        {
            var data = user.toData();
            data.Stamina += recoveriedDiff;
            return new User(data, user.MaxFuel, user.NeedNextRankExp);
        }
    }
}