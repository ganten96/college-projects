var is = require('./is');

var fileName = 'a7';
var selectedTest = process.argv[2];
var solution; // student's solution code


/////////////////////// define the test suite /////////////////////////
var tests = [
    /*  0 */ "add_adj(is.from(1))",
    /*  1 */ "hailstone(5)",
    /*  2 */ "hailstone(11)",
    /*  3 */ "merge(evens, primes)",
    /*  4 */ "strange_sequence"
];

////////////////// load the student's solution  //////////////////////
process.stdout.write("\nLoading student code... ");
try {
    solution = require('./' + fileName);
    console.log(" done\n");
} catch (e) {
    console.log("\nError loading the student's solution code from " + fileName + ".js\n");
    process.exit(1);
}
////////////////////// helper code for testing //////////////////////

var primes = function () {
    var sift = function (p,s) { return is.filter(function (n) { return n % p !== 0; }, s); };
    var helper = function (s) {
	return is.cons(is.hd(s), function () { return helper(sift(is.hd(s), is.tl(s))); } );
    };
    return helper(is.from(2));
}();

var evens = is.filter(function (n) { return (n % 2 === 0); }, is.from(1));


///////////////////////// run the test(s) /////////////////////////////
if (selectedTest) {
    if ( (/^[0-9]+$/.test(selectedTest)) &&
	 (Number(selectedTest) < tests.length) ) {
	runTest(selectedTest);
    } else {
	console.log("Error: Test number is invalid or out of range" + selectedTest);
	process.exit(1);
    }
} else { 
    console.log("===========================");
    console.log("Test suite for", fileName +".js");
    console.log("===========================");
    for(var i=0; i<tests.length; i++) {
	runTest(i);
    }
}

/////////////// helper function to run one test //////////////////
function runTest(testNumber) {
    var test = tests[testNumber];
    var output;

//    console.log(is.take(a3.add_adj(is.from(1)), 10));
    try {
	console.log("Test #",testNumber);
	console.log("is.take(" +  "solution." + test + ",20)");
	output = eval("is.take(" +  "solution." + test + ",20)");
	console.log( "", test );
	process.stdout.write(" ==> ");
	console.log( output );
    } catch (e) {
	console.log(e.message);
    }

    console.log("----------------------------------------------------");
}
