var fp = require("./fp.js")
var bt = require("./bt.js")

if ( ! exports )
   var exports = [ ];

// All your code for the first problem should be inside the function
// bestPitcher
var bestPitcher = function (db) {
	//add up all innings, and all earned runs allowed.
	//compose a new list that has [firstName, eraValue] of the person who has the greatest ERA.
	var mapper = function(players){
		var innerReducer = function(){
			return fp.makeList(fp.hd(players), 
				fp.mul(9, 
					fp.div(fp.reduceRight(
					function(x,y){
					return fp.add(fp.hd(x), y);
			}, fp.tl(players), 0),
			fp.reduceRight(function(x,y){
				return fp.add(fp.hd(fp.tl(x)), y);
			}, fp.tl(players), 0))));
		}
		return innerReducer();
	}

	//pass in each player to be checked against eachother. Only need to check tails because
	//we only care about ERA.
	var reducer = function(p1, p2){
		return (fp.isLT(fp.hd(fp.tl(p1)), fp.hd(fp.tl(p2)))) ? p1 : p2;
	}
	return fp.reduce(reducer, fp.map(mapper, db), ["", Number.MAX_VALUE]);
}

// All your code for the second problem should be inside the function
// weight
var weight = function (tree) {
    if (bt.isLeaf(tree)) {
        return bt.rootValue(tree);
    } else {
        return fp.add(
        		fp.add(
    				weight(bt.leftChild(tree)), 
    				bt.rootValue(tree)), 
        		weight(bt.rightChild(tree)));
    }
}

// All your code for the third problem should be inside the function
// isMobile with the exception that you are allowed to call on weight
var isMobile = function  (tree) {
    if(bt.isLeaf(tree)) {
        return true;
    } else {
        return isMobile(bt.leftChild(tree)) 
        		&&
			   fp.isEq(
		   			weight(bt.leftChild(tree)), 
		   			weight(bt.rightChild(tree))) 
			   &&
			   isMobile(bt.rightChild(tree));
    }
}


// All your code for the third problem should be inside the function
// weightMobilesCPS with the exception that you are allowed to call on
// weight and isMobile
var weightMobilesCPS = function (lm) {
    var traverseTree = function(list, func) {
        if(fp.isNull(list)){
            return func(0);
        } else if(!isMobile(fp.hd(list))){
            throw new Error("I only eat mobiles");
        } else {
            return traverseTree(fp.tl(list), 
					function(x) {
					    return func(fp.add(x, 
					    	weight(fp.hd(list))));
					});
        }
    }
    return traverseTree(lm, function(x) { return x; });
}
var isMobile = function  (tree) {
    if(bt.isLeaf(tree)) {
        return true;
    } else {
        return isMobile(bt.leftChild(tree)) &&
			   fp.isEq(weight(bt.leftChild(tree)), 
			   	weight(bt.rightChild(tree))) &&
			   isMobile(bt.rightChild(tree));
    }
} 

exports.bestPitcher = bestPitcher;
exports.weight = weight;
exports.isMobile = isMobile;
exports.weightMobilesCPS = weightMobilesCPS;
