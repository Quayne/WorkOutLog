$(document).ready(function () {
    
    spaceTableButton();
    $('.btn-submit-user').click(function () {
        return validatePerson();
    });

    $('.btn-save-workout').click(function () {        
        return validateWorkOutProperties();
    });
});

function spaceTableButton() {
    $("td button").addClass("button-spacing");
}