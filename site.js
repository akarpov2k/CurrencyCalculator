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