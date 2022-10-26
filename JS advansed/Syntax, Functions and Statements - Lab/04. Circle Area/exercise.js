function solve(input) {

    let result = typeof(input);

    if (result === 'number') {

        result = (Math.PI * input ** 2).toFixed(2);
    }
    else {

        result = `We can not calculate the circle area, because we receive a ${result}.`;
    }

    return result;
}

console.log(solve(5));
console.log(solve('name'));

