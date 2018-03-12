function createBook(selector, title, author, isbn) {
    let bookGenerator = (function () {
        let id = 1;
        
        return function (selector, title, author, isbn) {
            let container = $(selector);
            let divBook = $('<div>');
            divBook.attr('id', `book${id}`);
            divBook.css('border', 'none');
            divBook.append($(`<p class="title">${title}</p>`));
            divBook.append($(`<p class="author">${author}</p>`));
            divBook.append($(`<p class="isbn">${isbn}</p>`));
            divBook.append($('<button>Select</button>'));
            divBook.append($('<button>Deselect</button>'));

            container.append(divBook);

            $('button:contains("Select")').click(function () {
                let div = $(this).parent();
                div.css('border', '2px solid blue');
            });

            $('button:contains("Deselect")').click(function () {
                let div = $(this).parent();
                div.css('border', 'none');
            });

            id++;
        }
    }());

    bookGenerator(selector, title, author, isbn);
}