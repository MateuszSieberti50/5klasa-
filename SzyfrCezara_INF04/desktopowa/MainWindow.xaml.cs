using System;
using System.IO;
using System.Windows;
using Microsoft.Win32;

namespace SzyfrCezara
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        /***************************************************
        nazwa metody:        Szyfruj
        opis metody:         Szyfruje tekst jawny przy użyciu algorytmu Szyfru Cezara.
        parametry:           tekst - tekst do zaszyfrowania (string)
                             klucz - przesunięcie w alfabecie (int)
        zwracany typ i opis: string - zaszyfrowany tekst
        autor:               Mateusz Golnau
        ***************************************************/
        public static string Szyfruj(string tekst, int klucz)
        {
            if (string.IsNullOrEmpty(tekst)) return "";

            char[] wynik = new char[tekst.Length];
            for (int i = 0; i < tekst.Length; i++)
            {
                char c = tekst[i];
                if (c >= 'a' && c <= 'z')
                {
                    int code = c - 'a';
                    int newCode = (code + klucz) % 26;
                    if (newCode < 0) newCode += 26;
                    wynik[i] = (char)('a' + newCode);
                }
                else
                {
                    wynik[i] = c;
                }
            }
            return new string(wynik);
        }

        private void BtnZaszyfruj_Click(object sender, RoutedEventArgs e)
        {
            string tekst = TxtTekst.Text;
            int klucz = 0;

            if (!int.TryParse(TxtKlucz.Text, out klucz))
            {
                klucz = 0;
            }

            TxtWynik.Text = Szyfruj(tekst, klucz);
        }

        private void BtnZapisz_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Pliki tekstowe (*.txt)|*.txt|Wszystkie pliki (*.*)|*.*";
            saveFileDialog.Title = "Zapisz zaszyfrowany tekst";

            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, TxtWynik.Text);
                MessageBox.Show("Plik został pomyślnie zapisany!", "Sukces", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
    }
}
