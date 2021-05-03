function solve(array) {

    let result = [];

    let totalSum = 0;
    let inverseSum = 0;
    let concatSum = 0;

    totalSum = array.reduce((acc, c,) => acc + c, 0);
    result[result.length] = totalSum;

    inverseSum = array.reduce((acc, c) => acc + 1 / c, 0);
    result[result.length] = inverseSum;

    concatSum = array.reduce((acc, c) => acc + c.toString());
    result[result.length] = concatSum;

    return result.join('\n');
}

console.log(solve([1, 2, 3]));
console.log(solve([2, 4, 8, 16]));




