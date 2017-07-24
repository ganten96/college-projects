var fp = require('./fp');
var bt = require('./bt');

var fileName = 'a3';
var selectedTest = process.argv[2];
var solution; // student's solution code


/////////////////////// define the test suite /////////////////////////
var tests = [ /*  0 */ "insert(1,bt.emptyTree)",
              /*  1 */ "insert(1,t5)", 
              /*  2 */ "insert(10,t5)", 
              /*  3 */ "insert(1,t10)", 
              /*  4 */ "insert(1,t20)", 
              /*  5 */ "insert(5,t20)", 
              /*  6 */ "insert(12,t20)", 
              /*  7 */ "insert(17,t20)",               
              /*  8 */ "insert(15,t20)", 
              /*  9 */ "insert(22,t20)", 
              /* 10 */ "insert(32,t20)", 
              /* 11 */ "insert(40,t20)",               
              /* 12 */ "makeBST([])",               
              /* 13 */ "makeBST([1])", 
              /* 14 */ "makeBST([1,2])", 
              /* 15 */ "makeBST([2,1])", 
              /* 16 */ "makeBST([1,2,3,4,5])", 
              /* 17 */ "makeBST([5,4,3,2,1])", 
              /* 18 */ "makeBST([20,10,30,5,15,25,35])", 
              /* 19 */ "isBST(bt.emptyTree)", 
              /* 20 */ "isBST(t5)", 
              /* 21 */ "isBST(t20)",
              /* 22 */ "isBST(t6)", 
              /* 23 */ "isBST(t)", 
              /* 24 */ "find(10,bt.emptyTree)", 
              /* 25 */ "find(5,t5)", 
              /* 26 */ "find(6,t5)", 
              /* 27 */ "find(5,t10)", 
              /* 28 */ "find(10,t10)", 
              /* 29 */ "find(11,t10)", 
              /* 30 */ "find(5,t20)", 
              /* 31 */ "find(35,t20)", 
              /* 32 */ "find(15,t20)", 
              /* 33 */ "find(6,t20)", 
              /* 34 */ "find(14,t20)", 
              /* 35 */ "find(18,t20)", 
              /* 36 */ "find(28,t20)", 
              /* 37 */ "find(32,t20)", 
              /* 38 */ "find(37,t20)", 
              /* 39 */ "inorder([])",
              /* 40 */ "inorder(t5)",
              /* 41 */ "inorder(t10)",
              /* 42 */ "inorder(t30)",
              /* 43 */ "inorder(t20)",
              /* 44 */ "curryLandR(areStrictlyAscending)(1)(10)(-1)",
              /* 45 */ "curryLandR(areStrictlyAscending)(1)(10)(1)",
              /* 46 */ "curryLandR(areStrictlyAscending)(1)(10)(1.001)",
              /* 47 */ "curryLandR(areStrictlyAscending)(1)(10)(5)",
              /* 48 */ "curryLandR(areStrictlyAscending)(1)(10)(10)",
              /* 49 */ "curryLandR(areStrictlyAscending)(1)(10)(11)",
              /* 50 */ "compose(fp.makeList(function (x) { return fp.add(x,3); }, function (x) { return fp.mul(x,x); }, function (x) { return fp.add(x,2); }))(3)",
              /* 51 */ "xerox([])",
              /* 52 */ "xerox([1])",
              /* 53 */ "xerox([1,2,3,3,2,1])",
              /* 54 */ "minima([])",
              /* 55 */ "minima([[1,2]])",
              /* 56 */ "minima([[2,1]])",
              /* 57 */ "minima([[2,2]])",
              /* 58 */ "minima([[1,2],[4,3],[5,-4],[-7,-6]])",
              /* 59 */ "convert([])",
              /* 60 */ "convert([[true,'a']])",
              /* 61 */ "convert([[1,'a'],[2,'b'],[3,'c'],[4,'d']])",
              /* 62 */ "map(fp.isZero,[])",
              /* 63 */ "map(fp.isZero,[-1,0,1,2,3,0,0])"
            ];
////////////////// load the student's solution  //////////////////////
process.stdout.write("\nLoading student code... ");
try {
    solution = require('./' + fileName);
    console.log(" done\n");
} catch (e) {
    console.log("\nError loading the student's solution code from " 
		+ fileName + ".js\n");
    process.exit(1);
}
////////////////////// helper code for testing //////////////////////
var t5  = bt.makeTree(5,bt.emptyTree,bt.emptyTree);
var t15 = bt.makeTree(15,bt.emptyTree,bt.emptyTree);
var t35 = bt.makeTree(35,bt.emptyTree,bt.emptyTree);
var t10 = bt.makeTree(10,t5,t15);
var t30 = bt.makeTree(30,bt.emptyTree,t35);
var t20 = bt.makeTree(20,t10,t30);
var t   = bt.makeTree(10,
		      bt.makeTree(5, 
				  bt.emptyTree,
				  bt.makeTree(10,bt.emptyTree,bt.emptyTree)), 
		      bt.makeTree(15,bt.emptyTree,bt.emptyTree));
var t6  = bt.makeTree(6,
                      bt.makeTree(6, 
				  bt.makeTree(3,bt.emptyTree,bt.emptyTree),
				  bt.makeTree(1,bt.emptyTree,bt.emptyTree)),
                      bt.makeTree(10, 
				  bt.makeTree(7,bt.emptyTree,bt.emptyTree),
				  bt.makeTree(12,bt.emptyTree,bt.emptyTree)));
var isTree= function (tree) {
    return ( tree &&  typeof tree === 'object' && tree.constructor === Array)
	&& (tree.length === 0 || tree.length === 3);
}
var areStrictlyAscending = function (x,y,z) {
    if (fp.isLT(x,y)) {
	if (fp.isLT(y,z))
	    return true;
	else
	    return false;
    } else
	return false;
}
///////////////////////// run the test(s) /////////////////////////////
if (selectedTest) {
    if ( (/^[0-9]+$/.test(selectedTest)) &&
	 (Number(selectedTest) < tests.length) ) {
	runTest(selectedTest)
    } else {
	console.log("Error: Test number is invalid or out of range");
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
    var fname = "addIfNew";
    var args = [[1,2,3],4];
    
    var fn = solution[fname];
    try {
	console.log("Test #",testNumber);
	output = eval( "solution." + test );
	console.log( "", test )
	process.stdout.write(" ==> ");
	if (isTree(output))
	    bt.print(output); 
	else
	    console.log( output );
    } catch (e) {
	console.log(e.message);
    }
    console.log("----------------------------------------------------");
}
