
const latitudeArray = [];
const longitudeArray = [];
const streetArray = [];
const postalCodeArray = [];
const priceArray = [];
const labelArray = [];

function getInfo(domElement, array) {
    for (let i = 0; i < 259; i++) {
        let info = document.getElementsByClassName(domElement).item(i);
        array.push(info.innerHTML)
    }
}
getInfo("data-street", streetArray)
getInfo("data-postalCode", postalCodeArray)
getInfo("data-price", priceArray)
getInfo("data-label", labelArray)


for (let i = 0; i < 259; i++) {
    let latitudes = document.getElementsByClassName("data-latitude").item(i);
    let fixlatitude = parseFloat(latitudes.innerHTML)
    latitudeArray.push(fixlatitude)
}
for (let i = 0; i < 259; i++) {
    let longitude = document.getElementsByClassName("data-longitude").item(i);
    let fixlongitude = parseFloat(longitude.innerHTML)
    longitudeArray.push(fixlongitude)
}





// init the map
const mymap = L.map('myMap').setView([52.55596141, 13.3843708], 12);
const attribution =
    '&copy; <a href="https://www.openstreetmap.org/copyright">OpenStreetMap</a> contributors';

const tileUrl = 'https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png';
const tiles = L.tileLayer(tileUrl, { attribution });
tiles.addTo(mymap);


if ('geolocation' in navigator) {
    navigator.geolocation.getCurrentPosition(function (position) {
        const usersLatitude = position.coords.latitude;
        const usersLongitude = position.coords.longitude;

        const issIcon = L.icon({
            iconUrl: 'street-view-solid.PNG',
            iconSize: [50, 50],
            iconAnchor: [25, 16]
        });

        let user = L.marker([usersLatitude, usersLongitude], { icon: issIcon }).addTo(mymap);

        user.bindPopup("You are here");
        user.openPopup();
        mymap.setView([usersLatitude, usersLongitude], 12)
    });

} else {
    alert("Your Geolocation is not available");
}



function addMarker(latitudes, longitudes, street, postalcode, price, label) {
    for (let i = 0; i < 259; i++) {
        let marker = L.marker([latitudes[i], longitudes[i]]).addTo(mymap);
        const description = `
                                <div class="info-popup">
                                    <p class="street">${street[i]}</p>
                                    <p class="postalcode">${postalcode[i]}</p>
                                    <p class="label">${label[i]}</p>
                                    <p>Price: ${price[i]}</p>
                                </div>
                                `;
        marker.bindPopup(description);
    }
}
addMarker(latitudeArray, longitudeArray, streetArray, postalCodeArray, priceArray, labelArray);

function refresh() {
    location.reload()
}

////let firstTime = true;
////@*@foreach(var item in latitudeList)
//{
//    @foreach(var longi in longititudeList)
//    {
//        @: addMarker(@item, @longi)
//    }

//}*@
//    //var x = "";
//    //var tds = document.querySelectorAll('#table td'), i;
//    //for (i = 0; i < tds.length; ++i) {
//    //    x = x + tds[i].innerHTML;
//    //}
//    //console.log(x)


//    @*var json = @Html.Raw(Json.Serialize(@Model.LocationsBerlin));
//json.map((obj) => {
//    console.log(obj.values())
//})
//alert(json)
//alert(json.values()) *@