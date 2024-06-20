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
    var buslist_row = document.querySelector(".buslist-row");
    buslist_row.removeAttribute('id');
    buslist_row.setAttribute('id', pgno);

    var buslist_html = '';
    console.log(data);

    const ItemsPerPage = 5;
    var StartIndex = (pgno-1) * ItemsPerPage;

    var sliced_data = data.slice(StartIndex, StartIndex + ItemsPerPage);

    sliced_data.forEach(element => {
        buslist_html += 
        '<div class="card">' +
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