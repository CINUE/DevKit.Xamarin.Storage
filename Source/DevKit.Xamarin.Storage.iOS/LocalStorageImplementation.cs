using DevKit.Xamarin.Storage.Abstractions;
using Newtonsoft.Json;
using System.IO;
using System.Threading.Tasks;

namespace DevKit.Xamarin.Storage
{
    public class LocalStorageImplementation : ILocalStorage
    {
        public async Task<T> ReadLocalDataAsync<T>(string fileName)
        {
            var filename = fileName;
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, filename);
            string content = string.Empty;
            T result = default(T);

            try
            {
                using (var streamReader = new StreamReader(path))
                {
                    await streamReader.ReadToEndAsync()
                        .ContinueWith((b) =>
                        {
                            content = b.Result;
                            result = JsonConvert.DeserializeObject<T>(content);
                        });
                }
            }
            catch
            {
                result = default(T);
            }

            return result;
        }

        public async Task<bool> SaveLocalDataAsync<T>(T model, string fileName)
        {
            var filename = fileName;
            string documentsPath = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            var path = Path.Combine(documentsPath, filename);

            string json = JsonConvert.SerializeObject(model);

            using (var streamWriter = new StreamWriter(path, false))
                await streamWriter.WriteAsync(json);

            return true;
        }
    }
}