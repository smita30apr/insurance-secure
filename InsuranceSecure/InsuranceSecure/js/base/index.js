$(document).ready(function () {  
    if ($("#state").length > 0) {
        populateCountries("country", "state");
        $("#country").val("India");
        populateStates("country", "state");
    }
    $(window).trigger("asyncDOMReady");
});