var fp = require('./fp');
var util = require('util');

/**
 * This module implements a binary tree (BT) data structure.
 *
 * @requires module:fp
 * @requires module:util
 * @module bt
 * @author David Furcy - Feb. 2015
 * @version 1.0
 */

// not exported
var isTree = function (tree) {
    return ( tree &&  typeof tree === 'object' && tree.constructor === Array)
	&& (tree.length === 0 || tree.length === 3);
}
/** The empty tree, i.e., a tree with zero nodes in it 
 */
var emptyTree = [ ];
/** makeTree, the only BT constructor, takes in a value and two binary trees 
    and returns a new binary tree whose root node contains the input value 
    and whose left and right sub-trees are the two input trees, in this order
    @param  value - any value
    @param  leftTree {BT} - a binary tree
    @param  rightTree {BT} - a binary tree
    @alias module:bt.makeTree
    @return {BT} a new, non-empty  binary tree
    @throws Exception: The second argument of makeTree must be a binary tree.
    @throws Exception: The third argument of makeTree must be a binary tree.
 */
var makeTree = function (value,left,right) {
    if (! isTree(left))
	throw new Error('The second argument of makeTree must be a binary tree.')
    else if (! isTree(right))
	throw new Error('The third argument of makeTree must be a binary tree.')
    else
	return fp.makeList(value,left,right);
}
/** isEmpty is a predicate that returns true if its binary tree argument 
    is an empty tree, false otherwise
    @param  tree {BT} - a binary tree
    @alias module:bt.isEmpty
    @return {boolean} true if the argument is the empty tree, false otherwise
    @throws Exception: The argument of isEmpty must be a binary tree.
 */
var isEmpty = function (tree) {
    if 	(! tree || typeof tree !== 'object' || tree.constructor !== Array)
	throw new Error('The argument of isEmpty must be a binary tree.')
    else
	return tree.length === 0;
}
/** isLeaf is a predicate that returns true if its argument is a binary tree
    containing a single value (i.e., no sub-trees), false otherwise
    @param  tree {BT} - a binary tree
    @alias module:bt.isLeaf
    @return {boolean} true if the argument is a binary tree containing a 
    single value, false otherwise
    @throws Exception: The argument of isLeaf must be a binary tree.
 */

var isLeaf = function (tree) {
    if (! isTree(tree))
	throw new Error('The argument of isLeaf must be a binary tree.')
    else 
	return fp.isNull(leftChild(tree)) && fp.isNull(rightChild(tree));
}
/** rootValue is an accessor that takes in a non-empty binary tree and 
    returns the value stored in its root node
    @param  tree {BT} - a binary tree
    @alias module:bt.rootValue
    @return {value} the value stored in the root node of the input tree
    @throws Exception: The argument of rootValue must be a binary tree.
    @throws Exception: The argument of rootValue cannot be an empty binary tree.
 */
var rootValue = function (tree) {
    if (isEmpty(tree))
	throw new Error('The argument of rootValue cannot be an empty binary tree.')
    else if (! isTree(tree))
	throw new Error('The argument of rootValue must be a binary tree.')
    else 
	return tree[0];
}
/** leftChild is an accessor that takes in a non-empty binary tree and returns 
    its left sub-tree
    @param  tree {BT} - a binary tree
    @alias module:bt.leftChild
    @return {BT} the left sub-tree of the input binary tree
    @throws Exception: The argument of leftChild must be a binary tree.
    @throws Exception: The argument of leftChild cannot be an empty tree.
 */
var leftChild = function (tree) {
    if (isEmpty(tree))
	throw new Error('The argument of leftChild cannot be an empty tree.')
    else if (! isTree(tree))
	throw new Error('The argument of leftChild must be a binary tree.')
    else 
	return tree[1];
}
/** rightChild is an accessor that takes in a non-empty binary tree  and 
    returns its right sub-tree
    @param  tree {BT} - a binary tree
    @alias module:bt.rightChild
    @return {BT} the right sub-tree of the input tree
    @throws Exception: The argument of rightChild must be a binary tree.
    @throws Exception: The argument of rightChild cannot be an empty binary tree.
 */
var rightChild = function (tree) {
    if (isEmpty(tree))
	throw new Error('The argument of rightChild cannot be an empty binary tree.')
    else if (! isTree(tree))
	throw new Error('The argument of rightChild must be a binary tree.')
    else 
	return tree[2];
}
/** maxValue takes in a non-empty binary tree of numbers and returns the 
    largest value stored in it
    @param  tree {BT} - a binary tree containing numbers
    @alias module:bt.maxValue
    @return {number} the largest number stored in the input tree
    @throws Exception: The argument of maxValue must be a binary tree.
    @throws Exception: The argument of maxValue cannot be an empty binary tree.
    @throws Exception: The argument of maxValue must be a binary tree containing only numbers.
 */
var maxValue = function (tree) {
    if (isEmpty(tree))
	throw new Error('The argument of maxValue cannot be an empty binary tree.')
    else if (! isTree(tree))
	throw new Error('The argument of maxValue must be a binary tree.')
    else if (! fp.isNumber(rootValue(tree)))
	throw new Error('The argument of maxValue must be a binary tree containing only numbers.')
    else if (isLeaf(tree))
	return rootValue(tree);
    else if (isEmpty(leftChild(tree)))
	return fp.max( rootValue(tree), maxValue( rightChild(tree)));
    else if (isEmpty(rightChild(tree)))
	return fp.max( rootValue(tree), maxValue( leftChild(tree)));
    else
	return fp.max( rootValue(tree),
		       fp.max( maxValue( leftChild(tree)),
			       maxValue( rightChild(tree))));
}
/** minValue takes in a non-empty binary tree of numbers and returns the 
    smallest value stored in it
    @param  tree {BT} - a binary tree containing numbers
    @alias module:bt.minValue
    @return {number} the smallest number stored in the input tree
    @throws Exception: The argument of minValue must be a binary tree.
    @throws Exception: The argument of minValue cannot be an empty binary tree.
    @throws Exception: The argument of minValue must be a binary tree containing only numbers.
 */
var minValue = function (tree) {
    if (isEmpty(tree))
	throw new Error('The argument of minValue cannot be an empty binary tree.')
    else if (! isTree(tree))
	throw new Error('The argument of minValue must be a binary tree.')
    else if (! fp.isNumber(rootValue(tree)))
	throw new Error('The argument of minValue must be a binary tree containing only numbers.')
    else if (isLeaf(tree))
	return rootValue(tree);
    else if (isEmpty(leftChild(tree)))
	return fp.min( rootValue(tree), minValue( rightChild(tree)));
    else if (isEmpty(rightChild(tree)))
	return fp.min( rootValue(tree), minValue( leftChild(tree)));
    else
	return fp.min( rootValue(tree),
		       fp.min( minValue( leftChild(tree)),
			       minValue( rightChild(tree))));
}
/** print takes in a binary tree and sends a string representation of it to 
    standard output
    @param  tree {BT} - a binary tree
    @alias module:bt.print
    @return {undefined} undefined
    @throws Exception: The argument of print must be a binary tree.
 */
function print(tree) {
    if (isTree(tree))
	util.puts(util.inspect(tree, false ,null,true));
    else
	throw new Error('The argument of print must be a binary tree.')
}

exports.makeTree = makeTree;
exports.emptyTree = emptyTree;
exports.rootValue = rootValue;
exports.leftChild = leftChild;
exports.rightChild = rightChild;
exports.maxValue = maxValue;
exports.minValue = minValue;
exports.isEmpty = isEmpty;
exports.isLeaf = isLeaf;
exports.print = print;


var t1 =  makeTree(1,emptyTree,emptyTree);
var t2 =  makeTree(2,emptyTree,emptyTree);
var t3 =  makeTree(3,t1,t2);

