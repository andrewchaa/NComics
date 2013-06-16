using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Win32;
using NComics.Domain;

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
        }

        private void NewClick(object sender, RoutedEventArgs e)
        {
            var dialogue = new OpenFileDialog();
            var result = dialogue.ShowDialog();
            if (result.Value)
            {
                _book = new ComicsBook(dialogue.FileName);
                DisplayPage(_book.CurrentPage);
            }
        }

        private void DisplayPage(ComicsPage page)
        {
            CurrentImage.Source = page.GetBitmap();
        }

        private void WindowKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Right)
            {
                if (_book != null)
                {
                    DisplayPage(_book.ReadNext());
                }
            }
                
        }
    }
}
