var insurance_appy = function () {
    var agentName = "Rajeev Sri";
    return {
        "updateAgentName": function (name) {
            agentName = name;
        },
        "agentName": function () {
            return agentName;
        }

    }
}();

$(window).on("asyncDOMReady", function (event, withinElement) {
    $("#agents-view a", withinElement).click(function () {
        var li = $(this).parent();
        var agentId = li.data("agent-id");
        var agentName = $(this).find(".agent-name").text();
        var agentEmail = $(this).find("input[name='email']").val();
        insurance_appy.updateAgentName(agentName);
        var url = li.data("url") + "?AgentName=" + agentName + "&AgentEmail=" + agentEmail;
        $.ajax({
            url: url,
            data: { name: "User" },
            success: function (data) {
                $("#appointment-popup .agent-name").text(agentName);
                $("#appointment-popup").addClass("visible");
            },
            error: function () {
                console.error("Problems in storing session object");
            }
        });
    });

    $("#appointment-popup .cancel-button", withinElement).click(function () {
        $("#appointment-popup").removeClass("visible");
    });

    $("#appointment-popup .select-button", withinElement).click(function () {
        var isConfirmed = $("#appointment-popup .confirmation input[type='checkbox']").is(':checked');
        if (!isConfirmed) {
            $("#appointment-popup .confirm").addClass("active");
            return;
        }
        $("#appointment-popup").removeClass("visible");
        $("#loading").addClass("visible");
        var url = $(this).data("url");
        var name = $("#user-details input[name='user-name']").val();
        var email = $("#user-details input[name='email']").val();
        var contact = $("#user-details input[name='contact']").val();
        var contactDateTime = $("#appointment-date").val() + " " + $("#timeslots button.selected").text() + ":00";
        var agentName = insurance_appy.agentName();
        $.ajax({
            url: url,
            data: {user: name, email: email, contact: contact, dateTime: contactDateTime},
            success: function (data) {
                $("#loading").removeClass("visible");
                var url = "http://" + window.location.host + "/home/AppointmentConfirmation?agentName="+agentName+"&date=" + contactDateTime;
                //window.location.href = "http://www.stackoverflow.com";
                window.location.href = url;
            },
            error: function (xhr, error) {
                $("#loading").removeClass("visible");
                console.error("Some problem making an appointment");
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