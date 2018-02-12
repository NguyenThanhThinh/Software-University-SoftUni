function calculateImperialUnits(feet) {
    let inches = Math.floor(feet / 12);
    let remainder = "-0";

    if(inches != feet)
    {
        remainder = `-${feet - (12 * inches)}"`;
    }
    console.log(`${inches}'${remainder}`);
}

//calculateImperialUnits(11);