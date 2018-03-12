function initializeTable() {
    addCountry('Bulgaria', 'Sofia');
    addCountry('Germany', 'Berlin');
    addCountry('Russia', 'Moscow');

    $('#createLink').click(createEntries);

    function createEntries() {
        let country = $('#newCountryText');
        let capital = $('#newCapitalText');
        addCountry(country.val(), capital.val());
        country.val('');
        capital.val('');
    }

    function addCountry(country, capital) {
        let table = $('#countriesTable');

        let row = $('<tr>')
            .append($('<td>').text(country))
            .append($('<td>').text(capital))
            .append($('<td>')
                .append($('<a href="#">[Up] </a>').click(moveRowUp))
                .append($('<a href="#">[Down] </a>').click(moveRowDown))
                .append($('<a href="#">[Delete]</a>').click(deleteRow)))

        row.css('display', 'none');
        table.append(row);
        row.fadeIn();
        addjustLinks();
    }
    
    function addjustLinks() {
        $('#countriesTable tr td a').css('display', 'inline');

        $('#countriesTable tr:nth-child(3) td:last a:first').css('display', 'none');
        $('#countriesTable tr:last td:last a:nth-child(2)').css('display', 'none');
    }

    function moveRowUp() {
        let currentRow = $(this).parent().parent();
        currentRow.fadeOut(function () {
            currentRow.insertBefore(currentRow.prev());
            currentRow.fadeIn();
            addjustLinks()
        });
    }

    function moveRowDown() {
        let currentRow = $(this).parent().parent();
        currentRow.fadeOut(function () {
            currentRow.insertAfter(currentRow.next());
            currentRow.fadeIn();
            addjustLinks();
        });
    }

    function deleteRow() {
        let trForDelete = $(this).parent().parent();
        trForDelete.fadeOut(function () {
            trForDelete.remove();
            addjustLinks();
        });
    }
}