import os.path
import cherrypy
import sqlite3 as sql
import json
import hashlib

# The absolute path to this file's base directory
baseDir = os.path.abspath(os.path.dirname(__file__))

# Dictionary with this application's static directories configuration
config = {
			"/":		{	"tools.staticdir.root": baseDir, "tools.sessions.on": True, "tools.sessions.storage_class": cherrypy.lib.sessions.FileSession, "tools.sessions.storage_path": "./cherrypy_sessions_cookies" },
			"/Template/assets/js":		{	"tools.staticdir.on": True, "tools.staticdir.dir": "Template/assets/js" },
			"/Template/assets/css":		{	"tools.staticdir.on": True, "tools.staticdir.dir": "Template/assets/css" },
            "/imgs":		{	"tools.staticdir.on": True, "tools.staticdir.dir": "imgs" },
            "/Template/assets/webfonts": 	{"tools.staticdir.on": True, "tools.staticdir.dir": "Template/assets/webfonts"},
            "/Template": 	{"tools.staticdir.on": True, "tools.staticdir.dir": "Template"},
            
}

class Root(object):
    @cherrypy.expose
    def session_checker(self):
        # Aceder à sessão do utilizador
        session = cherrypy.session
        #for key, value in session.items():
        #    print(key, ":    ", value)

        # verificar se o utilizador já fez login, ou se entretanto o cookie já foi eliminado
        if 'username' in session:
            username = session['username']
            userID = session['userID']
            return json.dumps({"result": True, "username" : username, "userID": userID}).encode("utf-8")
        else:
            return json.dumps({"result": False}).encode("utf-8")

    @cherrypy.expose
    def logout(self):
        cherrypy.session.clear()       #as cookies permanecem no browser depois de fazer logout sem esta linha de código. CWE 613
        return json.dumps({"result": True}).encode("utf-8")


    @cherrypy.expose
    def index(self):
            return open("Template/login.html")
    
    @cherrypy.expose
    def inicio(self):
            return open("Template/index.html")

    
    @cherrypy.expose
    def about(self):
            return open("Template/about.html")

    @cherrypy.expose
    def products(self):
            return open("Template/shop.html")


    @cherrypy.expose
    def contact(self):
            return open("Template/contact.html")

	
    @cherrypy.expose
    def cart(self):
            return open("Template/cart.html")

    @cherrypy.expose
    def profile(self):
            return open("Template/profile.html")



    """ 
    @cherrypy.expose
    def login_bem_feito(self, username, password):        #tive horas encravado com os bad requests do javascript (error 400) não por erro do javascript, mas por faltar o atributo "self" aqui
        h = hashlib.sha256()
        h.update(password.encode())          
        password = h.hexdigest()            

        db=sql.connect('base_dados.db')
        result = db.execute("SELECT * FROM accounts WHERE username = ?", (username,))   #secure
        linha = result.fetchone()
        db.close()		

        if linha == None:
            return json.dumps({"result" : "Nome de utilizador ou palavra-passe incorretos."}).encode("utf-8")

        account_info = dict()
        account_info={"id": linha[0], "username": linha[1], "password":linha[2]}


        #mesmo que a query de SQL seja insegura e retorne sempre um resultado qualquer, é preciso que o username e password inseridos sejam iguais ao username e password desse resultado
        if account_info["username"].lower() == username.lower() and account_info["password"]==password:
            #adicionar sessão/cookies
            session = cherrypy.session
            # guardar nome de utilizador na sessão
            session['username'] = username
            msg = json.loads (str(self.get_userID(username), "utf8"))
            session['userID'] = msg['result']
            

            return json.dumps({"result" : "sucesso"}).encode("utf-8")
        else:
            return json.dumps({"result" : "Nome de utilizador ou palavra-passe incorretos."}).encode("utf-8")
        
     """

    
        
    #login baixo nível, como aqueles que me mandaste!!!!!
    @cherrypy.expose
    def login(self, username, password):        #tive horas encravado com os bad requests do javascript (error 400) não por erro do javascript, mas por faltar o atributo "self" aqui
        #sem hash         

        db=sql.connect('base_dados.db')
        result = db.execute("SELECT * FROM accounts WHERE username = '"+username+"' AND password = '"+password+"'")   #insecure
        linha = result.fetchone()
        db.close()		

        # literalmente só verificam se houve um resultado na query para permitir acesso ao site
        if linha!=None:
            #adicionar sessão/cookies
            session = cherrypy.session
            # guardar nome de utilizador na sessão
            session['username'] = linha[1]
            msg = json.loads (str(self.get_userID(username), "utf8"))
            session['userID'] = msg['result']
            return json.dumps({"result" : "sucesso"}).encode("utf-8")
        else:
            return json.dumps({"result" : "Nome de utilizador ou palavra-passe incorretos."}).encode("utf-8")
        
        





    @cherrypy.expose
    def memorabilia_stock(self):
        db=sql.connect('base_dados.db')
        result = db.execute("SELECT * FROM memorabilia")
        linhas=result.fetchall()
        db.close()

        memorabilia_info = []
        for linha in linhas:
            memorabilia_dict = {"id": linha[0], "nome": linha[1], "stock": linha[2], "price": linha[3]}
            memorabilia_info.append(memorabilia_dict)

        return json.dumps({"result" : memorabilia_info}).encode("utf-8")







    @cherrypy.expose
    def register(self, username, password):
        db=sql.connect('base_dados.db')
        result = db.execute("SELECT * FROM accounts WHERE username = '%s'" % username)     #not secure
        linha = result.fetchone()
        db.close()

        if linha == None:

            #no hash
            
            db = sql.connect('base_dados.db')
            #db.execute("INSERT INTO accounts(username, password, admin) VALUES (?, ?, ?)", (username, password, False))
            result = db.execute("INSERT INTO accounts(username, password, admin) VALUES ('"+username+"', '"+password+"', '"+str(False)+"')") 
            db.commit()
            db.close()
            return json.dumps({"result" : "Conta criada."}).encode("utf-8")
		
        else:
	        return json.dumps({"result" : "Erro: a conta já existe."}).encode("utf-8")



    @cherrypy.expose
    def get_userID(self, username):
        db = sql.connect('base_dados.db')
        result = db.execute("SELECT * FROM accounts WHERE username = ?", (username,)) 
        linha = result.fetchone()
        db.close()

        if linha == None:
            return json.dumps({"result" : "Não existe."}).encode("utf-8")
        return json.dumps({"result" : linha[0]}).encode("utf-8")
    


    @cherrypy.expose
    def cart_insert(self, user_id, memorabilia_id):
        db = sql.connect('base_dados.db')

        result = db.execute("SELECT * FROM memorabilia WHERE id = ?", (memorabilia_id))
        linha = result.fetchone()
        if int(linha[2]) == 0:
            return json.dumps({"result" : "Sem stock."}).encode("utf-8")


        db.execute("INSERT INTO cart(user_id, memorabilia_id) VALUES (?, ?)", (user_id, memorabilia_id))
        db.commit()
        db.close()

        return json.dumps({"result" : "Adicionado com sucesso."}).encode("utf-8")


    @cherrypy.expose
    def cart_list(self, user_id):
        db = sql.connect('base_dados.db')
        #result = db.execute("SELECT * FROM cart, memorabilia WHERE user_id = ? AND memorabilia.id = cart.memorabilia_id", (user_id))
        result = db.execute("SELECT * FROM cart, memorabilia WHERE user_id = '"+user_id+"' AND memorabilia.id = cart.memorabilia_id")
        linhas = result.fetchall()
        db.close()


        dicio_cart={}
        for linha in linhas:
            if linha[4] not in dicio_cart:
                dicio_cart[linha[4]] = [1, float(linha[6])]
           
            else:
                dicio_cart[linha[4]] = [1 + dicio_cart[linha[4]][0], (1+dicio_cart[linha[4]][0])*linha[6]]

        print(dicio_cart)

        return json.dumps({"result" : dicio_cart}).encode("utf-8")
    



    @cherrypy.expose
    def submit_message(self, user_id, subject, message):
        if subject!=None and len(subject)>0 and message!= None and len(message)>1:

            db = sql.connect('base_dados.db')
            db.execute("INSERT INTO comments(user_id, subject, comment) VALUES (?, ?, ?)", (user_id, subject, message))
            db.commit()
            db.close()
            return json.dumps({"result" : "Mensagem entregue com sucesso.", "status": True}).encode("utf-8")
        return json.dumps({"result" : "Erro: Mensagem não pode ser entregue nestas condições.", "status": False}).encode("utf-8")
        
        
        #if subject!=None and len(subject)>0 and message!=None and len(message)>0:
        #    with open('message_logs/'+user_id+'_'+subject+".txt", 'w') as stream:
        #        stream.write(message)
        #    return json.dumps({"result" : "Mensagem entregue com sucesso.", "status": True}).encode("utf-8")
        #return json.dumps({"result" : "Erro: Mensagem não pode ser entregue nestas condições.", "status": False}).encode("utf-8")

    @cherrypy.expose
    def load_previous_message(self):            

        db = sql.connect('base_dados.db')
        result = db.execute("select * from accounts,comments where accounts.id = comments.user_id order by comments.id desc")
        linhas=result.fetchall()
        db.commit()
        db.close()

        lista=[]
        for linha in linhas:
            lista.append({"user": linha[1], "subject": linha[6], "comment": linha[7]})
        print(lista)
        
        return json.dumps({"result" : lista, "status": True}).encode("utf-8")
    
        #text=''
        #with open('message_logs/1_Script manhoso do Eduardo.txt', 'r') as stream:
        #    text=stream.read()
        #return json.dumps({"result" : text, "status": True}).encode("utf-8")



    @cherrypy.expose
    def change_password(self, user_id, new_pw):

        db=sql.connect('base_dados.db')
        result = db.execute("SELECT * FROM accounts WHERE id = '%s'" % user_id)     #not secure
        linha = result.fetchone()
        db.close()

        if linha:

                db = sql.connect('base_dados.db')
                db.execute("UPDATE accounts SET password = ? WHERE id = ?", (new_pw, user_id))
                db.commit()
                db.close()
                return json.dumps({"result" : "Password alterada com sucesso.", "status": True}).encode("utf-8")

		
        else:
	        return json.dumps({"result" : "Erro: a conta não existe.", "status": False}).encode("utf-8")



cherrypy.config.update({'server.socket_port': 13000})
cherrypy.quickstart(Root(), "/", config)