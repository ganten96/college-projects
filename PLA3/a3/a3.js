/*
    Nick Ganter
    Cory Benz
    CS331 Assignment 3
*/
var fp = require('./fp');
var bt = require('./bt');

if ( ! exports )
   var exports = [ ];

var insert = function (value,tree) {
    if(bt.isEmpty(tree)){
        return bt.makeTree(value, bt.emptyTree, bt.emptyTree);
    }else{
        if(fp.isLT(bt.rootValue(tree), value)) {
            return bt.makeTree(bt.rootValue(tree), 
                bt.leftChild(tree), 
                insert(value, bt.rightChild(tree)));
        } else {
            return bt.makeTree(bt.rootValue(tree), 
                insert(value, bt.leftChild(tree)), 
                bt.rightChild(tree));
            
        }
    }
}

var makeBST = function (ns) {
    var makeInitialTree = function(ns, tree) {
        if(fp.isNull(ns)) {
            return tree;
        } else {
            return makeInitialTree(fp.tl(ns), insert(fp.hd(ns), tree));
        }
    };
    if(fp.isNull(ns)) {
        return bt.emptyTree;
    }
    return makeInitialTree(fp.tl(ns), 
        bt.makeTree(fp.hd(ns), 
        bt.emptyTree, 
        bt.emptyTree));
}


var isBST = function (tree) {
    if(bt.isEmpty(tree)){
        return true;
    }else{
        if(bt.isLeaf(tree)){
            return true;
        }else{
            //both items came back as trees.
            if(isBST(bt.leftChild(tree)) && isBST(bt.rightChild(tree))){
                if(fp.isLT(bt.rootValue(bt.rightChild(tree)), bt.rootValue(tree))){
                    return false;
                }
                if(!bt.isEmpty(bt.leftChild(tree))){
                    if(fp.isEq(bt.rootValue(bt.leftChild(tree)), bt.rootValue(tree))){
                        return false;
                    }else{
                        return true;
                    }
                }
                return true;
            }else{
                return false;
            }
        }
    }
}

var find = function (value,tree) {
    if(bt.isEmpty(tree)){
        return false;
    }else{
        if(bt.isLeaf(tree)){
            return fp.isEq(value, bt.rootValue(tree));
        }else if(fp.isEq(bt.rootValue(tree), value)){
            return true;
        }else{
            return find(value, bt.rightChild(tree)) || find(value, bt.leftChild(tree));
        }
    }
}

var inorder = function (tree) {
    if(bt.isEmpty(tree)){
        return [];
    }else{
        if(!bt.isEmpty(bt.leftChild(tree)) 
            && !bt.isEmpty(bt.rightChild(tree))){
            
            return fp.append(inorder(bt.leftChild(tree)), 
                fp.cons(bt.rootValue(tree), 
                    inorder(bt.rightChild(tree))));
        }
        else{
            if(bt.isEmpty(bt.leftChild(tree)) 
                && !bt.isEmpty(bt.rightChild(tree))){
                return fp.cons(bt.rootValue(tree), 
                    inorder(bt.rightChild(tree)));
            }else if(!bt.isEmpty(bt.leftChild(tree)) 
                && bt.isEmpty(bt.rightChild(tree))){
                return fp.cons(bt.rootValue(tree), 
                    inorder(bt.leftChild(tree)));
            }
            return fp.makeList(bt.rootValue(tree));
        }
    }
}

var curryLandR = function (f) {
    return function(x){
        return function(z){
            return function(y){
                return f(x,y,z);
            }
        }
    }
}

var xPlusZequalsY = curryLandR(
    function (x,y,z) { 
        return fp.isEq(x, fp.add(y,z));
    })(100)(100);

var yMinusZdividedByX = curryLandR(
    function (x,y,z) { 
    return fp.div(fp.sub(z,x),y);
})(100)(101);

var compose = function (list) {
    if(fp.isNull(fp.tl(list))){
        return [];
    }else{
        return fp.reduce(fp.compose, fp.tl(list), fp.hd(list));
    }
}

var xerox = function (ns) {
    if(fp.isNull(ns)){
        return [];
    }
    else{
        return fp.reduce(fp.append, 
            fp.map(function(x){
                return fp.makeList(x,x)
            }, ns), []);
    }
}

var minima = function (ns) {
    if(fp.isNull(ns)){
        return [];
    }else{
        return fp.map(function(x){
            return fp.reduceRight(fp.min, fp.tl(x), fp.hd(x));
        }, ns);
    }
}

var convert = function (ns) {
    if(fp.isNull(ns)){
            return [];
    }else{
        return fp.append(
            fp.makeList(
                fp.map(
                    function(x){
                        return fp.hd(x);
                    } , ns)
                ), 
            fp.makeList(
                fp.map(
                    function(x){
                        return fp.hd(fp.tl(x));
                    }, ns)
                )
            ); 
    }
}

var map = function (f,ns) {
    if(fp.isNull(ns)){
        return [];
    }else{
        return fp.reduceRight(
            function(x, y) { 
                return fp.cons(f(x), y); 
            }, 
            ns, []);
    }
}

exports.insert = insert;
exports.makeBST = makeBST;
exports.isBST = isBST;
exports.find = find;
exports.inorder = inorder;
exports.curryLandR = curryLandR;
exports.compose = compose;
exports.xerox = xerox;
exports.minima = minima;
exports.convert = convert;
exports.map = map;
