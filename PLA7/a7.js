// Note -- the next two lines should ensure that the is module is uncached.
var name = require.resolve('./is');
delete require.cache[name];

var is = require("./is");

if ( ! exports )
   var exports = [ ];

/////// Problem 1 ///////////////////

var add_adj = function (seq) {
	return is.cons(is.hd(seq) + is.hd(is.tl(seq)), function(){
		return add_adj(is.tl(is.tl(seq)));
	});
};

/////// Problem 2 //////////////////////

var hailstone = function (n) {
   if(n % 2 == 0){
		return is.cons(n, function(){
			return hailstone(n/2);
		});
   }else{
	return is.cons(n, function(){
		return hailstone(3*n+1);
	});
   }
};


/////// Problem 3 /////////////////

var merge = function (s1, s2) {
	//s1 even
	//s2 odd
	if(is.hd(s1) === is.hd(s2)){
		return is.cons(is.hd(s1), function(){ return merge(is.tl(s1), is.tl(s2));});
	}else if(is.hd(s1) < is.hd(s2)){
		return is.cons(is.hd(s1), function(){ return merge(is.tl(s1), s2);});
	}else{
		return is.cons(is.hd(s2), function(){ return merge(s1, is.tl(s2));});
	}
};

////// Problem 4 /////////////////

//// Note that strange_sequence is the result of calling on an
//// anonymous function that, when called, produces the desired
//// sequence -- similar to the way that we bound the sequence of all
//// prime numbers to the variable primes in the class notes

var strange_sequence = function () {
	var twolist = is.map(function(x){return x * 2;}, strange_sequence);
	var threelist = is.map(function(x){return x * 3;}, strange_sequence);
	var fivelist = is.map(function(x){return x * 5;}, strange_sequence);
    return is.cons(1, merge(twolist, merge(threelist, fivelist)));
}();


//////////////////////////////////////////////////

exports.hailstone = hailstone;
exports.add_adj = add_adj;
exports.merge = merge;
exports.strange_sequence = strange_sequence;
