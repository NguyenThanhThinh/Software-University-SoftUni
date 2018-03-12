let manager = (function () {
    let robot = {
        protein: 0,
        carbohydrate: 0,
        fat: 0,
        flavour: 0
    };

    let success = 'Success';

    return function solve(ingredients) {
        let tokens = ingredients.split(' ').filter(i => i.trim());
        let command = tokens[0];

        let restock = function () {
            let microelement = tokens[1];
            robot[microelement] += Number(tokens[2]);
        };

        let prepare = function () {
            let meal = tokens[1];
            let quantity = Number(tokens[2]);

            switch (meal) {
                case 'apple':
                    if(ifIngredientsQuantityIsNotEnough(robot.carbohydrate, quantity)) {
                        return(`Error: not enough carbohydrate in stock`);
                    }
                    if(ifIngredientsQuantityIsNotEnough(robot.flavour, 2 * quantity)) {
                        return(`Error: not enough flavour in stock`);
                    }
                    robot.carbohydrate -= quantity;
                    robot.flavour -= 2 * quantity;
                    break;
                case 'coke':
                    if(ifIngredientsQuantityIsNotEnough(robot.carbohydrate, 10 * quantity)) {
                        return (`Error: not enough carbohydrate in stock`);
                    }
                    if(ifIngredientsQuantityIsNotEnough(robot.flavour, 20 * quantity)) {
                        return(`Error: not enough flavour in stock`);
                    }
                    robot.carbohydrate -= 10 * quantity;
                    robot.flavour -= 20 * quantity;
                    break;
                case 'burger':
                    if(ifIngredientsQuantityIsNotEnough(robot.carbohydrate, 5 * quantity)) {
                        return(`Error: not enough carbohydrate in stock`);
                    }
                    if(ifIngredientsQuantityIsNotEnough(robot.fat, 7 * quantity)) {
                        return(`Error: not enough fat in stock`);
                    }
                    if(ifIngredientsQuantityIsNotEnough(robot.flavour, 3 * quantity)) {
                        return(`Error: not enough flavour in stock`);
                    }
                    robot.carbohydrate -= 5 * quantity;
                    robot.fat -= 7 * quantity;
                    robot.flavour -= 3 * quantity;
                    break;
                case 'omelet':
                    if(ifIngredientsQuantityIsNotEnough(robot.protein, 5 * quantity)) {
                        return(`Error: not enough protein in stock`);
                    }
                    if(ifIngredientsQuantityIsNotEnough(robot.fat, quantity)) {
                        return(`Error: not enough fat in stock`);
                    }
                    if(ifIngredientsQuantityIsNotEnough(robot.flavour, quantity)) {
                        return(`Error: not enough flavour in stock`);
                    }
                    robot.protein -= 5 * quantity;
                    robot.fat -= quantity;
                    robot.flavour -= quantity;
                    break;
                case 'cheverme':
                    if(ifIngredientsQuantityIsNotEnough(robot.protein, 10 * quantity)) {
                        return (`Error: not enough protein in stock`);
                    }
                    if(ifIngredientsQuantityIsNotEnough(robot.carbohydrate, 10 * quantity)) {
                        return(`Error: not enough carbohydrate in stock`);
                    }
                    if(ifIngredientsQuantityIsNotEnough(robot.fat, 10 * quantity)) {
                        return(`Error: not enough fat in stock`);
                    }
                    if(ifIngredientsQuantityIsNotEnough(robot.flavour, 10 * quantity)) {
                        return(`Error: not enough flavour in stock`);
                    }
                    robot.protein -= 10 * quantity;
                    robot.carbohydrate -= 10 * quantity;
                    robot.fat -= 10 * quantity;
                    robot.flavour -= 10 * quantity;
                    break;
            }
            return(success);
        };

        let report = function () {
            return(`protein=${robot.protein} carbohydrate=${robot.carbohydrate} fat=${robot.fat} flavour=${robot.flavour}`);
        };

        function ifIngredientsQuantityIsNotEnough(ingredient, quantity) {
            return ingredient - quantity < 0;
        }

        let commands = {
            "restock": restock,
            "prepare": prepare,
            "report": report
        };

        commands[command]();
    };

})();

/*
manager('restock carbohydrate 10');
manager('restock flavour 10');
manager('prepare apple 1');
manager('restock fat 10');
manager('prepare burger 1');
manager('report');
*/

console.log(manager('prepare cheverme 1'));
manager('restock protein 10');
manager('prepare cheverme 1');
manager('restock carbohydrate 10');
manager('prepare cheverme 1');
manager('restock fat 10');
manager('prepare cheverme 1');
manager('restock flavour 10');
manager('prepare cheverme 1');
manager('report');

