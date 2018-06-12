// Write your JavaScript code.

var myCenter=new google.maps.LatLng(37.97777, 23.730522);
function initialize()
{
    var mapProp = {
        center:myCenter,
        scrollwheel: false,
        zoom:18,
        mapTypeId:google.maps.MapTypeId.ROADMAP
    };
    var map=new google.maps.Map(document.getElementById("hastech"),mapProp);
    var marker=new google.maps.Marker({
        position:myCenter,
        animation:google.maps.Animation.BOUNCE,
        icon:'/img/map-marker.png',
        map: map,
    });
    var styles = [
        {
            stylers: [
                { hue: "#c5c5c5" },
                { saturation: -100 }
            ]
        },
    ];
    map.setOptions({styles: styles});
    marker.setMap(map);
}
google.maps.event.addDomListener(window, 'load', initialize);