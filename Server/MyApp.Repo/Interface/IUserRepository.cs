using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Repo.Interface
{
    public interface IUserRepository<T>: IAsyncRepository<T> where T : class
    {
        Task<bool> ResetPassword(string newPassword, T vm);
        Task<T> GetUserByUserVM(T vm);
        Task<string> GetEmailConfirmationToken(T vm);        
        Task<bool> ConfirmEmailVerification(string userid, string token);

        Task<bool> IsEmailVerified(T vm);

        Task<string> GetResetPasswordToken(T vm);
        Task<bool> forgetPasswordReset(string token ,T vm);
    }
}
