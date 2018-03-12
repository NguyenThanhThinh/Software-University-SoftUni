function domSearch(selector, isCaseSensitive) {
    let container = $(selector);
    let addDiv = $('<div class="add-controls">');

    $('<label for="text">').text('Enter text:').appendTo(addDiv);
    $('<input id="text" type="text">').appendTo(addDiv);
    $('<a class="button" href="#" id="add">').text('Add').appendTo(addDiv);
    addDiv.appendTo(container);

    let searchDiv = $('<div class="search-controls">');
    $('<label for="search">').text('Search:').appendTo(searchDiv);
    $('<input id="search" type="text">').appendTo(searchDiv);
    searchDiv.appendTo(container);

    let resultDiv = $('<div class="result-controls">');
    let list = $('<ul class="items-list">');
    list.appendTo(resultDiv);
    resultDiv.appendTo(container);

    $('#add').on('click', addItem);
    $('#search').on("input", searchItems);

    function addItem() {
        let searchInput = $(this).prev();
        let anchor = $('<a class="button">').text('X');
        anchor.click(deleteItem);

        let li = $('<li class="list-item">')
            .append(anchor)
            .append($('<strong>').text(searchInput.val()));

        li.appendTo(list);
        searchInput.val('');
    }

    function searchItems() {
        let needle = $(this).val();
        let items = $('.list-item strong').toArray();
        for (let item of items) {
            let current = $(item);

            if(isCaseSensitive) {
                if(current.text().indexOf(needle) < 0) {
                    current.parent().css('display', 'none');
                } else {
                    current.parent().css('display', '');
                }
            }  else {
                if(current.text().toLowerCase().indexOf(needle.toLowerCase()) < 0) {
                    current.parent().css('display', 'none');
                } else {
                    current.parent().css('display', '');
                }
            }
        }

        let selectedInputs = $('.list-item').each(e => function () {
            console.dir(e);
            for (let input of e.children) {
                console.dir(input);
                if(input.text !== $(this).val()){
                    e.css('display', 'none')
                } else {
                    e.css('display', 'block')
                }
            }
        });
    }

    function deleteItem() {
        $(this).parent().remove();
    }
}