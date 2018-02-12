function calendar([day, month, year]) {
    let html = '<table>\n  <tr><th>Sun</th><th>Mon</th><th>Tue</th><th>Wed</th><th>Thu</th><th>Fri</th><th>Sat</th></tr>\n';
    let currentDate = new Date(year, month - 1, 1);
    let lastDayOfPrevMonth = new Date(year, month - 1, 0).getDate();

    if(currentDate.getDay() !== 0) {
        currentDate = new Date(year, month - 2, lastDayOfPrevMonth - currentDate.getDay() + 1);
    }

    while (currentDate.getMonth() != month || currentDate.getDay() != 0) {
        if(currentDate.getDay() == 0) {
            html += '<tr>';
        }

        if(currentDate.getMonth() == month - 2) {
            html += `<td class="prev-month">${currentDate.getDate()}</td>`;
        }
        else if (currentDate.getMonth() == month) {
            html += `<td class="next-month">${currentDate.getDate()}</td>`;
        }
        else if (currentDate.getDate() == day) {
            html += `<td class="today">${currentDate.getDate()}</td>`;
        }
        else {
            html += `<td>${currentDate.getDate()}</td>`;
        }

        if(currentDate.getDay() == 6) {
            html += '</tr>';
        }

        currentDate.setDate(currentDate.getDate() + 1);
    }

    html += '</table>';
    return html;
}

//console.log(calendar(['24', '7', '2012']));