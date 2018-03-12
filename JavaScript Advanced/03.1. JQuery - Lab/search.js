function search() {
    let search = $('#searchText').val();
    $('#towns').find('li').css('font-weight', 'normal')
    let towns = $('#towns').find(`li:contains(${search})`).css('font-weight', 'bold');
    $('#result').text(`${towns.length} matches found`);
}