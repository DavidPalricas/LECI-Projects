"""Example client."""
import asyncio
import getpass
import json
import os
from consts import Direction
import math, random
from consts import Direction



import websockets

orientacoes = {"w": Direction.NORTH, "a": Direction.WEST, "s": Direction.SOUTH, "d": Direction.EAST} #Dicionário global que relaciona as teclas com as direções
alcance_max_ataque = 3 #Variável global que reperesenta o alcance máximo do ataque do digdug
limite_eixo_x = [0,47] #Lista global que representa os limites do eixo x
limite_eixo_y = [0,23] #Lista global que representa os limites do eixo y



def bug_fygar(digdug_pos, digdug_direction, inimigo_mais_proximo):
     #Esta função ignora as condições de defesa do digdug (ignora possíveis posições fatais)
     #Limita-se a perseguir o fygar o que provalvelmente resultará na morte do digdug
     #Basicamente serve para o digdug ter uma chance de matar o fygar quando o tempo está a acabar
     #E não morrer por timeout
     inimigo_mais_proximo_pos = inimigo_mais_proximo["pos"] #Simplificar escrita

     if inimigo_mais_proximo_pos[0] == digdug_pos[0]:
         if inimigo_mais_proximo_pos[1] >= digdug_pos[1]:
             key = "s"
         else:
             key = "w"
     elif inimigo_mais_proximo_pos[1] == digdug_pos[1]:
         if inimigo_mais_proximo_pos[0] >= digdug_pos[0]:
             key = "d"
         else:
             key = "a"

     else: 
         difx = eixo_x(inimigo_mais_proximo_pos[0], digdug_pos[0]) 
         dify = eixo_y(inimigo_mais_proximo_pos[1],digdug_pos[1])

         if dify <= difx:
             if inimigo_mais_proximo_pos[1] > digdug_pos[1]:
                 key = "s"
             else:
                 key = "w"
         else:
                if inimigo_mais_proximo_pos[0] > digdug_pos[0]:
                    key = "d"
                else:
                    key = "a"

     digdug_direction = obter_direcao(key,digdug_direction)

     return key, digdug_direction
         
         


def perto_time_out(passos,timeout): #Função que verifica se o tempo está a acabar
    if passos >= timeout-850:
        return True
    return False

def obter_direcao(key,digdug_direction): #Função que devolve a direção do digdug
    for movimento in orientacoes:
        if key == movimento:
            return orientacoes[movimento]
            
    return digdug_direction


def evitar_timeout(inimigo_mais_proximo,passos,timeout):
    if inimigo_mais_proximo["name"] == "Pooka" :
        inimigo_mais_proximo["pos"] = [limite_eixo_x[1], limite_eixo_y[1]/2] #Posição segura para o digdug ir quando o tempo estiver para acabar
                                                                        #Isto permite que o Pooka consiga fugir do digdug e não morra por timeout
    return inimigo_mais_proximo["pos"]


def dentro_limites(pos, limite_eixo_x, limite_eixo_y):
        if pos[0] >= limite_eixo_x[0] and pos[0] <= limite_eixo_x[1] and pos[1] >= limite_eixo_y[0] and pos[1] <= limite_eixo_y[1]:
            return True
        return False


def posicoes_digdug(digdug_pos):           
     movimentos = {"w": [digdug_pos[0],digdug_pos[1]-1], "a": [digdug_pos[0]-1,digdug_pos[1]], 
                   "s": [digdug_pos[0],digdug_pos[1]+1], "d": [digdug_pos[0]+1,digdug_pos[1]],
                   " ": [digdug_pos[0],digdug_pos[1]]}
  

     for movimento in movimentos:
         if not dentro_limites(movimentos[movimento], limite_eixo_x, limite_eixo_y):
             movimentos[movimento] = [digdug_pos[0],digdug_pos[1]]
   

     return movimentos



def areas_perigosas(digdug_pos,inimigos,rochas):               
    indentidades_malignas = {}
    areas_fatais = []
    
    for inimigo in inimigos:
        if math.dist(digdug_pos,inimigo["pos"]) <= 5:
            perigo = posicoes_inimigo(inimigo["pos"])
            if inimigo["name"] == "Fygar":
                perigo+=fygar_fire(inimigo)

            indentidades_malignas[inimigo["id"]] = perigo
  
        for rocha in rochas:
                 indentidades_malignas[rocha["id"]] = [ rocha["pos"], [rocha["pos"][0],rocha["pos"][1]+1]]

    for coordenadas in indentidades_malignas.values():
        areas_fatais+=coordenadas
   
    return areas_fatais
                         

                   


def posicoes_inimigo(inimigo_pos):               
     
    possiveis_posicoes = [[inimigo_pos[0],inimigo_pos[1]], [inimigo_pos[0]-1,inimigo_pos[1]],
                          [inimigo_pos[0]+1,inimigo_pos[1]], [inimigo_pos[0],inimigo_pos[1]-1], 
                          [inimigo_pos[0],inimigo_pos[1]+1]] #Possíveis posições do inimigo
   
    return possiveis_posicoes                           






 
def fygar_fire(fygar):       
    posicoes_fogo = []
    max_alcance = 4 #alcance máximo do fogo

    fygar_pos = fygar["pos"] # Para simplificar a escrita

    for i in range(1,max_alcance+1):
        posicoes_fogo.append([fygar_pos[0]+i, fygar_pos[1]])
        posicoes_fogo.append([fygar_pos[0]-i, fygar_pos[1]])

    
    
    if fygar["dir"] == Direction.EAST:
        for i in range(1,max_alcance):
            posicoes_fogo.append([fygar_pos[0]+i, fygar_pos[1]-1])
            posicoes_fogo.append([fygar_pos[0]+i, fygar_pos[1]+1])


    elif fygar["dir"] == Direction.WEST:
         posicoes_fogo.append([fygar_pos[0]-i, fygar_pos[1]-1])
         posicoes_fogo.append([fygar_pos[0]-i, fygar_pos[1]+1])
     
    return posicoes_fogo



def condicoes_ataque(digdug_pos, digdug_direction,inimigo_mais_proximo,inimigos,rochas):
    key = ""
    alvos = {"Esquerda":[], "Direita":[], "Cima":[], "Baixo":[]}
    inimigo_mais_proximo_pos = inimigo_mais_proximo["pos"] #Simplificar escrita 
    direcoes_conts =[Direction.NORTH,Direction.SOUTH,Direction.WEST,Direction.EAST]
    direcoes = ["Cima","Baixo","Esquerda","Direita"]
   
    
        #Posições em que o digdug consegue atacar
    for i in range(1,alcance_max_ataque+1):  
        alvos["Esquerda"].append([digdug_pos[0]-i,digdug_pos[1]])
        alvos["Direita"].append([digdug_pos[0]+i,digdug_pos[1]])
        alvos["Cima"].append([digdug_pos[0],digdug_pos[1]-i])
        alvos["Baixo"].append([digdug_pos[0],digdug_pos[1]+i])

      
    inimigos_proximos_pos = [inimigo_mais_proximo_pos]

    for inimigo in inimigos:
        if math.floor(math.dist(digdug_pos, inimigo["pos"])) <= 4:
            inimigos_proximos_pos.append(inimigo["pos"])
          
        #Verificar se o dig dug pode atacar o inimigo mais próximo
    for i in range(0,len(direcoes)):
        if digdug_direction == direcoes_conts[i]:
            for alvo in alvos[direcoes[i]]:
                if alvo in inimigos_proximos_pos:
                    return 'A',digdug_direction
 
    if digdug_pos != inimigo_mais_proximo_pos:
        return ultimo_recruso(digdug_pos,inimigos,rochas,digdug_direction) #Devolve uma key  que não o mate, ou que não o deixe preso num impasse com um inimigo

    
    return key, digdug_direction




 #Esta função é usada quando o dig dug não consegue atacar o inimigo mais próximo, ou quando o digdug está preso num impasse com um inimigo
def ultimo_recruso(digdug_pos,inimigos,rochas,digdug_direction):       
     movimentos = posicoes_digdug(digdug_pos)
     
     key = ""

     
     areas_fatais = areas_perigosas(digdug_pos, inimigos, rochas)

     movimentos_seguros = ""
     for movimento, coordenadas in movimentos.items():
          if coordenadas not in areas_fatais:
            movimentos_seguros+=movimento

     if movimentos_seguros == "":
         return key, digdug_direction
     
 
     key = random.choice(movimentos_seguros) #Escolher um movimento aleatório que não o mate
     

     digdug_direction = obter_direcao(key,digdug_direction)
         

     return key, digdug_direction
     

    



def encontrar_inimigo_mais_proximo(digdug_pos,inimigos):                       
   return  min(inimigos,key=lambda inimigo:math.dist(digdug_pos,inimigo["pos"])) #Fómula euclideana da distância entre 2 pontos


def eixo_y(pos1,pos2):
    return abs(pos1 - pos2)


def eixo_x(pos1,pos2): 
    return abs(pos1 - pos2)
     
    
def movimentacao(digdug_pos, digdug_direction,inimigo_mais_proximo, keys_fatais,inimigo_mais_proximo_dist):                

        
        inimigo_mais_proximo_pos = inimigo_mais_proximo["pos"] #Simplificar escrita

        if digdug_pos[0] <= inimigo_mais_proximo_pos[0]:
            difx = eixo_x(inimigo_mais_proximo_pos[0], digdug_pos[0])  - alcance_max_ataque  
        else:
            difx = eixo_x(digdug_pos[0],inimigo_mais_proximo_pos[0]) + alcance_max_ataque

        if digdug_pos[1] <= inimigo_mais_proximo_pos[1]:
            dify = eixo_y(inimigo_mais_proximo_pos[1],digdug_pos[1]) - alcance_max_ataque
        else:
            dify = eixo_y(inimigo_mais_proximo_pos[1],digdug_pos[1]) + alcance_max_ataque

        if inimigo_mais_proximo["name"]=='Fygar':
            difx += alcance_max_ataque

        key=""
        inimigo_mais_proximo_dist = math.floor(inimigo_mais_proximo_dist)

        if  inimigo_mais_proximo_dist >= 4:   #Evitar diagonais , para evitar especialmente Pookas no modo transverse           
            if difx > dify:
                if  inimigo_mais_proximo_pos[0] > digdug_pos[0]:
                    if "d" not in keys_fatais:
                        key = "d"
                   
                    elif "w" not in keys_fatais:
                        key = "w"
                 
                    elif "s" not in  keys_fatais:
                        key = "s"
                    
                elif inimigo_mais_proximo_pos[0] < digdug_pos[0]:
                    if "a" not in keys_fatais:
                        key = "a"
                     
                    elif "w" not in keys_fatais:
                        key = "w"
                    
                    elif "s" not in keys_fatais:
                        key = "s"
                     
            else:
                if inimigo_mais_proximo_pos[1] > digdug_pos[1]:
                    if 's' not in keys_fatais:
                        key = "s"
                
                    elif 'a' not in keys_fatais:
                        key = "a"
                    
                    elif 'd' not in keys_fatais:
                        key = "d"
                     
                elif inimigo_mais_proximo_pos[1] <= digdug_pos[1]:
                    if 'w' not in keys_fatais:
                        key = "w"
                    
                    elif 'a' not in keys_fatais:
                        key = "a"
                  
                    elif 'd' not in keys_fatais:
                        key = "d"
                       
        
        elif inimigo_mais_proximo_dist > 2:
            if inimigo_mais_proximo_pos[1] > digdug_pos[1] and 's' not in keys_fatais:
                    key = "s"
                 
            elif inimigo_mais_proximo_pos[0] > digdug_pos[0] and "d" not in keys_fatais:
                    key = "d"
                   
            elif inimigo_mais_proximo_pos[1] < digdug_pos[1] and 'w' not in keys_fatais:
                    key = "w"
                  
            
            elif inimigo_mais_proximo_pos[0] <= digdug_pos[0] and "a" not in keys_fatais:
                    key = "a"
                  

        elif inimigo_mais_proximo_dist <= 2: #Desviar-se do inimigo mais próximo a esta distância corre-se o risco de o digdug falecer
            if inimigo_mais_proximo_pos[1] >= digdug_pos[1] and 'w' not in keys_fatais:
                    key = "w"
                 
            elif inimigo_mais_proximo_pos[1] < digdug_pos[1] and 's' not in keys_fatais:
                    key = "s"
                 
            elif inimigo_mais_proximo_pos[0] > digdug_pos[0] and "a" not in keys_fatais:
                    key = "a"
                 
            elif  inimigo_mais_proximo_pos[0] <=digdug_pos[0] and "d" not in keys_fatais:
                    key = "d"
                
        
        digdug_direction = obter_direcao(key,digdug_direction)
         
        return key, digdug_direction
                


def esquiva(digdug_pos, digdug_direction,areas_fatais):
    key = ""        
  

    movimentos = posicoes_digdug(digdug_pos) #Possíveis posições/movimentos do digdug
              
    movimento_fatal = ""   
                                    
    for key, coordenadas in movimentos.items():           
        if coordenadas in areas_fatais:                        
             movimento_fatal+=key

    
    for movimento in orientacoes:
        if movimento not in movimento_fatal:
            key = movimento
            digdug_direction = obter_direcao(key,digdug_direction)
            break
                                                                  
    return key, digdug_direction

    

def obter_tecla(state, digdug_direction,mapa):
   
    
    key = ""
    digdug_pos = state['digdug']
    inimigos = state['enemies']
    rochas = state['rocks']
    passos = state["step"]
    timeout = state["timeout"] #3000


    
    if len(inimigos) != 0:
            
        areas_fatais = areas_perigosas(digdug_pos, inimigos, rochas)


            
        if digdug_pos in areas_fatais:
            return esquiva(digdug_pos, digdug_direction, areas_fatais)
        

           
        inimigo_mais_proximo= encontrar_inimigo_mais_proximo(digdug_pos, inimigos)
           
                 
        inimigo_mais_proximo_dist = math.dist(digdug_pos, inimigo_mais_proximo["pos"]) #Distância Euclideana do inimigo mais próximo ao digdug
    
       

        if inimigo_mais_proximo_dist <=  alcance_max_ataque:
                   
            key, digdug_direction = condicoes_ataque( digdug_pos, digdug_direction,inimigo_mais_proximo,inimigos,rochas)
            if key == 'A' or len(key)>1:
        
                return key, digdug_direction
            
       
        if perto_time_out(passos,timeout):
            if inimigo_mais_proximo["name"] == "Fygar":
                if len(inimigos) == 1  or passos>= timeout- 500:
                    return bug_fygar(digdug_pos, digdug_direction, inimigo_mais_proximo) #Situação  muito especifica 
                                                                                         #em que o digdug não consegue matar o Fygar
                                                                                         #Fica preso num loop atacar um bloco do mapa
            else:
                inimigo_mais_proximo["pos"] = evitar_timeout(inimigo_mais_proximo,passos,timeout)
        
 
            
            
        movimentos = posicoes_digdug(digdug_pos)

        keys_fatais = ""
        for movimento, coordenadas in movimentos.items():
            if coordenadas in areas_fatais:
                keys_fatais+=movimento

        key, digdug_direction = movimentacao(digdug_pos, digdug_direction,inimigo_mais_proximo, keys_fatais,inimigo_mais_proximo_dist)


    return key, digdug_direction
    






async def agent_loop(server_address="localhost:8000", agent_name="student"):
    """Example client loop."""
    async with websockets.connect(f"ws://{server_address}/player") as websocket:
        # Receive information about static game properties
        await websocket.send(json.dumps({"cmd": "join", "name": agent_name}))

        
        digdug_direction = Direction.EAST
        digdug_steps = 0
        key_antiga = ""
        key=""

        while True:
            try:
                state = json.loads(await websocket.recv())# receive game update, this must be called timely or your game will get out of sync with the server


                if("digdug" not in state):
                  mapa = state["map"]
                else:
                  key, digdug_direction = obter_tecla(state, digdug_direction,mapa)
                
                  if key== "A" and key_antiga!= "A":
                    digdug_steps=0 #Resetar o contador de passos quando ataca e não atacou na jogada anterior

                  digdug_steps += 1
                  if digdug_steps >= 16: #Digdug ficou preso num impasse com um inimigo
                    key, digdug_direction = ultimo_recruso(state["digdug"],state["enemies"],state["rocks"],digdug_direction) 
                    digdug_steps=0

                  key_antiga = key
                


                await websocket.send(json.dumps({"cmd": "key", "key": key}))  # send key command to server - you must implement this send in the AI agent
                



            except websockets.exceptions.ConnectionClosedOK:
                print("Server has cleanly disconnected us")
                return

            


# DO NOT CHANGE THE LINES BELLOW
# You can change the default values using the command line, example:
# $ NAME='arrumador' python3 client.py
loop = asyncio.get_event_loop()
SERVER = os.environ.get("SERVER", "localhost")
PORT = os.environ.get("PORT", "8000")
NAME = os.environ.get("NAME", getpass.getuser())
loop.run_until_complete(agent_loop(f"{SERVER}:{PORT}", NAME))