function attachEvents() {
    $('.button').click(checkButton);

    function checkButton() {
        $('.selected').removeClass('selected');
        $(this).addClass('selected');
    }
}