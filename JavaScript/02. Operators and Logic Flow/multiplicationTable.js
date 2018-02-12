function multiplicationTable(n) {
    let result = '<table border="1">\n';

    for (let i = 0; i <= n; i++) {
        result += '<tr>';

        for (let p = 0; p <= n; p++) {
            if (i == 0) {
                if (p == 0) {
                    result += `<th>x</th>`;
                }
                else {
                    result += `<th>${p}</th>`;
                }
            }
            else {
                if (p == 0) {
                    result += `<th>${i}</th>`;
                }
                else {
                    result += `<td>${i * p}</td>`;
                }
            }
        }

        result += '</tr>\n';
    }

    result += '</table>';
    console.log(result);
}

//multiplicationTable(5);