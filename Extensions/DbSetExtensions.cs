using AsyncCoder.UserAuth.Authentication;
using AsyncCoder.UserAuth.DbModels;
using AsyncCoder.UserAuth.Interfaces;

namespace AsyncCoder.UserAuth.Extensions
{
    public static class DbSetExtensions
    {
        public static T? Authenticate<T>(this IUserAuthContext<T> db, string email, string password) where T : class, IUser
        {
            return AuthHelper.Authenticate(db, email, password);
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