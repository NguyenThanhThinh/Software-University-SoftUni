function calculateDistanceBetweenTwoObjects([vOne, vTwo, time]) {
    let hours = time / 60 / 60;
    let distanceOne = vOne * hours * 1000;
    let distanceTwo = vTwo * hours * 1000;
    console.log(Math.abs(distanceOne - distanceTwo));
}

//calculateDistanceBetweenTwoObjects([0, 60, 3600]);