using System.IO;

namespace WPF.Lesson18.Models
{
    public class DisplayImageItem
    {
        public FileInfo ImageFile { get; set; }

        public DisplayImageItem(FileInfo imageFile)
        {
            ImageFile = imageFile;
        }
    }
}
