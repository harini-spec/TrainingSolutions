function setNavDetails(){
    var profileName = sessionStorage.getItem("email");
    if(profileName){
        profileName = profileName.split("@")[0];
        document.getElementById("account").innerHTML = profileName;
    }

    if(sessionStorage.getItem("token")){
        var login_element = document.getElementById("login");
        var register_element = document.getElementById("register");
        if(login_element)
            login_element.remove();
        if(register_element)
            register_element.remove();
    }
    else{
        var logout_element = document.getElementById("logout");
        var ticket_element = document.getElementById("ticket");
        if(logout_element)
            logout_element.remove();
        if(ticket_element)
            ticket_element.remove();
    }
}


document.getElementById("logout").addEventListener("click", function(){
    if(!sessionStorage.getItem("email") || !sessionStorage.getItem("token")){
        Swal.fire("You are not logged in!");
        return;
    }
    sessionStorage.removeItem("email");
    sessionStorage.removeItem("token");
    Swal.fire({
        title: "You've been successfully logged out!",
        confirmButtonText: "OK"
        }).then((result) => {
        if (result.isConfirmed) {
          location.reload();
        }
      });
});