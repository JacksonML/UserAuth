using System.ComponentModel.DataAnnotations;

namespace AsyncCoder.UserAuth.DbModels
{
    public interface IUser
    {
        [Key]
        public long Id { get; set; }
        public string? Email { get; set; }
        public string? SaltedHash { get; set; }
    }
}