function increment(selector) {
    let container = $(selector);
    let fragment = document.createDocumentFragment();
    let textarea = $('<textarea>');
    let incrementBtn = $('<button></button>');
    let addBtn = $('<button></button>');
    let ul = $('<ul></ul>');

    textarea.addClass('counter');
    textarea.val(0);
    textarea.attr('disabled', 'disabled');

    incrementBtn.addClass('btn');
    incrementBtn.text('Increment');
    incrementBtn.attr('id', 'incrementBtn');

    addBtn.addClass('btn');
    addBtn.attr('id', 'addBtn');
    addBtn.text('Add');

    ul.addClass('results');

    incrementBtn.click(function () {
        let number = Number(textarea.val());
        textarea.val(++number);
    });

    addBtn.click(function () {
        let li  = $('<li></li>');
        li.text($('.counter').val());
        ul.append(li);
    });

    textarea.appendTo(fragment);
    incrementBtn.appendTo(fragment);
    addBtn.appendTo(fragment);
    ul.appendTo(fragment);

    container.append(fragment);
}