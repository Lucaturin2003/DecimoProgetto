using Delegate;

internal static class PhotoProcessorHelpers
{
    public static void Process(Action<Photo> filterHandler, string path)
    {
        var photo = Photo.Load(path);

        filterHandler(photo);

        photo.Save();
    }
        public static void Process(Action<Photo> filterHandler, string path)
        {
            var photo = Photo.Load(path);

            filterHandler(photo);

            photo.Save();
        }
}