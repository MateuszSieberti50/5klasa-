# **************************************************
# nazwa metody:       wczytaj_i_wyswietl_albumy
# opis metody:        Wczytuje dane o albumach muzycznych z pliku i wyświetla je w konsoli
# parametry:          sciezka_pliku (str) - ścieżka do pliku Data.txt
# zwracany typ i opis: list - lista obiektów albumów
# autor:              Mateusz Golnau
# **************************************************

import os

class Album:
    def __init__(self, wykonawca, tytul, utworow, rok, pobrania):
        self.wykonawca = wykonawca
        self.tytul = tytul
        self.utworow = int(utworow)
        self.rok = int(rok)
        self.pobrania = int(pobrania)

def wczytaj_i_wyswietl_albumy(nazwa_pliku):
    albumy = []
    
    # Automatyczne ustalenie ścieżki tam, gdzie leży ten skrypt (main.py)
    skrypt_dir = os.path.dirname(os.path.abspath(__file__))
    sciezka_pliku = os.path.join(skrypt_dir, nazwa_pliku)
    
    try:
        with open(sciezka_pliku, 'r', encoding='utf-8') as plik:
            linie = [linia.strip() for linia in plik if linia.strip()]
            
            for i in range(0, len(linie), 5):
                if i + 4 < len(linie):
                    wykonawca = linie[i]
                    tytul = linie[i+1]
                    utworow = linie[i+2]
                    rok = linie[i+3]
                    pobrania = linie[i+4]
                    
                    album = Album(wykonawca, tytul, utworow, rok, pobrania)
                    albumy.append(album)
                    
                    print(album.wykonawca)
                    print(album.tytul)
                    print(album.utworow)
                    print(album.rok)
                    print(album.pobrania)
                    print()
    except FileNotFoundError:
        print(f"Nie znaleziono pliku w lokalizacji: {sciezka_pliku}")
        
    return albumy

if __name__ == "__main__":
    wczytaj_i_wyswietl_albumy("Data.txt")