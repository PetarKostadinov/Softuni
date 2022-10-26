
function solve(x, y){
    while(y){
        let t = y;
        y = x % y;
        x = t;
    }

    return x;
} 

console.log(solve(15,5));
console.log(solve(2154, 458));