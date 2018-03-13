function extendObject() {

    let myObj = {
        extend: function (template) {
            for (let prop in template) {
                if (template.hasOwnProperty(prop)) {
                    if(typeof template[prop] === "function") {
                        myObj.__proto__[prop] = template[prop];
                    } else {
                        myObj[prop] = template[prop];
                    }
                }
            }
        }
    };

    return myObj;
}

let template = {
    extensionMethod: function some() {},
    extensionProperty: 'someString'
};

let obj = extendObject();
obj.extend(template);
console.log(obj);