function checkForDotAndZero(e,input) {
    if (e.key === '.') {
        e.preventDefault();        
        return false;
    }
}

function TriggerOnChange(input) {
    $(input).change();
    $(input)[0].blur();
    $(input)[0].focus();
}

function SwitchMode() {
    var body = document.body;
    body.classList.toggle("dark-mode");
    for (var i = 0; i < body.children.length; i++) {
        body.children[i].classList.toggle("dark-mode");
    }
}