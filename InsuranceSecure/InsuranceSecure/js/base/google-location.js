var google_maps = function () {
    var geocoder; //To use later
    var map; //Your map

    function codeAddress() {
        google.maps.event.addDomListener(window, 'load', function () {
            geocoder = new google.maps.Geocoder();
            var mapProp = {
                center: new google.maps.LatLng(51.508742, -0.120850),
                zoom: 15,
                mapTypeId: google.maps.MapTypeId.ROADMAP
            };
            map = new google.maps.Map(document.getElementById("googleMap"), mapProp);

            $("#agents-view li").each(function () {
                var adress = $(this).attr("data-address");
                geocoder.geocode({ 'address': adress }, function (results, status) {
                    if (status == google.maps.GeocoderStatus.OK) {
                        //Got result, center the map and put it out there
                        map.setCenter(results[0].geometry.location);
                        var marker = new google.maps.Marker({
                            map: map,
                            position: results[0].geometry.location
                        });
                    } else {
                        alert("Geocode was not successful for the following reason: " + status);
                    }
                });
            });
        });
    }

    return {
        "codeAddress": codeAddress
    };
}();

$(window).on("asyncDOMReady", function (event, withinElement) {

    if ($("#agents-view").length > 0)
    {
        google_maps.codeAddress()
    }
});