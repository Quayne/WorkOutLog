$(document).ready(function () {
    spaceTableButton();

    $('.btn-save-workout').click(function () {        
        return validateWorkOutProperties();
    });
});

function spaceTableButton() {
    $("td button").addClass("button-spacing");
}