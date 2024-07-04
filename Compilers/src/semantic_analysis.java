import org.antlr.v4.runtime.tree.TerminalNode;
import error.*;
import type.*;
import symbol.*;
import java.util.Hashtable;
import java.util.ArrayList;
import java.util.HashMap;
import java.util.List;
import java.util.Map;

@SuppressWarnings("CheckReturnValue")
public class semantic_analysis extends aglBaseVisitor<Boolean> {
   Hashtable <String,List <String> > basic_operators = new Hashtable<>(); //Operadores basicos -> +,-,()
   Hashtable <String,List <String> > mult_operators = new Hashtable<>(); //Operadores de multiplicação, divisão e modulo -> *,/,%
   Hashtable <String,List <String> > comparsion_operators = new Hashtable<>(); //Operadores logicos -> &&,||,!
   Hashtable <String,List <String> > figure_params = new Hashtable<>(); //Valida os parâmetros de uma figura
   HashMap<String,Symbol <Type>> var_map = new HashMap<>(); 
   



   @Override public Boolean visitProgram(aglParser.ProgramContext ctx) {

      Fill_Hashtables();
      
 
      return visitChildren(ctx);
      //return res;
   }

   @Override public Boolean visitImportSmt(aglParser.ImportSmtContext ctx) {
      return visitChildren(ctx);
   }
   
   @Override public Boolean visitStat(aglParser.StatContext ctx) {
 
    
      return visitChildren(ctx);
 
   }

   @Override public Boolean visitFor(aglParser.ForContext ctx) {
     Boolean expr1 = visit(ctx.expr(0));
     Boolean expr2 = visit(ctx.expr(1));

     List<aglParser.StatContext> stat_params = ctx.stat();


     for (aglParser.StatContext param : stat_params) {
         Boolean paramResult = visit(param);
   
         
         if (!paramResult && paramResult != null) {
            return false;
         }
      }
     

       if (expr1 && expr2) {
         if (!ctx.expr(0).t.name().equals("int")) {
            ErrorHandling.printError(ctx,"Error: " + ctx.expr(0).getText() + " is not a int" );
            return false;
            
         }

         if (!ctx.expr(1).t.name().equals("int")) {
            ErrorHandling.printError(ctx,"Error: " + ctx.expr(1).getText() + " is not a int" );
            return false;
            
         }

         return true;
        
       
       }

       return false;
   }

   @Override public Boolean visitExprComparison(aglParser.ExprComparisonContext ctx) {
      Boolean expr1 = visit(ctx.expr(0));
      Boolean expr2 = visit(ctx.expr(1));
      String operator = ctx.op.getText();

      if (expr1 && expr2) {

         if (!operator.contains("=")){
            
            String expr1_value = ctx.expr(0).t.name();
            String expr2_value = ctx.expr(1).t.name();

            if (!(comparsion_operators.containsKey(expr1_value) && comparsion_operators.get(expr1_value).contains(expr2_value))){
               ErrorHandling.printError(ctx,"Error : " + operator + " invalid operator between " + expr1_value+ " and " + expr2_value);
               return false;
            }
            ctx.t = bool;

      }
      }

      return true;
   }

   @Override public Boolean visitExprnumber(aglParser.ExprnumberContext ctx) {
     ctx.t = number;
     return true;
   }

   @Override public Boolean visitExprpoint(aglParser.ExprpointContext ctx) {
      Boolean visit_point= visit(ctx.point());

      if (visit_point) {
         ctx.t = point;
         return true;
         
      }
      return false;
     
   }

   @Override public Boolean visitExprString(aglParser.ExprStringContext ctx) {
      ctx.t = string;
      return true;
   }

   @Override public Boolean visitExprParent(aglParser.ExprParentContext ctx) {
      Boolean expr = visit(ctx.expr());

      if (expr){
         ctx.t = ctx.expr().t;
         return true;
      }
      return false;
   }

  

   @Override public Boolean visitExprInt(aglParser.ExprIntContext ctx) {
      ctx.t = integer;
      
      return true;
   }

   @Override public Boolean visitExprNot(aglParser.ExprNotContext ctx) {
  
      ctx.t = bool;
    
      return true;
   }

   @Override public Boolean visitExprMultDivMod(aglParser.ExprMultDivModContext ctx) {
      Boolean expr1 = visit(ctx.expr(0));
      Boolean expr2 = visit(ctx.expr(1));

      String operator = ctx.op.getText();

      if (expr1 && expr2) {
         String expr1_value = ctx.expr(0).t.name();
         String expr2_value = ctx.expr(1).t.name();

         
         if (!(mult_operators.containsKey(expr1_value) && mult_operators.get(expr1_value).contains(expr2_value))){
            ErrorHandling.printError(ctx,"Error : " + operator + " invalid operator between " + expr1_value+ " and " + expr2_value);
            return false;
         }

         

         if (!operator.equals("*") ) {
            if (ctx.expr(1).getText().equals("0") || ctx.expr(1).getText().equals("0.0")){
               ErrorHandling.printError(ctx,"Error: Division by zero");
               return false;
            } 
         }
         if (ctx.expr(0).t == integer && ctx.expr(1).t == integer) {
            ctx.t = integer;   
        }
        else{
           ctx.t = number;
        }

         return true;
      }

      return false;
  
   }

   @Override public Boolean visitExprAddSub(aglParser.ExprAddSubContext ctx) {
      Boolean expr1 = visit(ctx.expr(0));
      Boolean expr2 = visit(ctx.expr(1));
      String operator = ctx.op.getText();



      if (expr1 && expr2) { 
         String expr1_value = ctx.expr(0).t.name();
         String expr2_value = ctx.expr(1).t.name();

         if (operator.equals("+")) {
            
            
                /*Se o tipo de ambos os operandos forem diferentes do que é permitido ou ambos serem diferentes de string 
                   inovação  erro a alertar ao utilizador que  esta operação é inválida
                */ 
            
            boolean condition = (expr1_value.equals("string") && expr2_value.equals("string")) || (expr1_value.equals("point") && expr2_value.equals("vector") ||(expr1_value.equals("vector") && expr2_value.equals("point") ) || (expr1_value.equals("vector") && expr2_value.equals("point")));

            if (!(basic_operators.containsKey(expr1_value) && basic_operators.get(expr1_value).contains(expr2_value)) && !condition){
               ErrorHandling.printError(ctx,"Error : " + operator + " invalid operator between " + expr1_value+ " and " + expr2_value);
               return false;
            }




            if ((expr1_value.equals("point") && expr2_value.equals("vector")) || (expr1_value.equals("vector") && expr2_value.equals("point"))) {
               ctx.t = point;
               return true;
               
            }

            switch (expr1_value) {
               case "string":
                  ctx.t = string;
                  break;
                 
               case "time":
                  ctx.t = time;
                  break;

               case "vector":
                  ctx.t = vector;
                  break;

            
               default:
                  ctx.t = Check_Number(ctx.expr(0),ctx.expr(1));
                  break;
            }



            return true;


         }

         
          if (expr1_value.equals("point") && expr2_value.equals("point")) {
            ctx.t = vector;
            return true;
            
          }

         if (!(basic_operators.containsKey(expr1_value) && basic_operators.get(expr1_value).contains(expr2_value))){
            ErrorHandling.printError(ctx,"Error : " + operator + " invalid operator between " + expr1_value+ " and " + expr2_value);
            return false;
         }  
         
         
         switch (expr1_value) {
            case "time":
               ctx.t = time;
               break;
            default:
               ctx.t = Check_Number(ctx.expr(0),ctx.expr(1));
               break;
         }



         return true;
      }
         
      
      return false;

   }

   @Override public Boolean visitExprLogical(aglParser.ExprLogicalContext ctx) {
      Boolean expr1 = visit(ctx.expr(0));
      Boolean expr2 = visit(ctx.expr(1));
      String operator = ctx.op.getText();

      if (expr1 && expr2) {
         String expr1_value = ctx.expr(0).t.name();
         String expr2_value = ctx.expr(1).t.name();

         if (expr1_value != "boolean" || expr2_value != "boolean") {
            ErrorHandling.printError(ctx,"Error: " + operator + " invalid operator between " + expr1_value+ " and " + expr2_value);
            return false;
         }

         ctx.t = bool;
      }

      return true;
   }

   @Override public Boolean visitExprUnary(aglParser.ExprUnaryContext ctx) {
     
      Boolean  expr = visit(ctx.expr());
      String unary_operator = ctx.uop.getText();

      if (expr){
  
         String expr_value = ctx.expr().t.name();
         
        
         if (!basic_operators.containsKey(expr_value)){
            ErrorHandling.printError(ctx,"Error: unary operator " + unary_operator + " is invalid for " + expr_value);
            return false;
         }

         ctx.t = ctx.expr().t;

         return true;
      }
      

      return false;


      
   }

   @Override public Boolean visitExprtime(aglParser.ExprtimeContext ctx) {
      ctx.t = time;
      return true;
   }

   @Override public Boolean visitExprvector(aglParser.ExprvectorContext ctx) {
      Boolean visit_vector =  visit(ctx.vector());

      return  visit_vector;
   }

   @Override public Boolean visitExprBool(aglParser.ExprBoolContext ctx) {
      ctx.t = bool;
      return true;
       

   }

   @Override public Boolean visitExprID(aglParser.ExprIDContext ctx) {
      String var_name = ctx.ID().getText();


      if (!var_map.containsKey(var_name)) {
         ErrorHandling.printError(ctx,"Error: Variable " + "'" + var_name + "'" + " not declared");
         return false;
      }

  
      ctx.t = var_map.get(var_name).type();

      return true;
   }

 
   @Override public Boolean visitPrint(aglParser.PrintContext ctx) {
      if (ctx.ID() != null) {
         String var_name = ctx.ID().getText();
         if (!var_map.containsKey(var_name)) {
            ErrorHandling.printError(ctx,"Error: Variable " + "'" + var_name + "'" + " not declared");
            return false;
         }
         
      }
      return true;
   



   }

   @Override public Boolean visitVardefault(aglParser.VardefaultContext ctx) {
      Boolean wait_command = false,expr = false;
      String var_name = ctx.ID().getText();

      if (ctx.wait_command() != null) {
         wait_command = visit(ctx.wait_command());
         
      }

 
      if (wait_command) {
         Symbol <Type> s = new  VariableSymbol<>(var_name,point);
            //Atualiza o tipo da variável
         if (var_map.containsKey(var_name)) {
               var_map.remove(var_name);
         }
         var_map.put(var_name,s);
        
         return true;
      }

      expr = visit(ctx.expr());

      if (expr && expr!= null) {
         Symbol <Type> s = new  VariableSymbol<>(var_name,ctx.expr().t);
            //Atualiza o tipo da variável
         if (var_map.containsKey(var_name)) {
            var_map.remove(var_name);
               
         }
         var_map.put(var_name,s);
         
      
         return true;
      }

      return false;
   }

   @Override public Boolean visitVartype(aglParser.VartypeContext ctx) {
      Boolean wait_command = false,expr = false;
      String var_name = ctx.ID().getText();
      String type = ctx.type().getText();

      if (ctx.wait_command() != null) {
         wait_command = visit(ctx.wait_command());
         
      }

 
      if (wait_command) {
         if (!type.equals("Point")) {
            ErrorHandling.printError(ctx,"Error: wait command only works with points");
            return false;
            
         }

         Symbol <Type> s = new  VariableSymbol<>(var_name,point);
         var_map.put(var_name,s);

         return true;
      }

      expr = visit(ctx.expr());


      if (expr && expr!= null) {
         String expr_value = ctx.expr().t.name();

         if(type.equals("Number") && !(ctx.expr().t.subtype(numeric))){
            ErrorHandling.printError(ctx,"Error: " + ctx.expr().getText() + " is not a " + type);
            return false;
         }

         if (type.equals("Color") && !(ctx.expr().t.name().equals("string"))){
            ErrorHandling.printError(ctx,"Error: " + ctx.expr().getText() + " is not a " + type);
            return false;
            
         }

         if (type.equals("Vector") && !(ctx.expr().t.subtype(coordinate))){
            ErrorHandling.printError(ctx,"Error: " + ctx.expr().getText() + " is not a " + type);
            return false;
            
         }

               //Tipos já verificados nas condições anteriores
         Boolean condition_checked = !(type.equals("Number") || type.equals("Color") || type.equals("Vector"));
    
         if (!(expr_value.toLowerCase().equals(type.toLowerCase())) && condition_checked){
            ErrorHandling.printError(ctx,"Error: " + ctx.expr().getText() + " is not a " + type);
            return false;
         }
            
            
         if (type.equals("Number")) { //Para aceitar variáveis do tipo Number = Integer 
            Symbol <Type> s = new  VariableSymbol<>(var_name,number);
              
              //Atualiza o tipo da variável
            if (var_map.containsKey(var_name)) {
               var_map.remove(var_name);
               
            }
            var_map.put(var_name,s);
         

            return true;
         }
              
         if (type.equals("Vector")){
            Symbol <Type> s = new  VariableSymbol<>(var_name,vector);
               
               //Atualiza o tipo da variável
            if (var_map.containsKey(var_name)) {
               var_map.remove(var_name);
               
            }
            var_map.put(var_name,s);


            return true;

         }

         
         Symbol <Type> s = new  VariableSymbol<>(var_name,ctx.expr().t);

            //Atualiza o tipo da variável
         if (var_map.containsKey(var_name)) {
            var_map.remove(var_name);
                  
         }
         var_map.put(var_name,s);
         

 
      
         return true;
         

   }

   return false;
}

   @Override public Boolean visitVarfigure(aglParser.VarfigureContext ctx) {
      String var_name = ctx.ID().getText();
      Boolean figures = visit(ctx.figures());


      if (figures) {
         Symbol <Type> s = new  VariableSymbol<>(var_name,figure);

            //Atualiza o tipo da variável
         if (var_map.containsKey(var_name)) {
            var_map.remove(var_name);
               
         }
         var_map.put(var_name,s);
         
      
         return true;
         
      }

      return false;

   }


   @Override public Boolean visitVariable_parameters(aglParser.Variable_parametersContext ctx) {
      String var_name = ctx.ID().getText();
      if (!var_map.containsKey(var_name)) {
         ErrorHandling.printError(ctx,"Error: Variable " + "'" + var_name + "'" + " not declared");
         return false;
         
      }


      Boolean state = visit(ctx.state());

    

      return state;
   }

   @Override public Boolean visitState(aglParser.StateContext ctx) {
 
    
      String parameter = ctx.STRING().getText();
      parameter = parameter.substring(1,parameter.length()-1); //Remove as aspas

  

      if (!(parameter.equals("hidden") || parameter.equals("normal"))) {
         ErrorHandling.printError(ctx,"Error: " + parameter + " is not a valid state");
         return false;
         
      }
      return true;
      
   }

   @Override public Boolean visitType(aglParser.TypeContext ctx) {
      Boolean res = null;
      return visitChildren(ctx);
      //return res;
   }

   @Override public Boolean visitFigures_expr(aglParser.Figures_exprContext ctx) {
         Boolean figure = visit(ctx.figure());

         Boolean expr = visit(ctx.expr());
 


         if (expr) {
            if (!ctx.expr().t.equals(point) ) {
               ErrorHandling.printError(ctx,"Error: " + ctx.expr().getText() + " is not a point" );
               return false;
            }
            
         }

         return false;





   }
   @Override public Boolean visitFigures_expr_with(aglParser.Figures_expr_withContext ctx) {
      Boolean visit_figure = visit(ctx.figure()); 
      
      Boolean expr = visit(ctx.expr());

      Boolean visit_with_operator = visit(ctx.with_operator());
      
      


      if (expr && visit_with_operator) {


       

         if (!ctx.expr().t.equals(point)) {
            ErrorHandling.printError(ctx,"Error: " + ctx.expr().getText() + " is not a point" );
            return false;
            
         }
          
         if(!(ctx.with_operator().t.name().equals("figure") || ctx.with_operator().t.name().equals("string"))){
            String invalid_parameters = ctx.with_operator().getText();
            invalid_parameters = invalid_parameters.substring(5,invalid_parameters.length()-1); //Remove a string: with {}
            String [] invalid_parameters_array = invalid_parameters.split(";"); //Separar os parâmetros por 

            ErrorHandling.printError(ctx,"Error: " + invalid_parameters_array[0] + " invalid figure parameter" );
            return false;
            
         }


       
                   //Verificar se os parâmetros são válidos para a figura
         String with_operator = ctx.with_operator().getText();

         with_operator = with_operator.substring(5,with_operator.length()-1); //Remove a string: with {} para obter os parâmetros

         String [] with_operator_array = with_operator.split(";"); //Separar os parâmetros por ;
         

         List<String> figure_parameters = figure_params.get(ctx.figure().getText());



         for (String parameter : with_operator_array) {
             int equal_operator = parameter.indexOf("=");

            parameter = parameter.substring(0,equal_operator); //Remove o valor do parâmetro
          
            if (!figure_parameters.contains(parameter)) {
               ErrorHandling.printError(ctx,"Error: " + parameter + " invalid parameter for figure " + ctx.figure().getText());
               return false;
            }
         }
         return true;
         
      }

      return false;

   }

 

   @Override public Boolean visitFigure(aglParser.FigureContext ctx) {
       return true;
   }

   @Override public Boolean visitFigures_params_length(aglParser.Figures_params_lengthContext ctx) {
      Boolean length = visit(ctx.length());
      return length;
   }

   @Override public Boolean visitFigures_params_angles(aglParser.Figures_params_anglesContext ctx) {
      Boolean angles = visit(ctx.figure_angles());
      return angles;
   }

   @Override public Boolean visitFigures_params_colors(aglParser.Figures_params_colorsContext ctx) {
      Boolean colors = visit(ctx.figure_colors());
      return colors;
   }
   @Override public Boolean visitFigures_params_text(aglParser.Figures_params_textContext ctx) {
     Boolean text = visit(ctx.text());
      return text;
   }

   @Override public Boolean visitFigure_angles(aglParser.Figure_anglesContext ctx) {
      Boolean expr = visit(ctx.expr());

      if (expr) {
        if (!ctx.expr().t.subtype(numeric)) {
           ErrorHandling.printError(ctx,"Error: " + ctx.expr().getText() + " is not a number or a int" );
           return false;
           
        }

        return true;
        
      }

      return false;
   }

   @Override public Boolean visitFigure_colors(aglParser.Figure_colorsContext ctx) {
      Boolean color = visit(ctx.color());

      if (color) {
         if (!ctx.color().t.name().equals("color")) {
            ErrorHandling.printError(ctx,"Error: " + ctx.color().getText() + " is not a color" );
            return false;
            
         }

         return true;
         
      }

      return false;
   }

   @Override public Boolean visitLength(aglParser.LengthContext ctx) {
      Boolean expr = visit(ctx.expr());

      if (expr) {
         if (!ctx.expr().t.subtype(coordinate)) {
            ErrorHandling.printError(ctx,"Error: " + ctx.expr().getText() + " is not a vector or a point" );
            return false;
         }

         return true;
         
      }
      return false;
   }

   @Override public Boolean visitText(aglParser.TextContext ctx) {
      Boolean expr = visit(ctx.expr());

      if (expr) {
         if (ctx.expr().t.name() != "string") {
            ErrorHandling.printError(ctx,"Error: " + ctx.expr().getText() + " is not a string" );
            return false;
            
         }

         return true;
         
      }

      return false;
   }

   @Override public Boolean visitView_action_refresh(aglParser.View_action_refreshContext ctx) {
      Boolean refresh = visit(ctx.refresh());
      return refresh;
      
   }

   @Override public Boolean visitView_action_close(aglParser.View_action_closeContext ctx) {
      Boolean close = visit(ctx.close());
      return close;
   }


   @Override public Boolean visitClose(aglParser.CloseContext ctx) {
      String var_name = ctx.ID().getText();

      if(var_name != null){
         if (!var_map.containsKey(var_name)) {
            ErrorHandling.printError(ctx,"Error: Variable " + "'" + var_name + "'" + " not declared");
            return false;
         }

         if (var_map.get(var_name).type() != view) {
            ErrorHandling.printError(ctx,"Error: Variable " + "'" + var_name + "'" + " is not a view");
            return false;
            
         }

         return true;
      }

      Boolean View = visit(ctx.view());
      return View;
   }


   @Override public Boolean visitMovevar(aglParser.MovevarContext ctx) {
       String var_name = ctx.ID().getText();
       Boolean expr = visit(ctx.expr());

       if (!var_map.containsKey(var_name)) {
         ErrorHandling.printError(ctx,"Error: Variable " + "'" + var_name + "'" + " not declared");
         return false;
      }


      if (expr) {
         if (!ctx.expr().t.name().equals("point")) {
            ErrorHandling.printError(ctx,"Error : " + ctx.expr().getText() + "is not a point");
            return false;
         }

         return true;
         
      }

      return false;


   }
   @Override public Boolean visitMoveview(aglParser.MoveviewContext ctx) {
    Boolean visit_view = visit(ctx.view());
      Boolean expr = visit(ctx.expr());

     if (expr && visit_view) {
        if (!ctx.expr().t.name().equals("point")) {
           ErrorHandling.printError(ctx,"Error : " + ctx.expr().getText() + "is not a point");
           return false;
        }

        return true;
        
     }

     return false;

   }
   @Override public Boolean visitMovefigure(aglParser.MovefigureContext ctx) {
      Boolean visit_figure = visit(ctx.figure());
      Boolean expr = visit(ctx.expr());

     if (expr && visit_figure) {
        if (!ctx.expr().t.name().equals("point")) {
           ErrorHandling.printError(ctx,"Error : " + ctx.expr().getText() + "is not a point");
           return false;
        }

        return true;
        
     }

     return false;

   }

   @Override public Boolean visitRefresh_default(aglParser.Refresh_defaultContext ctx) {
      String var_name = ctx.ID().getText();

      if (var_name != null) {
         if (!var_map.containsKey(var_name)) {
            ErrorHandling.printError(ctx,"Error: Variable " + "'" + var_name + "'" + " not declared");
            return false;
         }

         if (var_map.get(var_name).type() != view) {
            ErrorHandling.printError(ctx,"Error: Variable " + "'" + var_name + "'" + " is not a view");
            return false;
            
         }

         return true;

       

      }

      Boolean View = visit(ctx.view());


      return View;

      
   }


   @Override public Boolean visitRefresh_aftertime(aglParser.Refresh_aftertimeContext ctx) {
      String var_name = ctx.ID().getText();

      if (var_name != null) {
         if (!var_map.containsKey(var_name)) {
            ErrorHandling.printError(ctx,"Error: Variable " + "'" + var_name + "'" + " not declared");
            return false;
         }

         if (var_map.get(var_name).type() != view) {
            ErrorHandling.printError(ctx,"Error: Variable " + "'" + var_name + "'" + " is not a view");
            return false;
            
         }

      

      }else{
        
         Boolean View = visit(ctx.view());

         if (View == false) {
            return false;
            
         }

      }

      Boolean expr = visit(ctx.expr());

      if(!(ctx.expr().t.name().equals("time"))){
         ErrorHandling.printError(ctx,"Error: " + ctx.expr().getText() + " is not type time" );
         return false;
      }

      return expr;

   }

   @Override public Boolean visitViewdefault(aglParser.ViewdefaultContext ctx) {


     String view_name = ctx.ID().getText();


     Symbol <Type> s = new  VariableSymbol<>(view_name,view);

     var_map.put(view_name,s);


     return true;
   }

   @Override public Boolean visitView_with_operator(aglParser.View_with_operatorContext ctx) {
      String view_name = ctx.ID().getText();
   
      Boolean with_operator = visit(ctx.with_operator());

      //Se receber o tipo string significa que o wtih operator não tinha parâmetros
      if(!(ctx.with_operator().t.name().equals("view") || ctx.with_operator().t.name().equals("string"))){
         String invalid_parameters = ctx.with_operator().getText();
         invalid_parameters = invalid_parameters.substring(5,invalid_parameters.length()-1); //Remove a string: with {}
          
         String [] invalid_parameters_array = invalid_parameters.split(";"); //Separar os parâmetros por 

         ErrorHandling.printError(ctx,"Error: " + invalid_parameters_array[0] + " invalid view parameter" );
         return false;
      }



      if (with_operator) {
         Symbol <Type> s = new  VariableSymbol<>(view_name,view);
    
         var_map.put(view_name,s);

         return true;
         
      }

    

     return false;
      
   }

   @Override public Boolean visitWith_figureparams(aglParser.With_figureparamsContext ctx) {
      String var_name = ctx.ID().getText();

     
      if (!var_map.containsKey(var_name)) {
         ErrorHandling.printError(ctx,"Error: Variable " + "'" + var_name + "'" + " not declared");
         return false;
      }

      List<aglParser.Figures_paramsContext> figures_params = ctx.figures_params();
      if (ctx.figures_params().size() == 0) {
         ctx.t = string;
         return true;
         
      }
      for (aglParser.Figures_paramsContext param : figures_params) {
         Boolean paramResult = visit(param);
         if (!paramResult) {
            return false;
         }
      }

      ctx.t = figure;

      return true;
   }

   @Override public Boolean visitWith_viewparams(aglParser.With_viewparamsContext ctx) {
      String var_name = ctx.ID().getText();

     
      if (!var_map.containsKey(var_name)) {
         ErrorHandling.printError(ctx,"Error: Variable " + "'" + var_name + "'" + " not declared");
         return false;
      }

      List<aglParser.View_paramsContext> view_params = ctx.view_params();
      if (ctx.view_params().size() == 0) {
         ctx.t = string;
         return true;
         
      }
      for (aglParser.View_paramsContext param : view_params) {
         Boolean paramResult = visit(param);
         if (!paramResult) {
            return false;
         }
      }

      ctx.t = view;

      return true;
   }


   @Override public Boolean visitWait_command(aglParser.Wait_commandContext ctx) {
      return true;
   }

   @Override public Boolean visitWith_operator_figure(aglParser.With_operator_figureContext ctx) {
      List<aglParser.Figures_paramsContext> figures_params = ctx.figures_params();
      if (ctx.figures_params().size() == 0) {
         ctx.t = string;
         return true;
         
      }
      for (aglParser.Figures_paramsContext param : figures_params) {
         Boolean paramResult = visit(param);
         if (!paramResult) {
            return false;
         }
      }

      ctx.t = figure;

      return true;
   }

   @Override public Boolean visitWith_operator_view(aglParser.With_operator_viewContext ctx) {
      List<aglParser.View_paramsContext> view_params = ctx.view_params();


      if (ctx.view_params().size() == 0) {
         ctx.t = string;
         return true;
         
      }
      
      for (aglParser.View_paramsContext param : view_params) {
            Boolean paramResult = visit(param);
            if (!paramResult) {
               return false;
            }
     }

      ctx.t = view;

      return true;
   }

   @Override public Boolean visitView_params_axis(aglParser.View_params_axisContext ctx) {
      Boolean view_axis = visit(ctx.view_axis());

       return  view_axis;
   }

   @Override public Boolean visitView_params_measures(aglParser.View_params_measuresContext ctx) {
      Boolean view_measures = visit(ctx.view_measures());

      return view_measures ;
      
   }

   @Override public Boolean visitView_params_title(aglParser.View_params_titleContext ctx) {
      Boolean view_title = visit(ctx.title());

      return view_title ;
   }

   @Override public Boolean visitView_params_background(aglParser.View_params_backgroundContext ctx) {
      Boolean view_background = visit(ctx.background());

      return view_background;
   }

   @Override public Boolean visitView_measures_width(aglParser.View_measures_widthContext ctx) {
      Boolean expr = visit(ctx.expr());

      if (expr) {
         if (ctx.expr().t.name() != "int") {
            ErrorHandling.printError(ctx,"Error: " + ctx.expr().t.name() + " is not a int" );
            return false;
            
         }
         
         return true;
         
      }

      return false;
      
   }

   @Override public Boolean visitView_measures_height(aglParser.View_measures_heightContext ctx) {
      Boolean expr = visit(ctx.expr());

      if (expr) {
         if (ctx.expr().t.name() != "int") {
            ErrorHandling.printError(ctx,"Error: " + ctx.expr().t.name() + " is not a int" );
            return false;
            
         }
         
         return true;
         
      }

      return false;
   }

   @Override public Boolean visitView_axis_x(aglParser.View_axis_xContext ctx) {
      Boolean expr = visit(ctx.expr());

      if (expr) {
         if (ctx.expr().t.name() != "number") {
            ErrorHandling.printError(ctx,"Error: " + ctx.expr().t.name() + " is not a number" );
            return false;
            
         }
         
         return true;
         
      }

      return false;
   }

   @Override public Boolean visitView_axis_y(aglParser.View_axis_yContext ctx) {
       Boolean expr = visit(ctx.expr());

      if (expr) {
         if (ctx.expr().t.name() != "number") {
            ErrorHandling.printError(ctx,"Error: " + ctx.expr().t.name() + " is not a number" );
            return false;
            
         }
         
         return true;
         
      }

      return false;
   }
   

   @Override public Boolean visitTitle(aglParser.TitleContext ctx) {
      Boolean expr = visit(ctx.expr());

      if (expr) {
         if (ctx.expr().t.name() != "string") {
            ErrorHandling.printError(ctx,"Error: " + ctx.expr().t.name() + " is not a string" );  
            return false;
         }
         return true;
         
      }

      return false;
   }
   

   @Override public Boolean visitBackground(aglParser.BackgroundContext ctx) {
      Boolean expr = visit(ctx.color());

      if (expr) {
         if (!(ctx.color().t.name().equals("color"))) {
            ErrorHandling.printError(ctx,"Error: " + ctx.color().t.name() + " is not a color" );
            return false;

            
         }
         
         return true;
         
      }

      return false;
   
   }




   @Override public Boolean visitColor(aglParser.ColorContext ctx) {
      Boolean color_name = visit(ctx.expr());

      if (color_name) {



          if (!ctx.expr().t.name().equals("string")) {
            ErrorHandling.printError(ctx,"Error: a color must be a string" );
            return false;
            
          }

          ctx.t = color;
        
          return true;
 
         }
       

      return false;
   }

   @Override public Boolean visitTime(aglParser.TimeContext ctx) {
      return true;
      //return res;
   }


   @Override public Boolean visitPoint(aglParser.PointContext ctx) {
      Boolean expr1 = visit(ctx.expr(0));
      Boolean expr2 = visit(ctx.expr(1));

      if (expr1 && expr2) {
         if (!ctx.expr(0).t.subtype(numeric)) {
            ErrorHandling.printError(ctx,"Error: " + ctx.expr(0).getText() +  " is not a int or a number" );
            return false;
         }

         if(!ctx.expr(1).t.subtype(numeric)){
            ErrorHandling.printError(ctx,"Error: " +  ctx.expr(1).getText() + " is not a int or a number" );
            return false;
         }
         
         return true;
         
      }  
      return false;
   }


   @Override public Boolean visitVector(aglParser.VectorContext ctx){
      Boolean expr1 = visit(ctx.expr(0));
      Boolean expr2 = visit(ctx.expr(1));

      if (expr1 && expr2) {
         if (!ctx.expr(0).t.subtype(numeric)) {
            ErrorHandling.printError(ctx,"Error: " + ctx.expr(0).getText() +  " is not a int or a number" );
            return false;
         }

         if(!ctx.expr(0).t.subtype(numeric)){
            ErrorHandling.printError(ctx,"Error: " +  ctx.expr(1).getText() + " is not a int or a number" );
            return false;
         }
         
         return true;
         
      }  
      return false;

   }


         //Funções auxiliares para verificar tipos e subtipos

   protected  static final Type coordinate = new CoordinateType();
   protected  static final Type numeric = new NumericType();
   protected  static final Type integer = new IntegerType();
   protected static final Type number = new NumberType();
   protected  static final Type string = new StringType();
   protected static final Type color = new ColorType();
   protected  static final Type bool = new BoolType();
   protected  static final Type point = new PointType();
   protected  static final Type vector = new VectorType();
   protected  static final Type time = new TimeType();
   protected  static final Type figure = new FigureType();
   protected  static final Type view = new ViewType();
   protected  static final Type wait = new WaitType();



   //Funções auxiliares para preencher as hashtables
   public void Fill_Hashtables(){
      Fill_basic_operators_conditions();
      Fill_mul_div_mod_conditions();
      Fill_comparsion_operators_conditions();
      Fill_Figure_Parameters();
         
   }

   public void Fill_basic_operators_conditions(){
      String [] data_types =  {"int","number","vector","time"};

      for (String data_type : data_types) {
         basic_operators.put(data_type,new ArrayList<>());

         switch (data_type) {
            case "time":
               Aux_fill_conditions(basic_operators, data_type,new String[]{"time"});
               break;

            case "vector":
               Aux_fill_conditions(basic_operators, data_type,new String[]{ "vector"});
               break;
         
            default:
                Aux_fill_conditions(basic_operators, data_type, new String[]{"int","number"});
         }
      }
      
   }


   public void Fill_mul_div_mod_conditions(){

      String [] data_types =  {"int","number","time"};

      for (String data_type : data_types) {
         mult_operators.put(data_type,new ArrayList<>());

         if (data_type.equals("time")) {
            Aux_fill_conditions(mult_operators, data_type,new String[]{"time"});
            
          }else{
            Aux_fill_conditions(mult_operators, data_type,new String[]{ "int","number"});
          }
      }



   }

   public void Fill_comparsion_operators_conditions(){
      String [] data_types =  {"int","number","vector","point","string","time","boolean"};
      for (String data_type : data_types) {
         comparsion_operators.put(data_type,new ArrayList<>());

         switch (data_type) {
            case "string":
               Aux_fill_conditions(comparsion_operators, data_type, new String[]{"string"});
               
               break;
            case "time":
               Aux_fill_conditions(comparsion_operators, data_type,new String[]{"time"});
               break;

            case "boolean":
               Aux_fill_conditions(comparsion_operators, data_type,new String[]{"boolean"});
               break;

            case "point":
               Aux_fill_conditions(comparsion_operators, data_type,new String[]{"point","vector"});
               break;

            case "vector":
               Aux_fill_conditions(comparsion_operators, data_type,new String[]{"point","vector"});
               break;
         
            default: //Para os tipos int e number
               Aux_fill_conditions(comparsion_operators, data_type,new String[]{"int","number"});
               break;
         }
      }
      
      
     
   }


   public void Fill_Figure_Parameters(){
      String [] figures = {"Arc","ArcChord","PieSlice","Text","Line","Rectangle","Ellipse","Dot"};
      
      for (String figure : figures) {
         figure_params.put(figure,new ArrayList<>());

         switch (figure) {
            case "Arc":
               Aux_fill_conditions(figure_params, figure,new String[]{"start","extent","outline","fill","length"});
               
               break;

            case "ArcChord":
               Aux_fill_conditions(figure_params, figure,new String[]{"start","extent","outline","fill","length"});
               break;

            case "PieSlice":
               Aux_fill_conditions(figure_params, figure,new String[]{"start","extent","outline","fill","length"});
               break;

            case "Text":
               Aux_fill_conditions(figure_params, figure,new String[]{"text","fill"});
               break;
            case "Dot":
               Aux_fill_conditions(figure_params, figure,new String[]{"fill"});
               break;
         
            default: //Para as figuras Line, Rectangle e Ellipse
               Aux_fill_conditions(figure_params, figure,new String[]{"length","fill","outline"});
               break;
         }
      }
     
   }

   public void Aux_fill_conditions( Hashtable <String,List <String> > hashtable,String key,String [] values){
      for (String value : values) {
   
         hashtable.get(key).add(value);
      }
      
   }
   
   public Type Check_Number(aglParser.ExprContext expr1,aglParser.ExprContext expr2){
      if (expr1.t == number || expr2.t == number) {
         return number;
      }
      return integer;
   }


      
}
