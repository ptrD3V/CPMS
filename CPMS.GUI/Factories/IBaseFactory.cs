using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace CPMS.GUI.Factories
{
    public interface IBaseFactory<T>
    {
        Task<IEnumerable<T>> MapToList(HttpClient client, string path);
        Task<bool> PostObject(string path, T model);
        Task<bool> PutObject(string path, T model);
        Task<T> GetObject(string path);
        Task<bool> DeleteObject(string path);
        Task<IEnumerable<T>> GetObjects(string path);
    }
}
