using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using System.IO;

namespace WPF.Lesson18.Services
{
    using Interfaces;
    using Models;

    public class ImageLoaderFromFolder : IImageLoad
    {
        private readonly FolderBrowserDialog _folderBrowser;

        public ImageLoaderFromFolder()
        {
            _folderBrowser = new FolderBrowserDialog();
        }

        public List<DisplayImageItem> LoadImageItems()
        {
            var images = new List<DisplayImageItem>();

            if (_folderBrowser.ShowDialog() != DialogResult.OK) return images;

            var di = new DirectoryInfo(_folderBrowser.SelectedPath);
            var imgs = di.GetFiles("*.jpg")
                .Union(di.GetFiles("*.png"))
                .Union(di.GetFiles("*.bnp")).ToList();

            if (imgs.Count == 0)
            {
                MessageBox.Show("Image Files Not Found");
                return images;
            }

            imgs.ForEach(img => images.Add(new DisplayImageItem(img)));

            return images;
        }
    }
}
