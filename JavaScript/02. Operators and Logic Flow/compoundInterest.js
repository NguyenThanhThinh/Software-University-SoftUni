function compoundInterestRate([sum, rate, frequancy, length]) {
    frequancy = 12 / frequancy;
    rate /= 100;
    let result = sum * Math.pow(1 + (rate / frequancy), (frequancy * length));
    console.log(result.toFixed(2));
}

compoundInterestRate([1500, 4.3, 3, 6]);

for (var obj in array) {
    
}