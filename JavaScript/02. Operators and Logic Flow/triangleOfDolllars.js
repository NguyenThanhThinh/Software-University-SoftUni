function print(n) {
    let result = "";
    for (let i = 1; i <= n; i++) {
        for(let p = 1; p <= i; p++) {
            result += '$';
        }
        result += '\n';
    }
    console.log(result);
}

//print(3);