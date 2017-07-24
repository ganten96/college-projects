var fp = require('./fp');
var bt = require('./bt');

var fileName = 'a4';
var selectedTest = process.argv[2];
var solution; // student's solution code

/////////////////////// define the test suite /////////////////////////
var tests = [
    /*  0 */ "bestPitcher(er_stats)",        
    /*  1 */ "bestPitcher(er_stats1)",        
    /*  2 */ "bestPitcher(er_stats2)",          
    /*  3 */ "weight(mobile3)",
    /*  4 */ "weight(mobile8)",
    /*  5 */ "isMobile(mobile1)", 
    /*  6 */ "isMobile(mobile2)", 
    /*  7 */ "isMobile(mobile3)", 
    /*  8 */ "isMobile(mobile4)", 
    /*  9 */ "isMobile(mobile5)", 
    /* 10 */ "isMobile(mobile6)", 
    /* 11 */ "isMobile(mobile7)", 
    /* 12 */ "isMobile(mobile8)", 
    /* 13 */ "isMobile(mobile1)", 
    /* 14 */ "weightMobilesCPS(mb_list1)",
    /* 15 */ "weightMobilesCPS(mb_list9)",
    /* 16 */ "weightMobilesCPS(mb_list5)"
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

var er_stats = [ ["Garza", [4,4], [1,9], [3,8]], 
                 ["Losch", [4,9], [2,6]], 
                 ["Nelson", [5,7], [4,8], [3,5], [2,6]], 
                 ["Fiers", [2,9], [5,3]], 
                 ["Peralta", [4,9], [0,9], [3,6], [3,7] ] 
          ];

var er_stats1 = [ ["Garza", [4,4], [1,9], [3,8]], 
                 ["Losch", [4,9], [2,6]], 
                 ["Peralta", [4,9], [0,9], [3,6], [3,7] ],
                 ["Fiers", [2,9], [5,3]], 
                 ["Nelson", [5,7], [4,8], [3,5], [2,6]]
          ];

var er_stats2 = [ ["Peralta", [4,9], [0,9], [3,6], [3,7] ] ,
                 ["Garza", [4,4], [1,9], [3,8]], 
                 ["Losch", [4,9], [2,6]], 
                 ["Nelson", [5,7], [4,8], [3,5], [2,6]], 
                 ["Fiers", [2,9], [5,3]]
               ];

var m1  = bt.makeTree(1,bt.emptyTree,bt.emptyTree);
var m2  = bt.makeTree(2,bt.emptyTree,bt.emptyTree);
var m3  = bt.makeTree(3,bt.emptyTree,bt.emptyTree);
var m5  = bt.makeTree(5,bt.emptyTree,bt.emptyTree);
var m9  = bt.makeTree(9,bt.emptyTree,bt.emptyTree);
var m15 = bt.makeTree(15,bt.emptyTree,bt.emptyTree);
var m20 = bt.makeTree(20,bt.emptyTree,bt.emptyTree);
var m35 = bt.makeTree(35,bt.emptyTree,bt.emptyTree);
var mobile1 = bt.makeTree(10,m5,m5); // Yes of total weight 20
var mobile2 = bt.makeTree(10,m2,m5); // No
var mobile3 = bt.makeTree(8,mobile1,m20); // yes of total weight 48
var mobile4 = bt.makeTree(8,mobile1,bt.makeTree(2,m3,m15)); // no
var mobile5 = bt.makeTree(8,mobile1,bt.makeTree(2,m9,m9)); // yes of total weight 48
var mobile6 = bt.makeTree(8,bt.makeTree(2,m3,m15), mobile1); // no
var mobile7 = bt.makeTree(8,bt.makeTree(2,m9,m9), mobile1); // yes of total weight 48
var mobile8 = bt.makeTree(12, mobile3, mobile5);             // yes of total weight 108
var mobile9 = bt.makeTree(12, mobile1, mobile5);             // no

var mb_list1 = fp.makeList(mobile1, mobile2);

var mb_list9 = fp.makeList(mobile1,mobile2,mobile3,mobile4,mobile5,mobile6,mobile7,mobile8,mobile9);

var mb_list5 = fp.makeList(mobile1,mobile3,mobile5,mobile7,mobile8);

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
        console.log( "", test );
        process.stdout.write(" ==> ");
        console.log( output );
    } catch (e) {
        console.log(e.message);
    }
    console.log("----------------------------------------------------");
}
