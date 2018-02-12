function oddNumbers(n) {
    let arr = new Array();

    for(let i = 1; i <= n; i++){
        if(i % 2 != 0){
            arr.push(i);
        }
    }

    console.log(arr);
}

//oddNumbers(5);