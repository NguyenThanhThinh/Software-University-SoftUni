function solve(name, age, weight, height) {
    let bmi = weight / Math.pow((height / 100), 2);

    let status = calculateBmiStatus();

    let obj = {
        name: name,
        personalInfo: {
            age: age,
            weight: weight,
            height: height
        },
        BMI: Math.round(bmi),
        status: status
    };

    if(status === 'obese') {
        obj.recommendation = 'admission required';
    }

    function calculateBmiStatus() {
        if(bmi < 18.5) {
            return 'underweight';
        } else if (bmi < 25) {
            return 'normal';
        } else if ( bmi < 30) {
            return 'overweight';
        } else {
            return 'obese';
        }
    }

    return obj;
}

//solve('Peter', 29, 75, 182);
solve('Honey Boo Boo', 9, 57, 137);