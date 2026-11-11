from datetime import datetime

class Notatka:
    licznik_notatek = 0

    # **************************************************
    # nazwa:               __init__
    # opis:                Konstruktor klasy Notatka. Inicjalizuje pola tytul, tresc, priorytet oraz ustawia aktualną datę dodania.
    # parametry:           tytul - tytuł notatki (str)
    #                      tresc - treść notatki (str, domyślnie pusty)
    #                      priorytet - czy notatka jest ważna (bool, domyślnie False)
    # zwracany typ:        brak
    # autor:               Mateusz Golnau
    # **************************************************
    def __init__(self, tytul: str, tresc: str = "", priorytet: bool = False):
        Notatka.licznik_notatek += 1
        self.tytul = tytul
        self.tresc = tresc
        self.priorytet = priorytet
        self.data_dodania = datetime.now().strftime("%d.%m.%Y %H:%M:%S")

    # **************************************************
    # nazwa:               wyswietl
    # opis:                Wypisuje na ekranie notatkę z nagłówkiem ważności, treścią i datą utworzenia w otoczeniu linii poziomych.
    # parametry:           brak
    # zwracany typ:        brak
    # autor:               Mateusz Golnau
    # **************************************************
    def wyswietl(self) -> None:
        print("____________________________________")
        if self.priorytet:
            print(f"Notatka WAŻNA! {self.tytul}")
        else:
            print(f"Notatka {self.tytul}")
        if self.tresc:
            print(self.tresc)
        print(self.data_dodania)
        print("____________________________________")


def main():
    notatka1 = Notatka("tenis", "Gra z Ewą w poniedziałek", True)
    
    tytul_user = input("Podaj tytuł notatki:\n")
    notatka2 = Notatka(tytul_user)
    
    notatka1.wyswietl()
    notatka2.wyswietl()


if __name__ == "__main__":
    main()
