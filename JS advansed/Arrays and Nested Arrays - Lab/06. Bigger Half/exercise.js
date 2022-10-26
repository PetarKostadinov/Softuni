
function solve(array) {

    let result = [];

    array.sort(function(a, b){return b-a});
   
    for(let i = 0; i < array.length / 2; i++){

        result[result.length] = array[i];
    }

    result.reverse();
    return result
}
console.log(solve([4, 7, 2, 5]))
console.log(solve([3, 19, 14, 7, 2, 19, 6]));


