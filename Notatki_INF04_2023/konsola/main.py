# **************************************************
# klasa:       Notatka
# opis:        Klasa reprezentująca pojedynczą notatkę tekstową z unikalnym identyfikatorem i statycznym licznikiem notatek.
# pola:        __licznikNotatek - statyczne pole zliczające łączną liczbę utworzonych obiektów Notatka
#              __id - unikalny identyfikator przydzielany danej notatce
#              _tytul - tytuł notatki (pole dostępne dla klas potomnych)
#              _tresc - treść notatki (pole dostępne dla klas potomnych)
# autor:       Mateusz Golnau
# **************************************************
class Notatka:
    __licznikNotatek = 0

    def __init__(self, tytul: str, tresc: str):
        Notatka.__licznikNotatek += 1
        self.__id = Notatka.__licznikNotatek
        self._tytul = tytul
        self._tresc = tresc

    def wyswietl(self) -> None:
        print(f"Tytuł: {self._tytul}")
        print(f"Treść: {self._tresc}")

    def diagnostyka(self) -> None:
        print(f"{self.__id};{self._tytul};{self._tresc};{Notatka.__licznikNotatek}")


def main():
    print("=== TEST KLASY NOTATKA ===")
    
    print("\n--- Notatka 1 ---")
    n1 = Notatka("Zakupy", "chleb, masło, ser")
    n1.wyswietl()
    print("Diagnostyka:")
    n1.diagnostyka()

    print("\n--- Notatka 2 ---")
    n2 = Notatka("Do zrobienia", "obiad, umyć podłogi")
    n2.wyswietl()
    print("Diagnostyka:")
    n2.diagnostyka()


if __name__ == "__main__":
    main()