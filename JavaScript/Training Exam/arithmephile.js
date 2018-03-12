function findBiggestProduct(inputNumbers) {
    inputNumbers = inputNumbers.map(Number)
    let biggestProduct = Number.MIN_SAFE_INTEGER
    for (var index = 0; index < inputNumbers.length; index++) {
        var currentNumber = inputNumbers[index];
        if (currentNumber >= 0 && currentNumber < 10) {
            let currentProduct = 1;
            for (var innerIndex = index + 1; innerIndex <= index + currentNumber; innerIndex++) {
                var currentMultiplier = inputNumbers[innerIndex];
                currentProduct *= currentMultiplier
            }
            if (currentProduct > biggestProduct) {
                biggestProduct = currentProduct
            }
        }
    }

    console.log(biggestProduct)
}