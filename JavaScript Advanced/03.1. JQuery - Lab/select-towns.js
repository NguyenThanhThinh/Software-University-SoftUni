function attachEvents() {
    $('#items li').click(selectTown);

    function selectTown() {
        let townClicked = $(this);

        if (townClicked.attr('data-selected') == 'true') {
            townClicked.removeAttr('data-selected');
            townClicked.css('background-color', '');
        }
        else {
            townClicked.attr('data-selected', 'true');
            townClicked.css('background-color', '#DDD');
        }
    }

    $('#showTownsButton').click(showTowns);

    function showTowns() {
        let selectedTowns = $('#items li[data-selected=true]').toArray().map(a => a.textContent);
        $('#selectedTowns').text(`Selected towns: ${selectedTowns.join(', ')}`);
    }
}