
$(window).on("asyncDOMReady", function (event, withinElement) {
    $("#open-appointment", withinElement).click(function () {
        $("#appointment-popup").addClass("visible");
    });

    $("#appointment-popup .cancel-button", withinElement).click(function () {
        $("#appointment-popup").removeClass("visible");
    });

    $("#appointment-popup .select-button", withinElement).click(function () {
        $("#appointment-popup").removeClass("visible");
        var url = $(this).data("url");
        var name = $("#user-details input[name='user-name']").val();
        var email = $("#user-details input[name='email']").val();
        var contact = $("#user-details input[name='contact']").val();
        var contactDateTime = $("#appointment-date").val(); // + " " + $("#timeslots button.selected").text() + ":00";
        $.ajax({
            url: url,
            data: {},
            success: function (data) {
                var x = 10;
                //$(window).trigger("asyncDOMReady", $("#timeslots").parent());
            }
        });

    });

    $("#timeslots button", withinElement).click(function () {
        $("#timeslots button").removeClass("selected");
        $(this).addClass("selected");
    });

    $('#appointment-date', withinElement).change(function () {
        var url = $(this).data("url");
        $.ajax({
            url: url,
            data: { date: this.value },
            success: function (data) {
                $("#timeslots").html(data);
                $(window).trigger("asyncDOMReady", $("#timeslots").parent());
            }
        });
    });
});