
function solve(array) {

    let result = [];

    for(let num of array){

        if(num < 0){

            result.unshift(num);
        }
        else{
            result.push(num);
        }
    }

    return result.join(', ')
}
console.log(solve([7, -2, 8, 9]))
console.log(solve([3, -2, 0, -1]));


