import tkinter as tk
from tkinter import *
from abc import ABC, abstractmethod
from pynput import mouse
import time


click_coordinates = None

class View:
    def __init__(self, window, **kwargs):
        self.canvas = tk.Canvas(
            window,
            width=kwargs.get('width', 601),
            height=kwargs.get('height', 601),
            bg=kwargs.get('background', 'pink')
        )
        self.window = window 
        self.window.title(kwargs.get('title', 'Illustrating the minimum level graphical models'))
        self.canvas.pack()
        self.canvas.figures = []
        self.figure_ids = {}





    def refresh(self,**kwargs):
        self.kwargs = kwargs

        if 'time' in self.kwargs:
            time.sleep(self.kwargs['time'])
            self.refresh()
            return


        for figure in self.canvas.figures:
            id = figure.draw(self.canvas)
            self.figure_ids[figure] = id
        self.canvas.figures.clear()
        self.canvas.update()

    def add(self, figure):
        self.canvas.figures.append(figure)
        
    def close(self):
        self.canvas.quit()
        self.canvas.destroy()
        self.window.destroy()

    def move(self, point):
        for id in self.figure_ids.values():
            self.canvas.move(id, -point[0], point[1])
            
        
class Figure(ABC):
    @abstractmethod
    def __init__(self,point): 
        self.x = point[0]
        self.y = point[1]
        self.canvas = None
        self.id = None
           
    def draw(self, canvas):
        pass

    def move(self, point):
        pass

    def remove(self):
        if self.id is not None and self.canvas is not None:
            self.canvas.delete(self.id)
            self.id = None

class Dot(Figure):
    def __init__(self,point, **kwargs):
        super().__init__(point)
        self.kwargs = kwargs

    def draw(self, canvas):
        self.canvas = canvas
        self.id = canvas.create_polygon(self.x, self.y, self.x+1, self.y, self.x+1, self.y+1, self.x, self.y+1, fill=self.kwargs.get('fill', 'lime'))
        return self.id
    
    def move(self, point):
        self.x += point[0]
        self.y -= point[1]
        self.remove()
        self.draw(self.canvas)

class Line(Figure):
    def __init__(self, point, **kwargs):
        super().__init__(point)
        self.length = kwargs.get('length',(100,100))
        self.kwargs = kwargs

    def draw(self, canvas):
        self.canvas = canvas
        self.id = canvas.create_polygon(self.x, self.y, self.length[0], self.length[1], fill=self.kwargs.get('fill', 'red'), outline=self.kwargs.get('outline', 'black'))
        return self.id
    
    def move (self, point):
        self.x += point[0]
        self.y -= point[1]
        self.length = (self.length[0] + point[0], self.length[1] - point[1])
        self.remove()
        self.draw(self.canvas)

class Rectangle(Figure):
    def __init__(self, point, **kwargs):
        super().__init__(point)
        self.length = kwargs.get('length',(100,100))
        self.kwargs = kwargs

    def draw(self, canvas):
        self.canvas = canvas
        self.id = canvas.create_polygon(self.x, self.y, self.length[0], self.y, self.length[0], self.length[1], self.x, self.length[1], fill=self.kwargs.get("fill","orange"),outline= self.kwargs.get('outline', 'black'))
        return self.id

    def move(self, point):
        self.x += point[0]
        self.y -= point[1]
        self.length = (self.length[0] + point[0], self.length[1] - point[1])
        self.remove()
        self.draw(self.canvas)


class Ellipse(Figure):
    def __init__(self, point, **kwargs):
        super().__init__(point)
        self.length = kwargs.get('length',(100,100))
        self.kwargs = kwargs

    def draw(self, canvas):
        self.canvas = canvas
        self.id  = canvas.create_oval(self.x, self.y, self.length[0], self.length[1], fill=self.kwargs.get('fill', 'purple'), outline=self.kwargs.get('outline', 'black'))
        return self.id
    
    def move(self, point):
        self.x += point[0]
        self.y -= point[1]
        self.length = (self.length[0] + point[0], self.length[1] - point[1])
        self.remove()
        self.draw(self.canvas)

class Text(Figure):
    def __init__(self, point, **kwargs):
        super().__init__(point)
        self.kwargs = kwargs

    def draw(self, canvas):
        self.canvas = canvas
        self.id = canvas.create_text(self.x, self.y, text=self.kwargs.get("text", "QUERO 20 A COMPILADORES"), fill=self.kwargs.get('fill', 'black'))
        return self.id 
    
    def move(self, point):
        self.x += point[0]
        self.y -= point[1]
        self.remove()
        self.draw(self.canvas)

class Arc(Figure):
    def __init__(self, point, **kwargs):
        super().__init__(point)
        self.length = kwargs.get('length',(100,100))
        self.kwargs = kwargs

    def draw(self, canvas):
       self.canvas = canvas
       self.id = canvas.create_arc(self.x, self.y, self.length[0], self.length[1], start=self.kwargs.get("start",50), extent=self.kwargs.get("extent",50), fill=self.kwargs.get("fill","green"), outline=self.kwargs.get('outline', 'black'))
       return self.id
    
    def move(self, point):
        self.x += point[0]
        self.y -= point[1]
        self.length = (self.length[0] + point[0], self.length[1] - point[1])
        self.remove()
        self.draw(self.canvas)

class ArcChord(Figure):
    def __init__(self, point ,**kwargs):
        super().__init__(point)
        self.length = kwargs.get('length',(100,100))
        self.kwargs = kwargs

    def draw(self, canvas):
        self.canvas = canvas
        self.id = canvas.create_arc(self.x, self.y, self.length[0], self.length[1], start=self.kwargs.get("start",50), extent=self.kwargs.get("extent",50), fill=self.kwargs.get("fill","cyan"), outline=self.kwargs.get('outline', 'black'), style=tk.CHORD)
        return self.id
    
    def move(self, point):
        self.x += point[0]
        self.y -= point[1]
        self.length = (self.length[0] + point[0], self.length[1] - point[1])
        self.remove()
        self.draw(self.canvas)

class PieSlice(Figure):
    def __init__(self, point, **kwargs):
        super().__init__(point)
        self.length = kwargs.get('length',(100,100))
        self.kwargs = kwargs

    def draw(self, canvas):
        self.canvas = canvas
        self.id = canvas.create_arc(self.x, self.y, self.length[0], self.length[1], start=self.kwargs.get("start",50), extent=self.kwargs.get("extent",50), fill=self.kwargs.get("fill","blue"), outline=self.kwargs.get('outline', 'black'), style=tk.PIESLICE)
        return self.id
    
    def move(self, point):
        self.x += point[0]
        self.y -= point[1] 
        self.length = (self.length[0] + point[0], self.length[1] - point[1])
        self.remove()
        self.draw(self.canvas)


class ClickListener:
    def __init__(self):
        self.click_coordinates = None

    def on_click(self, x, y, pressed,*args):
        if pressed:
            self.click_coordinates = (x, y)
        
            return False 

    def wait_for_click(self):
        print("wait mouse click")
        with mouse.Listener(on_click=self.on_click) as listener:
            listener.join()
        return self.click_coordinates