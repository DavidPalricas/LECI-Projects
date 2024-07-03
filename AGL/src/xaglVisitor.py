# Generated from xagl.g4 by ANTLR 4.13.1
from antlr4 import *
if "." in __name__:
    from .xaglParser import xaglParser
else:
    from xaglParser import xaglParser

# This class defines a complete generic visitor for a parse tree produced by xaglParser.

class xaglVisitor(ParseTreeVisitor):

    # Visit a parse tree produced by xaglParser#program.
    def visitProgram(self, ctx:xaglParser.ProgramContext):
        return self.visitChildren(ctx)


    # Visit a parse tree produced by xaglParser#statement.
    def visitStatement(self, ctx:xaglParser.StatementContext):
        return self.visitChildren(ctx)


    # Visit a parse tree produced by xaglParser#for.
    def visitFor(self, ctx:xaglParser.ForContext):
        return self.visitChildren(ctx)


    # Visit a parse tree produced by xaglParser#ExprComparison.
    def visitExprComparison(self, ctx:xaglParser.ExprComparisonContext):
        return self.visitChildren(ctx)


    # Visit a parse tree produced by xaglParser#Exprpoint.
    def visitExprpoint(self, ctx:xaglParser.ExprpointContext):
        return self.visitChildren(ctx)


    # Visit a parse tree produced by xaglParser#ExprString.
    def visitExprString(self, ctx:xaglParser.ExprStringContext):
        return self.visitChildren(ctx)


    # Visit a parse tree produced by xaglParser#ExprParent.
    def visitExprParent(self, ctx:xaglParser.ExprParentContext):
        return self.visitChildren(ctx)


    # Visit a parse tree produced by xaglParser#ExprInt.
    def visitExprInt(self, ctx:xaglParser.ExprIntContext):
        return self.visitChildren(ctx)


    # Visit a parse tree produced by xaglParser#ExprNot.
    def visitExprNot(self, ctx:xaglParser.ExprNotContext):
        return self.visitChildren(ctx)


    # Visit a parse tree produced by xaglParser#ExprMultDivMod.
    def visitExprMultDivMod(self, ctx:xaglParser.ExprMultDivModContext):
        return self.visitChildren(ctx)


    # Visit a parse tree produced by xaglParser#ExprAddSub.
    def visitExprAddSub(self, ctx:xaglParser.ExprAddSubContext):
        return self.visitChildren(ctx)


    # Visit a parse tree produced by xaglParser#ExprLogical.
    def visitExprLogical(self, ctx:xaglParser.ExprLogicalContext):
        return self.visitChildren(ctx)


    # Visit a parse tree produced by xaglParser#ExprUnary.
    def visitExprUnary(self, ctx:xaglParser.ExprUnaryContext):
        return self.visitChildren(ctx)


    # Visit a parse tree produced by xaglParser#Exprtime.
    def visitExprtime(self, ctx:xaglParser.ExprtimeContext):
        return self.visitChildren(ctx)


    # Visit a parse tree produced by xaglParser#Exprvector.
    def visitExprvector(self, ctx:xaglParser.ExprvectorContext):
        return self.visitChildren(ctx)


    # Visit a parse tree produced by xaglParser#Exprnumber.
    def visitExprnumber(self, ctx:xaglParser.ExprnumberContext):
        return self.visitChildren(ctx)


    # Visit a parse tree produced by xaglParser#ExprBool.
    def visitExprBool(self, ctx:xaglParser.ExprBoolContext):
        return self.visitChildren(ctx)


    # Visit a parse tree produced by xaglParser#ExprID.
    def visitExprID(self, ctx:xaglParser.ExprIDContext):
        return self.visitChildren(ctx)


    # Visit a parse tree produced by xaglParser#variable_assignment.
    def visitVariable_assignment(self, ctx:xaglParser.Variable_assignmentContext):
        return self.visitChildren(ctx)


    # Visit a parse tree produced by xaglParser#view_action_refresh.
    def visitView_action_refresh(self, ctx:xaglParser.View_action_refreshContext):
        return self.visitChildren(ctx)


    # Visit a parse tree produced by xaglParser#move_variable.
    def visitMove_variable(self, ctx:xaglParser.Move_variableContext):
        return self.visitChildren(ctx)


    # Visit a parse tree produced by xaglParser#move_expr.
    def visitMove_expr(self, ctx:xaglParser.Move_exprContext):
        return self.visitChildren(ctx)


    # Visit a parse tree produced by xaglParser#refresh.
    def visitRefresh(self, ctx:xaglParser.RefreshContext):
        return self.visitChildren(ctx)


    # Visit a parse tree produced by xaglParser#view.
    def visitView(self, ctx:xaglParser.ViewContext):
        return self.visitChildren(ctx)


    # Visit a parse tree produced by xaglParser#vector.
    def visitVector(self, ctx:xaglParser.VectorContext):
        return self.visitChildren(ctx)


    # Visit a parse tree produced by xaglParser#point.
    def visitPoint(self, ctx:xaglParser.PointContext):
        return self.visitChildren(ctx)


    # Visit a parse tree produced by xaglParser#time.
    def visitTime(self, ctx:xaglParser.TimeContext):
        return self.visitChildren(ctx)



del xaglParser