# Generated from xagl.g4 by ANTLR 4.13.1
from antlr4 import *
if "." in __name__:
    from .xaglParser import xaglParser
else:
    from xaglParser import xaglParser

# This class defines a complete listener for a parse tree produced by xaglParser.
class xaglListener(ParseTreeListener):

    # Enter a parse tree produced by xaglParser#program.
    def enterProgram(self, ctx:xaglParser.ProgramContext):
        pass

    # Exit a parse tree produced by xaglParser#program.
    def exitProgram(self, ctx:xaglParser.ProgramContext):
        pass


    # Enter a parse tree produced by xaglParser#statement.
    def enterStatement(self, ctx:xaglParser.StatementContext):
        pass

    # Exit a parse tree produced by xaglParser#statement.
    def exitStatement(self, ctx:xaglParser.StatementContext):
        pass


    # Enter a parse tree produced by xaglParser#for.
    def enterFor(self, ctx:xaglParser.ForContext):
        pass

    # Exit a parse tree produced by xaglParser#for.
    def exitFor(self, ctx:xaglParser.ForContext):
        pass


    # Enter a parse tree produced by xaglParser#ExprComparison.
    def enterExprComparison(self, ctx:xaglParser.ExprComparisonContext):
        pass

    # Exit a parse tree produced by xaglParser#ExprComparison.
    def exitExprComparison(self, ctx:xaglParser.ExprComparisonContext):
        pass


    # Enter a parse tree produced by xaglParser#Exprpoint.
    def enterExprpoint(self, ctx:xaglParser.ExprpointContext):
        pass

    # Exit a parse tree produced by xaglParser#Exprpoint.
    def exitExprpoint(self, ctx:xaglParser.ExprpointContext):
        pass


    # Enter a parse tree produced by xaglParser#ExprString.
    def enterExprString(self, ctx:xaglParser.ExprStringContext):
        pass

    # Exit a parse tree produced by xaglParser#ExprString.
    def exitExprString(self, ctx:xaglParser.ExprStringContext):
        pass


    # Enter a parse tree produced by xaglParser#ExprParent.
    def enterExprParent(self, ctx:xaglParser.ExprParentContext):
        pass

    # Exit a parse tree produced by xaglParser#ExprParent.
    def exitExprParent(self, ctx:xaglParser.ExprParentContext):
        pass


    # Enter a parse tree produced by xaglParser#ExprInt.
    def enterExprInt(self, ctx:xaglParser.ExprIntContext):
        pass

    # Exit a parse tree produced by xaglParser#ExprInt.
    def exitExprInt(self, ctx:xaglParser.ExprIntContext):
        pass


    # Enter a parse tree produced by xaglParser#ExprNot.
    def enterExprNot(self, ctx:xaglParser.ExprNotContext):
        pass

    # Exit a parse tree produced by xaglParser#ExprNot.
    def exitExprNot(self, ctx:xaglParser.ExprNotContext):
        pass


    # Enter a parse tree produced by xaglParser#ExprMultDivMod.
    def enterExprMultDivMod(self, ctx:xaglParser.ExprMultDivModContext):
        pass

    # Exit a parse tree produced by xaglParser#ExprMultDivMod.
    def exitExprMultDivMod(self, ctx:xaglParser.ExprMultDivModContext):
        pass


    # Enter a parse tree produced by xaglParser#ExprAddSub.
    def enterExprAddSub(self, ctx:xaglParser.ExprAddSubContext):
        pass

    # Exit a parse tree produced by xaglParser#ExprAddSub.
    def exitExprAddSub(self, ctx:xaglParser.ExprAddSubContext):
        pass


    # Enter a parse tree produced by xaglParser#ExprLogical.
    def enterExprLogical(self, ctx:xaglParser.ExprLogicalContext):
        pass

    # Exit a parse tree produced by xaglParser#ExprLogical.
    def exitExprLogical(self, ctx:xaglParser.ExprLogicalContext):
        pass


    # Enter a parse tree produced by xaglParser#ExprUnary.
    def enterExprUnary(self, ctx:xaglParser.ExprUnaryContext):
        pass

    # Exit a parse tree produced by xaglParser#ExprUnary.
    def exitExprUnary(self, ctx:xaglParser.ExprUnaryContext):
        pass


    # Enter a parse tree produced by xaglParser#Exprtime.
    def enterExprtime(self, ctx:xaglParser.ExprtimeContext):
        pass

    # Exit a parse tree produced by xaglParser#Exprtime.
    def exitExprtime(self, ctx:xaglParser.ExprtimeContext):
        pass


    # Enter a parse tree produced by xaglParser#Exprvector.
    def enterExprvector(self, ctx:xaglParser.ExprvectorContext):
        pass

    # Exit a parse tree produced by xaglParser#Exprvector.
    def exitExprvector(self, ctx:xaglParser.ExprvectorContext):
        pass


    # Enter a parse tree produced by xaglParser#Exprnumber.
    def enterExprnumber(self, ctx:xaglParser.ExprnumberContext):
        pass

    # Exit a parse tree produced by xaglParser#Exprnumber.
    def exitExprnumber(self, ctx:xaglParser.ExprnumberContext):
        pass


    # Enter a parse tree produced by xaglParser#ExprBool.
    def enterExprBool(self, ctx:xaglParser.ExprBoolContext):
        pass

    # Exit a parse tree produced by xaglParser#ExprBool.
    def exitExprBool(self, ctx:xaglParser.ExprBoolContext):
        pass


    # Enter a parse tree produced by xaglParser#ExprID.
    def enterExprID(self, ctx:xaglParser.ExprIDContext):
        pass

    # Exit a parse tree produced by xaglParser#ExprID.
    def exitExprID(self, ctx:xaglParser.ExprIDContext):
        pass


    # Enter a parse tree produced by xaglParser#variable_assignment.
    def enterVariable_assignment(self, ctx:xaglParser.Variable_assignmentContext):
        pass

    # Exit a parse tree produced by xaglParser#variable_assignment.
    def exitVariable_assignment(self, ctx:xaglParser.Variable_assignmentContext):
        pass


    # Enter a parse tree produced by xaglParser#view_action_refresh.
    def enterView_action_refresh(self, ctx:xaglParser.View_action_refreshContext):
        pass

    # Exit a parse tree produced by xaglParser#view_action_refresh.
    def exitView_action_refresh(self, ctx:xaglParser.View_action_refreshContext):
        pass


    # Enter a parse tree produced by xaglParser#move_variable.
    def enterMove_variable(self, ctx:xaglParser.Move_variableContext):
        pass

    # Exit a parse tree produced by xaglParser#move_variable.
    def exitMove_variable(self, ctx:xaglParser.Move_variableContext):
        pass


    # Enter a parse tree produced by xaglParser#move_expr.
    def enterMove_expr(self, ctx:xaglParser.Move_exprContext):
        pass

    # Exit a parse tree produced by xaglParser#move_expr.
    def exitMove_expr(self, ctx:xaglParser.Move_exprContext):
        pass


    # Enter a parse tree produced by xaglParser#refresh.
    def enterRefresh(self, ctx:xaglParser.RefreshContext):
        pass

    # Exit a parse tree produced by xaglParser#refresh.
    def exitRefresh(self, ctx:xaglParser.RefreshContext):
        pass


    # Enter a parse tree produced by xaglParser#view.
    def enterView(self, ctx:xaglParser.ViewContext):
        pass

    # Exit a parse tree produced by xaglParser#view.
    def exitView(self, ctx:xaglParser.ViewContext):
        pass


    # Enter a parse tree produced by xaglParser#vector.
    def enterVector(self, ctx:xaglParser.VectorContext):
        pass

    # Exit a parse tree produced by xaglParser#vector.
    def exitVector(self, ctx:xaglParser.VectorContext):
        pass


    # Enter a parse tree produced by xaglParser#point.
    def enterPoint(self, ctx:xaglParser.PointContext):
        pass

    # Exit a parse tree produced by xaglParser#point.
    def exitPoint(self, ctx:xaglParser.PointContext):
        pass


    # Enter a parse tree produced by xaglParser#time.
    def enterTime(self, ctx:xaglParser.TimeContext):
        pass

    # Exit a parse tree produced by xaglParser#time.
    def exitTime(self, ctx:xaglParser.TimeContext):
        pass



del xaglParser