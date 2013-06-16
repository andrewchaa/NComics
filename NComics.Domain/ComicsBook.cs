using System.Collections.Generic;
using System.IO;
using NComics.Domain.Ports;

namespace NComics.Domain
{
    public class ComicsBook
    {
        private readonly IPageReader _pageReader;
        private readonly string _fileName;
        private readonly string _directory;
        private string _extension;
        private string[] _fileNames;
        private IList<ComicsPage> _pages;

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

        public ComicsPage ReadNext()
        {
            throw new System.NotImplementedException();
        }

        public void Load(string directory)
        {
            
            var fileNames = _pageReader.GetFilesFrom(directory);
            foreach (var fileName in fileNames)
            {
                _pages.Add(new ComicsPage(fileName));
            }
        }
    }
}