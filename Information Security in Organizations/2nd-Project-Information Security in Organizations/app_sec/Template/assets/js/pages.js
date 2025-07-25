// About ---------------------------------------------------------------------------------------------------------------------
function about() {
    var xhr = new XMLHttpRequest();
    xhr.open("GET", "/about")

    xhr.onreadystatechange = () => {                                            
        // Call a function when the state changes.
        if (xhr.readyState === XMLHttpRequest.DONE && xhr.status === 200) {
            // Request finished. Do processing here.
            //open( xhr.response ); //abre uma janela vazia só (do open, o xhr.response é o texto/html do products.html)     
            window.location = 'http://127.0.0.1:8080/about' 

        }
    }
    xhr.send()
}
// Inicio ---------------------------------------------------------------------------------------------------------------------
function inicio() {
    var xhr = new XMLHttpRequest();
    xhr.open("GET", "/index")

    xhr.onreadystatechange = () => {                                            
        // Call a function when the state changes.
        if (xhr.readyState === XMLHttpRequest.DONE && xhr.status === 200) {
            // Request finished. Do processing here.
            //open( xhr.response ); //abre uma janela vazia só (do open, o xhr.response é o texto/html do products.html)     
            window.location = 'http://127.0.0.1:8080/inicio'

        }
    }
    xhr.send()

}
//Login --------------------------------------------------------------------------------------------------------------------

function login() {
window.location = 'http://127.0.0.1:8080/' 
}

// Shop --------------------------------------------------------------------------------------------------------------------
function products() {
    var xhr = new XMLHttpRequest();
    xhr.open("GET", "/products")

    xhr.onreadystatechange = () => {                                            
        // Call a function when the state changes.
        if (xhr.readyState === XMLHttpRequest.DONE && xhr.status === 200) {
            // Request finished. Do processing here.
            //open( xhr.response ); //abre uma janela vazia só (do open, o xhr.response é o texto/html do products.html)     
            window.location = 'http://127.0.0.1:8080/products' 

        }
    }
    xhr.send()
}


// Contactos ---------------------------------------------------------------------------------------------------------------------

function contact() {
    var xhr = new XMLHttpRequest();
    xhr.open("GET", "/contact")

    xhr.onreadystatechange = () => {                                            
        // Call a function when the state changes.
        if (xhr.readyState === XMLHttpRequest.DONE && xhr.status === 200) {
            // Request finished. Do processing here.
            //open( xhr.response ); //abre uma janela vazia só (do open, o xhr.response é o texto/html do products.html)     
            window.location = 'http://127.0.0.1:8080/contact' 

        }
    }
    xhr.send()
}

// logout -----------------------------------------------------------------------------------------------------------------------
function logout() {
    var xhr = new XMLHttpRequest();
    xhr.open("GET", "/logout")

    xhr.onreadystatechange = () => {                                            
        // Call a function when the state changes.
        if (xhr.readyState === XMLHttpRequest.DONE && xhr.status === 200) {
            // Request finished. Do processing here.
            //open( xhr.response ); //abre uma janela vazia só (do open, o xhr.response é o texto/html do products.html)     
            window.location = 'http://127.0.0.1:8080/contact' 

        }
    }
    xhr.send()
}

// cart -------------------------------------------------------------------------------------------------------------------------

function cart() {
    var xhr = new XMLHttpRequest();
    xhr.open("GET", "/cart")

    xhr.onreadystatechange = () => {                                            
        // Call a function when the state changes.
        if (xhr.readyState === XMLHttpRequest.DONE && xhr.status === 200) {
            // Request finished. Do processing here.
            //open( xhr.response ); //abre uma janela vazia só (do open, o xhr.response é o texto/html do products.html)     
            window.location = 'http://127.0.0.1:8080/cart' 

        }
    }
    xhr.send()
}
// profile ------------------------------------------------------------------------------------------------------------------------

function profile() {
    var xhr = new XMLHttpRequest();
    xhr.open("GET", "/profile")

    xhr.onreadystatechange = () => {                                            
        // Call a function when the state changes.
        if (xhr.readyState === XMLHttpRequest.DONE && xhr.status === 200) {
            // Request finished. Do processing here.
            //open( xhr.response ); //abre uma janela vazia só (do open, o xhr.response é o texto/html do products.html)     
            window.location = 'http://127.0.0.1:8080/profile' 

        }
    }
    xhr.send()
}



// atualizar o nome de utilizador na respetiva caixa de texto
function update_username() {
    var algo;
    xhr = new XMLHttpRequest();
    xhr.open("GET", "/session_checker")

    xhr.onreadystatechange = () => {                                            
    
        if (xhr.readyState === XMLHttpRequest.DONE && xhr.status === 200) {
            // Request finished. Do processing here.
            response = JSON.parse( xhr.response );  
            //algo = response.username
            document.getElementById("username").value=response.username;
            //return algo               //não dá para retorna um valor em concreto duma função assíncrona, porque pelo tempo que o readystatechange mudar, já a função retornou algo. Só dá para chamar outras funções ou fazer alerts do valor recebido assincronamente, porque podem e são invocaddas quando o readystatechange muda, enquanto que o return só pode ocorrer uma vez e ocorre antes dessa condição
        }
    }
    xhr.send();
}

// ler o que foi inserido nos campos de texto
function get_password_values() {
    current_pw = document.getElementById("current_password").value
    new_pw = document.getElementById("new_password").value
    new_pw2 = document.getElementById("new_password2").value

    if(current_pw != null && current_pw != "") {
        if(new_pw != null && new_pw != "" && new_pw2 != null && new_pw2 != "") {
            if(new_pw == new_pw2) {
                get_user_name_and_id_password(current_pw, new_pw) 
            }
            else {
                alert("Os dois campos da nova password não são indênticos.")
            }
        }
        else {
            alert("Por favor insira uma nova password nos respetivos campos.")
        }
    }
    else {
        alert("Por favor insira a atual password no respetivo campo.")
    }
}

// obter id e nome do utilizador a partir da sessão atual
function get_user_name_and_id_password(current_pw, new_pw) {
    xhr = new XMLHttpRequest();
    xhr.open("GET", "/session_checker")

    xhr.onreadystatechange = () => {                                            
    
        if (xhr.readyState === XMLHttpRequest.DONE && xhr.status === 200) {
            // Request finished. Do processing here.
            response = JSON.parse( xhr.response );  
            change_password(response.userID, current_pw, new_pw)
        }
    }
    xhr.send();
}


// pedir ao ao servidor para mudar password
function change_password(user_id, current_pw, new_pw) {
    xhr = new XMLHttpRequest();
    xhr.open("POST", "/change_password")



    var data = new FormData();
    data.append("user_id", user_id)
    data.append("current_pw", current_pw)
    data.append("new_pw", new_pw)
    xhr.send(data)

    xhr.onreadystatechange = () => {                                            
        if (xhr.readyState === XMLHttpRequest.DONE && xhr.status === 200) {
            // Request finished. Do processing here.
            response = JSON.parse( xhr.response );  
            if (response.status == true) {
                alert(response.result)
                logout()
                window.location = 'http://127.0.0.1:8080/inicio'
            }
            else {
                alert(response.result)
            }
        }
    }

}






// esconder os campos relativos ao login e apresentar os campos relativos ao registo
function switchToRegister() {
    document.getElementById('username1').value = document.getElementById('username0').value

    document.getElementById("dor").style.display = 'block'
    document.getElementById("register_form").style.display = 'block'
    document.getElementById("register_container").style.display = 'block'
    document.getElementById("register_switch_button").style.display = 'block'
    document.getElementById("register_div2").style.display = 'block'
    document.getElementById("QR_image").style.display = 'block'

    document.getElementById("dor_pico").style.display = 'none'
    document.getElementById("login_form").style.display = 'none'
    document.getElementById("login_container").style.display = 'none'
    document.getElementById("login_switch_button").style.display = 'none'
    document.getElementById("login_div2").style.display = 'none'
    //document.getElementById("QR_image").innerHTML = ''
}

// esconder os campos relativos ao registo e apresentar os campos relativos ao logn
function switchToLogin() {
    document.getElementById("dor").style.display = 'none'
    document.getElementById("register_form").style.display = 'none'
    document.getElementById("register_container").style.display = 'none'
    document.getElementById("register_switch_button").style.display = 'none'
    document.getElementById("register_div2").style.display = 'none'
    document.getElementById("QR_image").style.display = 'none'

    document.getElementById("dor_pico").style.display = 'block'
    document.getElementById("login_form").style.display = 'block'
    document.getElementById("login_container").style.display = 'block'
    document.getElementById("login_switch_button").style.display = 'block'
    document.getElementById("login_div2").style.display = 'block'
    //document.getElementById("QR_image").innerHTML = ''
}




function show_password(){
    passwordContent = document.getElementById('password1');
    passwordContent.type = passwordContent.type === 'password' ? 'text' : 'password';       //se alterar o tipo do input com id username1 de email para text, a página faz reset. EDIT: a cura é fazer com que o tipo do butão seja button, porque o default era submit (que faz refresh à página)
    setTimeout(function(){
        passwordContent.type = 'password';

    }, 3000); // Ao fim de 3 segundos, a palavra-passe é camuflada
    return false
}




function password_Strength() {
    let password = document.getElementById("password1").value;
    let password_strength = document.getElementById("password_strength");


    var strength = -1;

    const strength_values = ["Muito Fraca", "Fraca", "Média", "Forte", "Muito Forte"];

    const colors = ["red", "orange", "gold", "green", "darkgreen"];



    if (password.match(/[a-z]/)) {
        strength++;
    }

    if (password.match(/[A-Z]/)) {
        strength++;
    }

    if (password.match(/[0-9]/)) {
        strength++;
    }

    if (password.match(/[#*]/)) {
        strength++;
    }




    if (password.length >= 12 && password.length <= 128) {
        strength++;
    } else if (password.length > 128) {
        strength = -1;

    }

    if (strength > colors.length - 1) {
        strength = colors.length - 1;
    }




    if (strength == -1) { //caso a password é apagada ou tenha mais de 128 caracteres
        password_strength.textContent = "";

    } else {
        password_strength.style.color = colors[strength];

        password_strength.textContent = "Palavra-Passe:" + strength_values[strength];
    }


}










function password_Strength_profile() {
    let password = document.getElementById("new_password").value;
    let password_strength = document.getElementById("password_strength");


    var strength = -1;

    const strength_values = ["Muito Fraca", "Fraca", "Média", "Forte", "Muito Forte"];

    const colors = ["red", "orange", "gold", "green", "darkgreen"];



    if (password.match(/[a-z]/)) {
        strength++;
    }

    if (password.match(/[A-Z]/)) {
        strength++;
    }

    if (password.match(/[0-9]/)) {
        strength++;
    }

    if (password.match(/[#*]/)) {
        strength++;
    }




    if (password.length >= 12 && password.length <= 128) {
        strength++;
    } else if (password.length > 128) {
        strength = -1;

    }

    if (strength > colors.length - 1) {
        strength = colors.length - 1;
    }




    if (strength == -1) { //caso a password é apagada ou tenha mais de 128 caracteres
        password_strength.textContent = "";

    } else {
        password_strength.style.color = colors[strength];

        password_strength.textContent = "Palavra-Passe:" + strength_values[strength];
    }


}
