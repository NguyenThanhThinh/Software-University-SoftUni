function round([num, precision]) {
    precision = precision > 15 ? 15 : precision;

    let string = num.toString();
    let pointIndex = string.indexOf('.');
    let toTake = precision + pointIndex + 1;
    let result = string.substring(0, toTake);

    console.log(result);
}
//round([-3.1415926535897932384626433832795, 2]);

function roundTwo([a, b]) {
    b = b > 15 ? 15 : b;
    console.log(+a.toFixed(b));
}
//roundTwo([-3.1, 2]);

function roundThree([num, precision]) {
    precision = precision > 15 ? 15 : precision;

    let denominator = Math.pow(10, precision);
    console.log(Math.round(num * denominator) / denominator);
}
//roundThree([-3.1415926535897932384626433832795, 2]);