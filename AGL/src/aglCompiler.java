import org.stringtemplate.v4.*;
import java.io.File;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.HashSet;
import java.util.Iterator;
import java.util.List;
import java.util.Map;
import java.util.Set;
import org.antlr.v4.runtime.tree.TerminalNode;


@SuppressWarnings("CheckReturnValue")
public class aglCompiler extends aglBaseVisitor<ST> {

   String store_view;
   Boolean isvarfigure = false;

   protected STGroup stg = new STGroupFile("python.stg");
   protected ST result = null;
   
   @Override public ST visitProgram(aglParser.ProgramContext ctx) {
      
      result = stg.getInstanceOf("program");
      for (aglParser.StatContext stat : ctx.stat()) {
         ST st = visit(stat);
         result.add("stat", st.render());
      }
      return result;
   }

   @Override public ST visitStat(aglParser.StatContext ctx) {
      return visitChildren(ctx);
   }

   @Override public ST visitFor(aglParser.ForContext ctx) {
      ST res = stg.getInstanceOf("for");
      res.add("id", ctx.ID().getText());
      res.add("expr1", visit(ctx.expr(0)).render());
      res.add("expr2", visit(ctx.expr(1)).render());
      for (aglParser.StatContext stat : ctx.stat()) {
         ST st = visit(stat);
         res.add("statements", st.render());
      }
      return res;
   }

   @Override public ST visitExprComparison(aglParser.ExprComparisonContext ctx) {
      ST res = new ST ("<expr1> <op> <expr2>");
      res.add("expr1", visit(ctx.expr(0)).render());
      res.add("op", ctx.op.getText());
      res.add("expr2", visit(ctx.expr(1)).render());
      return res;
   }

   @Override public ST visitExprpoint(aglParser.ExprpointContext ctx) {
      ST point = visit(ctx.point());
      return point;
   }

   @Override public ST visitExprnumber(aglParser.ExprnumberContext ctx) {
      ST res = new ST ("<number>");
      res.add("number", ctx.NUMBER().getText());
      return res;
   }

   @Override public ST visitExprString(aglParser.ExprStringContext ctx) {
      ST res = new ST ("<string>");
      res.add("string", ctx.STRING().getText());
      return res;
   }

   @Override public ST visitExprParent(aglParser.ExprParentContext ctx) {
      ST res = new ST ("(<parent>)");
      res.add("parent", visit(ctx.expr()).render());
      return res;
   }

   @Override public ST visitExprInt(aglParser.ExprIntContext ctx) {
      ST res = new ST ("<int>");
      res.add("int", ctx.INT().getText());
      return res;
   }

   @Override public ST visitExprNot(aglParser.ExprNotContext ctx) {
      ST res = new ST ("not(<expr>)");
      res.add("expr", visit(ctx.expr()).render());
      return res;
   }

   @Override public ST visitExprMultDivMod(aglParser.ExprMultDivModContext ctx) {
      ST res = new ST ("<expr1> <op> <expr2>");
      res.add("expr1", visit(ctx.expr(0)).render());
      res.add("op", ctx.op.getText());
      res.add("expr2", visit(ctx.expr(1)).render());
      return res;
   }

   @Override public ST visitExprAddSub(aglParser.ExprAddSubContext ctx) {
      ST res = new ST ("<expr1> <op> <expr2>");
      res.add("expr1", visit(ctx.expr(0)).render());
      res.add("op", ctx.op.getText());
      res.add("expr2", visit(ctx.expr(1)).render());
      return res;
   }

   @Override public ST visitExprLogical(aglParser.ExprLogicalContext ctx) {
      ST res = new ST ("<expr1> <op> <expr2>");
      res.add("expr1", visit(ctx.expr(0)).render());
      res.add("op", ctx.op.getText());
      res.add("expr2", visit(ctx.expr(1)).render());
      return res;
   }

   @Override public ST visitExprUnary(aglParser.ExprUnaryContext ctx) {
      ST res =  new ST("<op>(<expr>)");
      res.add("op", ctx.uop.getText());
      res.add("expr", visit(ctx.expr()).render());
      return res;
   }

   @Override public ST visitExprtime(aglParser.ExprtimeContext ctx) {
      ST res = visit(ctx.time());
      return res;
   }

   @Override public ST visitExprvector(aglParser.ExprvectorContext ctx) {
      ST res = visit(ctx.vector());
      return res;
   }

   @Override public ST visitExprBool(aglParser.ExprBoolContext ctx) {
      ST res = new ST ("<bool>");
      res.add("bool", ctx.BOOL().getText());
      return res;
   }

   @Override public ST visitExprID(aglParser.ExprIDContext ctx) {
      ST res = new ST ("<id>");
      res.add("id", ctx.ID().getText());
      return res;
   }

   @Override public ST visitPrint(aglParser.PrintContext ctx) {
      ST res = new ST ("print(<expr>)");
      res.add("expr", ctx.txt.getText());
      return res;
   }
   
   @Override public ST visitVardefault(aglParser.VardefaultContext ctx) {
      ST res = new ST ("<var> = <expr>");
      res.add("var", ctx.ID().getText());
      if (ctx.wait_command() != null)
         res.add("expr", visit(ctx.wait_command()).render());
      else 
         res.add("expr", visit(ctx.expr()).render());
      return res;
   }
   
   @Override public ST visitVartype(aglParser.VartypeContext ctx) {
      ST res = new ST ("<var> = <expr>");
      res.add("var", ctx.ID().getText());
      if (ctx.wait_command() != null)
         res.add("expr", visit(ctx.wait_command()).render());
      else 
         res.add("expr", visit(ctx.expr()).render());
      return res;
   }

   @Override public ST visitVarfigure(aglParser.VarfigureContext ctx) {
      ST res = stg.getInstanceOf("varfigure");
      isvarfigure = true;
      res.add("figure_name", ctx.ID().getText());
      res.add("figure", visit(ctx.figures()).render());
      res.add("bool", isvarfigure);
      res.add("view_name", store_view);
      isvarfigure = false;
      return res;
   }

   @Override public ST visitVariable_parameters(aglParser.Variable_parametersContext ctx) {
      ST res = new ST ("<var>.state=<expr>"); 
      res.add("var", ctx.ID().getText());
      res.add("expr", visit(ctx.state()).render());
      return res;
   }

   @Override public ST visitState(aglParser.StateContext ctx) {
      ST res = new ST ("<state>");
      res.add("state", ctx.STRING().getText());
      return res;
   }

   @Override public ST visitType(aglParser.TypeContext ctx) {
      ST res = new ST ("<type>");
      res.add("type", ctx.getText());
      return res;
   }

   @Override public ST visitFigures_expr(aglParser.Figures_exprContext ctx) {
      ST res = stg.getInstanceOf("figures_expr");
      res.add("figure", visit(ctx.figure()).render());
      res.add("expr", visit(ctx.expr()).render());
      res.add("bool", isvarfigure);
      res.add("view_name", store_view);
    
      return res;
   }

   @Override public ST visitFigures_expr_with(aglParser.Figures_expr_withContext ctx) {
      ST res = stg.getInstanceOf("figures_expr_with");
      res.add("figure", visit(ctx.figure()).render());
      res.add("expr", visit(ctx.expr()).render());
      res.add("with_operator", visit(ctx.with_operator()).render());
      res.add("bool", isvarfigure);
      res.add("view_name", store_view);
      
      return res;
   }

   @Override public ST visitFigure(aglParser.FigureContext ctx) {
      ST res = new ST ("<figure>");
      res.add("figure", ctx.getText());
      return res;
   }

   @Override public ST visitFigures_params_length(aglParser.Figures_params_lengthContext ctx) {
      ST res = new ST ("<length>");
      res.add("length", visit(ctx.length()).render());
      return res;
   }

   @Override public ST visitFigures_params_angles(aglParser.Figures_params_anglesContext ctx) {
      ST res = new ST ("<angles>");
      res.add("angles", visit(ctx.figure_angles()).render());
      return res;
   }

   @Override public ST visitFigures_params_colors(aglParser.Figures_params_colorsContext ctx) {
      ST res = new ST ("<colors>");
      res.add("colors", visit(ctx.figure_colors()).render());
      return res;
   }

   @Override public ST visitFigures_params_text(aglParser.Figures_params_textContext ctx) {
      ST res = new ST ("<text>");
      res.add("text", visit(ctx.text()).render());
      return res;
   }

   @Override public ST visitFigure_angles(aglParser.Figure_anglesContext ctx) {
      ST res = stg.getInstanceOf("figure_angles");
      res.add("angle_param", ctx.angle_param.getText());
      res.add("expr", visit(ctx.expr()).render());
      return res;
   }

   @Override public ST visitFigure_colors(aglParser.Figure_colorsContext ctx) {
      ST res = stg.getInstanceOf("figure_colors");
      res.add("color_param", ctx.color_param.getText());
      res.add("color", visit(ctx.color()).render());
      return res;
   }

   @Override public ST visitLength(aglParser.LengthContext ctx) {
      ST res = stg.getInstanceOf("length");
      res.add("expr", visit(ctx.expr()).render());
      return res;
   }

   @Override public ST visitText(aglParser.TextContext ctx) {
      ST res = stg.getInstanceOf("text");
      res.add("expr", visit(ctx.expr()).render());
      return res;
   }

   @Override public ST visitView_action_refresh(aglParser.View_action_refreshContext ctx) {
      ST res = visit(ctx.refresh());
      return res;
   }

   @Override public ST visitView_action_close(aglParser.View_action_closeContext ctx) {
      ST res = visit(ctx.close());
      return res;
   }


   @Override public ST visitClose(aglParser.CloseContext ctx) {
      ST res = new ST ("<ID>.close()");
      res.add("ID", ctx.ID().getText());
      return res;
   }

   @Override public ST visitMovevar(aglParser.MovevarContext ctx) {
      ST res = new ST ("<ID>.move(<point>)");
      res.add("ID", ctx.ID().getText());
      res.add("point", visit(ctx.expr()).render());
      return res;
   }

   @Override public ST visitMoveview(aglParser.MoveviewContext ctx) {
      ST res = null;
      return visitChildren(ctx);
      //return res;
   }
   @Override public ST visitMovefigure(aglParser.MovefigureContext ctx) {
      ST res = null;
      return visitChildren(ctx);
      //return res;
   }

   @Override public ST visitRefresh_default(aglParser.Refresh_defaultContext ctx) {
      ST res = new ST ("<ID>.refresh()");
      res.add("ID", ctx.ID().getText());
      return res;
   }

   @Override public ST visitRefresh_aftertime(aglParser.Refresh_aftertimeContext ctx) {
      ST res = new ST ("<ID>.refresh(time=<time>)");
      res.add("ID", ctx.ID().getText());
      res.add("time", visit(ctx.expr()).render());
      return res;
   }

   @Override public ST visitViewdefault(aglParser.ViewdefaultContext ctx) {
      ST res = stg.getInstanceOf("viewdefault");
      res.add("view_name", ctx.ID().getText()); 
      store_view = ctx.ID().getText();
      return res;
   }

   @Override public ST visitView_with_operator(aglParser.View_with_operatorContext ctx) {
      ST res = stg.getInstanceOf("view_with_operator");
      res.add("view_name", ctx.ID().getText());
      res.add("with_operator", visit(ctx.with_operator()).render());
      store_view = ctx.ID().getText();
      return res;
   }

   @Override public ST visitWait_command(aglParser.Wait_commandContext ctx) {
      ST res = new ST ("ClickListener().wait_for_click()");
      return res;
   }

   @Override public ST visitWith_figureparams(aglParser.With_figureparamsContext ctx) {
      List<aglParser.Figures_paramsContext> with_figureparams = ctx.figures_params();
      String id = ctx.ID().getText();
      List<String> results = new ArrayList<>();
  
      for (aglParser.Figures_paramsContext param : with_figureparams) {
          ST res = stg.getInstanceOf("with_figureparams");
          res.add("id", id);
          ST st = visit(param);
          res.add("with_figureparams", st.render());
          results.add(res.render());
      }
  
      return new ST(String.join("\n", results));
  }

   @Override public ST visitWith_viewparams(aglParser.With_viewparamsContext ctx) {
      List<aglParser.View_paramsContext> with_viewparams = ctx.view_params();
      String id = ctx.ID().getText();
      List<String> results = new ArrayList<>();

      for (aglParser.View_paramsContext param : with_viewparams) {
         ST res = stg.getInstanceOf("with_viewparams");
         res.add("id", id);
         ST st = visit(param);
         res.add("with_viewparams", st.render());
         results.add(res.render());
      }

      return new ST(String.join("\n", results));
   }

   @Override public ST visitWith_operator_figure(aglParser.With_operator_figureContext ctx) {
      ST res = stg.getInstanceOf("with_operator_figure");
      List<aglParser.Figures_paramsContext> with_operator_figure = ctx.figures_params();
      for (aglParser.Figures_paramsContext param : with_operator_figure) {
         ST st = visit(param);
         res.add("with_operator_figure", st.render());
      }
      return res;
   }
   @Override public ST visitWith_operator_view(aglParser.With_operator_viewContext ctx) {
      ST res = stg.getInstanceOf("with_operator_view");
      List<aglParser.View_paramsContext> with_operator_view = ctx.view_params();
      for (aglParser.View_paramsContext param : with_operator_view) {
         ST st = visit(param);
         res.add("view_params", st.render());
      }
      return res;
   }

   @Override public ST visitView_params_axis(aglParser.View_params_axisContext ctx) {
      ST res = new ST ("<view_params_axis>");
      res.add("view_params_axis", visit(ctx.view_axis()).render()); 
      return res;
   }

   @Override public ST visitView_params_measures(aglParser.View_params_measuresContext ctx) {
      ST res = new ST ("<view_measures>");
      res.add("view_measures", visit(ctx.view_measures()).render()); 
      return res;
   }

   @Override public ST visitView_params_title(aglParser.View_params_titleContext ctx) {
      ST res = new ST ("<title>");
      res.add("title", visit(ctx.title()).render()); 
      return res;
   }

   @Override public ST visitView_params_background(aglParser.View_params_backgroundContext ctx) {
      ST res = new ST ("<background>");
      res.add("background", visit(ctx.background()).render()); 
      return res;
   }

   @Override public ST visitView_measures_width(aglParser.View_measures_widthContext ctx) {
      ST res = new ST ("width=<width>,");
      res.add("width", visit(ctx.expr()).render()); 
      return res;
   }

   @Override public ST visitView_measures_height(aglParser.View_measures_heightContext ctx) {
      ST res = new ST ("height=<height>,");
      res.add("height", visit(ctx.expr()).render()); 
      return res;
   }

   @Override public ST visitView_axis_x(aglParser.View_axis_xContext ctx) {
      ST res = new ST ("Ox=<Ox>"); 
      res.add("Ox", visit(ctx.expr()).render()); 
      return res;
   }

   @Override public ST visitView_axis_y(aglParser.View_axis_yContext ctx) {
      ST res = new ST ("Oy=<Oy>"); 
      res.add("Oy", visit(ctx.expr()).render()); 
      return res;
   }

   @Override public ST visitTitle(aglParser.TitleContext ctx) {
      ST res = new ST ("title=<title>,");
      res.add("title", visit(ctx.expr()).render());
      return res;
   }

   @Override public ST visitBackground(aglParser.BackgroundContext ctx) {
      ST res = new ST ("background=<background>,");
      res.add("background", visit(ctx.color()).render());
      return res;
   }


   @Override public ST visitColor(aglParser.ColorContext ctx) {
      ST res = new ST ("<color>");
      res.add("color", visit(ctx.expr()).render());
      return res;
   }

   @Override public ST visitTime(aglParser.TimeContext ctx) {
      ST res = new ST ("<time>");
      if (ctx.unit.getText().equals("s"))
         res.add("time", ctx.INT().getText());
      else
         res.add("time", String.valueOf(Double.parseDouble(ctx.INT().getText())/1000));
      return res;
   }

   @Override public ST visitPoint(aglParser.PointContext ctx) {
      ST res = stg.getInstanceOf("point");
      res.add("expr1", visit(ctx.expr(0)).render());
      res.add("expr2", visit(ctx.expr(1)).render());
      return res;
   }

   @Override public ST visitVector(aglParser.VectorContext ctx) {
      ST res = stg.getInstanceOf("vector");
      res.add("expr1", visit(ctx.expr(0)).render());
      res.add("expr2", visit(ctx.expr(1)).render());
      return res;
   }
}
