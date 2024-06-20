window.onload = function() {
    setProfileName();
};

document.getElementById("logout").addEventListener("click", function(){
    if(!sessionStorage.getItem("email") || !sessionStorage.getItem("token")){
        alert("You are not logged in!");
        return;
    }
    sessionStorage.removeItem("email");
    sessionStorage.removeItem("token");
    location.reload();
    alert("You are successfully logged out!")
});

function setProfileName(){
    var profileName = sessionStorage.getItem("email");
    if(profileName){
        profileName = profileName.split("@")[0];
        document.getElementById("account").innerHTML = profileName;
    }
}

function parseJwt (token) {
    var base64Url = token.split('.')[1];
    var base64 = base64Url.replace(/-/g, '+').replace(/_/g, '/');
    var jsonPayload = decodeURIComponent(window.atob(base64).split('').map(function(c) {
        return '%' + ('00' + c.charCodeAt(0).toString(16)).slice(-2);
    }).join(''));

    return JSON.parse(jsonPayload);
}

function checkAuthorization() {
    var token = sessionStorage.getItem('token');
    if (token == null) {
        window.location.href = "login.html";
        alert("Please login first.")
    }
    else{
        var decoded = parseJwt(token);
        var role = decoded['http://schemas.microsoft.com/ws/2008/06/identity/claims/role'];
        var exp = decoded['exp'] * 1000;
        var expiry_date = new Date(exp);
        var current_date = new Date();
        console.log(expiry_date);
        console.log(current_date);
        if((role == "Customer" || role == "Admin") && current_date <= expiry_date){
            console.log(decoded['exp']);
            window.location.href = "BusList.html";
        }
        else if(current_date > expiry_date){
            alert("Session timed out. Please login again.")
            window.location.href = "login.html";
        }
    }
}