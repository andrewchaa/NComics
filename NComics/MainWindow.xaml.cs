using System.Windows;
using System.Windows.Forms;
using System.Windows.Input;
using NComics.Domain;
using KeyEventArgs = System.Windows.Input.KeyEventArgs;
using OpenFileDialog = Microsoft.Win32.OpenFileDialog;

namespace NComics
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ComicsBook _book;

        public MainWindow()
        {
            InitializeComponent();
            _book = new ComicsBook(CurrentImage);
        }

        private void OpenFolder(object sender, RoutedEventArgs e)
        {
            var dialogue = new FolderBrowserDialog();
            var result = dialogue.ShowDialog();
            if (result == System.Windows.Forms.DialogResult.OK)
            {
                _book.Open(dialogue.SelectedPath);
                _book.OpenFirstPageOn(CurrentImage);
            }
        }

        private void GoPrevious(object sender, RoutedEventArgs e)
        {
            _book.OpenPrevious();
        }

        private void GoNext(object sender, RoutedEventArgs e)
        {
            _book.OpenNext();
        }
    }
}
