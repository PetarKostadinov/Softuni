
function solve(x) {
    const y = Array.from(String(x), Number);
    let bool = true;
    let count = 0; 

    for (let i = 0; i < y.length; i++) {

        count += y[i];

        if (i == y.length - 1) {
            break;
        }

        if (y[i] !== y[i + 1]) {

            bool = false;
        }
    }
    return `${bool} \r\n ${count}`;
}

console.log(solve(2222222));
console.log(solve(1234));