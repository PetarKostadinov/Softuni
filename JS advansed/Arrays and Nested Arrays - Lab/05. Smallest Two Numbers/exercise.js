
function solve(array) {

    let result = [];

    let firstMinNumber = Math.min(...array);

    result.push(firstMinNumber);

    for(let i = 0; i < array.length; i++){

        if(array[i] == firstMinNumber){

            array.splice(i, 1);
        }
    }

    let secondMinNumber = Math.min(...array);

    result.push(secondMinNumber);

    return result.join(', ')
}
console.log(solve([30, 15, 50, 5]))
console.log(solve([3, 0, 10, 4, 7, 3]));


