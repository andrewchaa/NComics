using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using NComics.Domain.Ports;

namespace NComics.Domain
{
    public class ComicsBook
    {
        private readonly Image _currentImage;
        private readonly IPageReader _pageReader;
        private readonly string _fileName;
        private readonly string _directory;
        private string _extension;
        private string[] _fileNames;
        private IList<ComicsPage> _pages;
        private int _index;

        public ComicsBook(Image currentImage)
        {
            _currentImage = currentImage;
            _pages = new List<ComicsPage>();
        }

        public ComicsBook(IPageReader pageReader)
        {
            _pageReader = pageReader;
            _pages = new List<ComicsPage>();
        }

        public ComicsBook(string fileName)
        {
            var file = new FileInfo(fileName);
            _fileName = fileName;
            _directory = file.DirectoryName;
            _extension = file.Extension;

            _fileNames = Directory.GetFiles(_directory, "");
        }

        public ComicsPage CurrentPage
        {
            get { return new ComicsPage(_fileName); }
        }

        public IEnumerable<ComicsPage> Pages
        {
            get { return _pages; }
        }

        public void Open(string directory)
        {
            var imageExtensions = new string[] {".jpg", ".gif", ".bmp", ".png"};
            var files = Directory.EnumerateFiles(directory)
                .Where(f => imageExtensions.Contains(Path.GetExtension(f)));

            foreach (var file in files)
            {
                _pages.Add(new ComicsPage(file));
            }
        }

        public void OpenFirstPageOn(Image currentImage)
        {
            _index = 0;
            ShowImage();
        }

        public void OpenPrevious()
        {
            _index -= 1;
            ShowImage();

        }

        public void OpenNext()
        {
            _index += 1;
            ShowImage();
        }

        private void ShowImage()
        {
            if (_index > _pages.Count - 1)
            {
                MessageBox.Show("This is the last page.");
                _index = _pages.Count - 1;
            }

            if (_index < 0)
            {
                MessageBox.Show("This is the first page.");
                _index = 0;
            }
            _currentImage.Source = _pages[_index].GetBitmap();
        }
    }
}