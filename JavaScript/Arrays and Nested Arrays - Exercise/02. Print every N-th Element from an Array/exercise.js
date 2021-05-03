function solve(array, step) {

    let result = [];

    for(let i = 0; i < array.length; i+= step){

        result[result.length] = array[i];
    }

    return result;   
}

console.log(solve(['5', 
'20', 
'31', 
'4', 
'20'], 
2
));
console.log(solve(['dsa',
'asd', 
'test', 
'tset'], 
2
));




