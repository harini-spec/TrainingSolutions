function calculateAge() {
    var dob = document.getElementById("dob").value;
    var today = new Date();
    var birthDate = new Date(dob);
    var age = today.getFullYear() - birthDate.getFullYear();
    var m = today.getMonth() - birthDate.getMonth();
    if (m < 0 || (m === 0 && today.getDate() < birthDate.getDate())) {
        age--;
    }
    document.getElementById("age").value = age;
}

var predefined_options = ["Doctor", "Engineer", "Teacher", "Lawyer", "Student", "Enterpreneur"];

function loadDataList(){
    var professions = document.getElementById("professions");
    var input_profession = document.getElementById("profession");
    input_profession.setAttribute("list", "datalist-professions");
    
    if(document.getElementById("datalist-professions") != null){
        professions.removeChild(document.getElementById("datalist-professions"));
    }
    
    datalist = document.createElement("datalist");
    datalist.id = "datalist-professions";

    for(var i=0; i<predefined_options.length; i++){
        var option = document.createElement("option");
        option.value = predefined_options[i];
        datalist.appendChild(option);
    }

    professions.appendChild(datalist);
}

function checkDatalistandAdd(){
    var profession = document.getElementById("profession").value;

    for(var i=0; i<predefined_options.length; i++){
        if(predefined_options[i] === profession){
            console.log("Profession already exists");
            return;
        }
    }
    
    predefined_options.push(profession);   
}

function validateName(){
    var name = document.getElementById("name");
    var name_error = document.getElementById("name_error");
    if(!name.value)
    {
        name_error.innerHTML = "Name is required!";
        name.classList.add("error");
        name.classList.remove("success");
    }
    else if(name.value.length < 3){
        name_error.innerHTML = "Name should be atleast 3 characters long!";
        name.classList.add("error");
        name.classList.remove("success");
    }
    else{
        name_error.innerHTML = "";
        name.classList.remove("error");
        name.classList.add("success");
    }
}

function validatePhone(){
    var phone = document.getElementById("phone");
    var phone_error = document.getElementById("phone_error");
    var phone_regex = /^\d{10}$/; //starts with /^, ends with $/, \d is for digit, {10} is for 10 digits
    if(!phone.value)
    {
        phone_error.innerHTML = "Phone Number is required!";
        phone.classList.add("error");
        phone.classList.remove("success");
    }
    else if(!phone_regex.test(phone.value)){
        phone_error.innerHTML = "Phone number should be 10 digits long and should only be digits!";
        phone.classList.add("error");
        phone.classList.remove("success");
    }
    else{
        phone_error.innerHTML = "";
        phone.classList.remove("error");
        phone.classList.add("success");
    }
}

function validateEmail(){
    var email = document.getElementById("email");
    var email_error = document.getElementById("email_error");
    var email_regex = /^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$/; //starts with /^, ends with $/, \w is for word character, + is for one or more, ? is for optional, \. is for dot
    if(!email.value)
    {
        email_error.innerHTML = "Email is required!";
        email.classList.add("error");
        email.classList.remove("success");
    }
    else if(!email_regex.test(email.value)){
        email_error.innerHTML = "Email should be of the correct format";
        email.classList.add("error");
        email.classList.remove("success");
    }
    else{
        email_error.innerHTML = "";
        email.classList.remove("error");
        email.classList.add("success");
    }
}

function validateDOB() {
    var dob = document.getElementById("dob");
    var dob_error = document.getElementById("dob_error");

    if(!dob.value)
    {
        dob_error.innerHTML = "Date of Birth is required!";
        dob.classList.add("error");
        dob.classList.remove("success");
    }
    else if(dob.value > new Date().toISOString().split('T')[0]){
        // console.log(new Date().toISOString().split('T')[0]); // ISO format -- 2024-06-17T10:05:12.216Z -- so split by T and take the first part
        dob_error.innerHTML = "Date of Birth cannot be in the future!";
        dob.classList.add("error");
        dob.classList.remove("success");
    }
    else if((new Date().getFullYear() - parseInt(dob.value.split('-')[0],10)) < 18){
        dob_error.innerHTML = "Should be atleast 18 years old!";
        dob.classList.add("error");
        dob.classList.remove("success");
    }
    else{
        dob_error.innerHTML = "";
        dob.classList.remove("error");
        dob.classList.add("success");
        calculateAge();
    }
}

function validateProfession(){
    var profession = document.getElementById("profession");
    var profession_error = document.getElementById("profession_error");
    if(!profession.value)
    {
        profession_error.innerHTML = "Profession is required!";
        profession.classList.add("error");
        profession.classList.remove("success");
    }
    else{
        profession_error.innerHTML = "";
        profession.classList.remove("error");
        profession.classList.add("success");
    }
}

function validateGender(){
    var male = document.getElementById("male");
    var female = document.getElementById("female");
    var gender_error = document.getElementById("gender_error");
    if(!(male.checked || female.checked)){
        gender_error.innerHTML = "Please select your gender!";
    }
    else{
        gender_error.innerHTML = "";
    }
}

function validateQualification(){
    var diploma = document.getElementById("diploma");
    var masters = document.getElementById("masters");
    var bachelors = document.getElementById("bachelors");
    var qualification_error = document.getElementById("qualification_error");
    if(!(diploma.checked || masters.checked || bachelors.checked))
    {
        qualification_error.innerHTML = "Qualification is required!";
    }
    else{
        qualification_error.innerHTML = "";
    }
}

function validateForm(){
    validateName();
    validatePhone();
    validateEmail();
    validateDOB();
    validateProfession();
    validateQualification();
    validateGender();
    checkDatalistandAdd();
}