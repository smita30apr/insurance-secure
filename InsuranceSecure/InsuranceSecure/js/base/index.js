$(document).ready(function () {  
    if ($("#state").length > 0) {
        populateCountries("country", "state");
        $("#country").val("India");
        populateStates("country", "state");
    }
    $(window).trigger("asyncDOMReady");
});

$(window).on("asyncDOMReady", function (event, withinElement) {
    $("#is-insurance-types select").change(function () {
        var value = $(this).val();
        if (value == "")
            return;
        var url = "http://" + window.location.host + "/home/insurance?type=" + value;
        window.location.href = url;
    })
});