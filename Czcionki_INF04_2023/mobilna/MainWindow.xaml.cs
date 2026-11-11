using System.Windows;

namespace CzcionkiApp
{
    public partial class MainWindow : Window
    {
        private string[] cytaty = new string[] { "Dzień dobry", "Good morning", "Buenos dias" };
        private int indeksCytatu = 0;

        public MainWindow()
        {
            InitializeComponent();
            AktualizujWidok();
        }

        private void AktualizujWidok()
        {
            if (TxtCytat != null)
            {
                TxtCytat.Text = cytaty[indeksCytatu];
            }
        }

        private void SldRozmiar_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            int rozmiar = (int)SldRozmiar.Value;
            if (TxtRozmiar != null)
            {
                TxtRozmiar.Text = string.Format("Rozmiar: {0}", rozmiar);
            }
            if (TxtCytat != null)
            {
                TxtCytat.FontSize = rozmiar > 0 ? rozmiar : 1;
            }
        }

        private void BtnZmien_Click(object sender, RoutedEventArgs e)
        {
            indeksCytatu = (indeksCytatu + 1) % cytaty.Length;
            AktualizujWidok();
        }
    }
}
