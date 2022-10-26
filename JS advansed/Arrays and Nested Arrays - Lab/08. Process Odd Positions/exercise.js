
function solve(array) {

    let result = [];

    for (let i = 1; i < array.length; i += 2) {

        result.unshift(array[i] * 2);
    }

    return result;
}
console.log(solve([10, 15, 20, 25]))
console.log(solve([3, 0, 10, 4, 7, 3]));
