
function solve(array) {

    let first = Number(array[0]);
    let last = Number(array[array.length-1]);
 
    let result = first + last;

    return result;
}
console.log(solve(['20', '30', '40']))
console.log(solve(['5', '10']));


