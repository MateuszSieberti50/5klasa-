using System;
using System.Windows;
using System.Windows.Media;

namespace WzornikKolorow
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            AktualizujDuzyProstokat();
        }

        /***************************************************
        nazwa metody:        AktualizujDuzyProstokat
        opis metody:         Odczytuje wartości suwaków R, G, B i aktualizuje kolor tła dużego prostokąta oraz etykiety.
        parametry:           brak
        zwracany typ i opis: brak
        autor:               Mateusz Golnau
        ***************************************************/
        private void AktualizujDuzyProstokat()
        {
            if (SliderR == null || SliderG == null || SliderB == null ||
                LabelR == null || LabelG == null || LabelB == null || DuzyProstokat == null) return;

            byte r = (byte)SliderR.Value;
            byte g = (byte)SliderG.Value;
            byte b = (byte)SliderB.Value;

            LabelR.Text = r.ToString();
            LabelG.Text = g.ToString();
            LabelB.Text = b.ToString();

            DuzyProstokat.Background = new SolidColorBrush(Color.FromRgb(r, g, b));
        }

        private void Suwak_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            AktualizujDuzyProstokat();
        }

        /***************************************************
        nazwa metody:        BtnPobierz_Click
        opis metody:         Kopiuje aktualne wartości suwaków do małego prostokąta, zmieniając jego kolor tła oraz napis z wartościami RGB.
        parametry:           sender - obiekt wywołujący zdarzenie (object)
                             e - argumenty zdarzenia (RoutedEventArgs)
        zwracany typ i opis: brak
        autor:               Mateusz Golnau
        ***************************************************/
        private void BtnPobierz_Click(object sender, RoutedEventArgs e)
        {
            if (SliderR == null || SliderG == null || SliderB == null ||
                MalyProstokat == null || TxtPobranyKolor == null) return;

            byte r = (byte)SliderR.Value;
            byte g = (byte)SliderG.Value;
            byte b = (byte)SliderB.Value;

            Color wybranyKolor = Color.FromRgb(r, g, b);
            MalyProstokat.Background = new SolidColorBrush(wybranyKolor);
            TxtPobranyKolor.Text = $"{r}, {g}, {b}";

            double jasnosc = (0.299 * r + 0.587 * g + 0.114 * b);
            TxtPobranyKolor.Foreground = jasnosc > 128 ? Brushes.Black : Brushes.White;
        }
    }
}
