namespace Delegate
{
    class Photo
    {
        public string Path;
        public Photo(string path)
        {
            Path = path;
        }

        public static Photo Load(string path)
        {
            return new Photo(path);
        }

        public void Save()
        {
            Console.WriteLine("Foto salvata");
        }
    }

    public class PhotoFilter
    {
        internal void Resize(Photo photo)
        {
            Console.WriteLine("Resizing photo");
        }

        internal void ApplyBrightness(Photo photo)
        {
            Console.WriteLine("Apply brightness");
        }

        internal void ApplyContrast(Photo photo)
        {
            Console.WriteLine("Apply contrast");
        }
    }

    public class PhotoProcessor
    {
        internal void Process(Action<Photo> filterHandler, string path)
        {
            var photo = Photo.Load(path);

            filterHandler(photo);

            photo.Save();
        }
    }
    class Program
    {
        static void Main(string[] args)
        {
            var processor = new PhotoProcessor();
            var filters = new PhotoFilter();
            Action<Photo> filterHandler = filters.ApplyBrightness;
            filterHandler += filters.ApplyContrast;
            filterHandler += RemoveRedEyeFilter;
            processor.Process(filterHandler, "photo.jpg");
        }

        static void RemoveRedEyeFilter(Photo photo)
        {
            Console.WriteLine("Apply remove red eye");
        }
    }
}