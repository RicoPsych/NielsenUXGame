
var activeHeuristics = [1,2,4,5,6,7,8,10];
var choosenBadHeuristics = [];
const form = document.getElementById("gameForm"); 

function drawHeuristics(){
    //document.getElementById("postalCode").setCustomValidity("Podaj kod pocztowy w poprawnym formacie (xx-xxx).");
    var remainingHeuristics = activeHeuristics;
    for(var i=remainingHeuristics.length-1; i>=1; i--){
        if(chanceReturn(i,remainingHeuristics.length)){
            var index = randomNumber(0,remainingHeuristics.length-1);
            choosenBadHeuristics.push(remainingHeuristics[index]);
            //2 i 6 nie wykonają się jednocześnie, wylosuje się jedna lub żadna
            if(remainingHeuristics[index] == 6){
                remainingHeuristics.splice(index,1);
                var ind = remainingHeuristics.indexOf(2);
                if (ind !== -1) {
                    remainingHeuristics.splice(ind, 1);
                }
                i--;
            }
            else if(remainingHeuristics[index] == 2){
                remainingHeuristics.splice(index,1);
                var ind = remainingHeuristics.indexOf(6);
                if (ind !== -1) {
                    remainingHeuristics.splice(ind, 1);
                }
                i--;
            }
            else{
                remainingHeuristics.splice(index,1);
            }
            
        }
    }
    doBadHeuristics(choosenBadHeuristics);
}

function randomNumber(min,max){
    return Math.floor(Math.random() * (max - min + 1)) + min;
}

function chanceReturn(x,y){
    if(Math.random() <= x/y)
        return true;
    else 
        return false;
}

function doBadHeuristics(badHeuristics){
    for(let element of badHeuristics){
        switch(element){
            case 1:
                doBadHeuristic1();
            break;
            case 2:
                doBadHeuristic2();
            break;
            case 4:
                doBadHeuristic4();
            break;
            case 5:
                doBadHeuristic5();
            break;
            case 6:
                doBadHeuristic6();
            break;
            case 7: 
                doBadHeuristic7();
            break;
            case 8: 
                doBadHeuristic8();
            break;
            case 10:
                doBadHeuristic10();
            break;
        }
    }
}

function doBadHeuristic1(){
    var progressBar = document.querySelector('.progress-bar');
    if (progressBar) {
        progressBar.remove();
    }
    console.log("BAD HEURISTIC 1");
}

function doBadHeuristic2(){
    var newColorOptions = [
        {value: "", text: "Wybierz kolor bluzy"},
        {value: "#FF0000", text: "#FF0000"},
        {value: "#00FF00", text: "#00FF00"},
        {value: "#0000FF", text: "#0000FF"},
        {value: "#FFFF00", text: "#FFFF00"},
        // Dodaj inne opcje kolorów, jeśli jest taka potrzeba
    ];
    var newSizeOptions = [
        {value: "", text: "Wybierz rozmiar"},
        {value: "s", text: "najmniejszy"},
        {value: "m", text: "dość średni"},
        {value: "l", text: "chyba spory"},
        {value: "xl", text: "dość spory"},
        // Dodaj inne opcje kolorów, jeśli jest taka potrzeba
    ];

    var colorSelect = document.getElementById("color");
    var sizeSelect = document.getElementById("size");

    colorSelect.innerHTML = "";
    sizeSelect.innerHTML = "";

    newColorOptions.forEach(function(option) {
        var optionElement = document.createElement("option");
        optionElement.value = option.value;
        optionElement.text = option.text;
        colorSelect.appendChild(optionElement);
    });

    newSizeOptions.forEach(function(option) {
        var optionElement = document.createElement("option");
        optionElement.value = option.value;
        optionElement.text = option.text;
        sizeSelect.appendChild(optionElement);
    });

    console.log("BAD HEURISTIC 2");
}
function doBadHeuristic4(){
    var form = document.getElementById("gameForm");
    var elements = Array.from(form.children);
    
    // Filtrowanie inputów i selectów, wyłączając checkboxy i button submit
    var inputsAndSelects = elements.filter(function(element) {
        return (element.tagName === "INPUT" && element.type !== "checkbox" && element.type !== "submit") || element.tagName === "SELECT";
    });

    // Losowe mieszanie tablicy inputów i selectów
    for (let i = inputsAndSelects.length - 1; i > 0; i--) {
        const j = Math.floor(Math.random() * (i + 1));
        [inputsAndSelects[i], inputsAndSelects[j]] = [inputsAndSelects[j], inputsAndSelects[i]];
    }

    // Usunięcie wszystkich inputów i selectów z formularza
    inputsAndSelects.forEach(function(element) {
        form.removeChild(element);
    });

    // Ponowne dodanie pozostałych elementów (checkboxy i submit button) do formularza
    elements.forEach(function(element) {
        if ((element.tagName === "INPUT" && (element.type === "checkbox" || element.type === "submit")) || element.tagName === "DIV") {
            form.appendChild(element);
        }
    });

    // Dodanie wymieszanych inputów i selectów na początku formularza
    inputsAndSelects.forEach(function(element) {
        form.insertBefore(element, form.firstChild);
    });

    console.log("BAD HEURISTIC 4");
}
function doBadHeuristic5(){ //Done
    document.getElementById('name').removeAttribute("required");
    document.getElementById('surname').removeAttribute("required");
    document.getElementById('city').removeAttribute("required");
    document.getElementById('street').removeAttribute("required");
    document.getElementById('streetNumber').removeAttribute("required");
    document.getElementById('houseNumber').removeAttribute("required");
    document.getElementById('postalCode').removeAttribute("required");
    document.getElementById('postalCode').removeAttribute("pattern");
    document.getElementById('size').removeAttribute("required");
    document.getElementById('color').removeAttribute("required");
    document.getElementById('checkbox1').removeAttribute("required");
    document.getElementById('checkbox2').removeAttribute("required");
    document.getElementById('checkbox3').removeAttribute("required");
    document.getElementById('checkbox4').removeAttribute("required");

    document.getElementById("postalCode").setCustomValidity("");

    console.log("BAD HEURISTIC 5");
}
function doBadHeuristic6(){ //done
    const colorSelect = document.getElementById("color");
    const sizeSelect = document.getElementById("size");

    const colorInput = document.createElement("input");
    colorInput.type = "text";
    colorInput.id = "color";
    colorInput.name = "color";
    colorInput.placeholder = "Wprowadź kolor";

    const sizeInput = document.createElement("input");
    sizeInput.type = "text";
    sizeInput.id = "size";
    sizeInput.name = "size";
    sizeInput.placeholder = "Wprowadź rozmiar";

    if(!choosenBadHeuristics.includes(5)){
        colorInput.required = true;
        sizeInput.required = true;
    }

    colorSelect.parentNode.replaceChild(colorInput, colorSelect);
    sizeSelect.parentNode.replaceChild(sizeInput, sizeSelect);

    console.log("BAD HEURISTIC 6");
}
function doBadHeuristic7(){
    var checkboxall = document.getElementById("checkboxalldiv")
    if (checkboxall) {
        checkboxall.remove();
    }
    console.log("BAD HEURISTIC 7"); 
}
function doBadHeuristic8(){
    
    var divs = document.querySelectorAll(".toomuch");
    divs.forEach(function(div) {
        div.style.display = "block";
        var marquees = div.querySelectorAll("marquee");
        marquees.forEach(function(marquee) {
            var parent = marquee.parentNode;
            var next = marquee.nextSibling;
            parent.removeChild(marquee);
            parent.insertBefore(marquee, next);
        });
    });
    console.log("BAD HEURISTIC 8");
}
function doBadHeuristic10(){

    document.getElementById("tooltip").style.display = "none";
    console.log("BAD HEURISTIC 10");
}


form.addEventListener("submit", function(event) {
    event.preventDefault();
    
    const inputFields = form.querySelectorAll("input");
    inputFields.forEach(function(input) {
        input.value = ""; 
    });

    alert("Dziękujemy za złożenie zamówienia!")
});

function PrzekazWylosowaneLiczbyDoUnity() {
    return JSON.stringify(choosenBadHeuristics);
}

//Zaznacz wszystko
var selectAllCheckbox = document.getElementById('checkbox-all');
var checkboxes = document.querySelectorAll('input[type="checkbox"]:not(#select-all)');
selectAllCheckbox.addEventListener('change', function() {
    checkboxes.forEach(function(checkbox) {
        checkbox.checked = selectAllCheckbox.checked;
    });
});

// Losuj i modyfikuj heurystyki przy ładowaniu strony
window.onload = drawHeuristics;