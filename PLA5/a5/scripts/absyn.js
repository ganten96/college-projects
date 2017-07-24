/* global SLang : true */

(function (){

"use strict";

var exports = {};

function createProgram(e) {
    return ["Program", e]; 
}
function isProgram(e) { 
    return e[0] === "Program"; 
}
function getProgramExp(e) { 
    if (isProgram(e)) {
	return e[1];
    } else {
	throw new Error("Interpreter error: "  +
			"The argument of getProgramExp is not a program.");
    }
}				       
function createVarExp(v) { 
    return ["VarExp", v]; 
}
function isVarExp(e) { 
    return e[0] === "VarExp"; 
}
function getVarExpId(e) { 
    if (isVarExp(e)) {
	return e[1];
    } else {
	throw new Error("Interpreter error: "  +
			"The argument of getVarExpId is not a VarExp.");
    }
}
function createIntExp(n) {
    return ["IntExp", parseInt(n)];
}
function isIntExp(e) { 
    return e[0] === "IntExp"; 
}
function getIntExpValue(e) { 
    if (isIntExp(e)) {
	return e[1];
    } else {
	throw new Error("Interpreter error: "  +
			"The argument of getIntExpValue is not an IntExp.");
    }
}
function createFnExp(params,body) {
    return ["FnExp",params,body];
}
function isFnExp(e) { 
    return e[0] === "FnExp"; 
}
function getFnExpParams(e) { 
    if (isFnExp(e)) {
	return e[1];
    } else {
	throw new Error("Interpreter error: "  +
			"The argument of getFnExpParams is not an FnExp.");
    }
}
function getFnExpBody(e) { 
    if (isFnExp(e)) {
	return e[2];
    } else {
	throw new Error("Interpreter error: "  +
			"The argument of getFnExpBody is not an FnExp.");
    }
}
function createAppExp(fn,args) {
    return ["AppExp",fn,args];
}
function isAppExp(e) { 
    return e[0] === "AppExp"; 
}
function getAppExpFn(e) { 
    if (isAppExp(e)) {
	return e[1];
    } else {
	throw new Error("Interpreter error: "  +
			"The argument of getAppExpFn is not an AppExp.");
    }
}
function getAppExpArgs(e) { 
    if (isAppExp(e)) {
	return e[2].slice(1); // eliminate the first element (i.e., "args")
    } else {
	throw new Error("Interpreter error: "  +
			"The argument of getAppExpArgs is not an AppExp.");
    }
}
/*function createPrimAppExp(prim,args) {
    return ["PrimAppExp",prim,args];
}*/



//////
function createPrimAppExp3Ops(arg1, arg2, arg3){
    return ["PrimAppExp3Ops", arg1, arg2, arg3];
}

function isPrimApp3Ops(e){
    return e[0] === "PrimAppExp3Ops";
}

function getPrimApp3OpsOperator(e){
    if(isPrimApp3Ops(e)){
        return e[3]; //false statement
    }else{
        throw new Error("Interpreter error: "
            + "The argument of getPrimApp3Ops is not a PrimAppExp3Ops");
    }
}
function getPrimApp3OpsOperand1(e){
    if(isPrimApp3Ops(e)){
        return e[1]; //condition
    }else{
        throw new Error("Interpereter error: " + "The agrument of getPrimApp3OpsOperand1 is not a PrimAppExp3Ops");
    }
}
function getPrimApp3OpsOperand2(e){
    if(isPrimApp3Ops(e)){
        return e[2]; //true statement
    }else{
        throw new Error("Interpereter error: " + "The agrument of getPrimApp3OpsOperand2 is not a PrimAppExp3Ops");
    }
}
/////

function createPrimAppExp2Ops(arg1, op, arg2){
    return ["PrimAppExp2Ops", arg1, op, arg2];
}

function isPrimApp2Ops(e){
    return e[0] === "PrimAppExp2Ops";
}

function getPrimApp2OpsOperator(e){
    if(isPrimApp2Ops(e)){
        return e[2]; //return the operator
    }else{
        throw new Error("Interpreter error: "
            + "The argument of getPrimApp2Ops is not a PrimAppExp2Ops");
    }
}
function getPrimApp2OpsOperand1(e){
    if(isPrimApp2Ops(e)){
        return e[1];
    }else{
        throw new Error("Interpereter error: " + "The agrument of getPrimApp2OpsOperand1 is not a PrimAppExp2Ops");
    }
}
function getPrimApp2OpsOperand2(e){
    if(isPrimApp2Ops(e)){
        return e[3];
    }else{
        throw new Error("Interpereter error: " + "The agrument of getPrimApp2OpsOperand1 is not a PrimAppExp2Ops");
    }
}
function createPrim1AppExp(op, arg){
    return ["PrimAppExp1Op", op, arg];
}

function isPrimApp1Op(e){
    return e[0] === "PrimAppExp1Op";
}

function getPrimApp1OpOperator(e){
    if(isPrimApp1Op(e)){
        return e[1]; //return the operator
    }else{
        throw new Error("Interpreter Error: " + "The argument of getPrimApp1OpOperator is not a PrimAppExp1Op");
    }
}

function getPrimApp1OpOperand(e){
    if(isPrimApp1Op(e)){
        return e[2];
    }else{
        throw new Error("Interpreter Error: " + "The argument of getPrimAppOp1Operand is not a PrimAppExp1Op");
    }
}

function isBooleanExp(e){
	return e[0] === "Bool";
}

function createBooleanExp(e){
	if(isBooleanExp(e)){
		return ["Bool", e[1]]; //boolean value;
	}else{
		throw new Error("Interpreter Error: " + "The argument of createBooleanExp is not a Boolean");
	}
}

function getBooleanExp(e){
	if(isBooleanExp(e)){
		return e[1];
	}
	else{
		throw new Error("Interpreter Error: " + "The argument of getBooleanExp is not a Boolean");
	}
}

function createListExp(e){
	return ["List", e];
}

function getListExp(e){
	if(isListExp(e)){
		return e[1];
	}else{
		throw new Error("Interpreter Error: " + "The argument of getListExp is not a List");
	}
}

function isListExp(e){
	return e[0] === "List";
}

exports.isListExp = isListExp;
exports.createListExp = createListExp;
exports.getListExp = getListExp;
exports.createProgram = createProgram;
exports.isProgram = isProgram;
exports.getProgramExp = getProgramExp;
exports.createVarExp = createVarExp;
exports.isVarExp = isVarExp;
exports.getVarExpId = getVarExpId;
exports.createIntExp = createIntExp;
exports.isIntExp = isIntExp;
exports.getIntExpValue = getIntExpValue;
exports.createFnExp = createFnExp;
exports.isFnExp = isFnExp;
exports.getFnExpParams = getFnExpParams;
exports.getFnExpBody = getFnExpBody;
exports.createAppExp = createAppExp;
exports.isAppExp = isAppExp;
exports.getAppExpFn = getAppExpFn;
exports.getAppExpArgs = getAppExpArgs;
exports.createPrim1AppExp = createPrim1AppExp;
exports.isPrimApp1Op = isPrimApp1Op;
exports.getPrimApp1OpOperator = getPrimApp1OpOperator;
exports.getPrimApp1OpOperand = getPrimApp1OpOperand;
exports.createPrim2AppExp = createPrimAppExp2Ops;
exports.createPrim3AppExp = createPrimAppExp3Ops;
exports.isPrimApp2Ops = isPrimApp2Ops;
exports.isPrimApp3Ops = isPrimApp3Ops;
exports.getPrimApp2OpsOperator = getPrimApp2OpsOperator;
exports.getPrimApp3OpsOperator = getPrimApp3OpsOperator;
exports.getPrimApp2OpsOperand1 = getPrimApp2OpsOperand1;
exports.getPrimApp2OpsOperand2 = getPrimApp2OpsOperand2;
exports.getPrimApp3OpsOperand1 = getPrimApp3OpsOperand1;
exports.getPrimApp3OpsOperand2 = getPrimApp3OpsOperand2;
SLang.absyn = exports;

}());
