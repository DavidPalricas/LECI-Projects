function memorabilia() {
        xhr = new XMLHttpRequest();
        xhr.open("GET", "/memorabilia_stock")

        xhr.onreadystatechange = () => {                                            
            
            if (xhr.readyState === XMLHttpRequest.DONE && xhr.status === 200) {
                // Request finished. Do processing here.
                response = JSON.parse( xhr.response );  
                
                for(i=0; i<response.result.length; i++) {
                    //alert(response.result[i]["nome"])
                    //alert(response.result[i]["stock"])

                    document.getElementById(response.result[i]["nome"]).textContent += response.result[i]["stock"];
                    document.getElementById(response.result[i]["nome"]+"_price").textContent += (response.result[i]["price"] + "€");
                }

                //get_user_name_and_id(); //em vez de chamar as 2 no onload do body html, chamar uma após a outra. Normalmente a primeira não dáva nada após o onreadystatechange (para variar)
            }

        }
        xhr.send();
}


function get_user_name_and_id() {
            xhr = new XMLHttpRequest();
            xhr.open("GET", "/session_checker")

            xhr.onreadystatechange = () => {                                            
            
                if (xhr.readyState === XMLHttpRequest.DONE && xhr.status === 200) {
                    // Request finished. Do processing here.
                    response = JSON.parse( xhr.response );  
                    cart_user(response.username, response.userID)
                }
            }
            xhr.send();
}


function cart_user(username, userID) {
        //div_cart = document.createElement("div");             //criar div alinhado à direita da página HTML para mostrar as coisas que o utilizador quer comprar
        //div_cart.classList.add("columnright")               //se não der, tentar div_cart.setAttribute("class", "columnright") Edit: nenhum dos dois está a funcionar, mesmo com div de class="row" a conter os dois. Dei fix em html, com 3 divs lado a lado, a ocupar o mesmo espaço cada, com a do meio sendo a principal com as imagens da memorabilia (mesmo no meio, como se fosse em coluna normal como antes)


        //div_cart.appendChild(document.createElement('h1').appendChild(document.createTextNode("Carrinho do utilizador")))
        //document.getElementById("memorabilia_cart").appendChild(div_cart)

        document.getElementById("nome").textContent = username;

        var data = new FormData();
        data.append("user_id", userID)                           //3 é o ID do Eduardo na base de dados (accounts)

        var xhr = new XMLHttpRequest();
        xhr.open("POST", "/cart_list")                        //sempre que se tem que enviar parâmetros para o servidor, faz-se POST em vez de GET, senão dá erro (o GET não envia parâmetros, pelo que o servidor diz que a request do javascript é má e mete-lhe um código de status 404)

        xhr.onreadystatechange = () => {                                            
        
            if (xhr.readyState === XMLHttpRequest.DONE && xhr.status === 200) {
                // Request finished. Do processing here.
                response = JSON.parse( xhr.response ); 
                
                for([chave, valor] of Object.entries(response.result)) {
                    //div_cart.appendChild(document.createElement('h1').appendChild(document.createTextNode("Artigo: "+chave+";  Quantidade: "+valor[0]+";   Preço: "+valor[1])))
                    document.getElementById(chave+"_div").removeAttribute("hidden")
                    document.getElementById(chave+"_cart").setAttribute('style', 'white-space: pre;');
                    document.getElementById(chave+"_cart").textContent = "Unidades: "+valor[0]+ "\r\nPreço: "+valor[1]+"€";
                }
            }
        }
        xhr.send(data); 
}







function add_item(item) {
    xhr = new XMLHttpRequest();
    xhr.open("GET", "/session_checker")

    xhr.onreadystatechange = () => {                                            
    
        if (xhr.readyState === XMLHttpRequest.DONE && xhr.status === 200) {
            // Request finished. Do processing here.
            response = JSON.parse( xhr.response );  
            add_item_helper(item, response.userID)
        }
    }
    xhr.send();
}

function add_item_helper(item, user_id) {
            xhr = new XMLHttpRequest();
            xhr.open("POST", "/cart_insert")

            var data = new FormData();
            data.append("user_id", user_id)
            data.append("memorabilia_id", item)

            xhr.onreadystatechange = () => {                                            
            
                if (xhr.readyState === XMLHttpRequest.DONE && xhr.status === 200) {
                    // Request finished. Do processing here.
                    response = JSON.parse( xhr.response );  
                    //alert(response.result); 
                    
                }
            }
            xhr.send(data);

            //refresh
            //get_user_name_and_id();
}










const divs_to_hide_ids = ['t-shirt_cart', "camisola_cart", "cachecol_cart", "copo_cart", "caneca_cart"]

function get_user_name_and_id_item() {
    xhr = new XMLHttpRequest();
    xhr.open("GET", "/session_checker")

    item = document.getElementById(filter).textContent;

    xhr.onreadystatechange = () => {                                            
    
        if (xhr.readyState === XMLHttpRequest.DONE && xhr.status === 200) {
            // Request finished. Do processing here.
            response = JSON.parse( xhr.response );  
            cart_user(response.username, response.userID, item);
        }
    }
    xhr.send();
}


function cart_user_item(username, userID, item) {

    document.getElementById("nome").textContent = username;

    var data = new FormData();
    data.append("user_id", userID)                           //3 é o ID do Eduardo na base de dados (accounts)
    data.append("item", item)

    var xhr = new XMLHttpRequest();
    xhr.open("POST", "/cart_list")                        //sempre que se tem que enviar parâmetros para o servidor, faz-se POST em vez de GET, senão dá erro (o GET não envia parâmetros, pelo que o servidor diz que a request do javascript é má e mete-lhe um código de status 404)

    xhr.onreadystatechange = () => {                                            

        if (xhr.readyState === XMLHttpRequest.DONE && xhr.status === 200) {
            // Request finished. Do processing here.
            response = JSON.parse( xhr.response ); 
            
            for([chave, valor] of Object.entries(response.result)) {
                //div_cart.appendChild(document.createElement('h1').appendChild(document.createTextNode("Artigo: "+chave+";  Quantidade: "+valor[0]+";   Preço: "+valor[1])))
                document.getElementById(chave+"_div").removeAttribute("hidden")
                document.getElementById(chave+"_cart").setAttribute('style', 'white-space: pre;');
                document.getElementById(chave+"_cart").textContent = "Unidades: "+valor[0]+ "\r\nPreço: "+valor[1]+"€";
            }
        }
    }
    xhr.send(data); 
}

//function hide_divs() {

//}