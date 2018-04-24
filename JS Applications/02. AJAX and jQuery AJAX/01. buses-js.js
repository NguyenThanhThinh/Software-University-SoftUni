function loadBusInfo() {
    let busId = $('#stopId').val();
    let title = $("#stopName");
    let buses = $('#buses');

    let request = {
        method: "GET",
        url: `https://judgetests.firebaseio.com/businfo/${busId}.json`,
        success: populateBuses,
        error: showError
    };
    $.ajax(request);
    
    function populateBuses(bus) {
        buses.empty();
        title.text(bus.name);

        for (let obj in bus.buses) {
            buses.append($(`<li>Bus ${obj} arrives in ${bus.buses[obj]} minutes</li>`));
        }
    }
    
    function showError() {
        buses.empty();
        title.text('Error');
    }
}