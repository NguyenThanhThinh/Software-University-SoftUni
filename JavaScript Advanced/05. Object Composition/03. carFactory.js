function solve(car) {
    let result = {};
    result.model = car.model;
    result.engine = car.power <= 90 ?
        { power: 90, volume: 1800 } :
            car.power > 120 ? { power: 200, volume: 3500 } : { power: 120, volume: 2400 };

    result.carriage = { type: car.carriage, color: car.color };
    result.wheels = calculateWheels();

    function calculateWheels() {
        let wheelsize = car.wheelsize;
        if(wheelsize % 2 === 0) {
            wheelsize--;
        }
        return [wheelsize, wheelsize, wheelsize, wheelsize];
    }

    return result;
}

let car = { model: 'VW Golf II',
    power: 90,
    color: 'blue',
    carriage: 'hatchback',
    wheelsize: 14 };

console.log(solve(car));