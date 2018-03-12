function solve(matrix) {
    let numberMatrix = matrix.map(r => r.split(' ').map(Number));

    let leftDiagonal = 0;
    let rightDiagonal = 0;
    let indexLeftD = 0;
    let indexRightD = numberMatrix[0].length - 1;

    numberMatrix.forEach(r => {
        leftDiagonal += r[indexLeftD++];
        rightDiagonal += r[indexRightD--]
    });

    indexLeftD = 0;
    indexRightD = numberMatrix[0].length - 1;

    for (let row = 0; row < numberMatrix.length; row++) {
        for (let col = 0; col < numberMatrix[row].length; col++) {
            if (col !== indexLeftD && col !== indexRightD) {
                numberMatrix[row][col] = leftDiagonal;
            }
        }

        indexRightD--;
        indexLeftD++;
    }
    
    console.log(numberMatrix
            .map(r => r.join(' '))
            .join('\n'));
}

//solve(['5 3 12 3 1', '11 4 23 2 5', '101 12 3 21 10', '1 4 5 2 2', '5 22 33 11 1']);