using AsyncCoder.UserAuth.DbModels;
using Microsoft.EntityFrameworkCore;

namespace AsyncCoder.UserAuth.Interfaces
{
    public interface IUserAuthContext<T> where T : class, IUser
    {
        DbSet<T> Users { get; set; }
    }
}