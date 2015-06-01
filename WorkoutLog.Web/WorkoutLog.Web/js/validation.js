
function validateWorkOutProperties() {
    var isValid = true;
    $('#errorList ul').html('');

    $('.validate-number').each(function () {
        var val = $(this).val();
        if (!isPositiveNumber(val) || isTextBoxEmpty(val)) {
            $(this).parents('.form-group').addClass('has-error');
            $('#errorList ul').append('<li>' + $(this).data('error-text') + '</li>');
            isValid = false;
        } else {
            $(this).parents('.form-group').removeClass('has-error');
        }
    });

    if (!isValid)
        $('#errorList').slideDown('fast');
    else
        $('#errorList').slideUp('fast');

    return isValid;
}

/*Validate Login and registration page*/
function validatePerson() {
    var isValid = true;
    $('#registrationErrorList ul').html('');

    if (!isValidUsername($('#usernameTextBox').val())) {
        $('#usernameTextBox').parents('.form-group').addClass('has-error');
        $('#registrationErrorList ul').append('<li>' + $('#usernameTextBox').data('error-text') + '</li>');
        isValid = false;
    }else {
        $('#usernameTextBox').parents('.form-group').removeClass('has-error');
    }

    if (!isValidEmail($('#emailTextBox').val())) {
        $('#emailTextBox').parents('.form-group').addClass('has-error');
        $('#registrationErrorList ul').append('<li>' + $('#emailTextBox').data('error-text') + '</li>');
        isValid = false;
    } else {
        $('#emailTextBox').parents('.form-group').removeClass('has-error');
    }

    if (!isPasswordMatch($('#passwordTextBox').val())) {
        $('#passwordTextBox').parents('.form-group').addClass('has-error');
        $('#registrationErrorList ul').append('<li>' + $('#passwordTextBox').data('error-text') + '</li>');
        isValid = false;
    } else {
        $('#passwordTextBox').parents('.form-group').removeClass('has-error');
        $('#confirmPasswordTextBox').parents('.form-group').removeClass('has-error');
    }

    if (!isValid)
        $('#registrationErrorList').slideDown('fast');
    else
        $('#registrationErrorList').slideUp('fast');

    return isValid;
}

/*Return true if number is greater than 0, false otherwise*/
function isPositiveNumber(inputNumber) {
    if (inputNumber > 0) {
        return true;
    }
    else {
        return false;
    }
}

/*Return true is textbox is empty, false otherwise*/
function isTextBoxEmpty(txtBoxInput) {
    if (txtBoxInput == null || txtBoxInput == "") {
        return true;
    }
    else {
        return false;
    }
}

function isValidUsername(username) {

    if (isTextBoxEmpty(username)) {       
        return false;
    }
    else if (username.length < 4) {
        return false;
    }
    else {
        return true;
    }
}

function isPasswordMatch(password) {
    var isPasswordMatch = false;
 
    var reTypedPassword = $('#confirmPasswordTextBox').val();

    if (isTextBoxEmpty(password)) {      
        return false;
    }
    if (password === reTypedPassword) {
        isPasswordMatch = true;
        return true;
    }
    else if (!isPasswordMatch) {
        $('#confirmPasswordTextBox').parents('.form-group').addClass('has-error');
        $('#registrationErrorList ul').append('<li>' + $('#confirmPasswordTextBox').data('error-text') + '</li>');
        return false;
    }

    return false;
}

function isValidEmail(emailValue) {

    if (isTextBoxEmpty(emailValue)) {
        return false;
    }
    else if (validateEmail(emailValue)) {
        return true;
    }
    else {
        return false;
    }
}


function validateEmail(email) {
    var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(email);
}
/*END REGISTRATION VALIDATION*/











