using System.Windows;

namespace RejestracjaKonta
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnZatwierdz_Click(object sender, RoutedEventArgs e)
        {
            string email = TxtEmail.Text.Trim();
            string haslo = TxtHaslo.Password;
            string powtorzHaslo = TxtPowtorzHaslo.Password;

            if (!email.Contains("@"))
            {
                TxtKomunikat.Text = "Nieprawidłowy adres e-mail";
            }
            else if (haslo != powtorzHaslo)
            {
                TxtKomunikat.Text = "Hasła się różnią";
            }
            else
            {
                TxtKomunikat.Text = string.Format("Witaj {0}", email);
            }
        }
    }
}
