using DevKit.Xamarin.Storage.Abstractions;
using System;

namespace DevKit.Xamarin.Storage
{
    public static class CrossLocalStorage
    {
        private static Lazy<ILocalStorage> TTS = new Lazy<ILocalStorage>(() => CreateLocalStorage(), System.Threading.LazyThreadSafetyMode.PublicationOnly);

        public static ILocalStorage Current
        {
            get
            {
                var ret = TTS.Value;
                if (ret == null)
                {
                    throw NotImplementedInReferenceAssembly();
                }
                return ret;
            }
        }

        private static ILocalStorage CreateLocalStorage()
        {
#if PORTABLE
            return null;
#else
            return new LocalStorageImplementation();
#endif
        }

        internal static Exception NotImplementedInReferenceAssembly()
        {
            return new NotImplementedException("This functionality is not implemented in the portable version of this assembly.  You should reference the DevKit.Xamarin.Storage NuGet package from your main application project in order to reference the platform-specific implementation.");
        }
    }
}