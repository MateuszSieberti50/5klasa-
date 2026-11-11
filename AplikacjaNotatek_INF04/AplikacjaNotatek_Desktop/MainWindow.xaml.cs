using System;
using System.Collections.ObjectModel;
using System.Windows;

namespace AplikacjaNotatek
{
    public class Notatka
    {
        public string Tytul { get; set; }
        public string Tresc { get; set; }
        public bool Priorytet { get; set; }
        public DateTime DataDodania { get; set; }

        public Notatka(string tytul, string tresc, bool priorytet)
        {
            Tytul = tytul;
            Tresc = tresc;
            Priorytet = priorytet;
            DataDodania = DateTime.Now;
        }

        public Notatka(string tytul) : this(tytul, "", false)
        {
        }
    }

    public partial class MainWindow : Window
    {
        public ObservableCollection<Notatka> ListaNotatek { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            ListaNotatek = new ObservableCollection<Notatka>();
            ListViewNotatki.ItemsSource = ListaNotatek;

            InicjalizujDane();
        }

        private void InicjalizujDane()
        {
            ListaNotatek.Add(new Notatka("tenis", "Gra z Ewą w poniedziałek", true));
        }

        /***************************************************
        nazwa:               BtnDodaj_Click
        opis:                Pobiera tytuł i treść z pól tekstowych, tworzy nowy obiekt Notatka i dodaje go do kolekcji widocznej na liście.
        parametry:           sender - obiekt wywołujący zdarzenie (object)
                             e - argumenty zdarzenia (RoutedEventArgs)
        zwracany typ:        brak
        autor:               Mateusz Golnau
        ***************************************************/
        private void BtnDodaj_Click(object sender, RoutedEventArgs e)
        {
            string tytul = TxtTytul.Text;
            string tresc = TxtTresc.Text;

            if (!string.IsNullOrWhiteSpace(tytul))
            {
                Notatka nowaNotatka = new Notatka(tytul, tresc, false);
                ListaNotatek.Add(nowaNotatka);

                TxtTytul.Clear();
                TxtTresc.Clear();
            }
            else
            {
                MessageBox.Show("Proszę wpisać tytuł notatki.", "Błąd", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }
    }
}
