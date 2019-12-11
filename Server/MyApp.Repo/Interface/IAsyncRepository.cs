using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyApp.Repo.Interface
{
     public interface IAsyncRepository<T> where T : class
    {
         Task<bool> Add(T vm);


        Task<T> Get(String id);
        Task<bool> IsExist(T vm);


        Task<IEnumerable<T>> GetAll();

        Task<bool> Remove(string id);

        Task<bool> Update(string id, T vm);
    }
}
