using Commander.Models;
using Microsoft.AspNetCore.Identity;
using System.Threading.Tasks;

namespace Commander.Data
{
    public interface IAccountRepository
    {
        Task<IdentityResult> CreateUserAsync(SignUpUserModel userModel);
        Task<bool> IsValidUsernameAndPassword(string email, string password);
    }
}