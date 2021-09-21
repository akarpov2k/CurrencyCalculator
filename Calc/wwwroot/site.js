function checkForZero(input) {
    
    if ($(input)[0].getAttribute('id') === 'firstNum') {
        ChangeSecondInput($(input)[0].value);
    }
    else {
        ChangeFirstInput($(input)[0].value);
    }
    var num = input.value.replace('.', ',');
    if (num) {
        input.value = num.replace(/^0+/, '');
    }
    if (input.value === '') {
        input.value = 0;
    }
}

function ChangeFirstInput(value) {
    var rate = GetCurrencyRate(false);
    $("#firstNum")[0].value = (Number(value) * rate).toString();
}

function ChangeSecondInput(value) {
    var rate = GetCurrencyRate(true);    
    $("#secondNum")[0].value = (Number(value) * rate).toString();
}

function GetCurrencyRate(isFirst) {
    var firstNum = document.getElementById('firstList').value;
    var secondNum = document.getElementById('secondList').value;
    if (isFirst) {
        return Number(secondNum) / Number(firstNum);
    }
    else {
        return Number(firstNum) / Number(secondNum);
    }
}