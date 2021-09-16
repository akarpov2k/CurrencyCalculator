
function checkForZero(input) {
    console.log($(input)[0].getAttribute('id') ==='firstNum');
    var num = input.value;
    if (num) {
        input.value = num.replace(/^0+/, '');
    }
    if ($(input)[0].getAttribute('id') === 'firstNum') {
        ChangeSecondInput($(input)[0].value);
    }
    else {
        ChangeFirstInput($(input)[0].value);
    }
}

function ChangeFirstInput(value) {
    $("#firstNum")[0].value = value;
}

function ChangeSecondInput(value) {
    $("#secondNum")[0].value = value;
}