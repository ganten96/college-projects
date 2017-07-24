/* description: Grammar for SLang 1 */

/* lexical grammar */
%lex

DIGIT		      [0-9]
LETTER		      [a-zA-Z]

%%

\s+                             { /* skip whitespace */ }
"fn"				                    { return 'FN'; }
"->"							  { return 'MAP'; }
"("                   		      { return 'LPAREN'; }
")"                   		      { return 'RPAREN'; }
"+"                   		      { return 'PLUS'; }
"*"                   		      { return 'TIMES'; }
"["								  { return 'LBRACKET';}
"]"								  { return 'RBRACKET'; }
"%"								  { return 'MOD'; }
"/"								  { return 'DIVIDE';}
"~"								  { return 'NEGATE';}
"-"								  { return 'SUBTRACT'}
"add1"                            { return 'ADD1'; }
","                   		      { return 'COMMA'; }
"=>"                   		      { return 'THATRETURNS'; }
"."                     		  { return 'INVALID'; }
"not"							  { return 'NOT';}
"==="							  { return 'EQUALS'; }
">" 							  { return 'GT'; }
"<"                               { return 'LT'; }
"if" 							  { return 'IF'; }
"then"                            { return 'THEN'; }
"else"                            { return 'ELSE'; } 
"hd"							  { return 'HD'; }
"tl"							  { return 'TL'; }
"::"                              { return 'CONS'; }
"isNull"						  { return 'ISNULL'; }
{LETTER}({LETTER}|{DIGIT}|_)*  	  { return 'VAR'; }
{DIGIT}+                          { return 'INT'; }
<<EOF>>               		      { return 'EOF'; }
/lex

%start program

%% /* language grammar */

program
    : exp EOF
        { return SLang.absyn.createProgram($1); }
    ;

exp
    : var_exp       { $$ = $1; }
    | intlit_exp    { $$ = $1; }
    | fn_exp        { $$ = $1; }
    | app_exp       { $$ = $1; }    
    | prim_app      { $$ = $1; }
    | if_exp	    { $$ = $1; }
	| list_exp      { $$ = $1; }
    ;

var_exp
    : VAR  { $$ = SLang.absyn.createVarExp( $1 ); }
    ;

intlit_exp
    : INT  { $$ = SLang.absyn.createIntExp( $1 ); }
    ;

list_exp
	: LBRACKET int_list RBRACKET
		{ $$ = SLang.absyn.createListExp($2);}
	;
int_list
	:  /* empty */ { $$ = [ ]; }
	| INT { $$ = [parseInt($1)]; }
	| INT rest_of_list 
		{ var result;
          if ($2 === [ ])
	     result = [ parseInt($1) ];
          else {
             $2.unshift(parseInt($1));
             result = $2;
          }
          $$ = result;
        }
	;
rest_of_list
	: COMMA INT { $$ = [parseInt($2)]; }
	| COMMA INT rest_of_list 
		{ var result;
          if ($3 === [ ])
	     result = [ parseInt($2) ];
          else {
             $3.unshift(parseInt($2));
             result = $3;
          }
          $$ = result;
        }
	;
fn_exp
    : FN LPAREN formals RPAREN THATRETURNS exp
           { $$ = SLang.absyn.createFnExp($3,$6); }
    ;

formals
    : /* empty */ { $$ = [ ]; }
    | VAR moreformals 
        { var result;
          if ($2 === [ ])
	     result = [ $1 ];
          else {
             $2.unshift($1);
             result = $2;
          }
          $$ = result;
        }
    ;

moreformals
    : /* empty */ { $$ = [ ] }
    | COMMA VAR moreformals 
       { $3.unshift($2); 
         $$ = $3; }
    ;

app_exp
    : LPAREN exp args RPAREN
       {  $3.unshift("args");
          $$ = SLang.absyn.createAppExp($2,$3); }
    ;
prim_app:
	 prim1_app_exp
	|prim2_app_exp
	|boolean_app_exp
	|prim2_list_exp
	|prim1_list_exp
	;

prim2_app_exp
	: LPAREN exp prim_op2 exp RPAREN
		{ $$ = SLang.absyn.createPrim2AppExp($2, $3, $4); }
	;

boolean_app_exp
	: LPAREN exp boolean_op exp RPAREN 
		{ $$ = SLang.absyn.createPrim2AppExp($2, $3, $4); }
	| NOT LPAREN boolean_app_exp RPAREN
		{ $$ = SLang.absyn.createPrim1AppExp($1, $3);}
	;
	
prim1_list_exp
	:
	  HD LPAREN list_exp RPAREN { $$ = SLang.absyn.createPrim1AppExp($1, $3);}
	| TL LPAREN list_exp RPAREN { $$ = SLang.absyn.createPrim1AppExp($1, $3);}
	| ISNULL LPAREN list_exp RPAREN { $$ = SLang.absyn.createPrim1AppExp($1, $3);}
	| HD LPAREN prim1_list_exp RPAREN { $$ = SLang.absyn.createPrim1AppExp($1, $3);}
	| TL LPAREN prim1_list_exp RPAREN { $$ = SLang.absyn.createPrim1AppExp($1, $3);}
	;
prim2_list_exp
	:
		LPAREN intlit_exp CONS list_exp RPAREN
		{ $$ = SLang.absyn.createPrim2AppExp($2, $3, $4); }
	| 	LPAREN intlit_exp CONS prim2_list_exp RPAREN
		{ $$ = SLang.absyn.createPrim2AppExp($2,$3,$4); }
	;
prim1_app_exp
	: prim_op1 LPAREN exp RPAREN
		{ $$ = SLang.absyn.createPrim1AppExp($1, $3); }
	;

prim_op2
    :  PLUS     { $$ = $1; }
    |  TIMES    { $$ = $1; }
    |  SUBTRACT { $$ = $1; }
    |  DIVIDE   { $$ = $1; }
    |  MOD      { $$ = $1; }
	|  EQUALS   { $$ = $1; }
	|  MAP		{ $$ = $1; }
    ;

boolean_op
	:  GT		{ $$ = $1; }
	|  LT		{ $$ = $1; }
	;

if_exp:
	IF exp THEN exp ELSE exp
  { $$ = SLang.absyn.createPrim3AppExp($2, $4, $6);}
	;
	
prim_op1
	: ADD1   { $$ = $1; }
	| NEGATE { $$ = $1; }
	;
args
    : /* empty */ { $$ = [ ]; }
    | exp args
        { var result;
          if ($2 === [ ])
	     result = [ $1 ];
          else {
             $2.unshift($1);
             result = $2;
          }
          $$ = result;
        }
    ;
%%

