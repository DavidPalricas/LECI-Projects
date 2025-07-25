// function alerta(){
//     alert("Mensagem enviada com sucesso!")
// }


// atualizar o nome de utilizador na respetiva caixa de texto
function update_username() {

    xhr = new XMLHttpRequest();
    xhr.open("GET", "/session_checker")

    xhr.onreadystatechange = () => {                                            
    
        if (xhr.readyState === XMLHttpRequest.DONE && xhr.status === 200) {
            // Request finished. Do processing here.
            response = JSON.parse( xhr.response );  
            document.getElementById("username").value=response.username;
            load_message()
        }
    }
    xhr.send();
}

// obter id e nome do utilizador a partir da sessão atual
function get_user_name_and_id_and_submit() {
    xhr = new XMLHttpRequest();
    xhr.open("GET", "/session_checker")

    xhr.onreadystatechange = () => {                                            
    
        if (xhr.readyState === XMLHttpRequest.DONE && xhr.status === 200) {
            // Request finished. Do processing here.
            response = JSON.parse( xhr.response );  
            submit(response.userID)
        }
    }
    xhr.send();
}

// submeter a partir do ID obtido acima
function submit(user_id) {

    subject = document.getElementById('subject').value;   //.value
    message = document.getElementById('message').value;   //.value

    xhr = new XMLHttpRequest();
    xhr.open("POST", "/submit_message")

    var data = new FormData();
    data.append("user_id", user_id)
    data.append("subject", subject)
    data.append("message", message)
    xhr.send(data)

    xhr.onreadystatechange = () => {                                            
    
        if (xhr.readyState === XMLHttpRequest.DONE && xhr.status === 200) {
            // Request finished. Do processing here.
            response = JSON.parse( xhr.response ); 
            if (response.status == false) alert("Erro ao enviar mensagem.")
        }
    }
}



//carregar mensagem de utilizador que alguém carregou usando a função acima, e sujeitar-nos a XSS
function load_message() {
    xhr = new XMLHttpRequest();
    xhr.open("GET", "/load_previous_message")

    xhr.onreadystatechange = () => {                                            
    
        if (xhr.readyState === XMLHttpRequest.DONE && xhr.status === 200) {
            // Request finished. Do processing here.
            response = JSON.parse( xhr.response );  
            if (response.status == true) {
                for(i=0; i<response.result.length; i++) {
                    var div = document.createElement("div")
                    //div.appendChild(document.createElement("h3").appendChild(document.createTextNode(response.result[i]["user"]+" wrote on "+response.result[i]["subject"]+":")))       //os textnodes é que fazem os headers serem pequenos e sem cor mesmo que tente mudar isso
                    var subject = document.createElement("h4")
                    subject.innerHTML = '*'+response.result[i]["user"]+'*'+" wrote on "+"'"+response.result[i]["subject"]+"':" 
                    subject.setAttribute("style", "color: lime")

                    var message = document.createElement("h5")
                    message.innerHTML = response.result[i]["comment"] 

                    div.appendChild(subject)
                    div.appendChild(message)

                    document.getElementById("previous_messages").appendChild(div)
                }
                //var algo = document.createElement("h4");
                //algo.innerHTML = response.result
                //document.body.appendChild(algo)

                //document.getElementById("previous_message").innerHTML = response.result           #a textarea existente em HTML, simplesmente não deixava que o conteúdo da response fosse executada como código. As textareas criadas em js, também não permitiam que o conteúdo da response fosse executado como código. Mas os headers permitem isso, com o mesmo código, a mesma atribuição de innerHTML a response.result
            }
            else alert("Erro a carregar mensagem prévia.")
        }
    }
    xhr.send();

}