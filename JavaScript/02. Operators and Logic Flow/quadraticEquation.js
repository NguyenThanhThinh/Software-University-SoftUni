function solveQuadraticEquation(a, b, c) {
    let d = Math.pow(b, 2) - (4 * a * c);

    if(d > 0){
        let x1 = (-b + Math.sqrt(d)) / (2 * a);
        let x2 = (-b - Math.sqrt(d)) / (2 * a);

        console.log(+(x1 < x2 ? x1 : x2).toFixed(5));
        console.log(+(x1 > x2 ? x1 : x2).toFixed(5));
    }
    else if(d == 0){
        let x = -b / (2 * a);
        console.log(+x.toFixed(5));
    }
    else{
        console.log('No');
    }
}

//solveQuadraticEquation(1, -12, 36);