function printElements(arr) {
    let step = Number(arr.pop());

    for (let i = 0; i < arr.length; i += step) {
        console.log(arr[i]);
    }
}

//printElements(['5','20','31','4','20', '2']);