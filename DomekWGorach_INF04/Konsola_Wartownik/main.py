import random

# **************************************************
# nazwa funkcji:       szukaj_z_wartownikiem
# argumenty:           tablica - lista liczb całkowitych do przeszukania (list)
#                      szukana - liczba całkowita, której szukamy (int)
# typ zwracany:        int, indeks pierwszego wystąpienia szukanej liczby lub -1 w przypadku jej braku
# informacje:          Algorytm przeszukiwania tablicy z wartownikiem. Dodaje szukaną wartość na koniec tablicy jako wartownika.
# autor:               Mateusz Golnau
# **************************************************
def szukaj_z_wartownikiem(tablica: list, szukana: int) -> int:
    kopia = list(tablica)
    kopia.append(szukana)
    
    i = 0
    while kopia[i] != szukana:
        i += 1
        
    if i == len(tablica):
        return -1
    return i


def wypelnij_tablice(rozmiar: int = 50) -> list:
    return [random.randint(1, 100) for _ in range(rozmiar)]


def main():
    tablica = wypelnij_tablice(50)
    
    try:
        szukana = int(input("Podaj liczbę do wyszukania w tablicy (1-100):\n"))
    except ValueError:
        print("Nieprawidłowe dane. Należy podać liczbę całkowitą.")
        return

    indeks = szukaj_z_wartownikiem(tablica, szukana)
    
    print("\nZawartość tablicy:")
    print(", ".join(map(str, tablica)))
    print()
    
    if indeks != -1:
        print(f"Liczba {szukana} została znaleziona pod indeksem: {indeks}")
    else:
        print(f"Liczby {szukana} nie odnaleziono w tablicy.")


if __name__ == "__main__":
    main()
