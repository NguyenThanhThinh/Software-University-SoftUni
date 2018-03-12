function rotate(arr) {
    let cycles = Number(arr.pop());
    cycles %= arr.length;

    for (let i = 0; i < cycles; i++) {
        let holdLastElement = arr.pop();
        arr.unshift(holdLastElement);
    }

    console.log(arr.join(' '));
}

//rotate(['1','2','3','4','2']);