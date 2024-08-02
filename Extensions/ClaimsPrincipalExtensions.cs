using System.Security.Claims;
using AsyncCoder.UserAuth.DbModels;
using AsyncCoder.UserAuth.Interfaces;

namespace AsyncCoder.UserAuth.Extensions
{
    public static class ClaimsPrincipalExtensions
    {
        public static long? UserId(this ClaimsPrincipal user)
        {
            var userId = user.FindFirst("userId")?.Value;
            if (long.TryParse(userId, out var id)) {
                return id;
            }
            return null;
        }

        public static T? Entity<T>(this ClaimsPrincipal user, IUserAuthContext<T> context) where T : class, IUser
        {
            var userId = UserId(user);
            var entity = context.Users.FirstOrDefault(u => u.Id == userId);
            return entity;
        }
    }
}