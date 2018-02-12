function factory() {
    let args = arguments[0];
    let desiredThickness = args[0];
    let crystals = args.slice(1);
    let usedOperations = [];

    let logs = '';
    let lastOperation;

    for (let crystal of crystals) {
        let currentCrystalState = crystal;

        logs += `Processing chunk ${currentCrystalState} microns\n`;

        while (currentCrystalState != desiredThickness) {
            currentCrystalState = giveCorrectOperation(currentCrystalState);
        }

        usedOperations = [];
        logs += `Finished crystal ${desiredThickness} microns\n`;
    }

    console.log(logs);

    function giveCorrectOperation(crystal) {

        let cut = crystal => crystal / 4;
        let lap = crystal => crystal -= crystal * 0.2;
        let grind = crystal => crystal -= 20;
        let etch = crystal => crystal -= 2;
        let xray = crystal => crystal += 1;

        let currentState = 0;

        if (desiredThickness <= cut(crystal) || desiredThickness - 1 == cut(crystal)) {
            crystal = transportAndWashIfOperationChanged(crystal, lastOperation, 1);
            usedOperations.push(1);
            currentState = cut(crystal);
        }
        else if (desiredThickness <= lap(crystal) || desiredThickness - 1 == lap(crystal)) {
            crystal = transportAndWashIfOperationChanged(crystal, lastOperation, 2);
            usedOperations.push(2);
            currentState = lap(crystal);
        }
        else if (desiredThickness <= grind(crystal) || desiredThickness - 1 == grind(crystal)) {
            crystal = transportAndWashIfOperationChanged(crystal, lastOperation, 3);
            usedOperations.push(3);
            currentState = grind(crystal);
        }
        else if (desiredThickness <= etch(crystal) || desiredThickness - 1 == etch(crystal)) {
            crystal = transportAndWashIfOperationChanged(crystal, lastOperation, 4);
            usedOperations.push(4);
            currentState = etch(crystal);
        }
        else if (desiredThickness == xray(crystal)) {
            crystal = transportAndWashIfOperationChanged(crystal, lastOperation, 5);
            usedOperations.push(5);
            currentState = xray(crystal);
        }

        lastOperation = usedOperations[usedOperations.length - 1];

        if (currentState == desiredThickness) {
            createLog(lastOperation);
        }

        return currentState;

        function transportAndWashIfOperationChanged(crystal, lastOperation, currentOperation) {
            let transportAndWash = crystal => Math.floor(crystal);

            if (lastOperation != currentOperation && lastOperation !== undefined) {
                createLog(lastOperation);
                return transportAndWash(crystal);
            }

            return crystal;
        }

        function createLog(lastOperation) {
            let count = usedOperations.length;

            switch (lastOperation) {
                case 1 : logs += `Cut x${count}\n`;
                    break;
                case 2 : logs += `Lap x${count}\n`;
                    break;
                case 3 : logs += `Grind x${count}\n`;
                    break;
                case 4 : logs += `Etch x${count}\n`;
                    break;
                case 5 : logs += `Etch x${count}\n`;
                    break;
            }

            if (lastOperation !== undefined) {
                usedOperations = [];
                logs += 'Transporting and washing\n';
            }
        }
    }
}

//factory([1375, 50000]);
//factory([1000, 4000, 8100]);