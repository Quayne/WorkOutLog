
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


function isPositiveNumber(inputNumber) {
    if (inputNumber > 0) {
        return true;
    }
    else {
        return false;
    }
}

function isTextBoxEmpty(txtBoxInput) {
    if (txtBoxInput == null || txtBoxInput == "") {
        return true;
    }
    else {
        return false;
    }
}

/*START REGISTRATION VALIDATION*/
function submitRegistrationEvent() {
    var isAllFieldValid = false;

    if (isValidUsername() && isValidEmail() && isPasswordMatch()) {
        alert("Registration Successful!!");
        return true;
    }
    if (!isValidUsername()) {
        isAllFieldValid = false;
    }
    if (!isValidEmail()) {
        isAllFieldValid = false;
    }
    if (!isPasswordMatch()) {
        isAllFieldValid = false;
    }

    return isAllFieldValid;
}


function isValidUsername() {
    var username = document.getElementById("username").value;

    username = username.trim();

    if (isTextBoxEmpty(username)) {
        document.getElementById("usernameMsg").innerHTML = "The username field must be filled out.";
        return false;
    }
    else if (username.length < 4) {
        document.getElementById("usernameMsg").innerHTML = "Username must be 4 or more characters.";
        return false;
    }
    else {
        return true;
    }
}

function isPasswordMatch() {
    var isPasswordMatch = false;
    var passwordErrMsg;

    var password = document.getElementById("password").value;
    var reTypedPassword = document.getElementById("confirmPassword").value;

    if (isTextBoxEmpty(password)) {
        document.getElementById("passwordMsg").innerHTML = "The password field must be filled out.";
        return isPasswordMatch;
    }
    if (password === reTypedPassword) {
        isPasswordMatch = true;
        return isPasswordMatch;
    }
    else {
        passwordErrMsg = "Passwords does not match";
    }

    if (!isPasswordMatch) {
        document.getElementById("passwordMsg").innerHTML = passwordErrMsg;
        return isPasswordMatch;
    }
}

function isValidEmail() {
    var emailValue = document.getElementById("emailTextBox").value;
    var emailErrMsg;
    var isValidEmail = false;

    emailValue = emailValue.trim();

    if (isTextBoxEmpty(emailValue)) {
        emailErrMsg = "Email is blank. Please fill it in. Example: username@domain.com"
        document.getElementById("emailMsg").innerHTML = emailErrMsg;
        return isValidEmail;
    }
    else if (validateEmail(emailValue)) {
        isValidEmail = true;
        return isValidEmail;
    }
    else {
        emailErrMsg = "Email format error. Example: username@domain.com";
        document.getElementById("emailMsg").innerHTML = emailErrMsg;
        return isValidEmail;
    }
}

function validateEmail(email) {
    var re = /^(([^<>()[\]\\.,;:\s@\"]+(\.[^<>()[\]\\.,;:\s@\"]+)*)|(\".+\"))@((\[[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\.[0-9]{1,3}\])|(([a-zA-Z\-0-9]+\.)+[a-zA-Z]{2,}))$/;
    return re.test(email);
}
/*END REGISTRATION VALIDATION*/











