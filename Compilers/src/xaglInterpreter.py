import sys
from antlr4 import *
from xaglLexer import xaglLexer
from xaglParser import xaglParser
from xaglVisitor import xaglVisitor
import tkinter as tk
from tkinter import *
from agl_library import *

class xaglInterpreter(xaglVisitor):
    def __init__(self, view=None):
        self.view = view
        self.variables = {}

    def visitProgram(self, ctx:xaglParser.ProgramContext):
        return self.visitChildren(ctx)

    def visitStatement(self, ctx:xaglParser.StatementContext):
        return self.visitChildren(ctx)

    def visitFor(self, ctx:xaglParser.ForContext):
        var = ctx.ID().getText()
        start = self.visit(ctx.expr(0))
        end = self.visit(ctx.expr(1))
        for i in range(start, end + 1):
            self.variables[var] = i
            for stmt in ctx.statement():
                self.visit(stmt)
        return None

    def visitExprID(self, ctx:xaglParser.ExprIDContext):
        var = ctx.getText()
        if var in self.variables:
            return self.variables[var]
        return 0

    def visitExprInt(self, ctx:xaglParser.ExprIntContext):
        return int(ctx.getText())

    def visitExprnumber(self, ctx:xaglParser.ExprnumberContext):
        return float(ctx.getText())

    def visitExprvector(self, ctx:xaglParser.ExprvectorContext):
        x = self.visit(ctx.expr(0))
        y = self.visit(ctx.expr(1))
        return (x, y)

    def visitExprString(self, ctx:xaglParser.ExprStringContext):
        return ctx.getText().strip('"')

    def visitVariable_assignment(self, ctx:xaglParser.Variable_assignmentContext):
        obj = ctx.ID(0).getText()
        prop = ctx.ID(1).getText()
        value = self.visit(ctx.expr())
        if obj not in self.variables:
            self.variables[obj] = {}
        self.variables[obj][prop] = value
        return None

    def visitView_action_refresh(self, ctx:xaglParser.View_action_refreshContext):
        return self.visit(ctx.refresh())

    def visitMove_variable(self, ctx:xaglParser.Move_variableContext):
        obj = ctx.ID().getText()
        vector = self.visit(ctx.expr())
        print(f"Moving {obj} by {vector}")
        return None

    def visitMove_expr(self, ctx:xaglParser.Move_exprContext):
        view = ctx.view().getText()
        vector = self.visit(ctx.expr())
        print(f"Moving view {view} by {vector}")
        return None

    def visitRefresh(self, ctx:xaglParser.RefreshContext):
        if ctx.ID():
            view_name = ctx.ID().getText()
        else:
            view_name = self.visit(ctx.view())
        
        view = self.variables.get(view_name)
        
        if view:
            print(f"Refresh {view_name}")
            view.refresh()
        else:
            print(f"View {view_name} not found")
        return None

    def visitExprComparison(self, ctx:xaglParser.ExprComparisonContext):
        left = self.visit(ctx.expr(0))
        right = self.visit(ctx.expr(1))
        op = ctx.op.text

        if op == '==':
            return left == right
        elif op == '!=':
            return left != right
        elif op == '>':
            return left > right
        elif op == '<':
            return left < right
        elif op == '>=':
            return left >= right
        elif op == '<=':
            return left <= right
        return None

    def visitExprpoint(self, ctx:xaglParser.ExprpointContext):
        return self.visit(ctx.point())

    def visitExprParent(self, ctx:xaglParser.ExprParentContext):
        return self.visit(ctx.expr())

    def visitExprNot(self, ctx:xaglParser.ExprNotContext):
        return not self.visit(ctx.expr())

    def visitExprMultDivMod(self, ctx:xaglParser.ExprMultDivModContext):
        left = self.visit(ctx.expr(0))
        right = self.visit(ctx.expr(1))
        op = ctx.op.text

        if op == '*':
            return left * right
        elif op == '/':
            return left / right
        elif op == '//':
            return left // right
        elif op == '%':
            return left % right
        return None

    def visitExprAddSub(self, ctx:xaglParser.ExprAddSubContext):
        left = self.visit(ctx.expr(0))
        right = self.visit(ctx.expr(1))
        op = ctx.op.text

        if op == '+':
            return left + right
        elif op == '-':
            return left - right
        return None

    def visitExprLogical(self, ctx:xaglParser.ExprLogicalContext):
        left = self.visit(ctx.expr(0))
        right = self.visit(ctx.expr(1))
        op = ctx.op.text

        if op == 'and':
            return left and right
        elif op == 'or':
            return left or right
        return None

    def visitExprUnary(self, ctx:xaglParser.ExprUnaryContext):
        val = self.visit(ctx.expr())
        if ctx.uop.text == '-':
            return -val
        elif ctx.uop.text == '+':
            return +val
        return val

    def visitExprtime(self, ctx:xaglParser.ExprtimeContext):
        return int(ctx.INT().getText()) * (1000 if ctx.unit.text == 's' else 1)

    def visitExprBool(self, ctx:xaglParser.ExprBoolContext):
        return ctx.BOOL().getText() == 'True'

    def visitVector(self, ctx:xaglParser.VectorContext):
        return (self.visit(ctx.expr(0)), self.visit(ctx.expr(1)))

    def visitPoint(self, ctx:xaglParser.PointContext):
        return (self.visit(ctx.expr(0)), self.visit(ctx.expr(1)))

    def visitTime(self, ctx:xaglParser.TimeContext):
        return self.visit(ctx.INT()) * (1000 if ctx.unit.text == 's' else 1)

    def visitView(self, ctx:xaglParser.ViewContext):
        view_name = ctx.ID().getText()
        if view_name in self.variables:
            return self.variables[view_name]
        return None

def main(argv):
    # Initialize your view and other necessary objects here
    root = tk.Tk()
    root.withdraw()  # Hide the main window
    top = tk.Toplevel()

    view = View(top, width=601, height=601, title="Illustrating the minimum level graphical models", background="alice blue")
    
    # Add initial figures to the view
    view.add(Line((50, 50), length=(150, 150), fill="red"))
    view.add(Rectangle((200, 200), length=(250, 250), fill="orange"))

    # Store the view in the interpreter
    interpreter = xaglInterpreter(view)
    interpreter.variables["mainView"] = view  # Assuming 'mainView' is the ID used in xAGL

    # Load the script written in xAGL
    input_file = argv[1] if len(argv) > 1 else 'script.xagl'
    lexer = xaglLexer(FileStream(input_file))
    stream = CommonTokenStream(lexer)
    parser = xaglParser(stream)
    tree = parser.program()

    # Execute the script
    interpreter.visit(tree)

    # Run the tkinter main loop
    root.mainloop()

if __name__ == "__main__":
    main(sys.argv)
