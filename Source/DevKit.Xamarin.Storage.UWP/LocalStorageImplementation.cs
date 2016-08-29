using DevKit.Xamarin.Storage.Abstractions;
using Newtonsoft.Json;
using System;
using System.Threading.Tasks;
using Windows.Storage;

namespace DevKit.Xamarin.Storage
{
    public class LocalStorageImplementation : ILocalStorage
    {
        public async Task<T> ReadLocalDataAsync<T>(string fileName)
        {
            var filename = fileName;
            StorageFolder storageFolder = ApplicationData.Current.LocalFolder;
            string content = string.Empty;
            T result = default(T);

            try
            {
                StorageFile sampleFile = await storageFolder.GetFileAsync(filename);
                content = await FileIO.ReadTextAsync(sampleFile);

                result = JsonConvert.DeserializeObject<T>(content);
            }
            catch (Exception)
            {
                result = default(T);
            }

            return result;
        }

        public async Task<bool> SaveLocalDataAsync<T>(T model, string fileName)
        {
            var filename = fileName;
            StorageFolder localFolder = ApplicationData.Current.LocalFolder;

            string json = JsonConvert.SerializeObject(model);

            StorageFile file = await localFolder.CreateFileAsync(filename, CreationCollisionOption.ReplaceExisting);
            await FileIO.WriteTextAsync(file, json);

            return true;
        }
    }
}