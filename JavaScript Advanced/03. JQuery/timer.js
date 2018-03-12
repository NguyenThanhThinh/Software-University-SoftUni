function timer() {
    let sec = $('#seconds');
    let min = $('#minutes');
    let h = $('#hours');

    let seconds = Number(sec.text());
    let minutes = Number(min.text());
    let hours = Number(h.text());

    let startInterval;

    function step() {
        seconds++;
        if(seconds === 60) {
            seconds = 0;
            minutes++;

            if(min === 60) {
                minutes = 0;
                hours++;
            }
        }

        sec.text(`0${seconds}`.slice(-2));
        min.text(`0${minutes}`.slice(-2));
        h.text(`0${hours}`.slice(-2));
    }

    $('#start-timer').click(function () {
        startInterval = setInterval(step, 1000);
    });

    $('#stop-timer').click(stopTImer);

    function stopTImer() {
        clearInterval(startInterval);
    }
}