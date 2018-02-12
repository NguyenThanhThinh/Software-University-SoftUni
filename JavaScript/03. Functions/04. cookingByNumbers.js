function cookNumbers() {
    let args = arguments[0];
    let result = Number(args[0]);

    let chop = num => (num / 2);
    let dice = num => Math.sqrt(num);
    let spice = num => ++num;
    let bake = num => num * 3;
    let fillet = num => num -= num * 0.2;

    let printAndUpdateResult = (newResult, func) => {
        result = func(newResult);
        console.log(result);
    };

    for (let i = 1; i < args.length; i++) {
        switch (args[i]) {
            case 'chop':
                printAndUpdateResult(result, chop);
                break;
            case 'dice':
                printAndUpdateResult(result, dice);
                break;
            case 'spice':
                printAndUpdateResult(result, spice);
                break;
            case 'bake':
                printAndUpdateResult(result, bake);
                break;
            case 'fillet':
                printAndUpdateResult(result, fillet);
                break;
        }
    }
}

//cookNumbers([32, 'chop', 'chop', 'chop', 'chop', 'chop']);