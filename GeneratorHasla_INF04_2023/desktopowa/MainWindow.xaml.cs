using System;
using System.Windows;
using System.Windows.Controls;

namespace GeneratorHasla
{
    public partial class MainWindow : Window
    {
        private string wygenerowaneHaslo = "";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void BtnGenerujHaslo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Sprawdzenie poprawności wpisanej liczby znaków
                if (!int.TryParse(TxtIleZnakow.Text, out int ileZnakow) || ileZnakow <= 0)
                {
                    MessageBox.Show("Podaj poprawną liczbę znaków!", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
                    return;
                }

                string maleLitery = "abcdefghijklmnopqrstuvwxyz";
                string wielkieLitery = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
                string cyfry = "0123456789";
                string znakiSpecjalne = "!@#$%^&*()_+-=";

                Random rand = new Random();
                char[] hasloArray = new char[ileZnakow];

                // 1. Domyślne wypełnienie małymi literami
                for (int i = 0; i < ileZnakow; i++)
                {
                    hasloArray[i] = maleLitery[rand.Next(maleLitery.Length)];
                }

                // 2. Obsługa checkboxa "Małe i wielkie litery" (zgodnie z arkuszem: jeden ze znaków losowany z wielkich liter)
                if (ChkLitery.IsChecked == true && ileZnakow > 0)
                {
                    int index = rand.Next(ileZnakow);
                    hasloArray[index] = wielkieLitery[rand.Next(wielkieLitery.Length)];
                }

                // 3. Obsługa checkboxa "Cyfry" (zgodnie z arkuszem: np. pierwszy lub losowy znak)
                if (ChkCyfry.IsChecked == true && ileZnakow > 0)
                {
                    int index = rand.Next(ileZnakow);
                    hasloArray[index] = cyfry[rand.Next(cyfry.Length)];
                }

                // 4. Obsługa checkboxa "Znaki specjalne" (zgodnie z arkuszem: losowy znak ze specjalnych)
                if (ChkZnaki.IsChecked == true && ileZnakow > 0)
                {
                    int index = rand.Next(ileZnakow);
                    hasloArray[index] = znakiSpecjalne[rand.Next(znakiSpecjalne.Length)];
                }

                wygenerowaneHaslo = new string(hasloArray);

                // Wyświetlenie wygenerowanego hasła zgodnie z wytycznymi z arkusza (Obraz 2)
                MessageBox.Show(wygenerowaneHaslo, "Wygenerowane hasło", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd: " + ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnZatwierdz_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string imie = TxtImie.Text;
                string nazwisko = TxtNazwisko.Text;

                // Pobranie zaznaczonego elementu z listy rozwijanej Stanowisko
                string stanowisko = "";
                if (CmbStanowisko.SelectedItem is ComboBoxItem selectedItem)
                {
                    stanowisko = selectedItem.Content?.ToString() ?? "";
                }

                // Komunikat zgodny z Obrazem 3 w arkuszu egzaminacyjnym
                string komunikat = string.Format("Dane pracownika: {0} {1} {2} Hasło: {3}", imie, nazwisko, stanowisko, wygenerowaneHaslo);
                MessageBox.Show(komunikat, "Dane pracownika", MessageBoxButton.OK, MessageBoxImage.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Wystąpił błąd: " + ex.Message, "Błąd", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}