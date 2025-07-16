using System.ComponentModel.DataAnnotations;

namespace AsyncCoder.UserAuth.DbModels
{
    public interface IFacebookUser
    {
        public string? FacebookAccountId { get; set; }
    }
}