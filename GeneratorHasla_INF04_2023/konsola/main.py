# **************************************************
# nazwa funkcji:       nwd
# opis funkcji:        Oblicza Największy Wspólny Dzielnik dwóch liczb całkowitych dodatnich algorytmem Euklidesa (zodejmowanie).
# parametry:           a - pierwsza liczba całkowita dodatnia (int)
#                      b - druga liczba całkowita dodatnia (int)
# zwracany typ i opis: int - wartość Największego Wspólnego Dzielnika NWD(a, b)
# autor:               Mateusz Golnau
# **************************************************
def nwd(a: int, b: int) -> int:
    while a != b:
        if a > b:
            a = a - b
        else:
            b = b - a
    return a


def main():
    print("=== PROGRAM OBLICZAJĄCY NWD (ALGORYTM EUKLIDESA) ===")
    try:
        a_val = int(input("Podaj pierwszą liczbę dodatnią (a): "))
        b_val = int(input("Podaj drugą liczbę dodatnią (b): "))
        
        if a_val <= 0 or b_val <= 0:
            print("Liczby muszą być dodatnie!")
            return
            
        wynik = nwd(a_val, b_val)
        print()
        print(f"Największy wspólny dzielnik NWD({a_val}, {b_val}) wynosi: {wynik}")
    except ValueError:
        print("Nieprawidłowe dane! Podaj liczby całkowite.")


if __name__ == "__main__":
    main()
