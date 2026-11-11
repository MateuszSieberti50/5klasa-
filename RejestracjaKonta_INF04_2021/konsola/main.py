# **************************************************
# nazwa funkcji:       szukaj_max_indeks
# argumenty:           tablica - lista liczb całkowitych do przeszukania (list)
#                      start_idx - indeks od którego rozpoczynamy poszukiwania (int)
# typ zwracany:        int - indeks elementu o maksymalnej wartości
# informacje:          Metoda pomocnicza klasy TablicaSortowana szukająca indeksu największego elementu.
# autor:               Mateusz Golnau
# **************************************************

# **************************************************
# nazwa funkcji:       sortuj
# argumenty:           brak
# typ zwracany:        brak (modyfikacja tablicy w miejscu)
# informacje:          Sortuje tablicę malejąco algorytmem sortowania przez wybieranie (Selection Sort).
# autor:               Mateusz Golnau
# **************************************************

class TablicaSortowana:
    def __init__(self):
        self.tablica = []

    def wczytaj_dane(self):
        print("Podaj 10 liczb całkowitych:")
        for i in range(10):
            while True:
                try:
                    val = int(input(f"Podaj liczbę {i + 1}: "))
                    self.tablica.append(val)
                    break
                except ValueError:
                    print("Błąd! Wprowadź poprawną liczbę całkowitą.")

    def _szukaj_max_indeks(self, start_idx: int) -> int:
        max_idx = start_idx
        for i in range(start_idx + 1, len(self.tablica)):
            if self.tablica[i] > self.tablica[max_idx]:
                max_idx = i
        return max_idx

    def sortuj(self) -> None:
        n = len(self.tablica)
        for i in range(n):
            max_idx = self._szukaj_max_indeks(i)
            # Ręczna zamiana miejscami
            temp = self.tablica[i]
            self.tablica[i] = self.tablica[max_idx]
            self.tablica[max_idx] = temp

    def wyswietl(self) -> None:
        print()
        print("Posortowana tablica (malejąco):")
        print(", ".join(map(str, self.tablica)))


def main():
    print("=== PROGRAM SORTUJĄCY PRZEZ WYBIERANIE (MALEJĄCO) ===")
    obj = TablicaSortowana()
    obj.wczytaj_dane()
    obj.sortuj()
    obj.wyswietl()


if __name__ == "__main__":
    main()
