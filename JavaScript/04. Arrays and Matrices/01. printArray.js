function printArray(arr) {
    let delimeter = arr.pop();

    console.log(arr.join(delimeter));
}

//printArray(['One','Two','Three','Four','Five', '-']);