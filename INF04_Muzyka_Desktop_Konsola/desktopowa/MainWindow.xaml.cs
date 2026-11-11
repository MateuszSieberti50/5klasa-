using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace MojeDzwiekiApp
{
    public partial class MainWindow : Window
    {
        private List<string[]> albumy = new List<string[]>();
        private int currentIndex = 0;

        public MainWindow()
        {
            InitializeComponent();
            WczytajDane();
            UstawStrzalki();
            WyswietlAlbum();
        }

        private void WczytajDane()
        {
            try
            {
                string basePath = AppDomain.CurrentDomain.BaseDirectory;
                string sciezkaPliku = Path.Combine(basePath, "Data.txt");

                if (!File.Exists(sciezkaPliku))
                {
                    string zawartoscDomyslna =
                        "Gorillaz\n\"The Now Now\"\n11\n2018\n11000102\n" +
                        "My Chemical Romance\n\"The Black Parade\"\n14\n2006\n304666444\n" +
                        "Wilki\n\"wilki\"\n16\n1992\n4000230\n" +
                        "30 Seconds To Mars\n\"A Beautiful Lie\"\n13\n2005\n304400500\n";
                    File.WriteAllText(sciezkaPliku, zawartoscDomyslna);
                }

                string[] linie = File.ReadAllLines(sciezkaPliku);
                List<string> tempAlbum = new List<string>();

                foreach (var linia in linie)
                {
                    if (!string.IsNullOrWhiteSpace(linia))
                    {
                        tempAlbum.Add(linia.Trim());
                        if (tempAlbum.Count == 5)
                        {
                            albumy.Add(tempAlbum.ToArray());
                            tempAlbum.Clear();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Błąd wczytywania: " + ex.Message);
            }

            if (albumy.Count == 0)
            {
                albumy.Add(new string[] { "Brak danych", "Brak", "0", "2024", "0" });
            }
        }

        private BitmapImage PobierzBitmapę(string nazwaPliku)
        {
            try
            {
                string sciezka1 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, nazwaPliku);
                string sciezka2 = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\..\\", nazwaPliku);
                string finalnaSciezka = "";

                if (File.Exists(sciezka1)) finalnaSciezka = sciezka1;
                else if (File.Exists(sciezka2)) finalnaSciezka = Path.GetFullPath(sciezka2);

                if (!string.IsNullOrEmpty(finalnaSciezka))
                {
                    BitmapImage bitmap = new BitmapImage();
                    bitmap.BeginInit();
                    bitmap.UriSource = new Uri(finalnaSciezka, UriKind.Absolute);
                    bitmap.CacheOption = BitmapCacheOption.OnLoad;
                    bitmap.EndInit();
                    return bitmap;
                }
            }
            catch { }
            return null;
        }

        private void UstawStrzalki()
        {
            try
            {
                var bmpLewa = PobierzBitmapę("obraz2.png");
                var bmpPrawa = PobierzBitmapę("obraz3.png");

                if (BtnPrev.Content is Image imgL)
                {
                    imgL.Source = bmpLewa;
                    imgL.Stretch = Stretch.Uniform;
                }
                if (BtnNext.Content is Image imgP)
                {
                    imgP.Source = bmpPrawa;
                    imgP.Stretch = Stretch.Uniform;
                }
            }
            catch { }
        }

        private void WyswietlAlbum()
        {
            if (albumy.Count == 0) return;
            var a = albumy[currentIndex];
            TxtWykonawca.Text = a[0];
            TxtTytul.Text = a[1];
            TxtUtworow.Text = a[2];
            TxtRok.Text = a[3];
            TxtPobrania.Text = a[4];

            var bmpPlyta = PobierzBitmapę("obraz.png");
            if (bmpPlyta != null)
            {
                ImgPlyta.Source = bmpPlyta;
                ImgPlyta.Stretch = Stretch.Uniform;
            }
        }

        private void BtnPrev_Click(object sender, RoutedEventArgs e)
        {
            currentIndex--;
            if (currentIndex < 0)
            {
                currentIndex = albumy.Count - 1;
            }
            WyswietlAlbum();
        }

        private void BtnNext_Click(object sender, RoutedEventArgs e)
        {
            currentIndex++;
            if (currentIndex >= albumy.Count)
            {
                currentIndex = 0;
            }
            WyswietlAlbum();
        }

        private void BtnPobierz_Click(object sender, RoutedEventArgs e)
        {
            if (albumy.Count > 0)
            {
                long pobrania = long.Parse(albumy[currentIndex][4]);
                pobrania++;
                albumy[currentIndex][4] = pobrania.ToString();
                TxtPobrania.Text = albumy[currentIndex][4];
            }
        }
    }
}