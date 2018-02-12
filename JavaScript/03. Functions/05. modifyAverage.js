function averageNumber(num) {

    while (calculateAverageNum(num)) {
        num = addDigitNine();
    }

    function calculateAverageNum(num) {
        let sum = 0;
        let numAsString = num.toString();

        for (let digit of numAsString) {
            sum += Number(digit);
        }

        let average = sum / numAsString.length;

        return average <= 5 ? true : false;
    }

    function addDigitNine() {
        let numAsString = num.toString();
        return Number(numAsString + '9');
    }

    console.log(num);
}

//averageNumber(101);