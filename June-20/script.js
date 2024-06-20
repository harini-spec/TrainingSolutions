const LoginCustomer =()=>{
    var email = ["himu@gmail.com", "somu@gmail.com"];
    var pass = ["himuPASS1@", "somuPASS1@"];
    var emailInput = document.getElementById('txtEmail').value;
    var passInput = document.getElementById('txtPass').value;
    var loginMsg = document.getElementById('loginMsg');
    var flag = false;
    for(var i=0; i<email.length; i++){
        if(emailInput == email[i] && passInput == pass[i]){
            flag = true;
            break;
        }
    }
    if(flag){
        loginMsg.innerHTML = "logged in successfully!";
    }
    else{
        loginMsg.innerHTML = "login failed!";
    }
}

document.getElementById('loginBtn').addEventListener('click', LoginCustomer);

