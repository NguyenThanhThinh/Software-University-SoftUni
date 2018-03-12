function extractText() {
    let text = $('#items').find('li').toArray().map(li => li.textContent).join(', ');
    $('#result').text(text);
}