function doLogin() {
    username = document.getElementById("username").value;       //buscar os dados que foram inseridos nos inputs/campos de texto do username e da password 
    password = document.getElementById("password").value;

    if (username == "" || password == "") {                     //verificar só se foi inserido algo nos dois campos (client-side)
        alert("Por favor insira um nome de utilizador e uma palavra-passe.")
    }
    else {
        var dados = new FormData();                                 //caso hajam dados suficientes, enviar POST ao servidor com eles
        dados.append("username", username);
        dados.append("password", password);

        var xhr = new XMLHttpRequest();
        xhr.open("POST", "/login")

        xhr.onreadystatechange = () => {                                            
            // Call a function when the state changes.
            if (xhr.readyState === XMLHttpRequest.DONE && xhr.status === 200) {
                // Request finished. Do processing here.
                response = JSON.parse( xhr.response );     
                if (response.result == "sucesso") {
                    window.location = 'http://127.0.0.1:13000/inicio' 
                }
                else {
                    alert(response.result);
                }  
            }
        }
        xhr.send(dados);
    }
}




function doRegister() {
    username = document.getElementById("username").value;       //buscar os dados que foram inseridos nos inputs/campos de texto do username e da password 
    password = document.getElementById("password").value;

    if (username == "" || password == "") {                     //verificar só se foi inserido algo nos dois campos (client-side)
        alert("Por favor insira um nome de utilizador e uma palavra-passe.")
    }
    else {
        dados = new FormData();                                 //caso hajam dados suficientes, enviar POST ao servidor com eles
        dados.append("username", username);
        dados.append("password", password);

        xhr = new XMLHttpRequest();
        xhr.open("POST", "/register")

        xhr.onreadystatechange = () => {                                            
            
            if (xhr.readyState === XMLHttpRequest.DONE && xhr.status === 200) {
                // Request finished. Do processing here.
                response = JSON.parse( xhr.response );  
                alert(response.result)     
            }

        }
        xhr.send(dados);
    }
}


function clearInputs() {
    document.getElementById("username").value="";
    document.getElementById("password").value="";
}

