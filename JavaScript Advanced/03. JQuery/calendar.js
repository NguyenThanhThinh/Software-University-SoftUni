function calendar() {
    let year = arguments[0][2];
    let monthNum = arguments[0][1] - 1;
    let day = arguments[0][0];
    let date = new Date(year, monthNum);
    let month = date.toLocaleString("en-us", {month: "long"});
    let daysOfWeek = ['Mon', 'Tue', 'Wed', 'Thu', 'Fri', 'Sat', 'Sun'];
    let container = $('#content');

    //extension for getting days in month
    Date.prototype.monthDays= function(){
        let d = new Date(this.getFullYear(), this.getMonth()+1, 0);
        return d.getDate();
    };

    let table = $('<table>')
        .append($('<caption>').text(`${month} ${date.getFullYear()}`))
        .append($('<tbody>'))
        .append($('<tr>'));

    container.append(table);

    for (let i = 0; i < daysOfWeek.length; i++) {
        $('tbody tr').append($('<th>').text(daysOfWeek[i]));
    }

    let daysCounter = 0;
    let currentWeek = $('<tr>');
    let daysInMont = date.monthDays();

    let startDay = date.getDay() === 0 ? 7 : date.getDay();

    for (let i = 1; i < startDay; i++) {
        currentWeek.append($('<td>'));
        daysCounter++;
    }

    for (let i = 0; i <= daysInMont; i++) {
        if(daysCounter === 7 || i + 1 > daysInMont) {
            $('tbody').append(currentWeek);
            currentWeek = $('<tr>');
            daysCounter = 0;
        }

        if(i + 1 === day) {
            currentWeek.append($('<td class="today">').text(i + 1));
        } else {
            currentWeek.append($('<td>').text(i + 1));
        }

        daysCounter++;
    }

    let lastRow = $('tr:last');
    let emptyDaysLeft = lastRow.find('td').length;

    while(emptyDaysLeft < 7) {
        lastRow.append($('<td>'));
        emptyDaysLeft++;
    }
}