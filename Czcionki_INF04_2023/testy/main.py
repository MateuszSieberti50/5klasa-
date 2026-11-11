import random

# **************************************************
# nazwa funkcji:       sortuj_babelkowo
# argumenty:           tablica - lista liczb całkowitych do posortowania (list)
# typ zwracany:        brak (modyfikacja tablicy w miejscu)
# informacje:          Funkcja sortuje tablicę liczb całkowitych rosnąco algorytmem sortowania bąbelkowego.
#                      Zamiana elementów realizowana jest ręcznie przy użyciu zmiennej tymczasowej (bez funkcji wbudowanych).
# autor:               Mateusz Golnau
# **************************************************
def sortuj_babelkowo(tablica: list) -> None:
    n = len(tablica)
    for i in range(n):
        for j in range(0, n - i - 1):
            if tablica[j] > tablica[j + 1]:
                # Ręczna zamiana miejscami bez gotowych funkcji
                temp = tablica[j]
                tablica[j] = tablica[j + 1]
                tablica[j + 1] = temp


def main():
    print("=== PROGRAM SORTUJĄCY (SORTOWANIE BĄBELKOWE) ===")
    
    # Generowanie 100 pseudolosowych liczb całkowitych
    tablica = [random.randint(1, 1000) for _ in range(100)]
    
    print("
Tablica przed posortowaniem:")
    print(", ".join(map(str, tablica)))
    
    # Wywołanie funkcji sortującej
    sortuj_babelkowo(tablica)
    
    print("
Posortowana tablica (rosnąco):")
    print(", ".join(map(str, tablica)))


if __name__ == "__main__":
    main()
