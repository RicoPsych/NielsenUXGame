document.getElementById("postalCode").setCustomValidity("Podaj kod pocztowy w poprawnym formacie (xx-xxx).");
var activeHeuristics = [2,5,6,8];
var choosenBadHeuristics = [];
const form = document.getElementById("gameForm"); 

function drawHeuristics(){
    
    var remainingHeuristics = activeHeuristics;
    for(var i=remainingHeuristics.length-1; i>=1; i--){
        if(chanceReturn(i,remainingHeuristics.length)){
            var index = randomNumber(0,remainingHeuristics.length-1);
            choosenBadHeuristics.push(remainingHeuristics[index]);
            remainingHeuristics.splice(index,1);
        }
    }
    //UnitySendMessage("","", JSON.stringify(choosenBadHeuristics));
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
            case 2:
                doBadHeuristic2();
            break;
            case 5:
                doBadHeuristic5();
            break;
            case 6:
                doBadHeuristic6();
            break;
            case 8:
                doBadHeuristic8();
            break;
        }
    }
}

function doBadHeuristic2(){
    console.log("BAD HEURISTIC 2");
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
function doBadHeuristic8(){
    
    console.log("BAD HEURISTIC 8");
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

// Losuj i modyfikuj heurystyki przy ładowaniu strony
window.onload = drawHeuristics;