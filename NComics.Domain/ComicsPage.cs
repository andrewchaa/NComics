using System;
using System.Windows.Media.Imaging;

namespace NComics.Domain
{
    public class ComicsPage
    {
        private readonly string _fileName;

        protected bool Equals(ComicsPage other)
        {
            return string.Equals(_fileName, other._fileName);
        }

        public override string ToString()
        {
            return _fileName;
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            if (obj.GetType() != this.GetType()) return false;
            return Equals((ComicsPage) obj);
        }

        public override int GetHashCode()
        {
            return (_fileName != null ? _fileName.GetHashCode() : 0);
        }

        public static bool operator ==(ComicsPage left, ComicsPage right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ComicsPage left, ComicsPage right)
        {
            return !Equals(left, right);
        }

        public ComicsPage(string fileName)
        {
            _fileName = fileName;
        }

        public BitmapImage GetBitmap()
        {
            var bitmapImage = new BitmapImage();
            bitmapImage.BeginInit();
            bitmapImage.UriSource = new Uri(_fileName);
            bitmapImage.EndInit();
            return bitmapImage;

        }



    }


}
