using System.ComponentModel.DataAnnotations;

namespace AsyncCoder.UserAuth.DbModels
{
    public interface IAppleUser
    {
        public string? AppleAccountId { get; set; }
    }
}