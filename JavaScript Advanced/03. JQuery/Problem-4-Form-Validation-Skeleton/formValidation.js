function validate() {
    let username = $('#username');
    let email = $('#email');
    let password = $('#password');
    let confirmPassword = $('#confirm-password');
    let company = $('#company');
    let companyInfo = $('#companyInfo');
    let companyNumber = $('#companyNumber');
    let isValid = true;

    company.click(function () {
        if (company.is(':checked')) {
            companyInfo.css('display', 'inline')
        }
        else {
            companyInfo.css('display', 'none')
        }
    });

    $('#submit').click(validateInputFields);

    function validateInputFields(ev) {
        ev.preventDefault();
        isValid = true;

        let validDiv = $('#valid');
        let passwordPattern = /^[\w]{5,15}$/;

        validateWithRegex(username, /^[a-zA-Z0-9]{3,20}$/);
        validateWithRegex(email, /.+@.+\..+/);
        validateWithRegex(password, passwordPattern);

        if (password.val() === confirmPassword.val()) {
            validateWithRegex(confirmPassword, passwordPattern);
        } else {
            confirmPassword.css('border', 'solid red');
        }

        if (company.is(':checked')) {
            validateWithRegex(companyNumber, /^\d{4}$/);
        }

        if (isValid) {
            validDiv.css('display', 'block');
        } else {
            validDiv.css('display', 'none')
        }
    }

    function validateWithRegex(input, pattern) {
        if (input.val().match(pattern)) {
            input.css('border', 'none');
        } else {
            input.css('border', 'solid red');
            isValid = false;
        }
    }
}