function addRemoveElements(commands) {
    let num = 0;
    let result = [];

    for (let command of commands) {
        num++;
        if(command != 'remove') {
            result.push(num);
        }
        else {
            result.pop();
        }
    }

    console.log(result.length > 0 ? result.join('\n') : 'Empty');
}

//addRemoveElements(['add', 'add', 'add', 'add']);
//addRemoveElements(['add', 'add', 'remove', 'add', 'add']);
