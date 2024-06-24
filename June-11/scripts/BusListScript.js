const getData = () => {
    var token = sessionStorage.getItem('token');
    return fetch('http://localhost:5251/api/Schedule/GetAllSchedules', {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + token
        }
        })
        .then(res => res.json())
        .then(data => {
            return data;
        })
        .catch(error => {
            console.error(error);
        });
}

const loadBuses = (data, pgno) => {
    document.querySelector('.sort').innerHTML = '<button type="button" class="btn sortAsc" onclick="sortAsc()">Asc Departure</button>' +
    '<button type="button" class="btn sortDesc" onclick="sortDesc()">Desc Departure</button>';
    document.querySelector('.buslist-heading').innerHTML = '<h1> Bus Schedules </h1>';

    var buslist_row = document.querySelector(".buslist-row");
    buslist_row.removeAttribute('id');
    buslist_row.setAttribute('id', pgno);

    var buslist_html = '';

    const ItemsPerPage = 5;
    var StartIndex = (pgno-1) * ItemsPerPage;

    var sliced_data = data.slice(StartIndex, StartIndex + ItemsPerPage);

    sliced_data.forEach(element => {
        buslist_html += 
        '<div class="card" id=' + element.scheduleId + ' >' +
        '<div class="card-body">' +
            '<div class="row">' +
                '<div class="col col1">' + 
                    '<h5 class="card-title">' + element.source + '</h5>' +
                '</div>' +
                '<div class="col col2">' +
                    '<h5 class="card-title"> <i class="fa-solid fa-arrow-right"></i> </h5>' +
                '</div>' +
                '<div class="col col3">' +
                    '<h5 class="card-title">' + element.destination + '</h5>' +
                '</div>' +
            '</div>' +
        
            '<div class="row">' +
                '<div class="col col1">' +
                    '<h5 class="card-title"> Departure: ' + element.dateTimeOfDeparture.split('T')[0] + ', ' + element.dateTimeOfDeparture.split('T')[1] + '</h5>' +
                '</div>' +
                '<div class="col col3">' +
                    '<h5 class="card-title"> Arrival: ' + element.dateTimeOfArrival.split('T')[0] + ', ' + element.dateTimeOfArrival.split('T')[1] + '</h5>' +
                '</div>' +
            '</div>' +
            
            '<div class="row">' +
                '<div class="col col1">' +
                    '<p class="card-body" style="padding: 0;"> Bus Number: ' + element.busNumber + '</p>' +
                '</div>' +
                '<div class="col col3">' +
                    '<a href="#" class="btn btn-primary">Check Seats</a>' +
                '</div>' +
            '</div>' +

        '</div>' + 
        '</div>';
    });
    buslist_row.innerHTML = buslist_html;
}

const getSeatsOfBus = (scheduleId) => {
    '<div class="row">' +
    '<div class = "seats-container">' +
        '<div class = "seat"> 1 </div>' +
        '<div class = "seat"> 2 </div>' +
        '<div class = "seat"> 3 </div>' +
    '</div>' +
    '</div>' 
}

function loadPagination(data){
    var divPagination = document.querySelector('.pagination');
    var paginationData = '<li class="page-item"><p class="page-link"><button class="btn" id="prevBtn">Previous</button></p></li>';
    var ItemsPerPage = 5;
    var totalSchedules = data.length;
    var totalPages = Math.ceil(totalSchedules / ItemsPerPage);

    for(var i = 1; i <= totalPages; i++){
        paginationData += '<li class="page-item"><p class="page-link"><button class="btn pageBtn" data-page="' + i + '">' + i +'</button></p></li>'
    }
    paginationData += '<li class="page-item"><p class="page-link"><button class="btn" id="nextBtn">Next</button></p></li>';
    divPagination.innerHTML = paginationData; // putting this at last will prevent the page from loading the pagination buttons - so event listeners won't work

    divPagination.querySelectorAll('.pageBtn').forEach(button => {
        button.addEventListener('click', function() {
            var page = parseInt(button.getAttribute('data-page'));
            DisplaySchedulesForPg(data, page);
        });
    });

    divPagination.querySelector('#prevBtn').addEventListener('click', function() {
        prev(data);
    });

    divPagination.querySelector('#nextBtn').addEventListener('click', function() {
        next(data);
    });

}

function next(data){
    const ItemsPerPage = 5;
    var totalPages = Math.ceil(data.length / ItemsPerPage);
    var Currentpgno = document.querySelector(".buslist-row").id;

    if(parseInt(Currentpgno) == totalPages){
        return;
    }

    DisplaySchedulesForPg(data, parseInt(Currentpgno) + 1);
}

function prev(data){
    var Currentpgno = document.querySelector(".buslist-row").id;

    if(Currentpgno === '1'){
        DisplaySchedulesForPg(data, Currentpgno);
        return;
    }

    DisplaySchedulesForPg(data, parseInt(Currentpgno) - 1);
}

function DisplaySchedulesForPg(data, pgno){
    loadBuses(data, pgno);
}

function sortAsc(){
    getData().then(data=>{
        data.sort((a, b) => (a.dateTimeOfDeparture > b.dateTimeOfDeparture) ? 1 : -1); // sort by date
        loadPagination(data);
        loadBuses(data, 1);
    });
}

function sortDesc(){
    getData().then(data=>{
        data.sort((a, b) => (a.dateTimeOfDeparture < b.dateTimeOfDeparture) ? 1 : -1); // sort by date
        loadPagination(data);
        loadBuses(data, 1);
    });
}

const getSchedulesOnAGivenDate = (source, destination, date) => {
    var token = sessionStorage.getItem('token');
    return fetch('http://localhost:5251/api/Schedule/BusesScheduledOnGivenDateAndRoute', {
            method: 'POST',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + token
            },
            body: JSON.stringify({
                source: source,
                destination: destination,
                dateTimeOfDeparture: date
            })})
            .then(res => res.json())
            .then(data => {
                return data;
            })
            .catch(error => {
                console.error(error);
            });
}

const findSchedules = () => {
    var source = document.getElementById('source').value;
    var destination = document.getElementById('destination').value;
    var date = document.getElementById('date').value;

    if(checkScheduleFormValidity()){
        getSchedulesOnAGivenDate(source, destination, date).then(data => {
            console.log(data);
            if(data.errorCode && data.errorMessage && data.errorCode == 404){
                console.log('No buses found for the given source, destination and date.');
                document.querySelector('.buslist-heading').innerHTML = '<h1> 404 Not found </h1>'; 
                document.querySelector('.sort').innerHTML = '';
                document.querySelector('.buslist-row').innerHTML = '<p> No buses found for the given source, destination and date. </p> <button class = "btn btn-primary" style = "width: 100px" onclick = "window.location.reload()"> Refresh </button>';
                document.querySelector('.pagination').innerHTML = '';
            }
            else{
                loadPagination(data);
                loadBuses(data, 1);
            }
        });
    }
}

function checkScheduleFormValidity(){
    if(validateSource() && validateDestination() && validateDate()){
        return true;
    }
    else{
        return false;
    }
}

const validateSource = () => {
    var source = document.getElementById('source').value;
    if(source == ""){
        document.getElementById('error-source').innerHTML = 'Please enter source.';
        document.getElementById('source').classList.add('error');
        return false;
    }
    else{
        document.getElementById('error-source').innerHTML = '';
        document.getElementById('source').classList.remove('error');
        return true;
    }
}

const validateDestination = () => {
    var destination = document.getElementById('destination').value;
    if(destination == ""){
        document.getElementById('error-destination').innerHTML = 'Please enter destination.';
        document.getElementById('destination').classList.add('error');
        return false;
    }
    else{
        document.getElementById('error-destination').innerHTML = '';
        document.getElementById('destination').classList.remove('error');
        return true;
    }
}

const validateDate = () => {
    var date = document.getElementById('date').value;
    if(date == ""){
        document.getElementById('error-date').innerHTML = 'Please enter date.';
        document.getElementById('date').classList.add('error');
        return false;
    }
    else if(date < new Date().toISOString().split('T')[0]){
        document.getElementById('error-date').innerHTML = 'Please enter a valid date.';
        document.getElementById('date').classList.add('error');
        return false;
    }
    else{
        document.getElementById('error-date').innerHTML = '';
        document.getElementById('date').classList.remove('error');
        return true;
    }
}
