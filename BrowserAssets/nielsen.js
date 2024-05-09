// Lista wszystkich heurystyk Nielsena
var heurystykiNielsena = [
    "Pokazuj status systemu",
    "Zachowaj zgodność pomiędzy systemem a rzeczywistością.",
    "Daj użytkownikowi pełną kontrolę.",
    "Trzymaj się standardów i zachowaj spójność.",
    "Zapobiegaj błędom.",
    "Pozwalaj wybierać zamiast zmuszać do pamiętania.",
    "Zapewnij elastyczność i efektywność.",
    "Dbaj o estetykę i umiar.",
    "Zapewnij skuteczną obsługę błędów.",
    "Zadbaj o pomoc i dokumentację."
];

// Funkcja losująca niespełnione heurystyki i modyfikująca interakcję użytkownika na stronie
function losujINieSpelnioneHeurystyki() {
    var container = document.getElementById('heuristicContainer');
    container.innerHTML = '';

    // Losowanie trzech różnych heurystyk
    for (var i = 0; i < 3; i++) {
        var index = Math.floor(Math.random() * heurystykiNielsena.length);
        var heuristic = heurystykiNielsena[index];
        var paragraph = document.createElement('p');
        paragraph.textContent = heuristic;
        container.appendChild(paragraph);

        // Modyfikacja interakcji na stronie w zależności od wylosowanej heurystyki
        switch (heuristic) {
            case "Zapobieganie błędom":
                // Zmiana formularza do akceptacji dowolnego tekstu
                document.getElementById('gameForm').addEventListener('submit', function(event) {
                    event.preventDefault(); // Zapobieganie domyślnej akcji wysyłania formularza
                    alert("Formularz został przesłany. Kod pocztowy nie został sprawdzony.");
                });
                break;
            // Dodaj więcej przypadków, jeśli chcesz modyfikować inne interakcje na stronie
        }

        // Usuwanie wylosowanej heurystyki z listy, aby się nie powtórzyła
        heurystykiNielsena.splice(index, 1);
    }
}

// Losuj i modyfikuj heurystyki przy ładowaniu strony
window.onload = losujINieSpelnioneHeurystyki;