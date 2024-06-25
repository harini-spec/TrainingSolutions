const setTicketDetailsInPage = () => {
    var token = sessionStorage.getItem('token');
    var scheduleId = sessionStorage.getItem('scheduleId');
    var selectedSeats = sessionStorage.getItem('selectedSeats');

    fetch('http://localhost:5251/api/Schedule/GetAllSchedules', {
        method: 'GET',
        headers: {
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + token
        }
        })
        .then(res => res.json())
        .then(data => {
            var schedule = data.find(d => d.scheduleId == scheduleId);
            displayTicketDetails(schedule);
        })
        .catch(error => {
            console.error(error);
        });
}

const displayTicketDetails = async(element) => {
    document.querySelector('.Schedule-Details').id = element.scheduleId;
    document.getElementById('busNumber').innerHTML += element.busNumber;
    var seats = await getSeatsFromSeatIds();
    document.getElementById('seats').innerHTML += seats.map(seat => seat.seatNumber).join(', ');
    document.getElementById('ticketSource').innerHTML = element.source;
    document.getElementById('ticketDest').innerHTML = element.destination;
    document.getElementById('departure').innerHTML += element.dateTimeOfDeparture.split('T')[0] + ', ' + element.dateTimeOfDeparture.split('T')[1];
    document.getElementById('arrival').innerHTML += element.dateTimeOfArrival.split('T')[0] + ', ' + element.dateTimeOfArrival.split('T')[1];
    getPassengerDetails(seats);
}

const getSeatsFromSeatIds = () => {
    var token = sessionStorage.getItem('token');
    var selectedSeats = sessionStorage.getItem('selectedSeats');
    var seatIds = selectedSeats.split(',').map(seat => seat.split("\"")[1]);

    // Create an array of fetch promises
    var fetchPromises = seatIds.map(seatId => 
        fetch('http://localhost:5251/GetSeatsBySeatId?SeatId=' + seatId, {
            method: 'GET',
            headers: {
                'Content-Type': 'application/json',
                'Authorization': 'Bearer ' + token
            }
        }).then(res => res.json())
    );

    // Return a promise that resolves when all fetch calls are complete
    return Promise.all(fetchPromises)
        .then(results => {
            return results; // Array of seat data
        })
        .catch(error => {
            console.error('Error fetching seats:', error);
            throw error;
        });
}

const getPassengerDetails = (selectedSeats) => {
    var form_data = "";
    selectedSeats.forEach(seat => {
        form_data += '<div class="row passenger-form-row" id=' + seat.seatNumber+ '><div class="col">' +
                    '<p class="seat" id=' + seat.id + '> Seat: <b>' + seat.seatNumber + '</b> </p>' +
                    '</div>' +
                    '<div class="col">' +
                        '<label for="name"> Name* </label>' +
                        '<input type="text" onblur="validateName(\'' + seat.seatNumber + '\')" class="form-control" id="name" name="name" required>' +
                        '<p class="error_msg"></p>' +
                    '</div>' +
                    '<div class="col age-container">' +
                        '<label for="age"> Age* </label>' +
                        '<input type="number" onblur="validateAge(\'' + seat.seatNumber + '\')" class="form-control" id="age" name="age" required>' +
                        '<p class="error_msg"></p>' +
                    '</div>' +
                    '<div class="col gender">' +
                        '<label for="gender"> Gender* </label>' +
                        '<div class="gender-input">' +
                        '<div id="Male" onclick="selectMale(\'' + seat.seatNumber + '\')"><i class="fa-solid fa-person"></i>Male</div>' +
                        '<div id="Female" onclick="selectFemale(\'' + seat.seatNumber + '\')"><i class="fa-solid fa-person-dress"></i>Female</div>' +
                        '</div>' +       
                        '<p class="error_msg"></p>' +
                    '</div>' +
                    '<div class="col">' +
                        '<label for="phone"> Phone </label>' +
                        '<input type="text" onblur="validatePhone(\'' + seat.seatNumber + '\')" class="form-control" id="phone" name="phone" required>' +
                        '<p class="error_msg"></p>' +                    
                    '</div>' +
                    '</div>';
    });
    document.querySelector('.passenger-form-container').innerHTML = form_data + '<div class="continue-button"> <button class="btn btn-primary" onclick="validationPassengerForm()">Continue</button> </div>';
}

const validatePhone = (seatNumber) => {
    var seat = document.getElementById(seatNumber);
    var phone = seat.querySelector('#phone');
    var phone_regex = /^\d{10}$/;

    if((phone.value.length < 10 || phone.value.length > 10) && phone.value.length != "") {
        phone.classList.remove('success');
        phone.classList.add('error');
        phone.nextElementSibling.innerHTML = "Enter a Valid Phone Number";
        return false;
    } else {
        if((phone.value.length==10 && phone_regex.test(phone.value)) || phone.value.length == 0){
            phone.nextElementSibling.innerHTML = "";
            phone.classList.remove('error');
            phone.classList.add('success');
            return true;
        }
        else{
            phone.nextElementSibling.innerHTML = "Phone number should only be digits!";
            phone.classList.add("error");
            phone.classList.remove("success");
            return false;
        }
    }
}

const validateName = (seatNumber) => {
    var seat = document.getElementById(seatNumber);
    var name = seat.querySelector('#name');
    if(name.value == "" || name.value.length < 3) {
        name.classList.remove('success');
        name.classList.add('error');
        name.nextElementSibling.innerHTML = "Enter a valid name";
        return false;
    } else {
        name.nextElementSibling.innerHTML = "";
        name.classList.remove('error');
        name.classList.add('success');
        return true;
    }
}

const validateAge = (seatNumber) => {
    var seat = document.getElementById(seatNumber);
    var age = seat.querySelector('#age');
    if(age.value == "" || age.value < 0 || age.value > 130) {
        age.classList.remove('success');
        age.classList.add('error');
        age.nextElementSibling.innerHTML = "Enter a valid age";
        return false;
    } else {
        age.nextElementSibling.innerHTML = "";
        age.classList.remove('error');
        age.classList.add('success');
        return true;
    }
}

const validateGender = (seatNumber) => {
    var seat = document.getElementById(seatNumber);
    var male = seat.querySelector('#Male');
    var female = seat.querySelector('#Female');
    if(male.classList.contains('selected') || female.classList.contains('selected')) {
        seat.querySelector(".gender").querySelector(".error_msg").innerHTML = "";
        seat.querySelector(".gender-input").classList.remove('error');
        return true;
    }
    else{
        seat.querySelector(".gender").querySelector(".error_msg").innerHTML = "Gender is required";
        seat.querySelector(".gender-input").classList.add('error');
        return false;
    }
} 

const selectFemale = (seatNumber) => {
    var seat = document.getElementById(seatNumber);
    if(seat.querySelector('#Male').classList.contains('selected')) {
        seat.querySelector('#Male').classList.remove('selected');
        seat.querySelector("#Female").classList.add('selected');
    }
    else if(seat.querySelector('#Female').classList.contains('selected')) {
        seat.querySelector('#Female').classList.remove('selected');
    }
    else
        seat.querySelector("#Female").classList.add('selected');
    validateGender(seatNumber);
}

const selectMale = (seatNumber) => {
    var seat = document.getElementById(seatNumber);
    if(seat.querySelector('#Female').classList.contains('selected')) {
        seat.querySelector('#Female').classList.remove('selected');
        seat.querySelector("#Male").classList.add('selected');
    }
    else if(seat.querySelector('#Male').classList.contains('selected')) {
        seat.querySelector('#Male').classList.remove('selected');
    }
    else
        seat.querySelector("#Male").classList.add('selected');
    validateGender(seatNumber);
}

const validationPassengerForm = () => {
    document.querySelectorAll('.passenger-form-row').forEach(row => {
        var name_res = validateName(row.id);
        var age_res = validateAge(row.id);
        var gender_res = validateGender(row.id);
        var phone_res = validatePhone(row.id);
        if(!(name_res && age_res && gender_res && phone_res)) {
            return;
        }
    });
    addTicket();
}

const addTicket = () => {
    var selectedSeats = sessionStorage.getItem('selectedSeats');
    var seats = selectedSeats.split(',').map(seat => seat.split("\"")[1]);
    var passengers = [];
    document.querySelectorAll('.passenger-form-row').forEach(row => {
        var seatNumber = row.id;
        var name = row.querySelector('#name').value;
        var age = row.querySelector('#age').value;
        var gender = row.querySelector('.gender-input').querySelector('.selected').id;
        var phone = row.querySelector('#phone').value; 
        var res = 
            JSON.stringify({
            seatId : parseInt(row.querySelector(".seat").id),
            passengerName : name,
            passengerGender: gender,
            passengerAge : parseInt(age),
            PassengerPhone : phone
        });
        passengers.push(JSON.parse(res));
    });
    // console.log(passengers);
    addTicketToDb(passengers);
}

const addTicketToDb = (passengers) => {
    var token = sessionStorage.getItem('token');
    var scheduleId = sessionStorage.getItem('scheduleId');
    var ticket_body = JSON.stringify({
        scheduleId: parseInt(scheduleId),
        ticketDetails: passengers
    });
    // console.log(ticket_body);
    fetch('http://localhost:5251/api/Ticket/AddTicket', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json',
            'Authorization': 'Bearer ' + token
        },
        body: ticket_body})
        .then(res => res.json())
        .then(data => {
            displayCostDetails(data);
            console.log(data);
            // return data;
        })
        .catch(error => {
            console.error(error);
    });
}

const displayCostDetails = (ticket) => {
    document.querySelector('.Cost-Details').innerHTML = "hello";
}