function toggle() {
    let span = document.getElementsByClassName('button')[0];
    let text = document.getElementById('extra');

    if(span.textContent === 'Less') {
        span.textContent = 'More';
        text.style.display = 'none';
    }
    else {
        span.textContent = 'Less';
        text.style.display = 'block';
    }
}