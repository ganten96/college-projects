/* global SLang : true */



(function () {

"use strict";

var samples = [

/* 0 */   "",
/* 1 */   [ "New prim. op. + infix syntax",
	    "(fn (n,p,q) => (((~(n)+20)-p) / (q % 3)) 10 2 11)",
            '["Num",4]' ],
/* 2 */   [ "Boolean ops", "(1 === ( (100 / 4) % 3))",
	    '["Bool",true]' ],
/* 3 */   [ "Boolean ops", "not( ((11 / 4) > (30 - (25 % 13))) )",
	    '["Bool",true]'],
/* 4 */   [ "If expression" , 
	    "(fn (n,p,q) => if n then (p + q) else (p * q) (6 < 1) 2 3)",
	    '["Num",6]' ],
/* 5 */   [ "If expression" , 
	    "(fn (n,p,q) => if n then (p + q) else (p * q) (6 > 1) 2 3)",
            '["Num",5]' ],
/* 6 */   [ "If expression" , 
	    "(fn (n,p,q) => if n then (p + q) else (q / 0) 1 2 3)",
            'No output [Runtime error]' ],
/* 7 */   [ "If expression" , 
	    "(fn (n,p,q) => if n then (p + q) else (q / 0) (6 > 1) 2 3)",
            '["Num",5]' ],
/* 8 */   [ "Lists", "[]", '["List",[]]' ],
/* 9 */   [ "Lists", "[1]", '["List",[1]]' ],
/* 10 */  [ "Lists", "[1,2,3,4,5]", '["List",[1,2,3,4,5]]' ],
/* 11 */  [ "Lists", "hd([1,2])", '["Num",1]' ],
/* 12 */  [ "Lists", "tl([1,2])", '["List",[2]]' ],
/* 13 */  [ "Lists", "tl([1])", '["List",[]]' ],
/* 14 */  [ "Lists", "(1 :: [])", '["List",[1]]' ],
/* 15 */  [ "Lists", "(1 :: [2,3])", '["List",[1,2,3]]' ],
/* 16 */  [ "Lists", "isNull( [] )", '["Bool",true]' ],
/* 17 */  [ "Lists", "isNull( [1,2,3] )", '["Bool",false]' ],
/* 18 */  [ "map", "(fn(x) => add1(x) -> [ ])", '["List",[]]' ],
/* 19 */  [ "map", "(fn(x) => x -> [1,2,3,5,6])", '["List",[1,2,3,5,6]]' ],
/* 20 */  [ "map", "(fn(x) => (2 * x) -> [1,2,3,5,6])", 
	    '["List",[2,4,6,10,12]]' ],
/* 21 */  [ "map", "(fn(x) => ~((x * x)) -> (1 :: (2 :: (3:: []))))", 
	    '["List",[-1,-4,-9]]' ],
/* 22 */  [ "map", "((fn(x) => fn (y) => (x + y) 10) -> [1,2,3,5,6])", 
	    '["List",[11,12,13,15,16]]' ],
/* 23 */  [ "map", "(fn(x) => (x + y) -> tl([0,1,2,3,5,6]))", 
	    '["List",[7,8,9,11,12]]' ],
/* 24 */  [ "map", "(fn (f,list) => (f -> list) x [1,2,3])", 
	    'No output [Runtime error]' ],
/* 25 */  [ "map", "(fn(x) => x -> 1)", 
	    'No output [Runtime error]' ]
];

 SLang.samples = samples;
})();
