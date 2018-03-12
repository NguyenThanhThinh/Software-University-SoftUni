function attachEventsListeners() {
    let daysButton = document.getElementById('daysBtn');
    let hoursButton = document.getElementById('hoursBtn');
    let minutesButton = document.getElementById('minutesBtn');
    let secondsButton = document.getElementById('secondsBtn');

    daysButton.addEventListener('click', dayCalculateTime);
    hoursButton.addEventListener('click', hoursCalculateTime);
    minutesButton.addEventListener('click', minutesCalculateTime);
    secondsButton.addEventListener('click', secondsCalculateTime);


    let daysValue = document.getElementById('days');
    let hoursValue = document.getElementById('hours');
    let minutesValue = document.getElementById('minutes');
    let secondsValue = document.getElementById('seconds');

    function dayCalculateTime() {
        let days = Number(daysValue.value);

        if (days === 0 || days <= 0 || days == NaN) {
            return;
        }

        hoursValue.value = days * 24;
        minutesValue.value = days * 1440;
        secondsValue.value = days * 86400;
    }

    function hoursCalculateTime() {
        let hours = Number(hoursValue.value);

        if (days === 0 || days <= 0 || days == NaN) {
            return;
        }

        daysValue.value = hours / 24;
        minutesValue.value = hours * 60;
        secondsValue.value = hours * 3600;
    }

    function minutesCalculateTime() {
        let minutes = Number(minutesValue.value);

        if (days === 0 || days <= 0 || days == NaN) {
            return;
        }

        daysValue.value = minutes / 60 / 24;
        hoursValue.value = minutes / 60;
        secondsValue.value = minutes * 60;
    }

    function secondsCalculateTime() {
        let seconds = Number(secondsValue.value);

        if (days === 0 || days <= 0 || days == NaN) {
            return;
        }

        daysValue.value = seconds / 86400;
        hoursValue.value = seconds / 3600;
        minutesValue.value = seconds / 60;
    }
}