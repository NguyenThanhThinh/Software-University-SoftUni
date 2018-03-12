function isMatrixMagical(arr) {
    let sumCheck = arr[0].reduce((e1, e2) => e1 + e2);
    let sum = 0;

    for (let row = 0; row < arr.length; row++) {
        sum = arr[row].reduce((e1, e2) => e1 + e2);

        if (sum !== sumCheck) {
            console.log(false);
            return;
        }
    }

    for (let row = 0; row < arr.length; row++) {
        sum = 0;
        for (let col = 0; col < arr[row].length; col++) {
            sum += arr[col][row];
        }
        if (sum !== sumCheck) {
            console.log(false);
            return;
        }
    }

    console.log(true);
}

isMatrixMagical([[4, 5, 6], [6, 5, 4], [5, 5, 5]]);