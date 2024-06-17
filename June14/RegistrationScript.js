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

function validateForm(){
    checkDatalistandAdd();
}