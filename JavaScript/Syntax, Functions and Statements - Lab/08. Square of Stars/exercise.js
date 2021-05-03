function solve(x) {

    let result = [];

    for(let i = 0; i < x; i++){

        result[i] = '* '.repeat(x);
    }

    return result.join('\n');
}

console.log(solve(5));
console.log(solve(2));




