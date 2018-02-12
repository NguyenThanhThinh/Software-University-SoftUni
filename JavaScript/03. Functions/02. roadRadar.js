function radar([speed, area]) {

    const motorwayMaxSpeed = 130;
    const interstateMaxSpeed = 90;
    const cityMaxSpeed = 50;
    const residentialMaxSpeed = 20;

    switch (area) {
        case 'motorway':
            if(speed > motorwayMaxSpeed) {
                calculateOverSpeed(speed, motorwayMaxSpeed)
            }
            break;
        case 'interstate':
            if(speed > interstateMaxSpeed) {
                calculateOverSpeed(speed, interstateMaxSpeed)
            }
            break;
        case 'city':
            if(speed > cityMaxSpeed) {
                calculateOverSpeed(speed, cityMaxSpeed)
            }
            break;
        case 'residential':
            if(speed > residentialMaxSpeed) {
                calculateOverSpeed(speed, residentialMaxSpeed)
            }
            break;
    }

    function calculateOverSpeed(currentSpeed, maxSpeed) {
        let overSpeed = currentSpeed - maxSpeed;

        if (overSpeed <= 20) {
            console.log('speeding');
        }
        else if (overSpeed <= 40) {
            console.log('excessive speeding');
        }
        else {
            console.log('reckless driving');
        }
    }
}

//radar([21, 'residential']);