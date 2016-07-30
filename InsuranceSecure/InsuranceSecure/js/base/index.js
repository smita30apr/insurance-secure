$(document).ready(function () {
    populateCountries("country", "state");
    $("#country").val("India");
    populateStates("country", "state");
    //$("#is-insurance-types a").click(function () {
    //    var children = $(this).parents("ul").children("li");
    //    children.removeClass("selected");
    //    $(this).parent().addClass("selected");
    //});

    //$("#is-benifits .btn").click(function () {
    //    $("#is-benifits").addClass("invisible");
    //    $("#is-policy-listing").removeClass("invisible");
    //});

    //$("#state").change(function () {
    //    $("#city").removeClass("invisible");
    //    $("#zip").removeClass("invisible");
    //});

    //$("#policy-listing .btn").click(function () {
    //    var parent = $(this).parents("#is-policy-listing");
    //    parent.addClass("invisible");
    //    $("#is-policy-agents").removeClass("invisible");
    //});
});