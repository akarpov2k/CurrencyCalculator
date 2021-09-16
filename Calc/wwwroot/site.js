
function checkForZero(input) {
    console.log(input);
    var num = input.value;
    if (num) {
        input.value = num.replace(/^0+/, '');
    }
    input.onchange();
}