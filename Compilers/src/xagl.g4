grammar xagl;

program: statement* EOF;

statement:  view_actions
        |   view
        |   move
        |   variable_assignment
        |   for
        |   expr
        ;

for : 'for' ID 'in' expr '..' expr 'do' '{' statement* '}' ;

expr:   
  
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



variable_assignment: ID '.' ID '=' expr ';' ;

view_actions: refresh #view_action_refresh
    ;

move: 'move' ID 'by' expr ';'     #move_variable
    | 'move' view 'by' expr ';'   #move_expr
    ;

refresh: 'refresh' (ID | view) ';' 
    |   'refresh' ID 'after' expr 'ms' ';' 
    |   'refresh' view 'every' expr 'ms' ';' 
    ;

view: ID ;

vector: '(' expr ',' expr ')' ;

INT: [0-9]+ ;

NUMBER: INT '.' INT ;

STRING: '"'.*?'"' ;


point : '(' expr ',' expr ')';

time : INT  unit = ('ms'|'s'); // Tempo em milissegundos ou segundos

BOOL: 'True' | 'False';

WS: [ \t\r\n]+ -> skip ;

ID: [a-zA-Z_][a-zA-Z_0-9]* ;

LINE_COMMENT: '#' ~[\r\n]* -> skip ;
