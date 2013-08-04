using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Machine.Specifications;
using Moq;
using NComics.Domain;
using NComics.Domain.Ports;
using It = Machine.Specifications.It;

namespace NComics.Tests
{
    public class ComicsBookTests
    {
        [Subject(typeof(ComicsBook))]
        public class When_a_ComicsBook_load_a_directory
        {
            private static ComicsBook _comicsBook;
            private static string _fileName;
            private static string _directory;
            private static Mock<IPageReader> _pageReader;
            private static string[] _files;

            Establish context = () =>
                {
                    _directory = "direcotry";
                    _fileName = _directory + "\\" + "image.jpg";
                    _files = new string[] { "image1.jpg", "image2.jpg", "image3.jpg" };
                    _pageReader = new Mock<IPageReader>();
                    _pageReader.Setup(p => p.GetFilesFrom(_directory)).Returns(_files);
                    _comicsBook = new ComicsBook(_pageReader.Object);
                };

            Because of = () => _comicsBook.Open(_directory);

            It should_load_all_files_in_the_directory = () =>
                {
                    _comicsBook.Pages.Count().ShouldEqual(_files.Length);
                    _comicsBook.Pages.ShouldContain(new ComicsPage("image1.jpg"));
                    _comicsBook.Pages.ShouldContain(new ComicsPage("image2.jpg"));
                    _comicsBook.Pages.ShouldContain(new ComicsPage("image3.jpg"));
                };

        }
    }

}
