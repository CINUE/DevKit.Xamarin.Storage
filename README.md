# DevKit.Xamarin.Storage
DevKit Xamarin Storage is a library to save data serialized in local files, supported platforms: iOS, Android and UWP.

Prerequisites: NewtonSoft.Json library.

Using Xamarin.Forms:

- Portable Class Library:
   - Add DevKit.Xamarin.Storage.Abstractions
   - Add DevKit.Xamarin.Storage (located in DevKit.Xamarin.Storage folder)

- iOS Project:
   - Add DevKit.Xamarin.Storage.Abstractions
   - Add DevKit.Xamarin.Storage (located in DevKit.Xamarin.Storage.iOS folder)

- Android Project:
   - Add DevKit.Xamarin.Storage.Abstractions
   - Add DevKit.Xamarin.Storage (located in DevKit.Xamarin.Storage.Android folder)

- UWP Project:
   - Add DevKit.Xamarin.Storage.Abstractions
   - Add DevKit.Xamarin.Storage (located in DevKit.Xamarin.Storage.UWP folder)

Usage:

Create a AppModel file.

```
    public class AppModel
    {
        public LanguagesEnum CurrentLanguage { get; set; }
        public bool IsLogged { get; set; }
        public bool RememberMe { get; set; }
    }
```

To read a file.
```
    private AppModel _appModel = null;
    await CrossLocalStorage.Current.ReadLocalDataAsync<AppModel>(AppConstants.LocalDataFileName).ContinueWith((b) =>
    {
        _appModel = b.Result;
    });
```

To save a file.

```
    private AppModel _appModel = null;
    _appModel = new AppModel();
    _appModel.CurrentLanguage = AppEnumerators.LanguagesEnum.English;
    _appModel.IsLogged = false;
    _appModel.RememberMe = false;
    await CrossLocalStorage.Current.SaveLocalDataAsync(_appModel, AppConstants.LocalDataFileName);
```

If you wanna contribute feel free to download, enhance the code and share the features.

happy coding. RC :)
