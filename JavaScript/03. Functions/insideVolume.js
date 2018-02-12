function checkMultiplyPointsAreInsideOfVolume() {
    let points = arguments[0];

    for (let i = 0; i < points.length; i += 3) {

        let x = points[i];
        let y = points[i + 1];
        let z = points[i + 2];

        isPointInsideOfVolume(x, y, z);
    }

    function isPointInsideOfVolume(x, y, z) {
        let x1 = 10;
        let x2 = 50;
        let y1 = 20;
        let y2 = 80;
        let z1 = 15;
        let z2 = 50;

        if (x >= x1 && x <= x2) {
            if (y >= y1 && y <= y2) {
                if (z >= z1 && z <= z2) {
                    console.log('inside');
                    return;
                }
            }
        }

        console.log('outside');
    }
}

//checkMultiplyPointsAreInsideOfVolume([13.1, 50, 31.5, 50, 80, 50, -5, 18, 43]);