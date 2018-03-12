function extract(arr) {
    let result = [arr[0]];

    for (let i = 1; i < arr.length; i++) {

        if(arr[i - 1] <= arr[i]) {
            result.push(arr[i]);
        }
    }

    console.log(result.join('\n'));
}

extract([1, 3, 8, 4, 10, 12, 3, 2, 24]);