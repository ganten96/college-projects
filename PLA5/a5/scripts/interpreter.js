/* global SLang : true, parser, fp */
// Nick Ganter and Cory Benz
(function () {

    "use strict";

    var A = SLang.absyn;
    var E = SLang.env;

function nth(n) {
    switch (n+1) {
        case 1: return "first";
        case 2: return "second";
        case 3: return "third";
        default: return (n+1) + "th";
    }
}
function typeCheckPrimitiveOp(op,args,typeCheckerFunctions) {
    var numArgs = typeCheckerFunctions.length;
    if (args.length !== numArgs) {
	   throw new Error("Wrong number of arguments given to '" + op + "'.");
    }
    for( var index = 0; index<numArgs; index++) {
    	if ( ! (typeCheckerFunctions[index])(args[index]) ) {
    	    throw new Error("The " + nth(index) + " argument of '" + op + "' has the wrong type.");
    	}
    }
}

function applyPrimitive(prim,args) {
    switch (prim) {
    case "+": 
	typeCheckPrimitiveOp(prim,args,[E.isNum,E.isNum]);
	return E.createNum( E.getNumValue(args[0]) + E.getNumValue(args[1]));
    case "*": 
	typeCheckPrimitiveOp(prim,args,[E.isNum,E.isNum]);
	return E.createNum( E.getNumValue(args[0]) * E.getNumValue(args[1]));
    case "add1": 
        //typeCheckPrimitiveOp(prim, args, [E.isNum]);
	return E.createNum( 1 + E.getNumValue(args[0]) );
    case "/":
        typeCheckPrimitiveOp(prim, args, [E.isNum, E.isNum]);
        return E.createNum(E.getNumValue(args[0]) / E.getNumValue(args[1]));
    case "-":
        typeCheckPrimitiveOp(prim, args, [E.isNum, E.isNum])
        return E.createNum(E.getNumValue(args[0]) - E.getNumValue(args[1]));
    case "%":
        typeCheckPrimitiveOp(prim, args, [E.isNum, E.isNum])
        return E.createNum(E.getNumValue(args[0]) % E.getNumValue(args[1]));
    case "~":
        //typeCheckPrimitiveOp(prim, args, [E.isNum]);
        return E.createNum(-(E.getNumValue(args)));
	case "not":
		//typeCheckPrimitiveOp(prim, args, [E.isBoolean, A.isBoolean]);
		return E.createBoolean(!(E.getBooleanValue(args)));
	case "===":
		typeCheckPrimitiveOp(prim, args, [E.isNum, E.isNum]);
		return E.createBoolean(E.getNumValue(args[0]) === E.getNumValue(args[1]));
	case ">":
		typeCheckPrimitiveOp(prim, args, [E.isNum, E.isNum]);
		return E.createBoolean(E.getNumValue(args[0]) > E.getNumValue(args[1]));
	case "<":
		typeCheckPrimitiveOp(prim, args, [E.isNum, E.isNum]);
		return E.createBoolean(E.getNumValue(args[0]) < E.getNumValue(args[1]));
	case "hd":
		//typeCheckPrimitiveOp(prim, args[0], [E.isList]);
		return E.createNum(fp.hd(args[1]));
	case "tl":
		//typeCheckPrimitiveOp(prim, args[1], [E.isList]);
		return E.createList(fp.tl(args[1]));
	case "isNull":
		typeCheckPrimitiveOp(prim, [args], [E.isList]);
		return E.createBoolean(fp.isNull(args[1]));
	case "::":
		typeCheckPrimitiveOp(prim, args, [E.isNum,E.isList]);
		return E.createList(fp.cons(E.getNumValue(args[0]), E.getList(args[1])));
	case "->":
		//typeCheckPrimitiveOp(prim, args, [E.isClo, E.isList]);
		return applyMap(args);
    }
}

function applyMap(args){
	var f = args[0]; //the function to be applied.
	var list = args[1]; //list to apply to.
	
	var mapFunction = function(x){
		var env = E.getCloEnv(f);
		var num = E.createNum(x);
		return E.getNumValue(evalExp(E.getCloBody(f), E.update(env, E.getCloParams(f), [num])));
	}
	
	return E.createList(fp.map(mapFunction, list[1]));
}

function evalExp(exp,envir) {
    if (A.isIntExp(exp)) {
		return E.createNum(A.getIntExpValue(exp));
    }
	else if(A.isListExp(exp)){
		return E.createList(A.getListExp(exp));
	}
    else if (A.isVarExp(exp)) {
		return E.lookup(envir,A.getVarExpId(exp));
    }
    else if (A.isFnExp(exp)) {
		return E.createClo(A.getFnExpParams(exp),A.getFnExpBody(exp),envir);
    }
    else if (A.isAppExp(exp)) {
		var f = evalExp(A.getAppExpFn(exp),envir);
		var args = A.getAppExpArgs(exp).map( function(arg) { return evalExp(arg,envir); } );
		if (E.isClo(f)) {
			if (E.getCloParams(f).length !== args.length) {		
			throw new Error("Runtime error: wrong number of arguments in " +
							"a function call (" + E.getCloParams(f).length +
				" expected but " + args.length + " given)");
			} else {
			return evalExp(E.getCloBody(f),
					   E.update(E.getCloEnv(f),
							E.getCloParams(f),args));
			}
		} else {
			throw new Error(f + " is not a closure and thus cannot be applied.");
		}
    }
	else if(A.isPrimApp1Op(exp)){
		return applyPrimitive(A.getPrimApp1OpOperator(exp), evalExp(A.getPrimApp1OpOperand(exp), envir));
	}
    else if(A.isPrimApp2Ops(exp)){
        return applyPrimitive(A.getPrimApp2OpsOperator(exp), 
            [A.getPrimApp2OpsOperand1(exp), A.getPrimApp2OpsOperand2(exp)].map(function(arg){
                return evalExp(arg, envir);
            }));
    }
    else if(A.isPrimApp3Ops(exp)){
        return evalExp(evalExp(exp[1], envir)[1] ? exp[2] : exp[3], envir);
    }
    else {
		throw new Error("Error: Attempting to evaluate an invalid expression");
    }
}
function myEval(p) {
    if (A.isProgram(p)) {
		return evalExp(A.getProgramExp(p),E.initEnv());
    } else {
		window.alert( "The input is not a program.");
    }
}
function interpret(source) {

    var theParser = typeof grammar === 'undefined' ? parser : grammar;

    var output='';

    try {
        if (source === '') {
            window.alert('Nothing to interpret: you must provide some input!');
	} else {
	    var ast = theParser.parse(source);
	    var value = myEval( ast );
            return JSON.stringify(value);
        }
    } catch (exception) {
	window.alert(exception);
        return "No output [Runtime error]";
    }
    return output;
}

SLang.interpret = interpret; // make the interpreter public

}());
