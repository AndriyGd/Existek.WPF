using System.Collections.Generic;

namespace WPF.Lesson18.Interfaces
{
    using Models;

    public interface IImageLoad
    {
        List<DisplayImageItem> LoadImageItems();
    }
}
