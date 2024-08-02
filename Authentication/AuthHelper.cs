using AsyncCoder.UserAuth.DbModels;
using AsyncCoder.UserAuth.Interfaces;

namespace AsyncCoder.UserAuth.Authentication
{
    public static class AuthHelper
    {
        public static T? Authenticate<T>(IUserAuthContext<T> db, string email, string password) where T : class, IUser
        {
            var user = db.Users.First(u => u.Email == email);
            if (user == null)
            {
                // Spend time to mask the lack of user, TODO: verify this doesn't get optimized away
                var test = Utility.Hash("-");
                return null;
            }
            if (Utility.Verify(password, user.SaltedHash))
            {
                return user;
            }
            else
            {
                return null;
            }
        }
    }
}