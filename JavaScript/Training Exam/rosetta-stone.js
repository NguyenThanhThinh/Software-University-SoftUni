function decodeMessage(input) {
    let templateMatrixSide = Number(input[0])
    let templateMatrix = []
    for (var index = 1; index < 1 + templateMatrixSide; index++) {
        var currentRow = input[index];
        templateMatrix.push(currentRow.split(' ').map(Number))
    }

    let encodedMatrix = []
    for (var index = 1 + templateMatrixSide; index < input.length; index++) {
        var currentRow = input[index];
        encodedMatrix.push(currentRow.split(' ').map(Number))
    }

    let templateMatrixRows = templateMatrixSide
    let templateMatrixCols = templateMatrix[0].length

    for (var encodedRow = 0; encodedRow < encodedMatrix.length; encodedRow += templateMatrixRows) {
        var currentRow = encodedMatrix[encodedRow];
        for (var encodedCol = 0; encodedCol < encodedMatrix[encodedRow].length; encodedCol += templateMatrixCols) {
            var currentEncodedNumber = encodedMatrix[encodedRow][encodedCol];

            for (var templateRow = 0; templateRow < templateMatrix.length; templateRow++) {
                var currentTemplateRow = templateMatrix[templateRow];
                for (var templateCol = 0; templateCol < templateMatrix[templateRow].length; templateCol++) {
                    var currentTemplateNumber = templateMatrix[templateRow][templateCol];

                    let targetRow = encodedRow + templateRow
                    let targetCol = encodedCol + templateCol

                    if (targetCol < encodedMatrix[encodedRow].length && targetRow < encodedMatrix.length) {
                        let summedNumber = encodedMatrix[targetRow][targetCol] + templateMatrix[templateRow][templateCol]
                        summedNumber %= 27
                        if (summedNumber === 0) {
                            encodedMatrix[targetRow][targetCol] = ' '
                        } else {
                            encodedMatrix[targetRow][targetCol] = String.fromCharCode(summedNumber + 64)
                        }
                    }
                }
            }
        }
    }

    let output = ''
    encodedMatrix.forEach(function(element) {
        element.forEach(function(letter) {
            output += letter
        }, this);
    }, this);

    console.log(output.trim())
}

decodeMessage(['2',
    '59 36',
    '82 52',
    '4 18 25 19 8',
    '4 2 8 2 18',
    '23 14 22 0 22',
    '2 17 13 19 20',
    '0 9 0 22 22'
])