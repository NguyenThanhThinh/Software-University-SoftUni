function printFigure(n) {

    let rowSymbols = 2 * (n - 1);
    let whenToResetCount = n;
    n = n % 2 === 0 ? n - 1 : n;
    let center = Math.floor(n / 2);

    let result = '';

    for (let i = 0; i < n; i++) {
        let countForSymbols = 1;

        if (i == 0 || i == center || i == n - 1) {

            for (let p = 0; p <= rowSymbols; p++) {
                if (countForSymbols == 1) {
                    result += '+';
                }
                else {
                    result += '-';
                }

                countForSymbols++;
                if (countForSymbols == whenToResetCount) {
                    countForSymbols = 1;
                }
            }
            result += '\n';
        }
        else {
            for (let p = 0; p <= rowSymbols; p++) {
                if (countForSymbols == 1) {
                    result += '|';
                }
                else {
                    result += ' ';
                }

                countForSymbols++;
                if (countForSymbols == whenToResetCount) {
                    countForSymbols = 1;
                }
            }
            result += '\n';
        }
    }

    console.log(result);
}

//printFigure(7);