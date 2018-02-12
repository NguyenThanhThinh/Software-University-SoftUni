function assignProperties([name, nameValue, age, ageValue, gender, genderValue]) {
    let obj = {};

    obj[name] = nameValue;
    obj[age] = ageValue;
    obj[gender] = genderValue;

    return obj;
}

//console.log(assignProperties(['name', 'Pesho', 'age', '23', 'gender', 'male']));;