import random

# **************************************************
# nazwa funkcji:       wypelnij_losowania
# opis funkcji:        Generuje dwuwymiarową listę n zestawów, z których każdy
#                      zawiera 6 unikalnych pseudolosowych liczb z zakresu <1, 49>.
# parametry:           n - liczba zestawów do wylosowania (int)
# zwracany typ i opis: list - dwuwymiarowa lista (n x 6) z wylosowanymi zestawami
# autor:               Mateusz Golnau
# **************************************************
def wypelnij_losowania(n: int) -> list:
    losowania = []
    for _ in range(n):
        zestaw = random.sample(range(1, 50), 6)
        losowania.append(zestaw)
    return losowania


# **************************************************
# nazwa funkcji:       wyswietl_wyniki
# opis funkcji:        Wyświetla wylosowane zestawy oraz zlicza i wypisuje
#                      liczbę wystąpień każdej liczby od 1 do 49.
# parametry:           losowania - dwuwymiarowa lista zestawów liczb (list)
# zwracany typ i opis: brak
# autor:               Mateusz Golnau
# **************************************************
def wyswietl_wyniki(losowania: list) -> None:
    print("\nZestawy wylosowanych liczb:")
    wystapienia = {i: 0 for i in range(1, 50)}
    
    for index, zestaw in enumerate(losowania, 1):
        zestaw_str = " ".join(str(liczba) for liczba in zestaw)
        print(f"Losowanie {index}: {zestaw_str}")
        for liczba in zestaw:
            wystapienia[liczba] += 1
            
    print()
    for liczba in range(1, 50):
        print(f"Wystąpienia liczby {liczba}: {wystapienia[liczba]}")


def main():
    try:
        ile_zestawow = int(input("Ile wygenerować losowań?\n"))
        if ile_zestawow <= 0:
            print("Liczba losowań musi być większa od 0.")
            return
        dane = wypelnij_losowania(ile_zestawow)
        wyswietl_wyniki(dane)
    except ValueError:
        print("Nieprawidłowe dane wejściowe. Podaj liczbę całkowitą.")


if __name__ == "__main__":
    main()
