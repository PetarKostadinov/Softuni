function solve(a, b) {

    let result = 0;
    let x = Number(a);
    let y = Number(b);

    for (let i = x; i <= y; i++) {

        result += i;
    }
    
    return result;
}

console.log(solve('1', '5'))
console.log(solve('-8', '20'))


