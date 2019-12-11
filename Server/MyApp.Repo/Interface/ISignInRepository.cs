using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Repo.Interface
{
    public interface ISignInRepository<T> where T : class
    {
        Task<bool> add(T vm);
        Task<bool> Remove();
    }
}
