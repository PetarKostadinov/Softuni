
//In currying, a function that takes multiple arguments is transformed into a series of nested functions, each of which takes a single argument.
//The nested functions are constructed in such a way that they each return a new function until all the arguments have been processed.


function add(a) {
    return function (b) {
        if (b) return add(a + b);
        return a;
    };
};

console.log(add(5)(2)(4)(8)());


//second example

function add1(x, y) {
    return x + y;
}
//Using currying, we can transform add into a series of nested functions:

function add1(x) {
    return function (y) {
        return x + y;
    }
}
//Now we can use the curried add function to create a new function that always adds 5 to a number:

const addFive = add1(5);
console.log(addFive(3)); // Output: 8