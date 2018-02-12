function shortestPath(arr) {
    let [x1, y1, x2, y2, x3, y3] = arr;
    let distanceBetweenTwoPoints = (x1, y1, x2, y2) => Math.sqrt((x2 - x1) ** 2 + (y2 - y1) ** 2);

    let distanceOneToTwo = distanceBetweenTwoPoints(x1, y1, x2, y2);
    let distanceTwoToThree = distanceBetweenTwoPoints(x2, y2, x3, y3);
    let distanceOneToThree = distanceBetweenTwoPoints(x1, y1, x3, y3);

    if ((distanceOneToTwo <= distanceOneToThree) && (distanceOneToThree => distanceTwoToThree)) {
        let a = distanceOneToTwo + distanceTwoToThree;
        console.log('1->2->3: ' + a);
    }
    else if ((distanceOneToTwo <= distanceTwoToThree) && (distanceOneToThree < distanceTwoToThree)) {
        let b = distanceOneToThree + distanceOneToTwo;
        console.log('2->1->3: '+ b);
    }
    else {
        let c = distanceTwoToThree + distanceOneToThree;
        console.log('1->3->2: ' + c);
    }
}

//shortestPath([0, 0, 2, 0, 4, 0]);
//shortestPath([0, 3, 1, 0, -1, 0]);
//shortestPath([5, 1, 1, 1, 5, 4]);