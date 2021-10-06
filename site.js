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

function showCell(cellId, value, color, eraseValue) {
    let btn = document.getElementById(cellId);
    console.log(btn);
    btn.style.background = color;
    if (eraseValue) {
        btn.innerHTML = '';
        btn.click = function () {
            return false;
        };
    }
    else {
        btn.innerHTML = value;
    }
}

function _sleep(delay) {
    var start = new Date().getTime();
    while (new Date().getTime() < start + delay);
}

function showSelectCell(cellId, value, color, eraseValue, sleep = false) {
    console.log(sleep);
    showCell(cellId, value, color, eraseValue);    
}