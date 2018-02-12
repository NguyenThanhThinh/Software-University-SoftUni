function biggestNumber([one, two, three]) {
    if (one > two) {
        return one > three ? one : three;
    }
    else if (one > three) {
        return one > two ? one : two;
    }
    else {
        return two > three ? two : three;
    }
}

//console.log(biggestNumber([5, -2, 7]));