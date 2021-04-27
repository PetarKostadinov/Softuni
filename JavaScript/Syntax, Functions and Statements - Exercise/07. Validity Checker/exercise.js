
function solve(x1, y1, x2, y2) {

    function getValidation(x1, y1, x2, y2) {

        // Pythagorean Theorem d=√((x1-x2)2+(y1-y2)2)

        let distance = Math.sqrt((x1 - x2) ** 2 + (y1 - y2) ** 2);

        return Number.isInteger(distance) ? 'valid' : 'invalid';
    }

    return `{${x1}, ${y1}} to {0, 0} is ${getValidation(x1, y1, 0, 0)}\n` +
        `{${x2}, ${y2}} to {0, 0} is ${getValidation(x2, y2, 0, 0)}\n` +
        `{${x1}, ${y1}} to {${x2}, ${y2}} is ${getValidation(x1, y1, x2, y2)}`;

}

console.log(solve(3, 0, 0, 4));
console.log(solve(2, 1, 1, 1));

