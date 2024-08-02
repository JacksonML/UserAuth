using AsyncCoder.UserAuth.DbModels;
using AsyncCoder.UserAuth.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace AsyncCoder.UserAuth.Authentication
{
    public static class DbSetExtensions
    {
        public static T? Authenticate<T>(this IUserAuthContext<T> db, string email, string password) where T : class, IUser
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

        /// <summary>
        /// Hashes and salts the provided password, then sets it to the <see cref="IUser"/>
        /// </summary>
        public static void SetSaltedHash(this IUser user, string password)
        {
            user.SaltedHash = Utility.Hash(password);
        }
    }
}