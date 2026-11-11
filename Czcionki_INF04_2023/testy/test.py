import random
from main import sortuj_babelkowo

def test_sortowania():
    print("=== TEST AKCEPTACYJNY FUNKCJI SORTUJĄCEJ ===")
    
    # Losowanie 100 liczb dodatnich z przedziału 0..1000
    dane_testowe = [random.randint(0, 1000) for _ in range(100)]
    
    print("Wyelosowane dane testowe (0-1000):")
    print(dane_testowe)
    
    sortuj_babelkowo(dane_testowe)
    
    print("
Dane po wywołaniu sortuj_babelkowo:")
    print(dane_testowe)
    
    # Weryfikacja czy tablica jest poprawnie posortowana rosnąco
    is_sorted = all(dane_testowe[i] <= dane_testowe[i + 1] for i in range(len(dane_testowe) - 1))
    
    if is_sorted:
        print("
TEST ZAKOŃCZONY SUKCESEM: Tablica została prawidłowo posortowana rosnąco.")
    else:
        print("
TEST NIEPOWODZENIE: Tablica nie jest prawidłowo posortowana.")

if __name__ == "__main__":
    test_sortowania()
