using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Media;

namespace NotatkiApp
{
    public partial class MainWindow : Window
    {
        public ObservableCollection<string> Notatki { get; set; }
        private bool isPlaceholder = true;

        public MainWindow()
        {
            InitializeComponent();
            Notatki = new ObservableCollection<string>
            {
                "Zakupy: chleb, masło, ser",
                "Do zrobienia: obiad, umyć podłogi",
                "weekend: kino, spacer z psem"
            };
            LstNotatki.ItemsSource = Notatki;
        }

        private void BtnDodaj_Click(object sender, RoutedEventArgs e)
        {
            string wpis = TxtNowyElement.Text.Trim();
            if (!string.IsNullOrEmpty(wpis) && !isPlaceholder)
            {
                Notatki.Add(wpis);
                TxtNowyElement.Text = "";
            }
        }

        private void TxtNowyElement_GotFocus(object sender, RoutedEventArgs e)
        {
            if (isPlaceholder)
            {
                TxtNowyElement.Text = "";
                TxtNowyElement.Foreground = Brushes.Black;
                isPlaceholder = false;
            }
        }

        private void TxtNowyElement_LostFocus(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(TxtNowyElement.Text))
            {
                TxtNowyElement.Text = "Nowy element";
                TxtNowyElement.Foreground = Brushes.Gray;
                isPlaceholder = true;
            }
        }
    }
}
