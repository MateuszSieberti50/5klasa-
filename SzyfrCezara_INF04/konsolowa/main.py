# **************************************************
# nazwa funkcji:       szyfruj
# argumenty:           tekst - tekst jawny do zaszyfrowania (str)
#                      klucz - liczba całkowita określająca przesunięcie w alfabecie (int)
# typ zwracany:        str - zaszyfrowany tekst
# informacje:          Funkcja realizująca algorytm Szyfru Cezara dla małych liter alfabetu łacińskiego (a-z).
#                      Spacje oraz inne znaki pozostają bez zmian.
# autor:               Mateusz Golnau
# **************************************************
def szyfruj(tekst: str, klucz: int) -> str:
    wynik = []
    for char in tekst:
        if 'a' <= char <= 'z':
            kod = ord(char) - ord('a')
            nowy_kod = (kod + klucz) % 26
            wynik.append(chr(ord('a') + nowy_kod))
        else:
            wynik.append(char)
    return "".join(wynik)


def main():
    print("=== PROGRAM SZYFRUJĄCY - SZYFR CEZARA ===")
    tekst = input("Podaj tekst do zaszyfrowania (małe litery): ")
    
    try:
        klucz_input = input("Podaj wartość klucza: ")
        klucz = int(klucz_input)
    except ValueError:
        print("Nieprawidłowy klucz! Zastosowano klucz domyślny 0.")
        klucz = 0
        
    zaszyfrowany = szyfruj(tekst, klucz)
    print(f"\nTekst zaszyfrowany: {zaszyfrowany}")


if __name__ == "__main__":
    main()