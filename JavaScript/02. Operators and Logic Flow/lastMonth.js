function lastMonth([day, month, year]) {
    month--;
    day = 0;

    let date = new Date(year, month, day);
    console.log(date.getDate());
}

//lastMonth([13, 3, 2002]);