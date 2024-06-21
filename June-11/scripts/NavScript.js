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