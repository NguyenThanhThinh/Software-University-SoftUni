function result() {
    let types = new Map();

    for (let arg of arguments) {
        let currentType = typeof(arg);
        if(types.has(currentType)) {
            types.get(currentType).push(arg);
        } else {
            types.set(currentType, []);
            types.get(currentType).push(arg);
        }

        console.log(`${currentType}: ${arg}`);
    }

    let sortedTypes = new Map(
        Array
            .from(types)
            .sort((a, b) => {
                return b[1].length - a[1].length;
            })
    );

    for (let [key, value] of sortedTypes) {
        console.log(`${key} = ${value.length}`);
    }
}

//result('cat', 42, function () { console.log('Hello world!'); }, 55, 'sd', 33);
//result(42, 'cat', 15, 'kitten', 'tomcat');