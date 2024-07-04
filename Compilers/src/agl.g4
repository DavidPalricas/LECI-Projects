grammar agl;
@header {import type.*;
         import symbol.*;} /*Importa os packages  type e symbol
                         que são usados no analisador semântico
                         tem de se usar este @header para importar
                         porque os package type e symbol não está no mesmo diretório
                         que este ficheiro
                         */ 



program: importSmt* stat * EOF; 

importSmt: 'import' STRING ';';
//Importa um ficheiro, onde STRING representa o nome do arquivo xAGL a ser importado

stat:    view_actions 
        |move
        |view
        |figures
        |variable_declaration
        |variable_parameters
        |print
        |with
        |for
        |expr
        ;

for : 'for' ID 'in' expr '..' expr 'do' '{' stat* '}' ; //Ciclo for que itera de um número inicial até um número final

wait_command: 'wait' 'mouse' 'click' ;

expr returns[Type t = null]:   
  
       uop=('-'|'+') expr #ExprUnary 
    | '(' expr ')' #ExprParent
    |  expr op=('*'|'/'|'//'|'%') expr #ExprMultDivMod
    | expr op=('+'|'-') expr #ExprAddSub
    | expr op=('=='|'>'|'<'|'>='|'<='|'!=') expr #ExprComparison
    | 'not' expr #ExprNot
    | expr op= ('and'|'or') expr #ExprLogical 
    |time #Exprtime 
    | BOOL #ExprBool
    | ID #ExprID
    | STRING #ExprString
    |point #Exprpoint 
    |vector #Exprvector 
    |NUMBER #Exprnumber
    | INT #ExprInt 
    ;

print: 'print' txt=(ID|STRING) ';'; //String ou variável

variable_declaration:  ID '=' (wait_command | expr) ';' #vardefault
                     | ID ':' type '=' (wait_command | expr) ';' #vartype
                     | ID ':' figures #varfigure
                     ;

variable_parameters: ID '.' state ';';

state:'state' '=' STRING; /* Regra que pode ser apagada no futuro
                            caso não exista + parâmetros para as variáveis
                         */

type: 'Number' | 'Point' | 'Vector' | 'Time'  | 'Color' | 'Int'  | 'String' | 'Boolean' ;


figures:  
         figure 'at' expr ';' #figures_expr
        | figure 'at' expr with_operator #figures_expr_with
        ;

figure: 'Dot'| 'Line' | 'Rectangle' | 'Ellipse' | 'Text' | 'Arc' | 'ArcChord' | 'PieSlice';

figures_params:  length ';' #figures_params_length
                 | figure_angles ';' #figures_params_angles
                 | figure_colors ';' #figures_params_colors
                 | text ';' #figures_params_text
                ;

figure_angles: angle_param = ('start' | 'extent') '=' expr; //Numerico

figure_colors: color_param = ('fill'  | 'outline') '=' color;

length: 'length''=' expr; /*Apesar na gramática aceitar vetor ou ponto
                                       este parâmetro só é válido para o tipo vetor
                                       esta verificação é feita no analisador semântico
                                     */

                                     //Vector ou ponto
text: 'text' '=' expr;  //String

view_actions:  refresh #view_action_refresh
             | close #view_action_close
             ;

close:  'close' (ID|view) ';' ;

move :  'move' ID 'by' expr ';'#movevar
       |'move' view 'by' expr ';' #moveview
       |'move' figure 'by' expr ';'#movefigure
       ; 

refresh:   'refresh'(ID |view ) 'after' expr ';' #refresh_aftertime
           |'refresh' (ID|view) ';' #refresh_default
          
          ;


view:    ID ':' 'View' with_operator #view_with_operator
        |ID':' 'View' ';'  #viewdefault
        ;
         


with returns [Type t = null]:
        'with' ID 'do' '{' figures_params*'}' #with_figureparams
       |'with' ID 'do' '{'view_params* '}' #with_viewparams
       ; 
       


with_operator returns [ Type t = null]: 
                  'with' '{' figures_params* '}' #with_operator_figure
                |'with' '{' view_params* '}' #with_operator_view
                ;  

view_params :
              view_axis ';'#view_params_axis
            | view_measures ';' #view_params_measures
            | title ';' #view_params_title
            | background ';' #view_params_background
            ; 

view_measures:  'width' '=' expr #view_measures_width
               |'height' '=' expr #view_measures_height
               ;   


view_axis: 'Ox' '=' expr  #view_axis_x // Coordenada x do ponto de origem da view
           |'Oy' '=' expr #view_axis_y // Coordenada y do ponto de origem da view
           ;
title: 'title' '=' expr; // Título da view

background: 'background' '=' color; // Cor de fundo da view


color returns[Type t = null] : 
        expr;

time returns[Type t = null]: INT  unit = ('ms'|'s'); // Tempo em milissegundos ou segundos


point : '(' expr ',' expr ')';

vector : '(' expr ':' expr ')';

INT: [0-9]+;

NUMBER: INT'.'INT;

STRING: '"'.*?'"'; //Aceita qualquer caráter entre aspas duplas


WS: [ \t\r\n]+ -> skip; //Ignora qualquer tipo de espaço em branco
                                      
BOOL: 'True' | 'False';
ID: [a-zA-Z_][a-zA-Z_0-9]*; // Aceita qualquer identificador que comece com letra ou _

LINE_COMMENT : '#' ~[\r\n]* -> skip ; /*
                                       Aceita qualquer caráter após # exceto quebra de linha
                                       mudanças de linha 
                                       */

BLOCK_COMMENT: '#(' .*? '#)' -> skip;// Aceita qualquer caráter entre #( e #)
