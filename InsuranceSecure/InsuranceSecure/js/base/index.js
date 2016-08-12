$(document).ready(function () {
    populateCountries("country", "state");
    $("#country").val("India");
    populateStates("country", "state");
    $(window).trigger("asyncDOMReady");
});