using System.Windows;

namespace DomekWGorach
{
    public partial class MainWindow : Window
    {
        private int licznikPolubien = 0;

        public MainWindow()
        {
            InitializeComponent();
            AktualizujLicznik();
        }

        /***************************************************
        nazwa metody:        AktualizujLicznik
        opis metody:         Aktualizuje etykietę z informacją o aktualnej liczbie polubień.
        parametry:           brak
        zwracany typ i opis: brak
        autor:               Mateusz Golnau
        ***************************************************/
        private void AktualizujLicznik()
        {
            TxtPolubienia.Text = string.Format("{0} polubień", licznikPolubien);
        }

        /***************************************************
        nazwa metody:        BtnPolub_Click
        opis metody:         Zwiększa wartość licznika polubień o 1 i aktualizuje widok.
        parametry:           sender - obiekt wywołujący zdarzenie (object)
                             e - argumenty zdarzenia (RoutedEventArgs)
        zwracany typ i opis: brak
        autor:               Mateusz Golnau
        ***************************************************/
        private void BtnPolub_Click(object sender, RoutedEventArgs e)
        {
            licznikPolubien++;
            AktualizujLicznik();
        }

        /***************************************************
        nazwa metody:        BtnUsun_Click
        opis metody:         Zmniejsza wartość licznika polubień o 1 (o ile jest większy od 0) i aktualizuje widok.
        parametry:           sender - obiekt wywołujący zdarzenie (object)
                             e - argumenty zdarzenia (RoutedEventArgs)
        zwracany typ i opis: brak
        autor:               Mateusz Golnau
        ***************************************************/
        private void BtnUsun_Click(object sender, RoutedEventArgs e)
        {
            if (licznikPolubien > 0)
            {
                licznikPolubien--;
                AktualizujLicznik();
            }
        }

        private void BtnZapisz_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Zapisano ofertę!", "Informacja", MessageBoxButton.OK, MessageBoxImage.Information);
        }
    }
}
