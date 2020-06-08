function loadMapRoads() {
    var myStyle = {
        "color": "rgb(229,72,64)",
        "weight": 4,
        "opacity": 0.05
    };

    $.getJSON("../Data/plane_osm_roads.geojson", function (data) {
        var geojsonRoads = L.geoJson(data, {
            style: myStyle
            //                      onEachFeature: function (feature, layer) {
            //                          layer.bindLabel(feature.properties.name, { noHide: true });
            //                      }

        });
        geojsonRoads.addTo(map);
    });
}


function loadMapOSMPolygon() {

    var myStyle = {
        "color": "rgb(48,139,87)",
        "weight": 2,
        "opacity": 0.65
    };

    $.getJSON("../Data/planet_osm_polygon.geojson", function (data) {
        var geojsonboundry = L.geoJson(data, {
            style: myStyle,
            onEachFeature: function (feature, layer) {
                var popupText = "Name: " + feature.properties.name
                layer.bindPopup(popupText)
            }
        });
        geojsonboundry.addTo(map);
    });
}


var markers = new Array();


function linestyle(feature) {
    return {
        fillColor: 'black',
        weight: 5,
        opacity: 1,
        color: 'rgb(249,249,249)',
        dashArray: 4,
        fillOpacity: 2
    }
}



function Buildings_Assignment(Isassigntoagent) {
    getPolygonColorByAssignment(Isassigntoagent)
    $.getJSON("../uploads/AMA_DISTRICT_BUILDING.geojson", function (data, Isassigntoagent) {
        var geojson = L.geoJson(data, { style: polygonStyle(Isassigntoagent) })
    });
    map.fitBounds(geojson.getBounds());
    geojson.addTo(map);
}


function getPolygonColorByAssignment(Isassigntoagent) {
    if (Isassigntoagent == "yes") {
        return "rgb(34,139,34)";
    }
    else 
    {
        return "rgb(193, 165, 113)";
    }
}

function polygonStyle(Isassigntoagent) {
    var myStyle = {
        "color": getPolygonColorByAssignment(Isassigntoagent),
        "weight": 2,
        "opacity": 0.65
    };
    return myStyle;
}


$('#btnCheckAssignment').click(function () {
    setTimeout(function () {
        $.ajax({
            url: "allocategrid.aspx/loadMapAssigments",
            data: JSON.stringify({ objectid: dobjectid }),
            datatype: "json",
            type: "POST",
            contentType: "application/json; charset=utf-8",
            success: function (result) {
                $("#Att").hideLoading();

                var data = JSON.parse(result.d);
                var DataArray = data.Table;
                for (var i = 0; i < DataArray.length; i++) {
                    Buildings_Assignment(DataArray[i].assigntoagent)
                }
            },
            onerror: function (err) {
                alert(err.toString);
            }
        });
    }, 500);
    return false;
});


function getPolygonAllocation(objectgid) {
    var dbresult;
    $.ajax({
        url: "allocategrid.aspx/loadMapAssigments",
        data: JSON.stringify({ objectid: dobjectid }),
        datatype: "json",
        type: "POST",
        contentType: "application/json; charset=utf-8",
        success: function (result) {
            $("#Att").hideLoading();
            var data = JSON.parse(result.d);
            var DataArray = data.Table;
      
            for (var i = 0; i < DataArray.length; i++) {
                dbresult = DataArray[i].assigntoagent
            }
        },
        onerror: function (err) {
            alert(err.toString);
        }
    });
    return dbresult;
}



$.getJSON("neighborhoods.geojson", function (hoodData) {
    L.geoJson(hoodData, {
        style: function (feature) {
            var fillColor,
          density = feature.properties.density;
            if (density > 80) 
            fillColor = "#006837";
            else if (density > 40)
            fillColor = "#31a354";
            else if (density > 20) 
            fillColor = "#78c679";
            else if (density > 10) 
            fillColor = "#c2e699";
            else if (density > 0) 
            fillColor = "#ffffcc";
            else 
            fillColor = "#f7f7f7";  // no data
            return { color: "#999", weight: 1, fillColor: fillColor, fillOpacity: .6 };
        },
        onEachFeature: function (feature, layer) {
            layer.bindPopup("<strong>" + feature.properties.Name + "</strong><br/>" + feature.properties.density + " rats per square mile")
        }
    }).addTo(map);
});


function AMA_District_Buildings(mapfilepath) {
    $.getJSON(mapfilepath, function (data) {
        geojson = L.geoJson(data, {
            style: function (feature) {
                  var fillColor,
                  density = getPolygonAllocation(feature.properties.OBJECTID);
                  if(density == "yes")
                      fillColor = "rgb(65,141,65)";
                  else if(density == "no")
                  fillColor="rgb(193,165,113)";
                  else
                  fillColor="";
                  return { color:fillColor, weight:2, Opacity: .65 };
            },
            onEachFeature: function (feature, layer) {
                layer.bindPopup("<strong>" + feature.properties.OBJECTID + "</strong><br/>" + feature.properties.GID)
           var objectgid = feature.properties.OBJECTID
            layer.on("click", function () {
                 loadDataInformation(objectgid)
             });
          }
         });
        map.fitBounds(geojson.getBounds());
        geojson.addTo(map);

    });
}


var myStyle = {
    "color": "rgb(193,165,113)",
    "weight": 2,
    "opacity": 0.65
};

function AMA_District_Buildings(mapfilepath) {

    $.getJSON(mapfilepath, function (data) {
        geojson = L.geoJson(data, 
        
         { style: myStyle, onEachFeature: function (feature, layer) {
            var popupText = "gid: " + feature.properties.OBJECTID
            var objectgid = feature.properties.OBJECTID
            layer.bindPopup(popupText)
            layer.on("click", function () {
                loadDataInformation(objectgid)
            });
        }

        });
        map.fitBounds(geojson.getBounds());
        geojson.addTo(map);

    });
}