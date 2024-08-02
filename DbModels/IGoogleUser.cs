using System.ComponentModel.DataAnnotations;

namespace AsyncCoder.UserAuth.DbModels
{
    public interface IGoogleUser
    {
        public string? GoogleAccountId { get; set; }
    }
}