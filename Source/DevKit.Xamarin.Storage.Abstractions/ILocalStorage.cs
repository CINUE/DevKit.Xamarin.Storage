using System.Threading.Tasks;

namespace DevKit.Xamarin.Storage.Abstractions
{
    public interface ILocalStorage
    {
        Task<T> ReadLocalDataAsync<T>(string fileName);

        Task<bool> SaveLocalDataAsync<T>(T model, string fileName);
    }
}